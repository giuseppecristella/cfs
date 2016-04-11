using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ez.Newsletter.MagentoApi;
using MagentoRepository.Helpers;
using Shop.Core;
using Shop.Core.BusinessDelegate;
using Shop.Core.Domain.ProductsCart;
using Shop.Core.Utility;
using Shop.Data;
using Shop.Web.Mvp.Infrastructure;
using Order = Shop.Core.Domain.Orders.Order;
using OrderProduct = Shop.Core.Domain.OrderProducts.OrderProduct;

namespace Shop.Web.Mvp.Checkout
{
    public enum AddressType
    {
        Billing,
        Shipping
    }

    public enum EmptyCartMode
    {
        Default,
        AfterOrder,
        AfterOrderError
    }

    public partial class Checkout : System.Web.UI.Page
    {
        private readonly BusinessDelegate _businessDelegate;
        private static int _magentoCustomerId = 1;

        #region CTor
        public Checkout()
        {
            _businessDelegate = new BusinessDelegate();
        }
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Classe base check Session redirect nel page load
            if (!Page.IsPostBack)
            {
                BindPaymentMethods();
                LoadUserInfoIfLogged();
            }

            if (SessionFacade.ProductsCart == null || !SessionFacade.ProductsCart.Any())
            {
                ActivateCartEmptyView(EmptyCartMode.Default);
                return;
            }

            if (!SessionFacade.CartId.Equals(0)) return;
            SessionFacade.CartId = _businessDelegate.CreateCart();
            if (SessionFacade.CartId.Equals(-1))
            {
                // Errore creazione carrello
                // 1. Log Exception 2. Alert 3. Redirect
            }
        }

        protected void cuwUser_OnCreatedUser(object sender, EventArgs e)
        {
            var membershipUser = Membership.GetUser(cuwUser.UserName);
            if (membershipUser == null) return;
            try
            {
                Roles.AddUserToRole(cuwUser.UserName, "User");
                // TODO: Check errore creazione utente lato Magento, rollback e cancellazione utente asp.net 
                var magentoCustomerId = CreateMagentoCustomer();

                // Salvo nel campo 'comment' dell'oggetto User di MembershipProvider il customer CustomerId di Magento
                membershipUser.Comment = magentoCustomerId;
                Membership.UpdateUser(membershipUser);

                // SubscriveSignedCustomerToNewsLetter();
                //SendNotificationEmailToSignedCustomer(membershipUser.UserName, cuwUser.Password);
                CreateMagentoCustomerAddress(AddressType.Billing, magentoCustomerId);
                CreateMagentoCustomerAddress(AddressType.Shipping, magentoCustomerId);
            }
            catch (Exception ex)
            {
                // log 

                //divErr.Visible = true;
                //lblErr.Text = "Attenzione: si è verificato un'errore nella creazione dell'account. Si prega di ripetere l'operazione.";
                // Cancello l'utente dal nostro db perchè non è stato creato in magento
                Membership.DeleteUser(membershipUser.UserName);
            }
        }

        protected void cuwUser_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            cuwUser.Email = txtEmail.Text;
        }

        protected void OnLoginError(object sender, EventArgs e)
        {
            var currentUser = Membership.GetUser(Login.UserName);
            var lblFailureText = Login.FindControl("lblFailureText") as Literal;
            if (lblFailureText == null) return;

            if (currentUser == null)
            {
                lblFailureText.Text = Resources.Resources.UnregisteredUser_Error;
            }
            else
            {
                if (!currentUser.IsApproved) Login.FailureText = Resources.Resources.NotApprovedUser_Error;
                else if (currentUser.IsLockedOut) Login.FailureText = Resources.Resources.LockedUser_Error;
                else lblFailureText.Text = Resources.Resources.InvalidPassword_Error;
            }
        }

        protected void OnLoggedIn(object sender, EventArgs e)
        {

        }

        protected void btnCheckout_OnClick(object sender, EventArgs e)
        {
            // Crea Entities
            var customer = BindUserInfoToObject();

            var customerAddresses = BindCustomerAddressesToObject(cbShowShipmentAddress.Checked);
            var products = GetProductsForCart();
            var paymentMethod = SetPaymentMethod();
            // Prepara l'ordine
            _businessDelegate.PrepareCartForOrder(SessionFacade.CartId, customer, customerAddresses, products, App.Configuration.DefaultShippingMethodMode, paymentMethod);
            // Invia l'ordine
            var orderId = _businessDelegate.CreateOrder(SessionFacade.CartId);
            UpdateProductSizesInventory(products);
            if (orderId > 0) SaveOrderDetail(orderId, products, customer, customerAddresses, paymentMethod);
            // Recupero l'ordine appena salvato
            var orderHeader = GetOrderHeader(orderId);
            if (orderHeader == null) return;
            var orderProducts = GetOrderProducts(orderHeader.Id);
            if (orderProducts == null) return;
            // Invio Email riepilogo
            if (!string.IsNullOrEmpty(txtPromo.Text) && ArePromoRelated(customer.email, txtPromo.Text))
            {
                SendOrderSummaryNotification(orderHeader, orderProducts, customer, true);
                SetPromotionCodeAsAssigned(customer.email);
            }
            else
            {
                SendOrderSummaryNotification(orderHeader, orderProducts, customer);
            }

            // Svuota Sessione
            SessionFacade.CartId = 0;
            SessionFacade.ProductsCart = null;
            // Gestisce il risultato
            ActivateCartEmptyView(orderId > 0 ? EmptyCartMode.AfterOrder : EmptyCartMode.AfterOrderError);
        }

        private void UpdateProductSizesInventory(IList<Product> products)
        {
            _businessDelegate.UpdateProduct(products);
        }

        private void SaveOrderDetail(int orderId, List<Product> products, Customer customer, List<CustomerAddress> customerAddresses, PaymentMethod paymentMethod)
        {
            var customerAddress = customerAddresses.FirstOrDefault();
            if (customerAddress == null) return;

            var order = new Order
            {
                SubmissionDate = DateTime.Now,
                CustomerAddress = string.Format("Via {0} {1} {2}",
                        customerAddress.street,
                        customerAddress.city,
                        customerAddress.postcode),
                CustomerFirstName = customer.firstname,
                CustomerId = int.Parse(customer.customer_id),
                MagentoOrderId = orderId,
                CustomerSecondName = customer.lastname,
                OrderStatus = "Submitted",
                PaymentType = paymentMethod.code,
                Total = 6 + products.Sum(p => int.Parse(p.qty) * decimal.Parse(CommonHelper.FormatCurrency(p.price))),
                SubTotal = products.Sum(p => int.Parse(p.qty) * decimal.Parse(CommonHelper.FormatCurrency(p.price))),
                Shipment = 6,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var product in products)
            {
                order.OrderProducts.Add(new OrderProduct
                {
                    Name = product.name,
                    Qty = int.Parse(product.qty),
                    UnitPrice = decimal.Parse(CommonHelper.FormatCurrency(product.price)),
                    TotalPrice = int.Parse(product.qty) * decimal.Parse(CommonHelper.FormatCurrency(product.price)),
                    Size = int.Parse(((string[])(product.additional_attributes[0]))[1])
                });
            }

            using (var ctx = new ShopDataContext())
            {
                ctx.Set<Order>().Add(order);
                var saveResult = ctx.SaveChanges();
            }

        }

        private PaymentMethod SetPaymentMethod()
        {
            var selectedPayment = new PaymentMethod
            {
                code = rdbtnListPayMethods.SelectedItem.Value,
                method = rdbtnListPayMethods.SelectedItem.Value,
                po_number = App.Configuration.PaymentPoNumber,
                title = rdbtnListPayMethods.SelectedItem.Text
            };
            return selectedPayment;
        }

        /// <summary>
        /// Accede a Magento per recuperare le informazioni effettive dei prodotti da ordinare
        /// </summary>
        /// <returns></returns>
        private List<Product> GetProductsForCart()
        {
            var products = new List<Product>();
            foreach (var productCart in SessionFacade.ProductsCart)
            {
                var productFromDb = _businessDelegate.GetProductInfo(productCart.Id);
                var p = new Product
                {
                    name = productCart.Name,
                    product_id = productCart.Id,
                    sku = productFromDb.sku,
                    qty = productCart.Qta.ToString(),
                    price = productFromDb.price,
                    additional_attributes = new object[] { new[] { "size", productCart.Size } }
                };
                CopySizes(productFromDb, p);
                products.Add(p);
            }
            return products;
        }

        private static void CopySizes(Product productFromDb, Product p)
        {
            p.tg_36 = productFromDb.tg_36;
            p.tg_37 = productFromDb.tg_37;
            p.tg_38 = productFromDb.tg_38;
            p.tg_39 = productFromDb.tg_39;
            p.tg_40 = productFromDb.tg_40;
            p.tg_41 = productFromDb.tg_41;
            p.tg_42 = productFromDb.tg_42;
            p.tg_43 = productFromDb.tg_43;
            p.tg_44 = productFromDb.tg_44;
            p.tg_45 = productFromDb.tg_45;
            p.tg_46 = productFromDb.tg_46;
            p.tg_47 = productFromDb.tg_47;
        }

        private void BindDataObjects()
        {
            //var dataObject = new CustomerVM();
            //if (TryUpdateModel(dataObject, new FormValueProvider(ModelBindingExecutionContext)))
            //{

            //} 
        }

        #endregion

        #region Bindings
        private void BindCustomerAddresses(IEnumerable<CustomerAddress> customerAddresses)
        {
            var shipmentAddress = customerAddresses.First(a => a.is_default_shipping);
            txtCity.Text = shipmentAddress.city;
            txtStreet.Text = shipmentAddress.street;
            txtZipCode.Text = shipmentAddress.postcode;
            txtPhone.Text = shipmentAddress.telephone;
        }

        /// <summary>
        /// Crea le entità di mapping per gli indirizzi di spedizione e fatturazione
        /// </summary>
        /// <param name="sendToSameAddress"></param>
        /// <returns></returns>
        private List<CustomerAddress> BindCustomerAddressesToObject(bool sendToSameAddress)
        {
            var shippingAddress = CreateShippingAddress();
            var billingAddress = CreateCustomerAddress();

            if (cbShowShipmentAddress.Visible && !sendToSameAddress)
            {
                shippingAddress.city = txtCity_2.Text;
                shippingAddress.street = txtStreet_2.Text;
                shippingAddress.postcode = txtZipCode_2.Text;
                shippingAddress.telephone = txtPhone_2.Text;
            }
            var customerAddresses = new List<CustomerAddress> { shippingAddress, billingAddress };
            return customerAddresses;
        }

        private void BindUserInfo(Customer customer)
        {
            txtFirstName.Text = customer.firstname;
            txtLastName.Text = customer.lastname;
            txtEmail.Text = customer.email;
            _magentoCustomerId = int.Parse(customer.customer_id);
        }

        private Customer BindUserInfoToObject()
        {
            return new Customer
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                email = txtEmail.Text,
                mode = App.Configuration.DefaultCustomerMode,
                customer_id = _magentoCustomerId.ToString()
            };
        }

        private void BindPaymentMethods()
        {
            rdbtnListPayMethods.DataSource = App.PaymentMethods;
            rdbtnListPayMethods.DataTextField = "value";
            rdbtnListPayMethods.DataValueField = "key";
            rdbtnListPayMethods.DataBind();
        }


        #endregion

        #region Private Methods

        private CustomerAddress CreateCustomerAddress()
        {
            var billingAddress = new CustomerAddress
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                country_id = App.Configuration.DefaultShippingCountryId,
                region = App.Configuration.DefaultShippingRegion,
                city = txtCity.Text,
                street = txtStreet.Text,
                postcode = txtZipCode.Text,
                telephone = txtPhone.Text,
                mode = App.Configuration.AddressModeBilling
            };
            return billingAddress;
        }

        private CustomerAddress CreateShippingAddress()
        {
            var shippingAddress = new CustomerAddress
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                country_id = App.Configuration.DefaultShippingCountryId,
                region = App.Configuration.DefaultShippingRegion,
                city = txtCity.Text,
                street = txtStreet.Text,
                postcode = txtZipCode.Text,
                telephone = txtPhone.Text,
                mode = App.Configuration.AddressModeShipping
            };
            return shippingAddress;
        }

        private void LoadUserInfoIfLogged()
        {
            var aspNetUser = Membership.GetUser(Page.User.Identity.Name);
            if (aspNetUser == null)
            {
                ltTreeStepCheckoutTitle.Text = Resources.Resources.TreeStepCheckoutTitle_NotLogged;
                pnlShowShipmentAddress.Visible = false;
                return;
            }
            var magentoUserId = aspNetUser.Comment;

            int id;
            if (!int.TryParse(magentoUserId, out id)) return;

            var customer = _businessDelegate.GetCustomerById(id);
            if (customer == default(Customer)) return;
            BindUserInfo(customer);

            var customerAddresses = _businessDelegate.GetCustomerAddresses(id);
            if (customerAddresses == null) return;
            BindCustomerAddresses(customerAddresses);
            pnlCreateNewAccount.Visible = pnlLoggedInUserHeader.Visible = false;
            ltTreeStepCheckoutTitle.Text = Resources.Resources.TreeStepCheckoutTitle_Logged;
        }

        private string CreateMagentoCustomer()
        {
            var customer = new Customer
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                email = txtEmail.Text,
                created_at = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            };
            return _businessDelegate.CreateCustomer(customer);
        }

        /// <summary>
        /// L'indirizzo inserito in interfaccia viene salvato in Magento sia come
        /// ind. di spedizione che come indirizzo di fatturazione
        /// </summary>
        /// <param name="type"></param>
        /// <param name="customerId"></param>
        private void CreateMagentoCustomerAddress(AddressType type, string customerId)
        {
            int id;
            if (!int.TryParse(customerId, out id)) return;
            var customerAddress = new CustomerAddress
            {
                firstname = txtFirstName.Text,
                lastname = txtLastName.Text,
                region = txtCity.Text,
                street = txtStreet.Text,
                telephone = txtPhone.Text,
                postcode = txtZipCode.Text,
                city = txtCity.Text,
                country_id = "IT",
            };

            switch (type)
            {
                case AddressType.Billing:
                    customerAddress.is_default_billing = true;
                    break;
                case AddressType.Shipping:
                    customerAddress.is_default_shipping = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
            _businessDelegate.CreateCustomerAddress(id, customerAddress);
        }

        private void SendNotificationEmailToSignedCustomer(string username, string passwordFromUI)
        {
            try
            {
                var from = new MailAddress("info@calzafacile.com", "CalzaFacile");
                var to = new MailAddress(cuwUser.Email, string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text));
                var email = new MailMessage(@from, to)
                {
                    Subject = "Conferma creazione account shop Calzafacile",
                    IsBodyHtml = true
                };
                var header =
                  string.Format(
                    "<img alt='header' src='http://www.calzafacile.com/images/logo_header.jpg' /> " +
                    "<br><br>Creazione account Shop <b style='color:#bf00000'>Calzafacile</b> di: {0} <br><br>",
                    cuwUser.Email);
                email.Body =
                  string.Format(
                    "{0}Gentile {1} {2},<br> le confermiamo l'iscrizione al nostro Shop.<br><br>Riepilogo dati di accesso: <br>Utente:" +
                    "{3}<br>Password: {4}<br>" + "<br><a href=\"http://www.Calzafacile.it/shop/accedi.html\">" +
                    "Cliccando qui</a> può accedere al suo account e verificare lo stato dei suoi ordini.",
                    header, txtFirstName.Text, txtLastName.Text, username, passwordFromUI);
                //email.Bcc.Add("");
                email.Bcc.Add("info@calzafacile.com"); // Settare in variabili di configurazione
                var smtpMail = new SmtpClient();
                smtpMail.Send(email);
            }
            catch (Exception ex)
            {

            }
        }

        private void ActivateCartEmptyView(EmptyCartMode emptyCartMode)
        {
            mvContainer.ActiveViewIndex = 0;

            switch (emptyCartMode)
            {
                case EmptyCartMode.Default:
                    {
                        ltEmptyCartTitle.Text = Resources.Resources.ltEmptyCartTitle_Default;
                        ltEmptyCartMsg.Text = Resources.Resources.ltEmptyCartMsg_Default;
                        break;
                    }
                case EmptyCartMode.AfterOrder:
                    {
                        ltEmptyCartTitle.Text = Resources.Resources.ltEmptyCartTitle_AfterOrder;
                        ltEmptyCartMsg.Text = Resources.Resources.ltEmptyCartMsg_AfterOrder;
                        break;
                    }
                case EmptyCartMode.AfterOrderError:
                    {
                        ltEmptyCartTitle.Text = Resources.Resources.ltEmptyCartTitle_AfterOrderError;
                        ltEmptyCartMsg.Text = Resources.Resources.ltEmptyCartMsg_AfterOrderError;
                        break;
                    }
            }

        }

        private void SendOrderSummaryNotification(Order order, List<OrderProduct> orderProducts, Customer customer, bool withPromo = false)
        {
            var mailManager = new MailManager
            {
                MailTo = customer.email,
                MailCc = "giuseppe.cristella@libero.it",
                MailFrom = "info@calzafacile.com",
                MailSubject = "Conferma ordine",
                MailTemplate = string.Format("{0}order.html", Server.MapPath("~/MailTemplates/Business/")),

                MailParameters = new Hashtable
                {
                    {"##FirstName##", customer.firstname},
                    {"##LastName##", customer.lastname},
                    {"##OrderNum##", order.MagentoOrderId} ,
                    {"##ShippingAddress##", order.CustomerAddress},
                    {"##SubTotal##", order.SubTotal},
                    {"##Shipment##", order.Shipment},
                    {"##Total##", order.Shipment}
                },
                DisplayName = "CalzaFacile Shop"
            };

            //StringBuilder sbOrderItem = new StringBuilder();
            var orderItems = string.Empty;
            foreach (var orderItem in orderProducts)
            {
                // Get image
                var productImages = _businessDelegate.GetProductImages(orderItem.Id.ToString());
                if (productImages.FirstOrDefault(p => p.exclude == "1") == default(ProductImage)) return;
                var productImage = productImages.First(p => p.exclude == "1").url;
                orderItems +="<div class=\"content\"><table bgcolor=\"\"><tr>" +
                          "<td class=\"small\" width=\"20%\" style=\"vertical-align: top; padding-right:10px;\">" +
                          "<img src=\"" + productImage + "\" /></td>" +
                          "<td><p class=\"\">" + orderItem.Name + "<br />taglia: " + orderItem.Size + "<br />Qta." + orderItem.Qty + "<br />Prezzo €. " + orderItem.TotalPrice + "</p>" +
                          "</td></tr></table></div>";
            }
            mailManager.MailParameters["##OrderItems##"] = orderItems;
            mailManager.SendMail();

            if (withPromo)
            {

            }
        }

        private bool ArePromoRelated(string email, string code)
        {
            using (var ctx = new ShopDataContext())
            {
                return ctx.PromotionCodes.FirstOrDefault(pc => pc.NewslettersubscriptionEmail.Equals(email) && pc.Code.Equals(code) && pc.IsAssigned) != null;
            }
        }

        private void SetPromotionCodeAsAssigned(string email)
        {
            using (var ctx = new ShopDataContext())
            {
                var code = ctx.PromotionCodes.FirstOrDefault(pc => pc.NewslettersubscriptionEmail.Equals(email));
                if (code == null) return;
                code.IsAssigned = false;
            }
        }

        private List<OrderProduct> GetOrderProducts(int orderId)
        {
            List<OrderProduct> orderProducts;
            using (var ctx = new ShopDataContext())
            {
                orderProducts = ctx.OrderProducts.Where(p => p.OrderId.Equals(orderId)).ToList();
            }
            return orderProducts;
        }

        private Order GetOrderHeader(int orderId)
        {
            Order order;
            using (var ctx = new ShopDataContext())
            {
                order = ctx.Orders.FirstOrDefault(o => o.MagentoOrderId.Equals(orderId));
            }
            return order;
        }

        #endregion

    }

    public class CustomerVM
    {
        public string FirstName { get; set; }
    }
}