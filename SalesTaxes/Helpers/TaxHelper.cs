using Newtonsoft.Json;
using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SalesTaxes.Helpers
{
    class TaxHelper
    {

        public Config GetConfigFile()
        {
            try
            {
                //Read the Config File
                using (StreamReader r = new StreamReader("./Config.json"))
                {
                    //Deserilalize json to Config Object and return the object 
                    return JsonConvert.DeserializeObject<Config>(r.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was issue reading the Config File /r" + ex.Message);
                return null;
            }
        }

        public List<Items> GetTestData()
        {
            try
            {
                //Get the Test Data 
                using (StreamReader r = new StreamReader("./TestData/TestData.json"))
                {
                    //Deserilalize json to Items Object and return the object 
                    return JsonConvert.DeserializeObject<List<Items>>(r.ReadToEnd());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was issue reading the Data and Converting to an Object /r" + ex.Message);
                return null;
            }
        }

        public List<string> GetTaxExemptationList()
        {
            //Get the Tax Expection List
            return new List<string>(new string[] { "Food", "Book", "Medical" });
        }

        public decimal GetProductTax(Item product)
        {
            var config = GetConfigFile();
            var Tax = 0.0m;
            //Check if the product is Exempted from Tax
            if (GetTaxExemptationList().Contains(product.Type) == false)
            {
                //Calc Tax of 10% and rounded up to nearest 0.05
                Tax += Math.Ceiling((config.TaxRate * product.Price) * 20) / 20;
            }
            //Check if the product is imported
            if (product.Imported == true)
            {
                //Calc Imported Tax of 5% and rounded up to nearest 0.05
                Tax += Math.Ceiling((config.ImportDutyRate * product.Price) * 20) / 20;
            }
            //Return Tax;
            return Tax;
        }
    }       
}
