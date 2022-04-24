using CakeDessertShop.Common;

namespace CakeDessertShop.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }
}
