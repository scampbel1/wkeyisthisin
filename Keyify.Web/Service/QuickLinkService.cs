using Keyify.Web.Models.QuickLink;
using Keyify.Web.Service.Interfaces;
using System;
using System.Text;
using System.Text.Json;

namespace Keyify.Web.Service
{
    public class QuickLinkService : IQuickLinkService
    {
        public string GenerateBase64(QuickLink quickLinkParameters)
        {
            var quickLinkParameterJson = JsonSerializer.Serialize(quickLinkParameters);
            var quickLinkParameterBytes = Encoding.Default.GetBytes(quickLinkParameterJson);

            return Convert.ToBase64String(quickLinkParameterBytes);
        }

        public QuickLink GenerateQuickLinkParameters(string base64String)
        {
            var base64Bytes = Convert.FromBase64String(base64String);

            return JsonSerializer.Deserialize<QuickLink>(base64Bytes);
        }
    }
}
