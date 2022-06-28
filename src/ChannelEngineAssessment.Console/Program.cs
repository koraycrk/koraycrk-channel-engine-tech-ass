// See https://aka.ms/new-console-template for more information
using AspnetRun.Application.Interfaces;
using ChannelEngineAssessment.Application.Services;
using ChannelEngineAssessment.Core.Interfaces;
using ChannelEngineAssessment.Core.Repositories;
using ChannelEngineAssessment.Core.Repositories.Base;
using ChannelEngineAssessment.Infrastructure.Logging;
using ChannelEngineAssessment.Infrastructure.Repository;
using ChannelEngineAssessment.Infrastructure.Repository.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Please wait until you see the product list...");

ServiceProvider serviceProvider = new ServiceCollection()
                                           
                                           .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                                           .AddScoped<IOrderRepository, OrderRepository>()
                                           .AddScoped<IOrderService, OrderService>()
                                           .BuildServiceProvider();

IOrderService _orderAppService = serviceProvider.GetService<IOrderService>();


var list = (await _orderAppService.GetProductByStatus("IN_PROGRESS")).ToList();
Console.WriteLine("Hello, Please select which product you want to set it's stock level to 25!");
int counter = 1;
foreach (var item in list)
{
    Console.WriteLine(String.Format("{4} - MerchantProductNo : {0}, Name : {1}, TotalQuantity : {2}, GTIN : {3}", item.MerchantProductNo, item.Name, item.TotalQuantity, item.GTIN, counter));
    counter++;
}

bool invalidChoice = true;
while (invalidChoice)
{
    int choice = 0;
    string ageInput = Console.ReadLine();
    if (int.TryParse(ageInput, out choice))
    {
        if (choice < 1 || choice > list.Count())
        {
            Console.WriteLine("Please select valid item: ");
        }
        else
        {
            invalidChoice = false;
            var result = await _orderAppService.UpdateStockOfProduct(25, list[choice - 1].StockLocationId, list[choice - 1].MerchantProductNo);
            if (result)
            {
                Console.WriteLine("Stock updated successfully. Please enter any key to exit");
                string input = Console.ReadLine();
                Environment.Exit(0);
            }
        }

    }
}
