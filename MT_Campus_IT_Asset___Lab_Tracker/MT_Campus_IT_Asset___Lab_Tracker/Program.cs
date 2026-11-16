using System;
using System.Text.Json;
using MT_Campus_IT_Asset___Lab_Tracker.Interfaces;
using MT_Campus_IT_Asset___Lab_Tracker.Functions;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace CampusAssetTracker;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "Data/assets.json";

        JsonAssetRepository repository =
            new JsonAssetRepository(filePath);

        ValidInput validator = new ValidInput();

        AssetService assetService =
            new AssetService(repository, validator);

        BorrowingService borrowingService =
            new BorrowingService(repository);

        MaintenanceService maintenanceService =
            new MaintenanceService(repository);

        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine(
                                "|++++++++++++++++++++++++++++++++++++\n" +
                                "|      CAMPUS IT ASSET TRACKER      |\n" +
                                "|===================================|\n" +
                                "|1. Register Workstation            |\n" +
                                "|2. Register Networking Hardware    |\n" +
                                "|3. Register Peripheral             |\n" +
                                "|4. Register Software License       |\n" +
                                "|5. Display All Assets              |\n" +
                                "|6. Search Asset                    |\n" +
                                "|7. Borrow Asset                    |\n" +
                                "|8. Return Asset                    |\n" +
                                "|9. Schedule Maintenance            |\n" +
                                "|10. Display Asset Values           |\n" +
                                "|11. Delete Asset                   |\n" +
                                "|0. Exit                            |\n" +
                                "|===================================|\n" +
                                "\nChoose option: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                PauseInput pauseInput = new PauseInput();
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        RegisterWorkstation(assetService);
                        break;

                    case "2":
                        Console.Clear();
                        RegisterNetworkingHardware(assetService);
                        break;

                    case "3":
                        Console.Clear();
                        RegisterPeripheral(assetService);
                        break;

                    case "4":
                        Console.Clear();
                        RegisterSoftwareLicense(assetService);
                        break;

                    case "5":
                        Console.Clear();
                        DisplayAssets(assetService);
                        pauseInput.Pause();
                        break;

                    case "6":
                        Console.Clear();
                        SearchAsset(assetService);
                        pauseInput.Pause();
                        break;

                    case "7":
                        Console.Clear();
                        BorrowAsset(borrowingService);
                        break;

                    case "8":
                        Console.Clear();
                        ReturnAsset(borrowingService);
                        break;

                    case "9":
                        Console.Clear();
                        DisplayMaintenance(maintenanceService);
                        pauseInput.Pause();
                        break;

                    case "10":
                        Console.Clear();
                        DisplayAssetValues(assetService);
                        pauseInput.Pause();
                        break;

                    case "11":
                        Console.Clear();
                        DeleteAsset(assetService);
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Thank you for using the program...");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        repository.Save();

        Console.WriteLine("Application closed.");
    }

    private static void RegisterWorkstation(
        AssetService service)
    {
        Console.Write("Asset ID: ");
        string id = ReadRequired();

        Console.Write("Asset Tag: ");
        string tag = ReadRequired();

        Console.Write("Asset Name: ");
        string name = ReadRequired();

        Console.Write("Purchase Price: ");
        double price = double.Parse(ReadRequired());

        Console.Write("Salvage Value: ");
        double salvage = double.Parse(ReadRequired());

        Console.Write("Operating System: ");
        string os = ReadRequired();

        Workstation workstation = new Workstation(
            id, name, tag,
            price, salvage,
            DateTime.Today, os
        );

        service.RegisterAsset(workstation);

        Console.WriteLine("Workstation registered.");
    }

    private static void RegisterNetworkingHardware(
        AssetService service)
    {
        Console.Write("Asset ID: ");
        string id = ReadRequired();

        Console.Write("Asset Tag: ");
        string tag = ReadRequired();

        Console.Write("Asset Name: ");
        string name = ReadRequired();

        Console.Write("Purchase Price: ");
        double price = double.Parse(ReadRequired());

        Console.Write("Salvage Value: ");
        double salvage = double.Parse(ReadRequired());

        Console.Write("Device Type: ");
        string deviceType = ReadRequired();

        Console.Write("Input IP: ");
        string iP = ReadRequired();

        Console.Write("Input MAC: ");
        string mac = ReadRequired();

        NetworkingHardware network = new NetworkingHardware(
            id, tag, name,
            price, salvage, DateTime.Today,
            deviceType, iP, mac
        );

        service.RegisterAsset(network);

        Console.WriteLine("Networking hardware registered.");
    }

    private static void RegisterPeripheral(
        AssetService service)
    {
        Console.Write("Asset ID: ");
        string id = ReadRequired();

        Console.Write("Asset Tag: ");
        string tag = ReadRequired();

        Console.Write("Asset Name: ");
        string name = ReadRequired();

        Console.Write("Purchase Price: ");
        double price = double.Parse(ReadRequired());

        Console.Write("Salvage Value: ");
        double salvage = double.Parse(ReadRequired());

        Console.Write("Peripheral Type: ");
        string type = ReadRequired();

        Console.Write("Connection Type: ");
        string connection = ReadRequired();

        Console.Write("Manufacturer: ");
        string compatibility = ReadRequired();

        Peripheral peripheral = new Peripheral(
            id, name, tag,
            price, salvage, DateTime.Today,
            type, connection, compatibility
        );

        service.RegisterAsset(peripheral);

        Console.WriteLine("Peripheral registered.");
    }

    private static void RegisterSoftwareLicense(
        AssetService service)
    {
        Console.Write("Asset ID: ");
        string id = ReadRequired();

        Console.Write("Asset Tag: ");
        string tag = ReadRequired();

        Console.Write("Asset Name: ");
        string name = ReadRequired();

        Console.Write("Purchase Price: ");
        double price = double.Parse(ReadRequired());

        Console.Write("Salvage Value: ");
        double salvage = double.Parse(ReadRequired());

        Console.Write("License Key: ");
        string key = ReadRequired();

        Console.Write("License Type: ");
        string type = ReadRequired();

        Console.Write("License Provider: ");
        string provider = ReadRequired();

        Console.Write("License Start Date (yyyy-MM-dd): ");
        DateTime start = DateTime.Parse(ReadRequired());

        Console.Write("License Expiry Date (yyyy-MM-dd): ");
        DateTime expiry = DateTime.Parse(ReadRequired());

        SoftwareLicense license = new SoftwareLicense(
            id, name, tag,
            price, salvage, DateTime.Today,
            key, type, provider,
            start, expiry
        );

        service.RegisterAsset(license);

        Console.WriteLine("Software license registered.");
    }

    private static void DisplayAssets(AssetService service)
    {
        List<CampusAsset> assets = service.GetAllAssets();

        if (assets.Count == 0)
        {
            Console.WriteLine("No assets registered.");
            return;
        }

        foreach (CampusAsset asset in assets)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine(asset);
            Console.WriteLine($"ID: {asset.AssetId}");
            Console.WriteLine($"Type: {asset.GetType().Name}");
            Console.WriteLine($"Purchase Price: {asset.PurchasePrice:F2}");
            Console.WriteLine($"Current Value: {asset.CalculateCurrentValue():F2}");
            Console.WriteLine($"Depreciation: {asset.CalculateDepreciation():F2}\n");
        }
    }

    private static void SearchAsset(AssetService service)
    {
        Console.Write("Enter Asset ID: ");

        string id = ReadRequired();

        CampusAsset? asset = service.FindAsset(id);

        if (asset == null)
        {
            Console.WriteLine("Asset not found.");
            return;
        }

        Console.WriteLine(asset);
        Console.WriteLine($"Asset Type: {asset.GetType().Name}");
        Console.WriteLine($"Current Value: {asset.CalculateCurrentValue():F2}");
    }

    private static void BorrowAsset(BorrowingService service)
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        Console.Write("Borrower ID: ");
        string borrowerId = ReadRequired();

        bool result = service.CheckOutAsset(assetId, borrowerId);

        Console.WriteLine(
            result ? "Asset checked out." : "Checkout failed."
        );
    }

    private static void ReturnAsset(BorrowingService service)
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        bool result = service.ReturnAsset(assetId);

        Console.WriteLine(
            result ? "Asset returned." : "Return failed."
        );
    }

    private static void DisplayMaintenance(
        MaintenanceService service)
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        Console.Write("Technician ID: ");
        string technicianId = ReadRequired();

        Console.Write("Maintenance Date (yyyy-MM-dd): ");

        DateTime date = DateTime.Parse(ReadRequired());

        bool result = service.ScheduleMaintenance(
            assetId,
            technicianId,
            date
        );

        //Console.WriteLine(
          //  result ? "Maintenance scheduled." : "Scheduling failed."
        //);
    }

    private static void DisplayAssetValues(AssetService service)
    {
        foreach (CampusAsset asset in service.GetAllAssets())
        {
            Console.WriteLine(
                $"{asset.AssetName}: " +
                $"Purchase {asset.PurchasePrice:F2} | " +
                $"Depreciation {asset.CalculateDepreciation():F2} | " +
                $"Current Value {asset.CalculateCurrentValue():F2}"
            );
        }
    }

    private static void DeleteAsset(AssetService service)
    {
        Console.Write("Enter Asset ID: ");

        string id = ReadRequired();

        bool result = service.DeleteAsset(id);

        Console.WriteLine(
            result ? "Asset deleted." : "Asset not found."
        );
    }

    private static string ReadRequired()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty.");

        return input.Trim();
    }
}