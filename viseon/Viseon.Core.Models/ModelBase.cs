using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.Models
{
    public class ModelBase 
    {
        public bool HasError { get; set; }
        public List<string> Messages { get; set; }
    }
}
