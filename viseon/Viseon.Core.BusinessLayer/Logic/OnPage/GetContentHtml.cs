using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;

namespace Viseon.Core.BusinessLayer.Logic.OnPage
{
    public partial class OnPageLogic
    {
        public List<string> GetContentHtml(HtmlDocument doc)
        {
            try
            {
                var nodesToSelect = new List<string>();
                nodesToSelect.AddRange(ViseonStaticData.HeaderElements);
                nodesToSelect.Add("p"); 
                var htmlElements = doc.DocumentNode.GetElementsByTagName(nodesToSelect);
                var result = new List<string>(); 
                foreach (var htmlElement in htmlElements)
                {
                    result.Add(htmlElement.OuterHtml);
                }
                return result; 
            }
            catch (Exception e)
            {
                return new List<string>();
            }
        }
    }
}
