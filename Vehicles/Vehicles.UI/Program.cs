using LinkedLists.Logic;
using Vehicles.Logic;

var car = new YourLinkedList<Car>();
car.Add(new Car("Kia", "Picanto", 2003, "Rojo", 60M));
car.Add(new Car("Mazda", "CX-5", 1882, "Rojo", 20M));
car.Add(new Car("Renault", "Logan", 1994, "Rojo", 75M));
car.Add(new Car("Chevrolet", "Malibu", 1994, "Azul", 120M));
car.Add(new Car("Chevrolet", "Malibu", 1994, "Azul", 13M));
car.Add(new Car("Mazda", "CX-5", 2003, "Azul", 21M));
car.Add(new Car("Renault", "Logan", 1882, "Amarillo", 66M));
car.Add(new Car("Kia", "Picanto", 2011, "Amarillo", 110M));
car.Add(new Car("Kia", "Picanto", 2011, "Amarillo", 137M));
car.Add(new Car("Chevrolet", "Malibu", 2011, "Verde", 240M)); ;
car.Add(new Car("Renault", "Logan", 2003, "Verde", 230M));
car.Add(new Car("Mazda", "CX-5", 1882, "Verde", 121M));

Console.WriteLine("***************** GetBrand *****************");
Console.WriteLine(car.GetBrand("Kia"));

Console.WriteLine("***************** GetCarsByYear *****************");
Console.WriteLine(car.GetYear(1900, 2000));

Console.WriteLine("***************** GetPrice *****************");
Console.WriteLine(car.GetPrice(60M, 120M));

Console.WriteLine("***************** GetSeveralFilters *****************");
Console.WriteLine(car.GetSeveralFilters("*", "*", "*", 2010, 2020));

Console.WriteLine("***************** GetMinMax *****************");
var mixMax = car.GetMinMax(car);
Console.WriteLine("\n********* Car with MIX price *********");
Console.WriteLine(mixMax[0]);
Console.WriteLine("\n********* Car with MAX price *********");
Console.WriteLine(mixMax[1]);
