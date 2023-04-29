using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Logic
{
    public class Car
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public string? Color { get; set; }
        public decimal Price { get; set; }

        public Car(string brand, string model, int year, string color, decimal price)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
        }

        public Car()
        {
        }

        public override string ToString()
        {
            return $"***Car***:\n - Brand: {Brand}\n - Model: {Model}\n - Year: {Year}\n - Color: {Color}\n - Price: {Price:C0}\n";
        }
    }
}
