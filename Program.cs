using System;
using System.Collections.Generic;

class Cosmetic
{
    public string Name { get; }
    public string Category { get; }
    public int Quantity { get; }
    public DateTime ExpirationDate { get; }

    public Cosmetic(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"{Name} ({Category}) - {Quantity} pcs, Expires: {ExpirationDate:yyyy-MM-dd}";
    }
}

class CosmoShelf
{
    private List<Cosmetic> cosmeticsList = new List<Cosmetic>();

    public void AddCosmetic(string name, string category, int quantity, DateTime expirationDate)
    {
        cosmeticsList.Add(new Cosmetic(name, category, quantity, expirationDate));
        Console.WriteLine("Cosmetic added successfully!");
    }

    public void RemoveCosmetic(string nameToRemove)
    {
        for (int i = 0; i < cosmeticsList.Count; i++)
        {
            if (cosmeticsList[i].Name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase))
            {
                cosmeticsList.RemoveAt(i);
                Console.WriteLine($"The cosmetic '{nameToRemove}' has been removed.");
                return;
            }
        }

        Console.WriteLine($"Cosmetic '{nameToRemove}' not found.");
    }

    public void DisplayCosmetics()
    {
        if (cosmeticsList.Count == 0)
        {
            Console.WriteLine("No cosmetics in the list.");
            return;
        }

        Console.WriteLine("\nList of Cosmetics:");
        foreach (var cosmetic in cosmeticsList)
        {
            Console.WriteLine(cosmetic);
        }
    }
}

class Program
{
    static void Main()
    {
        CosmoShelf shelf = new CosmoShelf();

        while (true)
        {
            Console.WriteLine("\nCosmoShelf - Cosmetic Organizer");
            Console.WriteLine("1. Add Cosmetic");
            Console.WriteLine("2. Remove Cosmetic");
            Console.WriteLine("3. Show All Cosmetics");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddCosmeticInteraction(shelf);
                    break;
                case "2":
                    RemoveCosmeticInteraction(shelf);
                    break;
                case "3":
                    shelf.DisplayCosmetics();
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void AddCosmeticInteraction(CosmoShelf shelf)
    {
        Console.Write("Enter the name of the cosmetic: ");
        string name = Console.ReadLine() ?? "Unknown";

        Console.Write("Enter the category of the cosmetic: ");
        string category = Console.ReadLine() ?? "Uncategorized";

        int quantity;
        Console.Write("Enter the quantity: ");
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for quantity.");
        }

        DateTime expirationDate;
        Console.Write("Enter the expiration date (yyyy-mm-dd): ");
        while (!DateTime.TryParse(Console.ReadLine(), out expirationDate))
        {
            Console.WriteLine("Invalid date format. Please enter the date in the format yyyy-mm-dd.");
        }

        shelf.AddCosmetic(name, category, quantity, expirationDate);
    }

    public static void RemoveCosmeticInteraction(CosmoShelf shelf)
    {
        Console.Write("Enter the name of the cosmetic to remove: ");
        string nameToRemove = Console.ReadLine() ?? "";

        shelf.RemoveCosmetic(nameToRemove);
    }
}
