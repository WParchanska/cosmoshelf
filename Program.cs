using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class  Cosmetic

{
public required string Name { get; set; }  // wymagamy przypisania wartosci; nazwa
public required string Category { get; set; } // kategoria 

public int Quantity {get; set;} // ilosc sztuk
public DateTime ExpirationDate { get; set; } // data waznosci 

}

public class CosmoShelf 
{
private List<Cosmetic> cosmeticsList = new List<Cosmetic>(); 


public void AddCosmetic( string name, string category, int quantity, DateTime expirationdate)
{
    Cosmetic newCosmetic = new Cosmetic
    {
        Name = name, 
        Category = category,
        Quantity = quantity,
        ExpirationDate = expirationdate
    };

    cosmeticsList.Add(newCosmetic);
    Console.WriteLine("Item added succesfully.");
}

public void DisplayCosmetics()

{
Console.WriteLine("All items in your cosmoshelf:");
foreach (var cosmetic in cosmeticsList)

{
    Console.WriteLine($"Name: {cosmetic.Name}, Category: {cosmetic.Category}, Quantity: {cosmetic.Quantity}, ExpirationDate: {cosmetic.ExpirationDate.ToShortDateString()}");
}

}

}

public class Program
{
      public static void Main(string[] args)

{

 CosmoShelf shelf = new CosmoShelf(); // instancja klasy cosmoshelf 

// Dodajemy kilka kosmetyków do naszego organizeru

        shelf.AddCosmetic("Krem nawilżający", "Pielęgnacja", 2, new DateTime(2025, 12, 31));
        shelf.AddCosmetic("Szminka", "Makijaż", 1, new DateTime(2024, 5, 1));
        shelf.AddCosmetic("Mleczko do demakijażu", "Pielęgnacja", 3, new DateTime(2026, 10, 15));

shelf.DisplayCosmetics();
    }
}

