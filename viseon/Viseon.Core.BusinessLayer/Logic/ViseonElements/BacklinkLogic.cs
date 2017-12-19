using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class BacklinkLogic : IViseonElements<ViseonBacklinkModel>
    {
        private readonly string _sourceUrl;
        public BacklinkLogic(string sourceUrl)
        {
            this._sourceUrl = sourceUrl; 
        }
        public List<ViseonBacklinkModel> GetViseonElements(HtmlDocument doc)
        {
            var links = doc.DocumentNode.GetElementsByName(ViseonStaticData.LinkElement);

            var result = new List<ViseonBacklinkModel>();
            foreach (var htmlNode in links)
            {
                var href = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Link.Href,""); 
                result.Add(new ViseonBacklinkModel()
                {
                    HtmlTagName = ViseonStaticData.LinkElement,
                    AnchorText = htmlNode.InnerText,
                    Href = href,
                    IsFollow = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Link.Rel.Name,ViseonStaticData.HtmlProps.Link.Rel.Follow) == ViseonStaticData.HtmlProps.Link.Rel.Follow,
                    IsInternal = CheckIsInternal(_sourceUrl,href)
                });
                
            }
            return result; 
        }
        /// <summary>
        /// Checks to see if the destination URL is internal or external
        /// Handles relative urls by trying to create URI object
        /// </summary>
        /// <param name="sourceUrl"></param>
        /// <param name="destUrl"></param>
        /// <returns></returns>
        private static bool CheckIsInternal(string sourceUrl, string destUrl)
        {
            try
            {
                var uri = new Uri(destUrl);
                var sourceUri = new Uri(sourceUrl);
                var domain = sourceUri.Host;
                return destUrl.Contains(domain); 

            }
            catch (Exception e)
            {

                return true; 
            }
        }
    }
}
