﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.BusinessLayer.StaticData
{
    public static class ViseonStaticData
    {
        public static string TitleElement = "title";
        public static string MetaElements = "meta"; 
        public static string MetaDescription = "description";
        public static string MetaKeywords = "keywords";
        public static string LinkElement = "a";
        public static string ImageElement = "img";
        public static string ParaElement = "p";

        public static List<string> AllowedReferrers = new List<string>()
        {
            "anchorprofiler.com"
        };
        public struct Meta
        {
            public static string NameProp = "name";
            public static string ContentProp = "content"; 
        }
        public static List<string> HeaderElements = new     List<string>()
        {
            "h1","h2","h3","h4","h5"
        };
        public struct HtmlProps
        {
            public struct Link
            {
                public struct Rel
                {
                    public static string Name = "rel";
                    public static string Follow = "follow";
                }

                public static string Href = "href"; 

            }

            public struct Image
            {

                public static string Source = "src";
                public static string Alt = "alt";
                public static string Title= "title";
            }
            

        }
    }
}
