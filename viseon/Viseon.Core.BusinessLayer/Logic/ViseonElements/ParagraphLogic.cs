using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class ParagraphLogic : IViseonElements<ViseonParagraphModel>
    {
        public List<ViseonParagraphModel> GetViseonElements(HtmlDocument doc)
        {
            try
            {
                var paras = doc.DocumentNode.GetElementsByName(ViseonStaticData.ParaElement);
                var result = new List<ViseonParagraphModel>();
                foreach (var htmlNode in paras)
                {
                    result.Add(new ViseonParagraphModel()
                    {
                        HtmlTagName = ViseonStaticData.ParaElement,
                        Text = htmlNode.InnerText,
                        WordCount = WordCounting.CountWords(htmlNode.InnerText)
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<ViseonParagraphModel>();
            }

           
        }
    }
}
