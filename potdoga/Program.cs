using potdoga;
using System.Text.Json;

var path = "C:\\Users\\b1harbal\\source\\repos\\potdoga\\potdoga\\autoparts_orders.json";
var data = File.ReadAllText(path);
var json = JsonSerializer.Deserialize<Rootobject>(data);
var customers = json.customers;
var orders = json.orders;
var parts  = json.parts;
Console.WriteLine("\n1:a legtobbbet vasarlo: ");
var maxOsszeg=0;
var maxOsszegNeve = "";
foreach (var customer in customers) 
{
    var osszes = 0;
    foreach (var order  in orders)
    {
        if (order.customer_id == customer.customer_id)
        {
            osszes += order.total;
        }
    }
    if (osszes > maxOsszeg)
    {
        maxOsszeg = osszes;
        maxOsszegNeve = customer.name;
    }
}
Console.WriteLine(maxOsszegNeve + "-" + maxOsszeg);


Console.WriteLine("\n2:a termek, amibol a legtobb fogyott: ");
int maxTermek = 0;
var maxTermekNeve = "";
foreach(var part  in parts)
{
    var termekDb = 0;
    foreach(var order in orders)
    {
        foreach (var partDb in order.items)
        {
            if (partDb.part_id == part.part_id)
            {
                termekDb += partDb.quantity;
            }
        }
    }
    if(termekDb > maxTermek)
    {
        maxTermek = termekDb;
        maxTermekNeve=part.name;
    }
}
Console.WriteLine($"{maxTermek}-{maxTermekNeve}");

Console.WriteLine("\n3:fizetesi modok osszegzese: ");
var fizModok=orders.Select(d=>d.payment_method).Distinct().ToList();
int db=fizModok.Count;
foreach(var order in fizModok)
{
    var osszegzes = orders.Where(c => c.payment_method == order).ToList();
    var fizModOssz=osszegzes.Sum(r=>r.total);
Console.WriteLine($"{order}:{osszegzes.Count} db rendeles, {fizModOssz} Ft ertekben");
}

Console.WriteLine("\n4:szallitasi modok osszegzese: ");
var szallModok=orders.Select(o=>o.shipping_method).Distinct().ToList();
int szall=szallModok.Count;
foreach(var order in szallModok)
{
    var ossz2=orders.Where(p=>p.shipping_method == order).ToList();
    var szallModOssz=ossz2.Sum(r=>r.total);
    Console.WriteLine($"{order}:{ossz2.Count} db rendeles, {szallModOssz} Ft ertekben");
}