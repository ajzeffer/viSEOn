using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Viseon.Core.Contracts
{
    public interface IViseonElements<T>
    {
        List<T> GetViseonElements(HtmlDocument doc);
    }

    public interface IViseonElement<T>
    {
        T GetViseonElement(HtmlDocument doc);
    }
}
