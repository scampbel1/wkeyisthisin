using Keyify.Web.Models.QuickLink;

namespace Keyify.Web.Service.Interfaces
{
    public interface IQuickLinkService
    {
        public string ConvertQuickLinkToBase64(QuickLink quickLinkParameters);
        public QuickLink DeserializeQuickLink(string base64String);
    }
}
