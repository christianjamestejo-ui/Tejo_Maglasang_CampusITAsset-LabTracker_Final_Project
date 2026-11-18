
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MT_Campus_IT_Asset___Lab_TrackerConsole.API;
using MT_Campus_IT_Asset___Lab_Tracker.Models;

namespace MT_Campus_IT_Asset___Lab_TrackerConsole.Menus;

public class AssetMenu
{
    private readonly AssetApiClient _api;

    public AssetMenu(AssetApiClient api)
    {
        _api = api;
    }

    // ==========================================
    // MAIN MENU
    // ==========================================

    public async Task Run()
    {
        bool run = true;

        while (run)
        {
            Console.Clear();

            Console.WriteLine(
                "|++++++++++++++++++++++++++++++++++++\n" +
                "|      CAMPUS IT ASSET TRACKER       |\n" +
                "|====================================|\n" +
                "|1. Register Workstation             |\n" +
                "|2. Register Networking Hardware     |\n" +
                "|3. Register Peripheral              |\n" +
                "|4. Register Software License        |\n" +
                "|5. Display All Assets               |\n" +
                "|6. Search Asset                     |\n" +
                "|7. Borrow Asset                     |\n" +
                "|8. Return Asset                     |\n" +
                "|9. Schedule Maintenance             |\n" +
                "|10. Display Asset Values            |\n" +
                "|11. Delete Asset                    |\n" +
                "|0. Exit                             |\n" +
                "|====================================|\n" +
                "\nChoose option: "
            );

            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        await RegisterWorkstation();
                        Pause();
                        break;

                    case "2":
                        Console.Clear();
                        await RegisterNetworkingHardware();
                        Pause();
                        break;

                    case "3":
                        Console.Clear();
                        await RegisterPeripheral();
                        Pause();
                        break;

                    case "4":
                        Console.Clear();
                        await RegisterSoftwareLicense();
                        Pause();
                        break;

                    case "5":
                        Console.Clear();
                        await DisplayAssets();
                        Pause();
                        break;

                    case "6":
                        Console.Clear();
                        await SearchAsset();
                        Pause();
                        break;

                    case "7":
                        Console.Clear();
                        await BorrowAsset();
                        Pause();
                        break;

                    case "8":
                        Console.Clear();
                        await ReturnAsset();
                        Pause();
                        break;

                    case "9":
                        Console.Clear();
                        await DisplayMaintenance();
                        Pause();
                        break;

                    case "10":
                        Console.Clear();
                        await DisplayAssetValues();
                        Pause();
                        break;

                    case "11":
                        Console.Clear();
                        await DeleteAsset();
                        Pause();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine(
                            "Thank you for using the program..."
                        );
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection.");
                        Pause();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Pause();
            }
        }

        Console.WriteLine("Application closed.");
    }

    // ==========================================
    // 1. REGISTER WORKSTATION
    // ==========================================

    private async Task RegisterWorkstation()
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

        int life = ReadPositiveInt("Useful Life (Months): ");

        Console.Write("Operating System: ");
        string os = ReadRequired();

        Console.Write("IP Address: ");
        string ip = ReadRequired();

        Console.Write("MAC Address: ");
        string mac = ReadRequired();

        Workstation workstation = new Workstation(
            id,
            name,
            tag,
            price,
            salvage,
            life,
            DateTime.Today,
            os,
            ip,
            mac
        );

        bool result = await _api.RegisterAsset(workstation);

        Console.WriteLine(
            result
                ? "Workstation registered successfully!"
                : "Workstation registration failed."
        );
    }

    // ==========================================
    // 2. REGISTER NETWORKING HARDWARE
    // ==========================================

    private async Task RegisterNetworkingHardware()
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

        int life = ReadPositiveInt("Useful Life (Months): ");

        Console.Write("Device Type: ");
        string deviceType = ReadRequired();

        Console.Write("Input IP: ");
        string ip = ReadRequired();

        Console.Write("Input MAC: ");
        string mac = ReadRequired();

        NetworkingHardware network = new NetworkingHardware(
            id,
            tag,
            name,
            price,
            salvage,
            life,
            DateTime.Today,
            deviceType,
            ip,
            mac
        );

        bool result = await _api.RegisterAsset(network);

        Console.WriteLine(
            result
                ? "Networking hardware registered successfully!"
                : "Networking hardware registration failed."
        );
    }

    // ==========================================
    // 3. REGISTER PERIPHERAL
    // ==========================================

    private async Task RegisterPeripheral()
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

        int life = ReadPositiveInt("Useful Life (Months): ");

        Console.Write("Peripheral Type: ");
        string type = ReadRequired();

        Console.Write("Connection Type: ");
        string connection = ReadRequired();

        Console.Write("Manufacturer: ");
        string compatibility = ReadRequired();

        Peripheral peripheral = new Peripheral(
            id,
            name,
            tag,
            price,
            salvage,
            life,
            DateTime.Today,
            type,
            connection,
            compatibility
        );

        await _api.RegisterAsset(peripheral);

        Console.WriteLine("Peripheral registered.");
    }

    // ==========================================
    // 4. REGISTER SOFTWARE LICENSE
    // ==========================================

    private async Task RegisterSoftwareLicense()
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

        int life = ReadPositiveInt("Useful Life (Months): ");

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
            id,
            name,
            tag,
            price,
            salvage,
            life,
            DateTime.Today,
            key,
            type,
            provider,
            start,
            expiry
        );

        await _api.RegisterAsset(license);

        Console.WriteLine("Software license registered.");
    }

    // ==========================================
    // 5. DISPLAY ALL ASSETS
    // ==========================================

    private async Task DisplayAssets()
    {
        List<CampusAsset> assets = await _api.GetAllAssets();

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
            Console.WriteLine(
                $"Purchase Price: {asset.PurchasePrice:F2}"
            );
            Console.WriteLine(
                $"Current Value: {asset.CalculateCurrentValue():F2}"
            );
            Console.WriteLine(
                $"Depreciation: {asset.CalculateDepreciation():F2}"
            );
        }
    }

    // ==========================================
    // 6. SEARCH ASSET
    // ==========================================

    private async Task SearchAsset()
    {
        Console.Write("Enter Asset ID: ");

        string id = ReadRequired();

        CampusAsset? asset = await _api.GetAsset(id);

        if (asset == null)
        {
            Console.WriteLine("Asset not found.");
            return;
        }

        Console.WriteLine(asset);
        Console.WriteLine($"Asset Type: {asset.GetType().Name}");
        Console.WriteLine(
            $"Current Value: {asset.CalculateCurrentValue():F2}"
        );
    }

    // ==========================================
    // 7. BORROW ASSET
    // ==========================================

    private async Task BorrowAsset()
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        Console.Write("Borrower ID: ");
        string borrowerId = ReadRequired();

        //bool result = await _api.BorrowAsset(
        //    assetId,
        //    borrowerId
        //);

        //Console.WriteLine(
        //    result ? "Asset checked out." : "Checkout failed."
        //);
    }

    // ==========================================
    // 8. RETURN ASSET
    // ==========================================

    private async Task ReturnAsset()
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        //bool result = await _api.ReturnAsset(assetId);

        //Console.WriteLine(
        //    result ? "Asset returned." : "Return failed."
        //);
    }

    // ==========================================
    // 9. SCHEDULE MAINTENANCE
    // ==========================================

    private async Task DisplayMaintenance()
    {
        Console.Write("Asset ID: ");
        string assetId = ReadRequired();

        Console.Write("Technician ID: ");
        string technicianId = ReadRequired();

        Console.Write("Maintenance Date (yyyy-MM-dd): ");
        DateTime date = DateTime.Parse(ReadRequired());

        //bool result = await _api.ScheduleMaintenance(
        //    assetId,
        //    technicianId,
        //    date
        //);

        //Console.WriteLine(
        //    result
        //        ? "Maintenance scheduled."
        //        : "Maintenance scheduling failed."
        //);
    }

    // ==========================================
    // 10. DISPLAY ASSET VALUES
    // ==========================================

    private async Task DisplayAssetValues()
    {
        List<CampusAsset> assets = await _api.GetAllAssets();

        if (assets.Count == 0)
        {
            Console.WriteLine("No assets registered.");
            return;
        }

        foreach (CampusAsset asset in assets)
        {
            Console.WriteLine(
                $"{asset.AssetName}: " +
                $"Purchase {asset.PurchasePrice:F2} | " +
                $"Depreciation {asset.CalculateDepreciation():F2} | " +
                $"Current Value {asset.CalculateCurrentValue():F2}"
            );
        }
    }

    // ==========================================
    // 11. DELETE ASSET
    // ==========================================

    private async Task DeleteAsset()
    {
        Console.Write("Enter Asset ID: ");

        string id = ReadRequired();

        bool result = await _api.DeleteAsset(id);

        Console.WriteLine(
            result ? "Asset deleted." : "Asset not found."
        );
    }

    // ==========================================
    // INPUT AND PAUSE HELPERS
    // ==========================================

    private static string ReadRequired()
    {
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException(
                "Input cannot be empty."
            );
        }

        return input.Trim();
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press ENTER to continue...");
        Console.ReadLine();
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine(
                "Invalid input! Please enter a positive whole number."
            );
        }
    }
}


