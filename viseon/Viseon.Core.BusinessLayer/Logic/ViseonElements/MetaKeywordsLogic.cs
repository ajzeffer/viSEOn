using System;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class MetaKeywordsLogic : IViseonElement<ViseonKeywordModel>
    {
        public ViseonKeywordModel GetViseonElement(HtmlDocument doc)
        {
            try
            {
                var list = doc.DocumentNode.GetElementsByTagName(ViseonStaticData.MetaElements);
                HtmlNode keywords = null; 
                foreach (var htmlNode in list)
                {
                    if (htmlNode.Attributes[ViseonStaticData.Meta.NameProp] == null) continue;
                    if (!String.Equals(htmlNode.Attributes[ViseonStaticData.Meta.NameProp].Value, ViseonStaticData.MetaKeywords, StringComparison.CurrentCultureIgnoreCase)) continue;
                    keywords = htmlNode;
                    break;
                }

                // No Keywords Found 
                if(keywords == null) return new ViseonKeywordModel()
                {
                    HtmlTagName = ViseonStaticData.MetaKeywords, 
                    WordCount = 0, 
                    Text = ""
                };

                var text = keywords.Attributes[ViseonStaticData.Meta.ContentProp]?.Value;
                return new ViseonKeywordModel()
                {
                    Text = text ?? "",
                    WordCount = text == null ? 0 :  WordCounting.CountWords(text),
                    HtmlTagName = ViseonStaticData.MetaDescription,
                    CharacterCount = text?.Length ?? 0
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
