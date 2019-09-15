using FuelSupply.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Analyzers
{
    class RecordAnalyzer
    {

        public int getExcessCount()
        {
            return excessCount;
        }
        public Double getExcessPercentage()
        {
            return excessPercentage;
        }
        public int getErrorCount()
        {
            return errorCount;
        }
        public Double getErrorPercentage()
        {
            return errorPercentage;
        }
        public List<Supply> GetSupplies()
        {
            return supplies;
        }
        public string getId()
        {
            return id;
        }

        private string id;
        private List<Supply> supplies;
        protected int probLeakCount;
        protected int probDetectorErrorCount;
        protected int errorCount;
        protected int excessCount;
        protected Double propLeakPercentage;
        protected Double probDetectorErrorPercentage;
        protected Double errorPercentage;
        protected Double excessPercentage;

        public void addSupply(Supply supply)
        {

            this.supplies.Add(supply);

        }
        public RecordAnalyzer(string id, Supply supply)
        {
            supplies = new List<Supply>();
            supplies.Add(supply);
            this.id = id;
        }


        public void analyze()
        {
            excessCount = errorCount = probLeakCount = probDetectorErrorCount = 0;

            foreach (Supply entry in supplies)
            {
                if (entry.isPossibleDetectorError() || entry.isPossibleLeak() || entry.getExcess())
                {
                    errorCount++;
                    if (entry.isPossibleDetectorError()) probDetectorErrorCount++;
                    else
                    {
                        if (entry.isPossibleLeak()) probLeakCount++;
                        if (entry.getExcess()) excessCount++;
                    }


                }

            }
            errorPercentage = errorCount / (double)supplies.Count * 100;
            propLeakPercentage = probLeakCount / (double)supplies.Count * 100;
            probDetectorErrorPercentage = probDetectorErrorCount / (double)supplies.Count * 100;
            excessPercentage = excessCount / (double)supplies.Count * 100;

        }

        public int getProbLeakCount()
        {
            return probLeakCount;
        }

        public int getProbDetectorErrorCount()
        {
            return probDetectorErrorCount;
        }

        public Double getPropLeakPercentage()
        {
            return propLeakPercentage;
        }

        public Double getProbDetectorErrorPercentage()
        {
            return probDetectorErrorPercentage;
        }


    }
}
