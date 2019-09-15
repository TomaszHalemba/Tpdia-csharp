using FuelSupply.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelSupply
{
    class Controller
    {
        ConfigManager configManager = new ConfigManager();
        FileManager fileManager = new FileManager();
        DataAnalyzer dataAnalyzer;
        public void execute(string configPath)
        {
            Console.WriteLine("start reading config fille");
            configManager.readConfigFile(configPath);
            Console.WriteLine("ended reading config fille");
            Console.WriteLine("start reading data");
            List<Supply> supplies = fileManager.getSuppliesFromCsv(configManager.getcsvFilePath());
            Console.WriteLine("ended reading data");
            dataAnalyzer = new DataAnalyzer(supplies);
            Console.WriteLine("started calculating variables");
            dataAnalyzer.calculateVars();
            Console.WriteLine("ended calculating variables");
            Console.WriteLine("started deleting extreme values");
            dataAnalyzer.deleteExtremeValues(configManager.getExtremePercent());
            Console.WriteLine("ended deleting extreme values");
            Console.WriteLine("started analysys");
            dataAnalyzer.makeAnalysis(configManager);
            Console.WriteLine("ended analysys");
            Console.WriteLine("started printing data");
            String outputPath = configManager.getOutputFilePath();
            this.fileManager.printRecordsIntervalAnalyzer(dataAnalyzer.getDriverInternalAnalyzer(), outputPath + "Driver\\","driver");
            this.fileManager.printRecordsIntervalAnalyzer(dataAnalyzer.getStationInternalAnalyzer(), outputPath + "Station\\", "station");
            this.fileManager.printRecordsIntervalAnalyzerTank(dataAnalyzer.getTankInternalAnalyzer(), outputPath + "Tank\\");
            this.fileManager.printRecordsIntervalAnalyzer(dataAnalyzer.getTerminalInternalAnalyzer(), outputPath + "Terminal\\", "terminal");
            this.fileManager.printRecordsIntervalAnalyzer(dataAnalyzer.getTruckInternalAnalyzer(), outputPath + "Truck\\", "truck");

            this.fileManager.printAnalyzer(dataAnalyzer.getDriverAnalyzer(), outputPath+"driver.txt","driver");
            this.fileManager.printAnalyzer(dataAnalyzer.getStationAnalyzer(), outputPath + "station.txt", "station");
            this.fileManager.printTank(dataAnalyzer.getTankAnalyzer(), outputPath + "tank.txt");
            this.fileManager.printAnalyzer(dataAnalyzer.getTerminalAnalyzer(), outputPath + "terminal.txt", "terminal");
            this.fileManager.printAnalyzer(dataAnalyzer.getTruckAnalyzer(), outputPath + "truck.txt", "truck");
            Console.WriteLine("ended printing data");
            Console.ReadKey();
        }
    }
}
