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
        public async Task<ActionResult> Overview(string target)
        {
            try
            {
                if (target.IsNullOrWhiteSpace()) return Content("Errrr... no target passed in");
                var vm = await new ResultViewModelBuilder().BuildResultViewModel(target);
                if (vm.OnPage.HasError) return Content(string.Join("", vm.OnPage.Messages));
                return View(vm); 
            }
            catch (Exception e)
            {
                return Content(e.Message); 
            }
           
        }
    }
}
