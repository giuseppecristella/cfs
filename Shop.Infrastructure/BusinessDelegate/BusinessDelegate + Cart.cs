using System;
using System.Collections.Generic;
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
        public void CreateCart(Customer customer, List<CustomerAddress> customerAddresses, List<Product> products, string shippingMethod, PaymentMethod paymentMethod)
        {
            try
            {
                var cartId = _repository.CreateCart();
                _repository.AssociateCustomerToCart(cartId, customer);
                _repository.AddCustomerAddressesToCart(cartId, customerAddresses);
                products.ForEach(p => _repository.AddProductToCart(cartId, p));
                _repository.AddShippingMethodToCart(cartId, shippingMethod);
                _repository.AddPaymentMethodsToCart(cartId, paymentMethod);
            }
            catch (Exception ex)
            {
                // Log message
                var message = ex.Message;
            }
        }
    }
}
