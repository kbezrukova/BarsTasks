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
            foreach (var item in dict)
            {
                Console.Write($"Key= {item.Key}"+ " Value=List");
                foreach (var val in item.Value)
                {
                    Console.Write("{ Entity{ Id =" + val.Id +"}}");
                }
                Console.WriteLine();
            }
        }
        public static Dictionary<int, List<Entity>> Method(List<Entity> list)
            {
            Dictionary<int, List<Entity>> dictionary = list.GroupBy(p => p.ParentId).ToDictionary(p => p.Key, p => p.Select(k => new Entity()
            {
                Id = k.Id,
                Name = k.Name
            }).ToList());
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
