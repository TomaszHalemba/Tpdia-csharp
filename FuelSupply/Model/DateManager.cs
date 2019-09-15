using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Model
{
    class DateManager
    {
        public List<List<Supply>> splitToLists(List<Supply> list, int interval)
        {
            List<List<Supply>> returnList = new List<List<Supply>>();

            List<Supply> tmp = new List<Supply>();

            DateTime lastDate = this.getMinDate(list);

            int listSize = list.Count;
            int arraySize = 1;


            DateTime lastDateLimit = lastDate;
            lastDateLimit = lastDateLimit.AddDays(interval);
            while (listSize > arraySize)
            {
                foreach (Supply entry in list)
                {
                    if (DateTime.Compare(lastDateLimit, entry.getStartTime()) >= 0)
                        if (DateTime.Compare(entry.getStartTime(), lastDate) > 0)
                        {
                            tmp.Add(entry);
                            arraySize++;
                        }

                }
                if (tmp.Count != 0)
                {
                    lastDate = getMaxDate(tmp);
                    returnList.Add(tmp);
                    lastDateLimit = lastDate.AddDays(interval);
                    tmp = new List<Supply>();
                }

            }


            return returnList;
        }

        private DateTime getMaxDate(List<Supply> list)
        {
            DateTime max = list[0].getStartTime();

            foreach (Supply entry in list)
            {
                if (DateTime.Compare(entry.getStartTime(), max) > 0)
                    max = entry.getStartTime();
            }

            return max;
        }

        private DateTime getMinDate(List<Supply> list)
        {
            DateTime min = list[0].getStartTime();

            foreach (Supply entry in list)
            {
                if (DateTime.Compare(entry.getStartTime(), min) < 0)
                    min = entry.getStartTime();
            }

            return min;
        }

    }
}
