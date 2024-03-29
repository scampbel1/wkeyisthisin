﻿using Keyify.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;

namespace Keyify.Web.Controllers.Quicklink
{
    public class QuickLinkController : Controller
    {
        private IConfiguration _configuration;
        private IQuickLinkService _quickLinkService;

        public QuickLinkController(IConfiguration configuration, IQuickLinkService quickLinkService)
        {
            _configuration = configuration;
            _quickLinkService = quickLinkService;
        }

        [HttpGet("/ql/v1/{code}")]
        public IActionResult Index(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Redirect("/");
            }

            try
            {
                var quickLink = _quickLinkService.DeserializeQuickLink(code);

                TempData[_configuration["QuickLinkTempDataKey:Tuning"]] = quickLink.Tuning;
                TempData[_configuration["QuickLinkTempDataKey:SelectedScale"]] = quickLink.SelectedScale;
                TempData[_configuration["QuickLinkTempDataKey:SelectedNotes"]] = quickLink.SelectedNotes;
                TempData[_configuration["QuickLinkTempDataKey:InstrumentType"]] = quickLink.InstrumentType;
                TempData[_configuration["QuickLinkTempDataKey:InstrumentName"]] = quickLink.InstrumentName;

                var redirectUrl = $"/{quickLink.InstrumentName}/";

                return Redirect(redirectUrl);
            }
            catch (Exception exception)
            {
                //TODO: Implement logging
                Trace.WriteLine(exception.Message);

                return Redirect("/");
            }
        }
    }
}
