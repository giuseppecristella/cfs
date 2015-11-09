using System;
using System.Collections.Generic;
using System.Linq;
using Ez.Newsletter.MagentoApi;

namespace Shop.Core.BusinessDelegate
{
    public partial class BusinessDelegate
    {

        public bool ValidateProducts()
        {
            return false;
        }

        /// <summary>
        /// Crea un carrello in Magento
        /// Associa il customer, gli indirizzi di spedizione e fatturazione
        /// i metodi di pagamento e di spedizione
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="customer"></param>
        /// <param name="customerAddresses"></param>
        /// <param name="products"></param>
        /// <param name="shippingMethod"></param>
        /// <param name="paymentMethod"></param>
        public void PrepareCartForOrder(int cartId, Customer customer, List<CustomerAddress> customerAddresses, List<Product> products, string shippingMethod, PaymentMethod paymentMethod)
        {
            try
            {
                customer.mode = "register";
                _repository.AssociateCustomerToCart(cartId, customer);
                _repository.AddCustomerAddressesToCart(cartId, customerAddresses);
                products.ForEach(p => _repository.AddProductToCart(cartId, p));
                _repository.AddShippingMethodToCart(cartId, shippingMethod);

                //var payMethod = _repository.GetPaymentMethods(cartId).FirstOrDefault(p => !p.code.Equals(paymentMethod.code));
                var payMethod = _repository.GetPaymentMethods(cartId).FirstOrDefault();
                if (payMethod == null) return;
                payMethod.method = payMethod.code;
                payMethod.po_number = "000";

                _repository.AddPaymentMethodsToCart(cartId, payMethod);
            }
            catch (Exception ex)
            {
                // Return response with error msg code
                // Log message
                var message = ex.Message;
            }
        }

        public void CreateCustomerAddress(int customerId, CustomerAddress address)
        {
            _repository.CreateCustomerAddress(customerId, address);
        }

        public string CreateCustomer(Customer customer)
        {
            return _repository.CreateCustomer(customer);
        }

        public int CreateCart()
        {
            return _repository.CreateCart();
        }

        public List<PaymentMethod> GetPaymentMethods(int cartId)
        {
            return _repository.GetPaymentMethods(cartId);
        }

        public int CreateOrder(int cartId)
        {
            return _repository.CreateOrder(cartId);
        }

        public object GetCustomerOrders(string p)
        {
            throw new NotImplementedException();
        }
    }
}
