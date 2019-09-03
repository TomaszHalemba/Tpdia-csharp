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
        public void execute()
        {
            ConfigManager.readConfigFile("config.xml");
            List<Supply> supplies = fileManager.getSuppliesFromCsv(ConfigManager.CsvFilePath);
            Console.Write(supplies);
            Console.ReadLine();
        }
    }
}
