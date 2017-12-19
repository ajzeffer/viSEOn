using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Viseon.Apps.MvcClient.ViewModelBuilder.Result;

namespace Viseon.Apps.MvcClient.Controllers
{
    public class ResultController: Controller

    {
        [HttpGet]
        public ActionResult Overview()
        {
            return Redirect("~/"); 
        }
        [HttpPost]
        public async Task<ActionResult> Overview(string target)
        {
            try
            {
                if (target.IsNullOrWhiteSpace()) throw new Exception("Invalid Url Passed In!"); 
                var vm = await new ResultViewModelBuilder().BuildResultViewModel(target);
                if (!vm.OnPage.HasError) return View(vm);
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
