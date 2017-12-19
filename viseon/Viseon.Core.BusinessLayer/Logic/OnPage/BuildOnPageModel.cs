using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Viseon.Core.Models;
using Viseon.Core.BusinessLayer.Logic.ViseonElements;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.BusinessLayer.Logic.RestClient;
namespace Viseon.Core.BusinessLayer.Logic.OnPage
{
    public partial    class OnPageLogic
    {
        public async Task<ViseonOnPageModel> BuildOnPageModel(string url)
        {


            try
            {
                var html = await new RestClientLogic().GetWebPageAsync(url);
                var doc = new HtmlDocument();
                doc.LoadHtml(html); 
                var onPage = new ViseonOnPageModel()
                {
                    PageUrl = url,
                    Title = new MetaTitleLogic().GetViseonElement(doc),
                    Description = new MetaDescriptionLogic().GetViseonElement(doc),
                    Keywords = new MetaKeywordsLogic().GetViseonElement(doc), 
                    Headers = new HeaderLogic().GetViseonElements(doc), 
                    Paras = new ParagraphLogic().GetViseonElements(doc), 
                    Images = new ImageLogic().GetViseonElements(doc), 
                    Links = new BacklinkLogic(url).GetViseonElements(doc),
                    HtmlContentElements = GetContentHtml(doc)
                };
                onPage.ContentWordCount = onPage.Headers.Sum(x => x.WordCount) + onPage.Paras.Sum(x => x.WordCount);
                onPage.TotalExternalLinks = onPage.Links.Count(x => !x.IsInternal);
                onPage.TotalInternalLinks = onPage.Links.Count(x => x.IsInternal);
                onPage.TotalDoFollowLinks = onPage.Links.Count(x => x.IsFollow);
                onPage.TotalNoFollowLinks= onPage.Links.Count(x => !x.IsFollow);
                onPage.TotalLinks = onPage.Links.Count; 
                onPage.TotalHeaders = onPage.Headers.Count;
                onPage.TotalParas = onPage.Paras.Count; 
                onPage.AvgWordPerHeader =
                    MathUtil.GetAverage(onPage.Headers.Sum(x => x.WordCount), onPage.Headers.Count);
                onPage.AvgWordPerPara=
                    MathUtil.GetAverage(onPage.Paras.Sum(x => x.WordCount), onPage.Paras.Count);

                onPage.TotalImages = onPage.Images.Count; 
                return onPage; 
            }
            catch (Exception e)
            {
                return new ViseonOnPageModel()
                {
                    HasError = true, 
                    Messages = new List<string>()
                    {
                        e.Message
                    }
                };
                throw;
            }

        }
    }
}
