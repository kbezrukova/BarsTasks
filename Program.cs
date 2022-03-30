//2 задание
using System;
using System.Collections.Generic;
using System.Linq;

namespace Барс2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Entity> list = new List<Entity>
                {
                    new Entity{Id=1, ParentId=0, Name="Root entity"},
                    new Entity { Id = 2, ParentId = 1, Name = "Child of 1 entity"},
                    new Entity { Id = 3, ParentId = 1, Name = "Child of 1 entity"},
                    new Entity { Id = 4, ParentId = 2, Name = "Child of 2 entity"},
                    new Entity { Id = 5, ParentId = 4, Name = "Child of 4 entity"}
                };
            Method(list);     
        }
        public static void Method(List<Entity> list)
            {               
                Dictionary<int, Entity> dictionary = list.ToDictionary(p =>p.ParentId);
                foreach (KeyValuePair<int, Entity> kvp in dictionary)
                {
                    Console.WriteLine(
                        "Key {0}: {1}, {2} pounds",
                        kvp.Key,
                        kvp.Value.Id);
                }
            }
    }
    class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        
    }
    

}
