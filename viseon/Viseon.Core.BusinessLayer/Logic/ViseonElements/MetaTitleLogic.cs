using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.BusinessLayer.Util;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class MetaTitleLogic : IViseonElement<ViseonTitleModel>
    {
        public ViseonTitleModel GetViseonElement(HtmlDocument doc)
        {
            try
            {
                var list = doc.DocumentNode.GetElementsByTagName(ViseonStaticData.TitleElement);
                var title = list.FirstOrDefault();
                // no title found 
                if (title == null)return new ViseonTitleModel()
                {
                    HtmlTagName = ViseonStaticData.TitleElement, 
                    Text = "", WordCount = 0
                };
                return new ViseonTitleModel()
                {
                    Text = title.InnerText, 
                    WordCount = WordCounting.CountWords(title.InnerText),
                    HtmlTagName = ViseonStaticData.TitleElement,
                    CharacterCount = title.InnerText.Length
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
