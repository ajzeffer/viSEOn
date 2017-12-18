using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Viseon.Core.BusinessLayer.ExtensionMethods;
using Viseon.Core.BusinessLayer.StaticData;
using Viseon.Core.Contracts;
using Viseon.Core.Models;

namespace Viseon.Core.BusinessLayer.Logic.ViseonElements
{
    public class ImageLogic : IViseonElements<ViseonImageModel>
    {
        public List<ViseonImageModel> GetViseonElements(HtmlDocument doc)
        {

            try
            {
                var links = doc.DocumentNode.GetElementsByName(ViseonStaticData.ImageElement);
                
                var result = new List<ViseonImageModel>();
                foreach (var htmlNode in links)
                {
                    result.Add(new ViseonImageModel()
                    {
                        HtmlTagName = ViseonStaticData.ImageElement,
                        Url = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Image.Source, ""),
                        Alt = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Image.Alt, ""),
                        Title = htmlNode.GetAttributeValue(ViseonStaticData.HtmlProps.Image.Title, ""),
                    });
                }
                return result;
            }
            catch (Exception ex)
            {
                return new List<ViseonImageModel>();
            }
          
        }
    }
}
