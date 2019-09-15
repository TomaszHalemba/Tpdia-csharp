using FuelSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Analyzers
{
    class RecordIntervalAnalyzer
    {
        private List<RecordAnalyzer> recordsIntervalAnalysis;
        private DateTime startDate;
        private DateTime endDate;

        public List<RecordAnalyzer> getrecordAnalyzers()
        {
            return recordsIntervalAnalysis;
        }

        public String getFolderName()
        {

            return String.Format("{0:dd-MM-yyyy}", startDate) + " " + String.Format("{0:dd-MM-yyyy}", endDate);
        }
        public void addRecordAnalyzer(RecordAnalyzer record)
        {
            recordsIntervalAnalysis.Add(record);
        }

        private void setData()
        {
            startDate = endDate = recordsIntervalAnalysis[0].GetSupplies()[0].getStartTime();
            foreach (RecordAnalyzer column in recordsIntervalAnalysis)
            {
                foreach (Supply entry in column.GetSupplies())
                {
                    if (entry.getStartTime() > startDate) startDate = entry.getStartTime();
                    if (entry.getStartTime() < endDate) endDate = entry.getStartTime();
                }
            }

        }
        public RecordIntervalAnalyzer()
        {
            this.recordsIntervalAnalysis = new List<RecordAnalyzer>();
        }

        public void addSupply(string id, Supply supply)
        {
            foreach (RecordAnalyzer entry in recordsIntervalAnalysis) if (entry.getId().Equals(id))
                {
                    entry.addSupply(supply);
                    break;
                }
        }

        public List<RecordAnalyzer> getRecordsIntervalAnalysis()
        {
            return recordsIntervalAnalysis;
        }

        public void setRecordsIntervalAnalysis(List<RecordAnalyzer> recordsIntervalAnalysis)
        {
            this.recordsIntervalAnalysis = recordsIntervalAnalysis;
        }



        public void sortByErrorPercentage()
        {

            this.recordsIntervalAnalysis.OrderBy(c => c.getErrorPercentage()).ThenBy(c => c.getProbDetectorErrorPercentage());

        }

        public void analyzeAll()
        {
            foreach (RecordAnalyzer analyzer in this.recordsIntervalAnalysis)
            {
                analyzer.analyze();
            }
            setData();
            sortByErrorPercentage();
        }

        public DateTime getStartDate()
        {
            return startDate;
        }

        public DateTime getEndDate()
        {
            return endDate;
        }

        public void setStartDate(DateTime startDate)
        {
            this.startDate = startDate;
        }

        public void setEndDate(DateTime endDate)
        {
            this.endDate = endDate;
        }
    }
}
