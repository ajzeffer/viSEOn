using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viseon.Apps.MvcClient.ViewModels.Result;
using Viseon.Core.BusinessLayer.Logic.OnPage;

namespace Viseon.Apps.MvcClient.ViewModelBuilder.Result
{
    public class ResultViewModelBuilder
    {
        public async Task<ResultViewModel> BuildResultViewModel(string url)
        {
            try
            {
                return new ResultViewModel()
                {
                    OnPage = await new OnPageLogic().BuildOnPageModel(url)

                };
            }
            
            catch (Exception e)
            {
                return new ResultViewModel();
            }
        }
    }
}
