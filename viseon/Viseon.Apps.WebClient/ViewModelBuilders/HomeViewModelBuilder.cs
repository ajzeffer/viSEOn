using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Viseon.Apps.WebClient.ViewModels;

namespace Viseon.Apps.WebClient.ViewModelBuilders
{
    public class HomeViewModelBuilder
    {
        public async Task<HomeViewModel> BuildHomeViewModel()
        {
            return new HomeViewModel; 
        }
    }
}