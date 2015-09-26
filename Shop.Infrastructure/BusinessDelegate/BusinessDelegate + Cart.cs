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
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="customerAddresses"></param>
        /// <param name="products"></param>
        /// <param name="shippingMethod"></param>
        /// <param name="paymentMethod"></param>
        public void CheckOut(Customer customer, List<CustomerAddress> customerAddresses, List<Product> products, string shippingMethod, PaymentMethod paymentMethod)
        {
            try
            {
                customer.mode = "register";
                var cartId = _repository.CreateCart();
                _repository.AssociateCustomerToCart(cartId, customer);
                _repository.AddCustomerAddressesToCart(cartId, customerAddresses);
                products.ForEach(p => _repository.AddProductToCart(cartId, p));
                _repository.AddShippingMethodToCart(cartId, shippingMethod);

                var payMethod = _repository.GetPaymentMethods(cartId).FirstOrDefault(p => !p.code.Equals(paymentMethod.code));
                if (payMethod == null) return;
                payMethod.method = payMethod.code;
                payMethod.po_number = "000";

                _repository.AddPaymentMethodsToCart(cartId, payMethod);
            }
            catch (Exception ex)
            {
                // Log message
                var message = ex.Message;
            }
        }
    }
}
