using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.Models
{
    public class ViseonBacklinkModel : ElementBase
    {
        public string Href { get; set; }
        public string Title { get; set; }
        public string AnchorText { get; set; }
        public bool IsInternal { get; set; }
        public bool IsFollow { get; set; }

    }
}
