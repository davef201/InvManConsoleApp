using InvManConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace InvManConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            InvManSettingsConfig iMSSettingsConfig = new InvManSettingsConfig();
            configuration.GetSection("IMSSettings").Bind(iMSSettingsConfig);

            string importFileLocation = iMSSettingsConfig.ImportFileLocation;
//            string errorFileLocation = ConfigurationManager.AppSettings["ErrorFileLocation"];

            if (importFileLocation != "")
            {
                string[] currentInventoryFiles = Directory.GetFiles(iMSSettingsConfig.ImportFileLocation);
                foreach (string fileName in currentInventoryFiles)
                {
                    List<Item> items = GetItemsFromFile(fileName);
                    items.ForEach(i => i.UpdateName());
                    items.ForEach(i => i.UpdateSellIn());
                    items.ForEach(i => i.UpdateQuality());
                    WriteItemsToFile(iMSSettingsConfig.ExportFileLocation, fileName, items);
                    MoveToProcessed(fileName, iMSSettingsConfig.ProcessedFileLocation);
                }
            }
        }

        private static List<Item> GetItemsFromFile(string fileName)
        {
            List<Item> items = new List<Item>();

            string[] fileLines = File.ReadAllLines(fileName);
            foreach(string line in fileLines)
            {
                string[] temp = line.Split(' ');
                string itemName = "";
                int sellIn;
                int quality;

                if (temp.Length > 3)
                {
                    itemName = GetItemName(temp[0], temp[1]);
                    sellIn = int.Parse(temp[2]);
                    quality = int.Parse(temp[3]);
                } else
                {
                    itemName = GetItemName(temp[0]);
                    sellIn = int.Parse(temp[1]);
                    quality = int.Parse(temp[2]);
                }
                switch (itemName)
                {
                    case "Fresh Item": 
                        Item freshItem = new FreshItem { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(freshItem);
                        break;
                    case "Frozen Item": 
                        Item frozenItem = new FrozenItem { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(frozenItem);
                        break;
                    case "Christmas Crackers":
                        Item christmasCrackers = new ChristmasCrackers { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(christmasCrackers);
                        break;
                    case "Soap":
                        Item soap = new Soap { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(soap);
                        break;
                    case "Aged Brie":
                        Item agedBrie = new AgedBrie { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(agedBrie);
                        break;
                    case "INVALID ITEM":
                        Item invalidItem = new InvalidItem { Name = itemName, SellIn = sellIn, Quality = quality };
                        items.Add(invalidItem);
                        break;
                }

            }
            return items;
        }

        private static string GetItemName(string firstPart, string secondPart = "")
        {
            if (secondPart != "")
            {
                return firstPart + " " + secondPart.Trim();
            } else
            {
                return firstPart;
            }
        }

        private static void WriteItemsToFile(string exportFileLocation, string fileName, List<Item> items)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            string exportFileName = exportFileLocation + "\\" + fileInfo.Name;

            try
            {
                using (TextWriter textWriter = new StreamWriter(exportFileName))
                {
                    items.ForEach(i => textWriter.WriteLine(string.Format("{0} {1} {2}", i.Name, i.SellIn, i.Quality)));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MoveToProcessed(string fileName, string processedFileLocation)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                string processedFileName = processedFileLocation + "\\" + fileInfo.Name;
                File.Move(fileName, processedFileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
