using Basics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace SimpleTasks
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello, World!");
            // Get all implementations of ILister and add them to the DI
            var listers = typeof(Program).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass && x.GetInterface(nameof(ILister)) == typeof(ILister));

            var host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   foreach (var lister in listers)
                     services.Add(new ServiceDescriptor(typeof(ILister), lister, ServiceLifetime.Transient));

                   services.AddTransient<ShowCase>();
               })
            .Build();

            var ShowCase = ActivatorUtilities.CreateInstance<ShowCase>(host.Services);
            ShowCase.Run();


        }
    }
}