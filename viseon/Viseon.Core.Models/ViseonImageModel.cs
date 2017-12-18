using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.Models
{
    public class ViseonImageModel : ElementBase
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Alt { get; set; }
    }
}