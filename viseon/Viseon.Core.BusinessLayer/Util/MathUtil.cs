using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.BusinessLayer.Util
{
    public static class MathUtil
    {
        public static decimal GetAverage(decimal? amt, int dividedBy)
        {
            amt = amt.GetValueOrDefault(0);
            return dividedBy == 0
                ? 0
                : System.Math.Round((decimal)amt / dividedBy, 2);
        }

        public static decimal GetPercentage(decimal? amt, int dividedBy)
        {
            amt = amt.GetValueOrDefault(0);
            return dividedBy == 0
                ? 0
                : System.Math.Round((decimal)amt / dividedBy * 100, 2);
        }

    }

}
