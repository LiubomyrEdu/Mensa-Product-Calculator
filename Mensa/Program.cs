using Mensa;
Console.OutputEncoding = System.Text.Encoding.UTF8;


List<Product> store = new List<Product>();
while(true)
{
    Console.WriteLine("1-Add new Product \n2-Exit");
    if (!int.TryParse(Console.ReadLine(), out int choice))
    {
        Console.WriteLine("Fehler 1.1: Ungültige Eingabe! Bitte geben Sie eine Zahl ein");
        continue;
    }
    
    if (choice == 1)
    {
        Console.Write("Name: ");
        string nameInput = Console.ReadLine() ?? "";

        Console.Write("Price: ");
        if (!double.TryParse(Console.ReadLine(), out double priceInput)) 
        {
            Console.WriteLine("Fehler 1.2: Ungültiger Preis"); continue;
        }


        Product newProduct = new Product();
        newProduct.Name = nameInput;
        newProduct.Price = priceInput;

        store.Add(newProduct);
        Console.WriteLine($"New Product: {nameInput} - {priceInput} CHF");
    }
    else if (choice == 2)
    {
        break;
    }
    else
    {
        Console.WriteLine("Fehler 2.1: Bitte wählen Sie 1 oder 2");
    }
}

while (true)
{
    Console.Clear();
    double total = 0;
    double discount = 0;

    Console.WriteLine("┌──────────────────────────┬────────────┐");

    for (int i = 0; i < store.Count; i++)
    {
        int indexNumber = i + 1;
        double roundedPrice = Math.Round(store[i].Price, 2);
        string namePart = store[i].Name.Length > 20 ? store[i].Name.Substring(0, 20) : store[i].Name;
        Console.WriteLine($"│ {indexNumber,2}. {namePart,-20} │ {roundedPrice,6:0.00} CHF │");

        if (i < store.Count - 1)
        {
            Console.WriteLine("├──────────────────────────┼────────────┤");
        }
    }
    Console.WriteLine("└──────────────────────────┴────────────┘");
    Console.Write("Wählen Sie eine Produktnummer: ");

    if (!int.TryParse(Console.ReadLine(), out int productChoice))
    {
        Console.WriteLine("Fehler 1.3: Ungültige Eingabe! Bitte geben Sie eine Zahl ein");
        Console.ReadLine();
        continue;
    }

    if (productChoice < 1 || productChoice > store.Count)
    {
        Console.WriteLine("Fehler 3.1: Produkt nicht gefunden"); Console.ReadLine();
        continue;
    }    

    Console.WriteLine("Menge: ");
    if (!int.TryParse(Console.ReadLine(), out int quantity)) 
    {
        Console.WriteLine("Fehler 1.4: Die Menge muss eine Zahl sein"); Console.ReadLine(); continue;
    }


    if (quantity <= 0)
    {
        Console.WriteLine("Fehler 4.1: Ungültige Menge"); Console.ReadLine();
        continue;
    }
    else if (quantity == 3 || quantity == 4)
    {
        discount = 1 - 10 / 100.0;
    }
    else if (quantity >= 5)
    {
        discount = 1 - 20 / 100.0;
    }
    else
    {
        discount = 1;
    }

    total = quantity * store[productChoice - 1].Price;
    double finalWithDiscount = total * discount;

    string rawName = store[productChoice - 1].Name;
    string nameRow = rawName.Length > 20 ? rawName.Substring(0, 20) : rawName;

    string priceRow = $"{total:0.00} CHF";
    string discRow = $"{Math.Round((1 - discount) * 100.0)}%";
    string totalRow = $"{finalWithDiscount:0.00} CHF";

    Console.Clear();

    Console.WriteLine("╔══════════════════════════════════════════╗");
    Console.WriteLine($"║ ◦ Produkt:     {nameRow,-25} ║");
    Console.WriteLine($"║ ◦ Preis:       {priceRow,-25} ║");
    Console.WriteLine($"║ ◦ Rabatt:      {discRow,-25} ║");
    Console.WriteLine("╠══════════════════════════════════════════╣");
    Console.WriteLine($"║ ◦ Total Preis: {totalRow,-25} ║");
    Console.WriteLine("╚══════════════════════════════════════════╝");
    Console.WriteLine("\nDrücken Sie Enter, um fortzufahren..."); Console.ReadLine();
}
