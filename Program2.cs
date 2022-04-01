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
            var dict=Method(list);
            foreach (KeyValuePair<int, Entity> kvp in dict)
            {
                Console.WriteLine(kvp.Key + " Name : " + kvp.Value.Name + ", Id: " + kvp.Value.Id);
            }

        }
        public static Dictionary<int, Entity> Method(List<Entity> list)
            {               
                Dictionary<int, Entity> dictionary = list.ToDictionary(p =>p.ParentId);
                return dictionary;            
        }
        
    }
    class Entity
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        
    }
    

}
