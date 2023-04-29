using System.Collections.Generic;
using System.Text.Json.Nodes;
using Vehicles.Logic;

namespace LinkedLists.Logic
{
    public class YourLinkedList<T>
    {
        private DoubleNode<T>? _first;

        private DoubleNode<T>? _last;

        public YourLinkedList()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public override string ToString()
        {
            var output = string.Empty;
            var pointer = _first;
            while (pointer != null)
            {
                output += $" - {pointer.Data}\n";
                pointer = pointer.Next;
            }
            return output;
        }

        public void Add(T item)
        {
            var node = new DoubleNode<T>(item);
            if (IsEmpty)
            {
                _first = node;
                _last = node;    
            }
            else
            {
                node.Previous = _last;
                _last!.Next = node;
                _last = node;
            }
            Count++;
        }

        public Responce Delete(T item)
        {
            var pointer = _first;
            var delete = new Responce();
            if (IsEmpty)
            {
                return delete;
            }
            else
            {
                if (pointer.Data.Equals(item) && Count == 1)
                {
                    _first = null;
                    pointer = null;
                    delete.IsSucced = true;
                    Count--;
                    return delete;
                }
                else if (pointer.Data.Equals(item))
                {
                    _first = pointer.Next;
                    pointer.Next.Previous = null;
                    pointer = null;
                    delete.IsSucced = true;
                    Count--;
                    return delete;
                }
                else
                {
                    while (pointer.Next.Next != null)
                    {
                        pointer = pointer.Next;
                        if (pointer.Data.Equals(item))
                        {
                            pointer.Previous.Next= pointer.Next;
                            pointer.Next.Previous= pointer.Previous;
                            pointer = null;
                            delete.IsSucced = true;
                            Count--;
                            return delete;
                        }
                    }
                    if (pointer.Next.Data.Equals(item))
                    {
                        pointer = pointer.Next;
                        pointer.Previous.Next= null;
                        _last = pointer.Previous;
                        pointer = null;
                        delete.IsSucced = true;
                        Count--;
                        return delete;
                    }
                    else
                    {
                        return delete;
                    }
                }
            }
        }

        public Responce Insert(T item, int position)
        {
            var insert = new Responce();
            if (IsEmpty && position != 0)
            {
                return insert;
            }
            else if (IsEmpty && position == 0)
            {
                insert.IsSucced = true;
                Add(item);
                return insert;
            }
            else if (Count <= position)
            {
                return insert;
            }
            else
            {
                var nodo = new DoubleNode<T>(item);
                var pointer = _first;
                if (position == 0)
                {
                    nodo.Next = pointer;
                    pointer.Previous = nodo;
                    _first = nodo;
                    insert.IsSucced = true;
                    Count++;
                    return insert;
                }
                for (int i = 1; i < Count; i++)
                {
                    pointer = pointer.Next;
                    if (position == i)
                    {
                        nodo.Next = pointer;
                        nodo.Previous = pointer.Previous;
                        pointer.Previous.Next = nodo;
                        pointer.Previous = nodo;
                        insert.IsSucced = true;
                        Count++;
                        return insert;
                    }
                }
            }
            return insert;
        }

        public YourLinkedList<Car> GetBrand(string brand)
        {
            var newList = new YourLinkedList<Car>();
            var pointer = _first;
            while (pointer != null)
            {
                Car car = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
                if (car.Brand.Equals(brand))
                {
                    newList.Add(car);
                }
                pointer = pointer.Next;
            }
            return newList;
        }

        public YourLinkedList<Car> GetYear(int lower, int upper)
        {
            var newList = new YourLinkedList<Car>();   
            var pointer = _first;
            while (pointer != null)
            {
                Car car = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
                if (car.Year > lower && car.Year <= upper)
                {
                    newList.Add(car);  
                }
                pointer = pointer.Next;
            }
            return newList;
        }

        public YourLinkedList<Car> GetPrice(decimal lower, decimal upper)
        {
            var newList = new YourLinkedList<Car>();
            var pointer = _first;
            while (pointer != null)
            {
                Car car = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
                if (car.Price > lower && car.Price <= upper)
                {
                    newList.Add(car);
                }
                pointer = pointer.Next;
            }
            return newList;
        }

        public YourLinkedList<Car> GetSeveralFilters(string brand, string model, string color, int minimunYear, int maximunYear)
        {
            var newList = new YourLinkedList<Car>();
            var pointer = _first;
            while (pointer != null)
            {
                Car car = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
                if (brand.Equals("*"))
                {
                    if (model.Equals("*"))
                    {
                        if (color.Equals("*"))
                        {
                            if (car.Year >= minimunYear && car.Year <= maximunYear)
                            {
                                newList.Add(car);
                            }
                        }
                        else
                        {
                            if (car.Color.Equals(color) && (car.Year >= minimunYear && car.Year <= maximunYear))
                            {
                                newList.Add(car);
                            }
                        }
                    }
                    else
                    {
                        if (color.Equals("*"))
                        {
                            if (car.Model.Equals(model) && (car.Year >= minimunYear && car.Year <= maximunYear))
                            {
                                newList.Add(car);
                            }
                        }
                        else
                        {
                            if (car.Model.Equals(model) && car.Color.Equals(color) && (car.Year >= minimunYear && car.Year <= maximunYear))
                            {
                                newList.Add(car);
                            }
                        }
                    }
                }
                else if (model.Equals("*"))
                {
                    if (color.Equals("*"))
                    {
                        if (car.Brand.Equals(brand) && (car.Year >= minimunYear && car.Year <= maximunYear))
                        {
                            newList.Add(car);
                        }
                    }
                    else
                    {
                        if (car.Brand.Equals(brand) && car.Color.Equals(color) && (car.Year >= minimunYear && car.Year <= maximunYear))
                        {
                            newList.Add(car);
                        }
                    }
                }
                else if (color.Equals("*"))
                {
                    if (car.Brand.Equals(brand) && car.Model.Equals(model) && (car.Year >= minimunYear && car.Year <= maximunYear))
                    {
                        newList.Add(car);
                    }
                }
                else
                {
                    if (car.Brand.Equals(brand) && car.Model.Equals(model) && car.Color.Equals(color) && (car.Year >= minimunYear && car.Year <= maximunYear))
                    {
                        newList.Add(car);
                    }
                }
                pointer = pointer.Next;
            }
            return newList;
        }

        public Car[] GetMinMax(YourLinkedList<Car> list)
        {
            var mixMax = new Car[2];
            var pointer = _first;
            Car mix = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
            Car max = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
            pointer = pointer.Next;
            while (pointer != null)
            {
                Car car = (Car)Convert.ChangeType(pointer.Data, typeof(Car));
                if (car.Price > max.Price)
                {
                    max = car;
                }
                else if (car.Price < mix.Price)
                {
                    mix = car;
                }
                pointer = pointer.Next;
            }
            mixMax[0] = mix;
            mixMax[1] = max;
            return mixMax; 
        }
    }
}
