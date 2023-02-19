using Keyify.Web.Models.QuickLink;

namespace Keyify.Web.Services.Interfaces
{
    public interface IQuickLinkService
    {
        public string ConvertQuickLinkToBase64(QuickLink quickLinkParameters);
        public QuickLink DeserializeQuickLink(string base64String);
    }
}
