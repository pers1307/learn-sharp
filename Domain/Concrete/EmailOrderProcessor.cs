using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "";
    }
    
    
    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            // send email
        }
    }
}