using System;
using System.Collections.Generic;
using System.Linq;
namespace repository
{
    class Repository<T>
    {
        private ICollection<T>items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }
        public void Remove(T item)
        { 
            items.Remove(item);
        }
        public List<T> GetAll()
        {
            return new List<T>(items);
        }
        public T Find(Func<T, bool> predicate)
        {
            return items.FirstOrDefault(predicate);
        }
        public int Count() {
            return items.Count;
        }
    }
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price) { 
        Name = name;
        Price = price;
        }
        public override string ToString()
        {
            return $"Product: {Name}, Price: {Price}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<int> repositoryInt = new Repository<int>();
            repositoryInt.Add(1);
            repositoryInt.Add(20);
            repositoryInt.Add(3);
            repositoryInt.Remove(40);
            Console.WriteLine("Repository<int> items:");
            foreach (var item in repositoryInt.GetAll()) { 
                Console.WriteLine(item);
            }
            

            Repository<string> repositoryString = new Repository<string>();
            repositoryString.Add("hello");
            repositoryString.Add("world");
            repositoryString.Add("bye");
            repositoryString.Remove("hello");
            Console.WriteLine("Repository<string> items:");
            foreach (var item in repositoryString.GetAll())
            {
                Console.WriteLine(item);
            }

            Repository<Product> repositoryProduct = new Repository<Product>();
            repositoryProduct.Add(new Product("Apple", 10));
            repositoryProduct.Add(new Product("Banana", 5));
            repositoryProduct.Add(new Product("Juice", 60));
            Console.WriteLine("Repository<Product> items:");
            foreach (var product in repositoryProduct.GetAll())
            {
                Console.WriteLine(product);
            }

            Product newproduct = repositoryProduct.Find(p => p.Price > 50);
            Console.WriteLine($"Expensive product: {newproduct}");
        }
    }
}
