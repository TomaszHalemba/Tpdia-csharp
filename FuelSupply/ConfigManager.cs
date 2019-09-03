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

        public static string CsvFilePath
        {
            get
            {
                return csvFilePath;
            }
            set
            {
                csvFilePath = value;
            }
        }                 //sciezka do pliku csv
        private static Double detectedVarMaxTolerance;      //maksymalna tolerancja dopuszczajÄ…ca brak wycieku dla varDetected
        private static Double detectedVarNetMaxTolerance;   //maksymalna tolerancja dopuszczajÄ…ca brak wycieku dla varDetectedNet
        private static Double detectedAndHeightMaxDiff;     //maksymalna dopusczalna roznica pomiedzy varem detected a height
        private static Double detectedAndHeightNetMaxDiff;  //maksymalna dopusczalna roznica pomiedzy varem detected a height (Net)
        private static String outputFilePath;               //scieĹĽka folderu do ktĂłrego majÄ… trafiaÄ‡ wyniki
        private static Double extremePercent;               //procent rekordĂłw usuwanych z ekstremalnymi pomiarami
        private static int dayInterval;                     //interwaĹ‚ dni




        // priwatny kontruktor, ĹĽeby nie daĹ‚o siÄ™ utworzyÄ‡ instancji klasy
  
        /**
         * Czytanie pliku konfiguracyjnego i zapisywanie wlasciwosci
         *
         * @param path
         */
        public static void readConfigFile(String path)
        {
            using (XmlReader reader = XmlReader.Create("config.xml"))
            {
                while (reader.Read())
                {
                    // Only detect start elements.
                    if (reader.IsStartElement())
                    {
                        // Get element name and switch on it.
                        switch (reader.Name)
                        {
                            case "config":
                                // Detect this article element.
                                Console.WriteLine("Start <article> element.");
                                break;
                            case "csvFilePath":
                                // Search for the attribute name on this current node.
                                string attribute = reader["name"];
                                if (attribute != null)
                                {
                                   
                                }
                                // Next read will contain text.
                                if (reader.Read())
                                {
                                    CsvFilePath = reader.Value.Trim();
                                }
                                break;
                        }
                    }
                }
            }

            //try
            //{
            //    try
            //    {
            //        File fXmlFile = new File(path);
            //        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
            //        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
            //        Document doc = dBuilder.parse(fXmlFile);
            //        doc.getDocumentElement().normalize();



            //        // pobieranie poszczegĂłlnych wartoĹ›ci z pliku configa
            //        csvFilePath = doc.getElementsByTagName("csvFilePath").item(0).getTextContent();
            //        detectedVarMaxTolerance = Double.parseDouble(doc.getElementsByTagName("detectedSupplyTolerance").item(0).getTextContent());
            //        detectedVarNetMaxTolerance = Double.parseDouble(doc.getElementsByTagName("detectedSupplyNetTolerance").item(0).getTextContent());
            //        detectedAndHeightMaxDiff = Double.parseDouble(doc.getElementsByTagName("detectedHeightMaxDiff").item(0).getTextContent());
            //        detectedAndHeightNetMaxDiff = Double.parseDouble(doc.getElementsByTagName("detectedNetHeightMaxDiff").item(0).getTextContent());
            //        outputFilePath = doc.getElementsByTagName("outputFilePath").item(0).getTextContent();
            //        extremePercent = Double.parseDouble(doc.getElementsByTagName("extremePercent").item(0).getTextContent());
            //        dayInterval = Integer.parseInt(doc.getElementsByTagName("dayInterval").item(0).getTextContent());
            //        if (extremePercent < 0 || extremePercent > 80.0) extremePercent = 5.0;//jak ktoĹ› wpisze za duĹĽÄ… wartoĹ›Ä‡
            //        if (dayInterval < 5 || dayInterval > 5000) dayInterval = 30;//jak ktoĹ› wpisze za duĹĽÄ… wartoĹ›Ä‡
            //        if (detectedVarMaxTolerance < 0) detectedVarMaxTolerance = 200.0;
            //        if (detectedVarNetMaxTolerance < 0) detectedVarNetMaxTolerance = 200.0;
            //        if (detectedAndHeightMaxDiff < 0) detectedAndHeightMaxDiff = 200.0;
            //        if (detectedAndHeightNetMaxDiff < 0) detectedAndHeightNetMaxDiff = 200.0;
            //        Path path1 = Paths.get(outputFilePath);

            //        if (!Files.exists(path1))
            //        {
            //            System.out.println("Miejsce pola wyjĹ›ciowego nie istnieje! Pliki bÄ™dÄ… utworzone w folderze projektu");
            //            outputFilePath = "";
            //        }

            //    }
            //    catch (IOException | NumberFormatException | ParserConfigurationException | DOMException | SAXException e) {
            //        outputFilePath = "";
            //        extremePercent = 5.0;
            //        dayInterval = 30;
            //        detectedVarMaxTolerance = 200.0;
            //        detectedVarNetMaxTolerance = 200.0;
            //        detectedAndHeightMaxDiff = 500.0;
            //        detectedAndHeightNetMaxDiff = 500.0;
            //        System.out.println("bĹ‚Ä…d wczytywania pliku konfiguracyjnego! ");
            //        e.printStackTrace();
            //        new java.util.Scanner(System.in).nextLine();
            //        System.exit(0);
            //    }
            //    }
            //    catch (Exception e)
            //    {
            //        outputFilePath = "";
            //        extremePercent = 5.0;
            //        dayInterval = 30;
            //        detectedVarMaxTolerance = 200.0;
            //        detectedVarNetMaxTolerance = 200.0;
            //        detectedAndHeightMaxDiff = 500.0;
            //        detectedAndHeightNetMaxDiff = 500.0;
            //        System.out.println("bĹ‚Ä…d wczytywania pliku konfiguracyjnego! ");
            //        new java.util.Scanner(System.in).nextLine();
            //        System.exit(0);

            //    }
            //}


           // - - -Gettery - - -
            //public static String getCsvFilePath()
            //{
            //    return CsvFilePath;
            //}

              Double getDetectedVarMaxTolerance()
            {
                return detectedVarMaxTolerance;
            }

            Double getDetectedVarNetMaxTolerance()
            {
                return detectedVarNetMaxTolerance;
            }

           Double getDetectedAndHeightMaxDiff()
            {
                return detectedAndHeightMaxDiff;
            }

           Double getDetectedAndHeightNetMaxDiff()
            {
                return detectedAndHeightNetMaxDiff;
            }

            String getOutputFilePath()
            {
                return outputFilePath;
            }

            Double getExtremePercent()
            {
                return extremePercent;
            }

           int getDayInterval()
            {
                return dayInterval;
            }
        }
    }
}
