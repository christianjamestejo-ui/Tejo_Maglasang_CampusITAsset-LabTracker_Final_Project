using System;
using System.Linq;
using System.Globalization;
using MT_Campus_IT_Asset___Lab_Tracker.Models;
namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
	public class WorkstationUI
	{
		public WorkstationUI()
		{
            static void Main(string[] args)
            {
                bool run = true;
                while (run)
                {
                    List<CampusAsset> assets = new List<CampusAsset>();
                    Console.WriteLine("++++++++++++++++++++++++++++++\n" +
                                      "|		  WORKSTATION       |\n" +
                                      "==============================\n");
                    Console.WriteLine("Enter Asset's ID");
                    string iD = Console.ReadLine();
                    Console.WriteLine("Enter Asset's Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Asset's ID");
                    double.TryParse(Console.ReadLine(), out double purchase);
                    Console.WriteLine("Enter Asset's ID");
                    double.TryParse(Console.ReadLine(), out double residual);
                    Console.WriteLine("Enter Asset's Service Life");
                    double.TryParse(Console.ReadLine(), out double life);
                    Console.WriteLine("Enter Asset's OS");
                    string os = Console.ReadLine();
                    Console.WriteLine("Enter Asset Warranty(yyyy-MM-dd)");
                    DateTime parsedDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string warranty = parsedDate.ToString("yyyy", CultureInfo.InvariantCulture);
                    //if (purchase > 0)
                    //{
                    //    double residual = purchase - (Workstation * life) - ;
                    //}
                    Workstation asset = new Workstation(iD, name, purchase, residual, life, os, warranty);

                    assets.Add(asset);

                    if (assets != null)
                    {
                        Console.WriteLine("Succesfully Added Data...");
                    }
                }
            }
        }
	}
}

