using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Viseon.Core.BusinessLayer.ExtensionMethods
{
    public static class HtmlNodeExtensions
    {
        public static IEnumerable<HtmlNode> GetElementsByName(this HtmlNode parent, string name)
        {
            return parent.Descendants().Where(node => node.Name.ToLower() == name.ToLower());
        }

        public static IEnumerable<HtmlNode> GetElementsByTagName(this HtmlNode parent, string name)
        {
            return parent.Descendants().Where(x => x.OriginalName.ToLower() == name.ToLower());
        }

        public static IEnumerable<HtmlNode> GetElementsByTagName(this HtmlNode parent, List<string> names)
        {
            names = names.ConvertAll(d => d.ToLower());
            return parent.Descendants().Where(x => names.Contains(x.OriginalName.ToLower()));
        }
    }
}
