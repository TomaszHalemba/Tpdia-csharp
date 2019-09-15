using FuelSupply.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Analyzers
{
    class RecordAnalyzerManager
    {
        private List<Supply> suppliesList;

        List<RecordAnalyzer> driverAnalyzer = new List<RecordAnalyzer>();
        List<RecordAnalyzer> truckAnalyzer = new List<RecordAnalyzer>();
        List<RecordAnalyzer> terminalAnalyzer = new List<RecordAnalyzer>();
        List<RecordAnalyzer> stationAnalyzer = new List<RecordAnalyzer>();
        List<RecordAnalyzer> tankAnalyzer = new List<RecordAnalyzer>();

        List<RecordIntervalAnalyzer> driverRecordInternalAnalyzers = new List<RecordIntervalAnalyzer>();
        List<RecordIntervalAnalyzer> truckRecordInternalAnalyzers = new List<RecordIntervalAnalyzer>();
        List<RecordIntervalAnalyzer> terminalRecordInternalAnalyzers = new List<RecordIntervalAnalyzer>();
        List<RecordIntervalAnalyzer> stationRecordInternalAnalyzers = new List<RecordIntervalAnalyzer>();
        List<RecordIntervalAnalyzer> tankRecordInternalAnalyzers = new List<RecordIntervalAnalyzer>();

        private DateManager dateManager;



        public List<RecordAnalyzer> getDriverAnalyzer()
        {
            return driverAnalyzer;
        }

        public List<RecordIntervalAnalyzer> getDriverInternalAnalyzer()
        {
            return driverRecordInternalAnalyzers;
        }

        public List<RecordAnalyzer> getTruckAnalyzer()
        {
            return truckAnalyzer;
        }

        public List<RecordIntervalAnalyzer> getTruckInternalAnalyzer()
        {
            return truckRecordInternalAnalyzers;
        }

        public List<RecordAnalyzer> getTerminalAnalyzer()
        {
            return terminalAnalyzer;
        }

        public List<RecordIntervalAnalyzer> getTerminalInternalAnalyzer()
        {
            return terminalRecordInternalAnalyzers;
        }

        public List<RecordAnalyzer> getStationAnalyzer()
        {
            return stationAnalyzer;
        }

        public List<RecordIntervalAnalyzer> getStationInternalAnalyzer()
        {
            return stationRecordInternalAnalyzers;
        }

        public List<RecordAnalyzer> getTankAnalyzer()
        {
            return tankAnalyzer;
        }

        public List<RecordIntervalAnalyzer> getTankInternalAnalyzer()
        {
            return tankRecordInternalAnalyzers;
        }


        public void sortAnalyzers(List<RecordIntervalAnalyzer> analyzers)
        {
            foreach (RecordIntervalAnalyzer entry in analyzers)
                entry.setRecordsIntervalAnalysis(entry.getrecordAnalyzers().OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList());
        }
        public void setArrays()
        {

            tankAnalyzer = tankAnalyzer.OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList();
            sortAnalyzers(tankRecordInternalAnalyzers);


            truckAnalyzer = truckAnalyzer.OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList();
            sortAnalyzers(truckRecordInternalAnalyzers);

            driverAnalyzer = driverAnalyzer.OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList();
            sortAnalyzers(driverRecordInternalAnalyzers);

            terminalAnalyzer = terminalAnalyzer.OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList();
            sortAnalyzers(terminalRecordInternalAnalyzers);

            stationAnalyzer = stationAnalyzer.OrderByDescending(o => o.getErrorPercentage()).ThenByDescending(o => o.getErrorCount()).ThenByDescending(o => o.getProbDetectorErrorPercentage()).ToList();
            sortAnalyzers(stationRecordInternalAnalyzers);

        }
        private void deleteRecordAnalyzers(List<RecordAnalyzer> recordAnalyzer, int tooSmallDataSample)
        {
            for (int i = recordAnalyzer.Count - 1; i >= 0; i--)
            {
                if (recordAnalyzer[i].GetSupplies().Count <= tooSmallDataSample) recordAnalyzer.RemoveAt(i);
            }
        }
        private void deleteRecordInternalAnalyzers(List<RecordIntervalAnalyzer> recordIntervalAnalyzers, int tooSmallDataSample)
        {
            for (int i = recordIntervalAnalyzers.Count - 1; i >= 0; i--)
            {
                deleteRecordAnalyzers(recordIntervalAnalyzers[i].getrecordAnalyzers(), tooSmallDataSample);
                if (recordIntervalAnalyzers[i].getrecordAnalyzers().Count == 0) recordIntervalAnalyzers.RemoveAt(i);
            }
        }
        public void deleteDataWithToSmallSample(int tooSmallDataSample)
        {
            deleteRecordAnalyzers(driverAnalyzer, tooSmallDataSample);
            deleteRecordAnalyzers(truckAnalyzer, tooSmallDataSample);
            deleteRecordAnalyzers(stationAnalyzer, tooSmallDataSample);
            deleteRecordAnalyzers(terminalAnalyzer, tooSmallDataSample);
            deleteRecordAnalyzers(tankAnalyzer, tooSmallDataSample);

            deleteRecordInternalAnalyzers(driverRecordInternalAnalyzers, tooSmallDataSample);
            deleteRecordInternalAnalyzers(truckRecordInternalAnalyzers, tooSmallDataSample);
            deleteRecordInternalAnalyzers(stationRecordInternalAnalyzers, tooSmallDataSample);
            deleteRecordInternalAnalyzers(terminalRecordInternalAnalyzers, tooSmallDataSample);
            deleteRecordInternalAnalyzers(tankRecordInternalAnalyzers, tooSmallDataSample);

        }

        public void analyzeLists()
        {
            foreach (RecordAnalyzer analyzer in driverAnalyzer)
            {
                analyzer.analyze();
            }
            foreach (RecordAnalyzer analyzer in truckAnalyzer)
            {
                analyzer.analyze();
            }
            foreach (RecordAnalyzer analyzer in terminalAnalyzer)
            {
                analyzer.analyze();
            }
            foreach (RecordAnalyzer analyzer in stationAnalyzer)
            {
                analyzer.analyze();
            }
            foreach (RecordAnalyzer analyzer in tankAnalyzer)
            {
                analyzer.analyze();
            }

            foreach (RecordIntervalAnalyzer intervalAnalyzer in driverRecordInternalAnalyzers)
            {
                intervalAnalyzer.analyzeAll();
            }
            foreach (RecordIntervalAnalyzer intervalAnalyzer in truckRecordInternalAnalyzers)
            {
                intervalAnalyzer.analyzeAll();
            }
            foreach (RecordIntervalAnalyzer intervalAnalyzer in terminalRecordInternalAnalyzers)
            {
                intervalAnalyzer.analyzeAll();
            }
            foreach (RecordIntervalAnalyzer intervalAnalyzer in stationRecordInternalAnalyzers)
            {
                intervalAnalyzer.analyzeAll();
            }
            foreach (RecordIntervalAnalyzer intervalAnalyzer in tankRecordInternalAnalyzers)
            {
                intervalAnalyzer.analyzeAll();
            }
        }

        public void createAnalysis(int interval)
        {
            List<List<Supply>> splitSupplies = this.dateManager.splitToLists(suppliesList, interval);
            int cycle = 0;
            foreach (List<Supply> entry in splitSupplies)
            {
                driverRecordInternalAnalyzers.Add(new RecordIntervalAnalyzer());
                truckRecordInternalAnalyzers.Add(new RecordIntervalAnalyzer());
                terminalRecordInternalAnalyzers.Add(new RecordIntervalAnalyzer());
                stationRecordInternalAnalyzers.Add(new RecordIntervalAnalyzer());
                tankRecordInternalAnalyzers.Add(new RecordIntervalAnalyzer());
                foreach (Supply supply in entry)
                {
                    addSupply(driverRecordInternalAnalyzers[cycle], driverAnalyzer, supply, supply.getDriverId().ToString(), cycle);
                    addSupply(truckRecordInternalAnalyzers[cycle], truckAnalyzer, supply, supply.getTruckId().ToString(), cycle);
                    addSupply(terminalRecordInternalAnalyzers[cycle], terminalAnalyzer, supply, supply.getTerminalId().ToString(), cycle);
                    addSupply(stationRecordInternalAnalyzers[cycle], stationAnalyzer, supply, supply.getStationId().ToString(), cycle);
                    addSupply(tankRecordInternalAnalyzers[cycle], tankAnalyzer, supply, supply.getStationId().ToString() + "_" + supply.getTankId().ToString(), cycle);
                }
                cycle++;
            }
            analyzeLists();

        }


        private void addSupply(RecordIntervalAnalyzer analyzer, List<RecordAnalyzer> list, Supply supply, string id, int cycle)
        {

            bool isAdded = false;
            if (list.Count == 0)
            {
                list.Add(new RecordAnalyzer(id, supply));
            }
            else
            {
                foreach (RecordAnalyzer entry in list) if (entry.getId().Equals(id))
                    {
                        entry.addSupply(supply);
                        isAdded = true;
                        break;
                    }
                if (isAdded == false)
                {
                    list.Add(new RecordAnalyzer(id, supply));
                }
            }
            isAdded = false;

            if (analyzer.getRecordsIntervalAnalysis().Count == 0)
            {
                analyzer.addRecordAnalyzer(new RecordAnalyzer(id, supply));
            }
            else
            {
                foreach (RecordAnalyzer entry in analyzer.getRecordsIntervalAnalysis()) if (entry.getId().Equals(id))
                    {
                        analyzer.addSupply(id, supply);
                        isAdded = true;
                        break;
                    }
                if (isAdded == false)
                {
                    analyzer.addRecordAnalyzer(new RecordAnalyzer(id, supply));
                }
            }

        }
        public RecordAnalyzerManager(List<Supply> suppliesList)
        {
            this.suppliesList = suppliesList;
            this.dateManager = new DateManager();
        }
    }
}
