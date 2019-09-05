using FuelSupply.Analyzers;
using System;
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
        /**
         * Obiekt wykonujÄ…cy operacje filtrowania
         */
        private DataFiltering dataFilterManager;

        /**
         * Lista danych, na ktĂłrych odbywa siÄ™ analiza
         */
        public List<Supply> suppliesList;

        public void deleteIncompleteRecords()
        {
            dataFilterManager.deleteIncompleteRecords(this.suppliesList);
        }
        public void deleteExtremeValues()
        {
            dataFilterManager.deleteExtremeValues(suppliesList,ConfigManager.ExtremePercent);
        }

        public void calculateVars()
        {
            if (suppliesList == null || suppliesList.Count==0)
            {
            }
            else
            {
                // iteracja po liĹ›cie i obliczanie varĂłw dla kaĹĽdego rekordu
                foreach (Supply supply in this.suppliesList)
                {
                    supply.calculateVarBasedOnDetected();
                    supply.calculateVarBasedOnDetectedNet();
                    supply.calculateVarBasedOnHeight();
                    supply.calculateVarBasedOnHeightNet();
                }

            }
        }


    }
}
