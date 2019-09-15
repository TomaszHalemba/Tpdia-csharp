using FuelSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Analyzers
{
    class DataFiltering
    {

        public void deleteExtremeValues(List<Supply> list, double extremePercent)
        {
            int percent = (int)Math.Floor(list.Count * (double)(extremePercent / 400.0));
            list.Sort((p, q) => Math.Abs(q.getVarBasedOnDetected()).CompareTo(Math.Abs(p.getVarBasedOnDetected())));


            for (int a = 0; a < percent; a++)
            {
                list.RemoveAt(a);
            }

            list.Sort((p, q) => Math.Abs(q.getVarBasedOnDetectedNet()).CompareTo(Math.Abs(p.getVarBasedOnDetectedNet())));


            for (int a = 0; a < percent; a++)
            {
                list.RemoveAt(a);
            }
            list.Sort((p, q) => Math.Abs(q.getVarBasedOnHeightNet()).CompareTo(Math.Abs(p.getVarBasedOnHeightNet())));


            for (int a = 0; a < percent; a++)
            {
                list.RemoveAt(a);
            }

            list.Sort((p, q) => Math.Abs(q.getVarBasedOnHeight()).CompareTo(Math.Abs(p.getVarBasedOnHeight())));


            for (int a = 0; a < percent; a++)
            {
                list.RemoveAt(a);
            }

        }
    }
}
