using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace edX.DataApp.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");                       
        }

        static async Task RunAsync()
        {
            using (ContosoContext context = new ContosoContext())
            {
                var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                await creator.ExistsAsync();
                Console.WriteLine("Connection Successful");
            }
        }
    }
}