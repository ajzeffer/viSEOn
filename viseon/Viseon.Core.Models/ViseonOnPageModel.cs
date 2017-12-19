using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.Models
{
    public class ViseonOnPageModel : ModelBase
    {
        public string PageUrl { get; set; }
        public int ContentWordCount { get; set; }
        public int TotalImages { get; set; }
        public int TotalLinks { get; set; }
        public int TotalExternalLinks { get; set; }
        public int TotalInternalLinks { get; set; }
        public int TotalDoFollowLinks { get; set; }
        public int TotalNoFollowLinks { get; set; }
        public int TotalHeaders { get; set; }
        public int TotalParas { get; set; }
        public decimal AvgWordPerHeader { get; set; }
        public decimal AvgWordPerPara { get; set; }
        public ViseonTitleModel Title { get; set; }
        public ViseonKeywordModel Keywords { get; set; }
        public ViseonDescriptionModel Description { get; set; }
        public List<ViseonHeaderModel> Headers { get; set; }
        public List<ViseonParagraphModel> Paras { get; set; }
        public List<ViseonImageModel> Images { get; set; }
        public List<ViseonBacklinkModel> Links { get; set; }
        public List<string> HtmlContentElements { get; set; }
    }
}
