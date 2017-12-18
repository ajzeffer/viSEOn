using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.Models
{
    public class ContentElementBase : ElementBase
     {
        public string Text { get; set; }
        public int WordCount { get; set; }
    }
}
