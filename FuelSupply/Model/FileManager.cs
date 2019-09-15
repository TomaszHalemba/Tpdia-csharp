using FuelSupply.Analyzers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Model
{
    class FileManager
    {

        private Supply parseSupply(string line)
        {
            Supply newSupply = new Supply();
            string[] lines = line.Split(';');

            try
            {
                newSupply.setStationId(Int32.Parse(lines[0]));
                if (newSupply.getStationId() == 0) return null;
                newSupply.setTankId(lines[1][0] - 48);
                if (newSupply.getTankId() == ' ') return null;
                newSupply.setFuelType(lines[2]);
                if (newSupply.getFuelType() == "") return null;
                newSupply.setTankCapacity(Int32.Parse(lines[3]));
                if (newSupply.getStationId() == 0) return null;
                DateTime startTime;
                startTime = DateTime.Parse(lines[4]);
                newSupply.setStartTime(startTime);
                if (newSupply.getStartTime() == null) return null;
                startTime = DateTime.Parse(lines[5]);
                newSupply.setEndTime(startTime);
                if (newSupply.getEndTime() == null) return null;
                newSupply.setTruckId(Int32.Parse(lines[6]));
                if (newSupply.getTruckId() == 0) return null;
                newSupply.setDriverId(Int32.Parse(lines[7]));
                if (newSupply.getDriverId() == 0) return null;
                newSupply.setTerminalId(Int32.Parse(lines[8]));
                if (newSupply.getTerminalId() == 0) return null;
                newSupply.setDetectedSupplyCapacity(Int32.Parse(lines[9]));
                if (newSupply.getDetectedSupplyCapacity() == 0) return null;
                newSupply.setDetectedSupplyCapacityNet(Int32.Parse(lines[10]));
                if (newSupply.getDetectedSupplyCapacityNet() == 0) return null;
                newSupply.setDeclaredSupplyCapacity(Int32.Parse(lines[11]));
                if (newSupply.getDeclaredSupplyCapacity() == 0) return null;
                newSupply.setDeclaredSupplyCapacityNet(Int32.Parse(lines[12]));
                if (newSupply.getDeclaredSupplyCapacityNet() == 0) return null;
                newSupply.setTankStartHeight(Int32.Parse(lines[13]));
                if (newSupply.getTankStartHeight() == 0) return null;
                newSupply.setTankEndHeight(Int32.Parse(lines[14]));
                if (newSupply.getTankEndHeight() == 0) return null;
            }
            catch (Exception e)
            {
                return null;
            }
            return newSupply;

        }
        public List<Supply> getSuppliesFromCsv(String path)
        {
            List<Supply> list = new List<Supply>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    int suppliesCounter = 0;
                    int counter = 0;
                    Boolean firstLine = true;


                    String tmp;
                    do
                    {
                        Supply newSupply = parseSupply(sr.ReadLine());

                        if (!firstLine && newSupply != null)
                        {
                            list.Add(newSupply);
                        }
                        else
                        {
                            firstLine = false;
                        }
                        suppliesCounter++;

                    } while (sr.Peek() != -1);
                }
            }
            catch (FileNotFoundException e)
            {


            }
            return list;
        }


        public void printRecordsIntervalAnalyzerTank(List<RecordIntervalAnalyzer> list, String path)
        {

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (RecordIntervalAnalyzer column in list)
            {
                String name = column.getFolderName();

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path + "\\" + name + ".txt"))
                {
                    file.WriteLine("station | tank | errors altogheter   |  error percentage   | detectors error   |  detector percentage error    | leaks     |  percentage of leaks| excess  | excess percentage  |");
                    foreach (RecordAnalyzer entry in column.getRecordsIntervalAnalysis())
                    {
                        file.Write((entry.GetSupplies()[0].getStationId() + "|").PadLeft(9, ' '));
                        file.Write((entry.GetSupplies()[0].getTankId() + "|").PadLeft(7, ' '));
                        file.Write((entry.getErrorCount() + "|").PadLeft(22, ' '));
                        file.Write((entry.getErrorPercentage() + "|").PadLeft(22, ' '));
                        file.Write((entry.getProbDetectorErrorCount() + "|").PadLeft(20, ' '));
                        file.Write((entry.getProbDetectorErrorPercentage() + "|").PadLeft(32, ' '));
                        file.Write((entry.getProbLeakCount() + "|").PadLeft(12, ' '));
                        file.Write((entry.getPropLeakPercentage() + "|").PadLeft(22, ' '));
                        file.Write((entry.getExcessCount() + "|").PadLeft(10, ' '));
                        file.Write((entry.getExcessPercentage() + "|").PadLeft(21, ' '));
                        file.Write("\n");

                    }
                }


            }
        }

        public void printRecordsIntervalAnalyzer(List<RecordIntervalAnalyzer> list, String path, string idname)
        {
            idname = idname.PadRight(10, ' ');
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (RecordIntervalAnalyzer column in list)
            {
                String name = column.getFolderName();

                using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path + "\\" + name + ".txt"))
                {
                    file.WriteLine(idname + "| errors altogheter   |  error percentage   | detectors error   |  detector percentage error    | leaks     |  percentage of leaks| excess  | excess percentage  |");
                    foreach (RecordAnalyzer entry in column.getRecordsIntervalAnalysis())
                    {
                        file.Write((entry.getId() + "|").PadLeft(11, ' '));
                        file.Write((entry.getErrorCount() + "|").PadLeft(22, ' '));
                        file.Write((entry.getErrorPercentage() + "|").PadLeft(22, ' '));
                        file.Write((entry.getProbDetectorErrorCount() + "|").PadLeft(20, ' '));
                        file.Write((entry.getProbDetectorErrorPercentage() + "|").PadLeft(32, ' '));
                        file.Write((entry.getProbLeakCount() + "|").PadLeft(12, ' '));
                        file.Write((entry.getPropLeakPercentage() + "|").PadLeft(22, ' '));
                        file.Write((entry.getExcessCount() + "|").PadLeft(10, ' '));
                        file.Write((entry.getExcessPercentage() + "|").PadLeft(21, ' '));
                        file.Write("\n");

                    }
                }


            }
        }


        public void printTank(List<RecordAnalyzer> list, String path)
        {
            using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(path))
            {
                file.WriteLine("station | tank | errors altogheter   |  error percentage   | detectors error   |  detector percentage error    | leaks     |  percentage of leaks| excess  | excess percentage  |");
                foreach (RecordAnalyzer entry in list)
                {
                    file.Write((entry.GetSupplies()[0].getStationId() + "|").PadLeft(9, ' '));
                    file.Write((entry.GetSupplies()[0].getTankId() + "|").PadLeft(7, ' '));
                    file.Write((entry.getErrorCount() + "|").PadLeft(22, ' '));
                    file.Write((entry.getErrorPercentage() + "|").PadLeft(22, ' '));
                    file.Write((entry.getProbDetectorErrorCount() + "|").PadLeft(20, ' '));
                    file.Write((entry.getProbDetectorErrorPercentage() + "|").PadLeft(32, ' '));
                    file.Write((entry.getProbLeakCount() + "|").PadLeft(12, ' '));
                    file.Write((entry.getPropLeakPercentage() + "|").PadLeft(22, ' '));
                    file.Write((entry.getExcessCount() + "|").PadLeft(10, ' '));
                    file.Write((entry.getExcessPercentage() + "|").PadLeft(21, ' '));
                    file.Write("\n");

                }
            }


        }

        public void printAnalyzer(List<RecordAnalyzer> list, String path, string idname)
        {
            idname = idname.PadRight(10, ' ');
            using (System.IO.StreamWriter file =
        new System.IO.StreamWriter(path))
            {
                file.WriteLine(idname + "| errors altogheter   |  error percentage   | detectors error   |  detector percentage error    | leaks     |  percentage of leaks| excess  | excess percentage  |");
                foreach (RecordAnalyzer entry in list)
                {
                    file.Write((entry.getId() + "|").PadLeft(11, ' '));
                    file.Write((entry.getErrorCount() + "|").PadLeft(22, ' '));
                    file.Write((entry.getErrorPercentage() + "|").PadLeft(22, ' '));
                    file.Write((entry.getProbDetectorErrorCount() + "|").PadLeft(20, ' '));
                    file.Write((entry.getProbDetectorErrorPercentage() + "|").PadLeft(32, ' '));
                    file.Write((entry.getProbLeakCount() + "|").PadLeft(12, ' '));
                    file.Write((entry.getPropLeakPercentage() + "|").PadLeft(22, ' '));
                    file.Write((entry.getExcessCount() + "|").PadLeft(10, ' '));
                    file.Write((entry.getExcessPercentage() + "|").PadLeft(21, ' '));
                    file.Write("\n");

                }
            }
        }

    }
}
