using ConsoleApp.Core;
using ConsoleApp.Models;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Entity oldObj = new Entity
            {
                Id = Guid.NewGuid(),
                OId = DateTime.Now.ToString("yyyyMMddHHmmss"),
                A = "a1",
                B = 1.01,
                C = true
            };

            Entity newObj = new Entity
            {
                A = "a2",
                B = 1.012
            };

            var logs = oldObj.GetPropertyLogs(newObj);

            Console.ReadKey();
        }
    }
}