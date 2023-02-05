using Keyify.Web.Models.QuickLink;

namespace Keyify.Web.Service.Interfaces
{
    public interface IQuickLinkService
    {
        public string GenerateBase64(QuickLink quickLinkParameters);
        public QuickLink GenerateQuickLinkParameters(string base64String);
    }
}
