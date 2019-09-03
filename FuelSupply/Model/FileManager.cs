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

        public List<Supply> getSuppliesFromCsv(String path)
        {
            List<Supply> list = new List<Supply>();

            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    int suppliesCounter = 0;
            int counter = 0;
            Boolean firstLine = true;
               

                    String tmp;
                    do
                    {
                        Supply newSupply = new Supply(suppliesCounter);
                        string[] lines = sr.ReadLine().Split(';');


                    if (!firstLine)
                    {

                        newSupply.setStationId(Int32.Parse(lines[0]));



                        newSupply.setTankId(lines[1][0]-48);


                        try
                        {
                            newSupply.setFuelType(lines[2]);
                        }
                        catch (Exception e)
                        {

                        }

                        try
                        {
                            newSupply.setTankCapacity(Int32.Parse(lines[3]));
                        }
                        catch (Exception e)
                        {

                        }

                        //DateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy HH:mm");

                        DateTime startTime;
                        try
                        {
                            startTime = DateTime.Parse(lines[4]);
                            newSupply.setStartTime(startTime);
                        }
                        catch (Exception e)
                        {
                            Console.Write("Unparseable using " + e);
                        }

                        try
                        {
                            startTime = DateTime.Parse(lines[5]);
                            newSupply.setEndTime(startTime);
                        }
                        catch (Exception e)
                        {
                            Console.Write("Unparseable using " + e);
                        }


                        try
                        {
                            newSupply.setTruckId(Int32.Parse(lines[6]));
                        }
                        catch (Exception e)
                        {
                        }


                        try
                        {
                            newSupply.setDriverId(Int32.Parse(lines[7]));
                        }
                        catch (Exception e)
                        {
                        }

                        try
                        {
                            newSupply.setTerminalId(Int32.Parse(lines[8]));
                        }
                        catch (Exception e)
                        {

                        }

                        try
                        {
                            newSupply.setDetectedSupplyCapacity(Int32.Parse(lines[9]));
                        }
                        catch (Exception e)
                        {
                        }

                        try
                        {
                            newSupply.setDetectedSupplyCapacityNet(Int32.Parse(lines[10]));
                        }
                        catch (Exception e)
                        {

                        }

                        try
                        {
                            newSupply.setDeclaredSupplyCapacity(Int32.Parse(lines[11]));
                        }
                        catch (Exception e)
                        {

                        }

                        try
                        {
                            newSupply.setDeclaredSupplyCapacityNet(Int32.Parse(lines[12]));
                        }
                        catch (Exception e)
                        {
                        }

                        try
                        {
                            newSupply.setTankStartHeight(Int32.Parse(lines[13]));
                        }
                        catch (Exception e)
                        {

                        }

                        try
                        {
                            newSupply.setTankEndHeight(Int32.Parse(lines[14]));
                        }
                        catch (Exception e)
                        {

                        }



                    }

 



                        if (!firstLine)
                        {
                            list.Add(newSupply);
                            newSupply = new Supply(suppliesCounter);

                        }
                        else
                        {
                            firstLine = false;
                        }
                        suppliesCounter++;
                    
                    } while (sr.Peek() != -1);
                }
                                      
                // after loop, close scanner


            }
            catch (FileNotFoundException e)
            {

               
            }
            return list;
        }

        //public List getStringDataFromCsv(String path)
        //{
        //    List list = new List();
        //    // -File class needed to turn stringName to actual file
        //    File file = new File(path);

        //    try
        //    {
        //        // -read from filePooped with Scanner class
        //        Scanner inputStream = new Scanner(file);
        //        inputStream.useDelimiter(";");
        //        // hashNext() loops line-by-line
        //        while (inputStream.hasNext())
        //        {
        //            // read single line, put in string
        //            String data = inputStream.next();
        //            list.add(data);

        //        }
        //        // after loop, close scanner
        //        inputStream.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {

        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    return list;
        //}



        //public static String formating(Object string, int length)
        //{
        //    return String.format("%1$" + length + "s", string);
        //}

        //public void printRecordsIntervalAnalyzerTank(List<RecordsIntervalAnalyzerTank> list, String path)
        //{

        //    for (RecordsIntervalAnalyzerTank column : list)
        //    {
        //        String name = column.getFolderName();


        //        File dir = new File(path);
        //        dir.mkdir();

        //        PrintWriter writer;
        //        try
        //        {
        //            writer = new PrintWriter(path + "\\" + name + ".txt", "UTF-8");

        //            writer.println("stacja | zbiornik | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |");

        //            for (TankAnalyzer entry:column.getRecordsIntervalAnalysis())
        //            {
        //                writer.print(formating(entry.getStationId() + "|", 8));
        //                writer.print(formating(entry.getTankId() + "|", 11));
        //                writer.print(formating(entry.getErrorCount() + "|", 18));
        //                writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //                writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //                writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //                writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //                writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //                writer.print(formating(entry.getExcessCount() + "|", 10));
        //                writer.print(formating(entry.getExcessPercentage() + "|", 20));

        //                writer.println();

        //            }
        //            writer.close();

        //        }
        //        catch (FileNotFoundException e)
        //        {

        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //        catch (UnsupportedEncodingException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //    }
        //}

        //public void printRecordsIntervalAnalyzerDriver(List<RecordsIntervalAnalyzerDriver> list, String path)
        //{

        //    for (RecordsIntervalAnalyzerDriver column : list)
        //    {
        //        String name = column.getFolderName();


        //        File dir = new File(path);
        //        dir.mkdir();

        //        PrintWriter writer;
        //        try
        //        {
        //            writer = new PrintWriter(path + "\\" + name + ".txt", "UTF-8");

        //            writer.println("kierowca | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |");

        //            for (DriverAnalyzer entry:column.getRecordsIntervalAnalysis())
        //            {
        //                writer.print(formating(entry.getDriverId() + "|", 10));
        //                writer.print(formating(entry.getErrorCount() + "|", 18));
        //                writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //                writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //                writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //                writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //                writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //                writer.print(formating(entry.getExcessCount() + "|", 10));
        //                writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //                writer.println();

        //            }
        //            writer.close();

        //        }
        //        catch (FileNotFoundException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //        catch (UnsupportedEncodingException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //    }
        //}


        //public void printRecordsIntervalAnalyzerTerminal(List<RecordsIntervalAnalyzerTerminal> list, String path)
        //{

        //    for (RecordsIntervalAnalyzerTerminal column : list)
        //    {
        //        String name = column.getFolderName();


        //        File dir = new File(path);
        //        dir.mkdir();

        //        PrintWriter writer;
        //        try
        //        {
        //            writer = new PrintWriter(path + "\\" + name + ".txt", "UTF-8");

        //            writer.println("terminal | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |");

        //            for (TerminalAnalyzer entry:column.getRecordsIntervalAnalysis())
        //            {
        //                writer.print(formating(entry.getTerminalId() + "|", 10));
        //                writer.print(formating(entry.getErrorCount() + "|", 18));
        //                writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //                writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //                writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //                writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //                writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //                writer.print(formating(entry.getExcessCount() + "|", 10));
        //                writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //                writer.println();

        //            }
        //            writer.close();

        //        }
        //        catch (FileNotFoundException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //        catch (UnsupportedEncodingException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //    }
        //}

        //public void printRecordsIntervalAnalyzerTruck(List<RecordsIntervalAnalyzerTruck> list, String path)
        //{

        //    for (RecordsIntervalAnalyzerTruck column : list)
        //    {
        //        String name = column.getFolderName();


        //        File dir = new File(path);
        //        dir.mkdir();

        //        PrintWriter writer;
        //        try
        //        {
        //            writer = new PrintWriter(path + "\\" + name + ".txt", "UTF-8");

        //            writer.println("cysterna | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |");

        //            for (TruckAnalyzer entry:column.getRecordsIntervalAnalysis())
        //            {
        //                writer.print(formating(entry.getTruckId() + "|", 10));
        //                writer.print(formating(entry.getErrorCount() + "|", 18));
        //                writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //                writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //                writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //                writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //                writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //                writer.print(formating(entry.getExcessCount() + "|", 10));
        //                writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //                writer.println();

        //            }
        //            writer.close();

        //        }
        //        catch (FileNotFoundException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //        catch (UnsupportedEncodingException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //    }
        //}

        //public void printRecordsIntervalAnalyzerStation(List<RecordsIntervalAnalyzerStation> list, String path)
        //{

        //    for (RecordsIntervalAnalyzerStation column : list)
        //    {
        //        String name = column.getFolderName();


        //        File dir = new File(path);
        //        dir.mkdir();

        //        PrintWriter writer;
        //        try
        //        {
        //            writer = new PrintWriter(path + "\\" + name + ".txt", "UTF-8");

        //            writer.println("stacja | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |");

        //            for (StationAnalyzer entry:column.getRecordsIntervalAnalysis())
        //            {
        //                writer.print(formating(entry.getStationId() + "|", 8));
        //                writer.print(formating(entry.getErrorCount() + "|", 18));
        //                writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //                writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //                writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //                writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //                writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //                writer.print(formating(entry.getExcessCount() + "|", 10));
        //                writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //                writer.println();


        //            }
        //            writer.close();

        //        }
        //        catch (FileNotFoundException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //        catch (UnsupportedEncodingException e)
        //        {
        //            // TODO Auto-generated catch block
        //            e.printStackTrace();
        //            new java.util.Scanner(System.in).nextLine();
        //            System.exit(-1);
        //        }
        //    }
        //}



        //public void printTankTop(List<TankAnalyzer> list, String path)
        //{
        //    PrintWriter writer;
        //    try
        //    {
        //        writer = new PrintWriter(path, "UTF-8");
        //        writer.println("Najbardziej niezgodne obiekty:");
        //        writer.println("stacja | zbiornik | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |   InterwaĹ‚y czasu   |");

        //        for (TankAnalyzer entry:list)
        //        {
        //            writer.print(formating(entry.getStationId() + "|", 8));
        //            writer.print(formating(entry.getTankId() + "|", 11));
        //            writer.print(formating(entry.getErrorCount() + "|", 18));
        //            writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //            writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //            writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //            writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //            writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //            writer.print(formating(entry.getExcessCount() + "|", 10));
        //            writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //            writer.print(formating(entry.getMinMaxDate() + "|", 22));
        //            writer.println();
        //        }

        //        writer.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    catch (UnsupportedEncodingException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //}

        //public void printDriverTop(List<DriverAnalyzer> list, String path)
        //{
        //    PrintWriter writer;
        //    try
        //    {
        //        writer = new PrintWriter(path, "UTF-8");
        //        writer.println("Najbardziej niezgodne obiekty:");
        //        writer.println("kierowca | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |   InterwaĹ‚y czasu   |");

        //        for (DriverAnalyzer entry:list)
        //        {
        //            writer.print(formating(entry.getDriverId() + "|", 10));
        //            writer.print(formating(entry.getErrorCount() + "|", 18));
        //            writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //            writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //            writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //            writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //            writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //            writer.print(formating(entry.getExcessCount() + "|", 10));
        //            writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //            writer.print(formating(entry.getMinMaxDate() + "|", 22));
        //            writer.println();

        //        }

        //        writer.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    catch (UnsupportedEncodingException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }

        //}

        //public void printStationTop(List<StationAnalyzer> list, String path)
        //{
        //    PrintWriter writer;
        //    try
        //    {
        //        writer = new PrintWriter(path, "UTF-8");
        //        writer.println("Najbardziej niezgodne obiekty:");

        //        writer.println("stacja | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |   InterwaĹ‚y czasu   |");

        //        for (StationAnalyzer entry:list)
        //        {
        //            writer.print(formating(entry.getStationId() + "|", 8));
        //            writer.print(formating(entry.getErrorCount() + "|", 18));
        //            writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //            writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //            writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //            writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //            writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //            writer.print(formating(entry.getExcessCount() + "|", 10));
        //            writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //            writer.print(formating(entry.getMinMaxDate() + "|", 22));
        //            writer.println();


        //        }

        //        writer.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    catch (UnsupportedEncodingException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //}

        //public void printTerminalTop(List<TerminalAnalyzer> list, String path)
        //{
        //    PrintWriter writer;
        //    try
        //    {
        //        writer = new PrintWriter(path, "UTF-8");
        //        writer.println("Najbardziej niezgodne obiekty:");

        //        writer.println("terminal | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |   InterwaĹ‚y czasu   |");

        //        for (TerminalAnalyzer entry:list)
        //        {
        //            writer.print(formating(entry.getTerminalId() + "|", 10));
        //            writer.print(formating(entry.getErrorCount() + "|", 18));
        //            writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //            writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //            writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //            writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //            writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //            writer.print(formating(entry.getExcessCount() + "|", 10));
        //            writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //            writer.print(formating(entry.getMinMaxDate() + "|", 22));
        //            writer.println();

        //        }

        //        writer.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    catch (UnsupportedEncodingException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //}


        //public void printTruckTop(List<TruckAnalyzer> list, String path)
        //{
        //    PrintWriter writer;
        //    try
        //    {
        //        writer = new PrintWriter(path, "UTF-8");
        //        writer.println("Najbardziej niezgodne obiekty:");

        //        writer.println("cysterna | bĹ‚Ä™dĂłw ogĂłlnych |  procent bĹ‚Ä™dĂłw  | bĹ‚Ä™dy detektora |  procent bĹ‚Ä™dĂłw detektora  | wyciekĂłw |  procent wyciekĂłw  | nadmiar | procent nadmiarĂłw |   InterwaĹ‚y czasu   |");

        //        for (TruckAnalyzer entry:list)
        //        {
        //            writer.print(formating(entry.getTruckId() + "|", 10));
        //            writer.print(formating(entry.getErrorCount() + "|", 18));
        //            writer.print(formating(entry.getErrorPercentage() + "|", 19));
        //            writer.print(formating(entry.getProbDetectorErrorCount() + "|", 18));
        //            writer.print(formating(entry.getProbDetectorErrorPercentage() + "|", 29));
        //            writer.print(formating(entry.getProbLeakCount() + "|", 11));
        //            writer.print(formating(entry.getPropLeakPercentage() + "|", 21));
        //            writer.print(formating(entry.getExcessCount() + "|", 10));
        //            writer.print(formating(entry.getExcessPercentage() + "|", 20));
        //            writer.print(formating(entry.getMinMaxDate() + "|", 22));
        //            writer.println();

        //        }

        //        writer.close();

        //    }
        //    catch (FileNotFoundException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //    catch (UnsupportedEncodingException e)
        //    {
        //        // TODO Auto-generated catch block
        //        e.printStackTrace();
        //        new java.util.Scanner(System.in).nextLine();
        //        System.exit(-1);
        //    }
        //}
    }
}
