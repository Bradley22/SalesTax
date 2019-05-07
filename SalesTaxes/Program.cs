using SalesTaxes.Helpers;
using SalesTaxes.Models;
using System;
using System.Collections.Generic;

namespace SalesTaxes
{
    class Program
    {
        //Consturor for the taxhelper class
        static TaxHelper taxhelper = new TaxHelper();
        static void Main(string[] args)
        {
            try
            {
                //Get the Test Data
                List<Items> Items = taxhelper.GetTestData();
                //Loop thought the Test Data
                foreach (Items item in Items)
                {
                    //Sets the TotalTax and TotalPricewithTax
                    decimal TotalTax = 0;
                    decimal TotalPricewithTax = 0;
                    //Loop though all the Products
                    foreach (Item product in item.Item)
                    {
                        //Call the Calulate Tax Method to the products Tax
                        var Tax = taxhelper.GetProductTax(product);
                        //Add the tax to the price
                        var PriceWithTax = (product.Price + Tax) * product.Qty;
                        //Sum the total Tax
                        TotalTax += Tax;
                        //Sum all products new prices
                        TotalPricewithTax += PriceWithTax;

                        
                        //Print out the Product
                        Console.WriteLine(product.Qty + ((product.Imported == true) ? " Imported " : " ") + product.Name + ": " + PriceWithTax);
                    }
                    //Prints out the total Tax
                    Console.WriteLine("Sales Taxes: " + TotalTax.ToString("F"));
                    //Prints out the Total
                    Console.WriteLine("Total: " + TotalPricewithTax.ToString("F"));
                    Console.WriteLine("======================================");
                }
                //Prevents the console from closing
                Console.ReadLine();
            }
            //Catch if there are any errors
            catch(Exception ex)
            {
                Console.WriteLine("There was an Error :" + ex.Message);
            }
        }
    }
}
