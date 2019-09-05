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

        public void deleteIncompleteRecords(List<Supply> list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {

                if ((list[i].getTankEndHeight() == null || list[i].getTankStartHeight() == null || list[i].getDeclaredSupplyCapacity() == null
                        || list[i].getDeclaredSupplyCapacityNet() == null || list[i].getDetectedSupplyCapacity() == null
                        || list[i].getDetectedSupplyCapacityNet() == null || list[i].getDriverId() == null || list[i].getEndTime() == null
                        || list[i].getFuelType() == null || list[i].getId() == null || list[i].getStartTime() == null
                        || list[i].getStationId() == null || list[i].getTankCapacity() == null || list[i].getTankId() == null
                        || list[i].getTankCapacity() == null || list[i].getTruckId() == null || list[i].getTruckId() == 0 || list[i].getDriverId() == 0 || list[i].getTerminalId() == 0 || list[i].getDeclaredSupplyCapacityNet() == 0))
                {
                    list.RemoveAt(i);
                }

            }
        }

        // usuwa jakiďż˝ procent najbardziej ekstremalnych pomiarďż˝w
        public void deleteExtremeValues(List<Supply> list, double extremePercent)
        {
            int percent = (int)Math.Floor(list.Count * (double)(extremePercent / 400.0));
            // sortowanie po getVarBasedOnDetected
            list.Sort((p, q) => Math.Abs(q.getVarBasedOnDetected()).CompareTo( Math.Abs(p.getVarBasedOnDetected())));


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
