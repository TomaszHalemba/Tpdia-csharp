using FuelSupply.Analyzers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply.Model
{
    class DataAnalyzer
    {

        public DataAnalyzer(List<Supply> supplies)
        {
            this.suppliesList = supplies;
            this.dataFilterManager = new DataFiltering();


        }
        private DataFiltering dataFilterManager;
        public List<Supply> suppliesList;

        RecordAnalyzerManager analysisManager;


        public void deleteExtremeValues(double percent)
        {
            dataFilterManager.deleteExtremeValues(suppliesList, percent);
        }

        public void calculateVars()
        {
            if (suppliesList == null || suppliesList.Count == 0)
            {
            }
            else
            {
                foreach (Supply supply in this.suppliesList)
                {
                    supply.calculateVarBasedOnDetected();
                    supply.calculateVarBasedOnDetectedNet();
                    supply.calculateVarBasedOnHeight();
                    supply.calculateVarBasedOnHeightNet();
                }

            }
        }

        private void setFlags(ConfigManager configManager)
        {
            foreach (Supply supply in this.suppliesList)
            {

                if (supply.getVarBasedOnDetected() > configManager.getDetectedVarMaxTolerance() &&
                       supply.getVarBasedOnDetectedNet() > configManager.getDetectedVarNetMaxTolerance())
                {
                    supply.setPossibleLeak(true);
                }
                else supply.setPossibleLeak(false);

                if (supply.getVarBasedOnDetected() < -1 * configManager.getDetectedVarMaxTolerance() &&
                        supply.getVarBasedOnDetectedNet() < -1 * configManager.getDetectedVarNetMaxTolerance())
                {
                    supply.setExcess(true);
                }
                else supply.setExcess(false);


                Double diff = Math.Abs(supply.getVarBasedOnHeight() - supply.getVarBasedOnDetected());
                Double diffNet = Math.Abs(supply.getVarBasedOnHeightNet() - supply.getVarBasedOnDetectedNet());

                if (diff > configManager.getDetectedAndHeightMaxDiff() && diffNet > configManager.getDetectedAndHeightNetMaxDiff())
                {
                    supply.setPossibleDetectorError(true);
                }
                else supply.setPossibleDetectorError(false);

            }
        }

        public void makeAnalysis(ConfigManager configManager)
        {

            setFlags(configManager);
            analysisManager = new RecordAnalyzerManager(this.suppliesList);

            analysisManager.createAnalysis(configManager.getDayInterval());
            analysisManager.deleteDataWithToSmallSample(configManager.getSmallValueSample());
            analysisManager.setArrays();

        }

        public List<RecordAnalyzer> getDriverAnalyzer()
        {
            return analysisManager.getDriverAnalyzer();
        }

        public List<RecordIntervalAnalyzer> getDriverInternalAnalyzer()
        {
            return analysisManager.getDriverInternalAnalyzer();
        }
        public List<RecordAnalyzer> getStationAnalyzer()
        {
            return analysisManager.getStationAnalyzer();
        }

        public List<RecordIntervalAnalyzer> getStationInternalAnalyzer()
        {
            return analysisManager.getStationInternalAnalyzer();
        }
        public List<RecordAnalyzer> getTruckAnalyzer()
        {
            return analysisManager.getTruckAnalyzer();
        }

        public List<RecordIntervalAnalyzer> getTruckInternalAnalyzer()
        {
            return analysisManager.getTruckInternalAnalyzer();
        }
        public List<RecordAnalyzer> getTankAnalyzer()
        {
            return analysisManager.getTankAnalyzer();
        }

        public List<RecordIntervalAnalyzer> getTankInternalAnalyzer()
        {
            return analysisManager.getTankInternalAnalyzer();
        }
        public List<RecordAnalyzer> getTerminalAnalyzer()
        {
            return analysisManager.getTerminalAnalyzer();
        }

        public List<RecordIntervalAnalyzer> getTerminalInternalAnalyzer()
        {
            return analysisManager.getTerminalInternalAnalyzer();
        }



    }
}
