using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FuelSupply
{
    class ConfigManager
    {

        private static String csvFilePath;

        private Double detectedVarMaxTolerance;
        private Double detectedVarNetMaxTolerance;
        private Double detectedAndHeightMaxDiff;
        private Double detectedAndHeightNetMaxDiff;
        private String outputFilePath;
        private Double extremePercent;

        private int dayInterval;
        private int smallValueSample;

        public void readConfigFile(String path)
        {
            using (XmlReader reader = XmlReader.Create(path))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "config":
                                break;
                            case "csvFilePath":
                                if (reader.Read())
                                {
                                    csvFilePath = reader.Value.Trim();
                                }
                                break;
                            case "extremePercent":
                                if (reader.Read())
                                {
                                    extremePercent = Double.Parse(reader.Value.Trim());
                                }
                                break;
                            case "detectedSupplyTolerance":
                                if (reader.Read())
                                {
                                    detectedVarMaxTolerance = Double.Parse(reader.Value.Trim());
                                }
                                break;
                            case "detectedSupplyNetTolerance":
                                if (reader.Read())
                                {
                                    detectedVarNetMaxTolerance = Double.Parse(reader.Value.Trim());
                                }
                                break;
                            case "detectedHeightMaxDiff":
                                if (reader.Read())
                                {
                                    detectedAndHeightMaxDiff = Double.Parse(reader.Value.Trim());
                                }
                                break;
                            case "detectedNetHeightMaxDiff":
                                if (reader.Read())
                                {
                                    detectedAndHeightNetMaxDiff = Double.Parse(reader.Value.Trim());
                                }
                                break;
                            case "outputFilePath":
                                if (reader.Read())
                                {
                                    outputFilePath = reader.Value.Trim();
                                }
                                break;
                            case "dayInterval":
                                if (reader.Read())
                                {
                                    dayInterval = int.Parse(reader.Value.Trim());
                                }
                                break;
                            case "smallValueSample":
                                if (reader.Read())
                                {
                                    smallValueSample = int.Parse(reader.Value.Trim());
                                }
                                break;
                        }
                    }
                }
            }
        }
        public int getSmallValueSample()
        {
            return smallValueSample;
        }
        public string getcsvFilePath()
        {
            return csvFilePath;
        }
        public Double getDetectedVarMaxTolerance()
        {
            return detectedVarMaxTolerance;
        }

        public Double getDetectedVarNetMaxTolerance()
        {
            return detectedVarNetMaxTolerance;
        }

        public Double getDetectedAndHeightMaxDiff()
        {
            return detectedAndHeightMaxDiff;
        }

        public Double getDetectedAndHeightNetMaxDiff()
        {
            return detectedAndHeightNetMaxDiff;
        }

        public String getOutputFilePath()
        {
            return outputFilePath;
        }

        public Double getExtremePercent()
        {
            return extremePercent;
        }

        public int getDayInterval()
        {
            return dayInterval;
        }


    }
}
