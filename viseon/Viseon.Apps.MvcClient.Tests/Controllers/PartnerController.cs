﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Viseon.Apps.MvcClient.ViewModelBuilder.Result;
using Viseon.Core.BusinessLayer.StaticData;

namespace Viseon.Apps.MvcClient.Tests.Controllers
{
    public class PartnerController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> glasses(string target)
        {
            // only allow certain domains to send referal traffic 
            if (!ViseonStaticData.AllowedReferrers.Contains(HttpContext.Request.UrlReferrer?.Host))
                return Redirect("~/"); 
                try
                {
                    if (target.IsNullOrWhiteSpace()) throw new Exception("Invalid Url Passed In!");
                    var vm = await new ResultViewModelBuilder().BuildResultViewModel(target);
                    if (!vm.OnPage.HasError) return View("~/Result/Overview",vm);
                    TempData["msg"] = string.Join("", vm.OnPage.Messages);
                    return Redirect("~/");
                }
                catch (Exception e)
                {
                    TempData["msg"] = e.Message;
                    return Redirect("~/");
                }

        }
    }
}
