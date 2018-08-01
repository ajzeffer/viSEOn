using System;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class MetaDescriptionLogic : IViseonElement<ViseonDescriptionModel>
    {
        public  ViseonDescriptionModel GetViseonElement(HtmlDocument doc)
        {
            try
            {
                var list = doc.DocumentNode.GetElementsByTagName(ViseonStaticData.MetaElements);
                HtmlNode desc = null; 
                foreach (var htmlNode in list)
                {
                    if(htmlNode.Attributes[ViseonStaticData.Meta.NameProp] == null) continue;
                    if (!String.Equals(htmlNode.Attributes[ViseonStaticData.Meta.NameProp].Value, ViseonStaticData.MetaDescription, StringComparison.CurrentCultureIgnoreCase)) continue;
                    desc = htmlNode;
                    break;
                }

                // no desc 
                if(desc == null) return new ViseonDescriptionModel()
                {
                    HtmlTagName = ViseonStaticData.MetaDescription, 
                    Text = "", 
                    WordCount = 0
                };

                var text = desc.Attributes[ViseonStaticData.Meta.ContentProp]?.Value;
                return new ViseonDescriptionModel()
                {
                    Text = text ?? "",
                    WordCount = text == null ? 0 : WordCounting.CountWords(text),
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
