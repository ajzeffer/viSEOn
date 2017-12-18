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
        private string sourceUrl;
        public BacklinkLogic(string SourceUrl)
        {
            sourceUrl = SourceUrl; 
        }
        public List<ViseonBacklinkModel> GetViseonElements(HtmlDocument doc)
        {
            var links = doc.DocumentNode.GetElementsByName(ViseonStaticData.LinkElement);

            var result = new List<ViseonBacklinkModel>();
            var sourceUri = new Uri(sourceUrl);
            var domain = sourceUri.Host;
            foreach (var htmlNode in links)
            {
                var href = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Link.Href,""); 
                result.Add(new ViseonBacklinkModel()
                {
                    HtmlTagName = ViseonStaticData.LinkElement,
                    AnchorText = htmlNode.InnerText,
                    Href = href,
                    IsFollow = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Link.Rel.Name,ViseonStaticData.HtmlProps.Link.Rel.Follow) == ViseonStaticData.HtmlProps.Link.Rel.Follow,
                    IsInternal = href.Contains(domain)
                });
                
            }
            return result; 
        }

        
    }
}
