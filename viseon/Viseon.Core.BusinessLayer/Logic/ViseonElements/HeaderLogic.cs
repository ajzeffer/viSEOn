using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.Contracts;using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class HeaderLogic : IViseonElements<ViseonHeaderModel>
    {
        public List<ViseonHeaderModel> GetViseonElements(HtmlDocument doc)
        {
            try
            {
                var headers = new List<ViseonHeaderModel>();
                foreach (var type in ViseonStaticData.HeaderElements)
                {
                    var list = doc.DocumentNode.GetElementsByTagName(type);
                    foreach (var item in list)
                    {
                        headers.Add(new ViseonHeaderModel()
                        {
                            HtmlTagName = item.Name,
                            Text = item.InnerText,
                            WordCount = WordCounting.CountWords(item.InnerText)

                        });

                    }
                }
                return headers;
            }
            catch (Exception ex)
            {
                return new List<ViseonHeaderModel>();
            }

          
        }
    }
}
