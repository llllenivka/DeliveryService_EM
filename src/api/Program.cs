using DeliveryService;
var builder = WebApplication.CreateBuilder();
var app = builder.Build();
 
app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    
    if (context.Request.Path == "/postuser")
    {
        var form = context.Request.Form;
        string district = form["district"];
        string date = form["date"];
        string time = form["time"];

        var inputData = new string [] {district, date, time, "log.txt" , "orders.txt"};

        var dataForFilter = new DataForFilter();
        bool inputSucces = true;

        try {
            dataForFilter = ParsOrders.GetInputUser(inputData);
        } catch (Exception error) {
            inputSucces = false;
            Console.WriteLine("Error: " + error.Message);
        }

        if(inputSucces) {
            try {
                DeliveryLogger.NewLog(dataForFilter.DeliveryLog, "The program is running.");
                string[] ordersString = NewOrders.GetOrders();
                List <OrderType> orders = ParsOrders.Parser(ordersString);
                DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"{orders.Count} orders have been successfully read.");
                List<OrderType> filter = FilterOrders.Filter(orders, dataForFilter);
                FileEntry.Output(filter, dataForFilter);
                DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"The orders were successfully filtered out.");
                DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"Program successfully completed");
            } catch(Exception error) {
                DeliveryLogger.NewLog(dataForFilter.DeliveryLog, $"The program terminated with an error: {error.Message}");
            }
        }

        var resultOrders = File.ReadAllLines("orders.txt");
        var logs = File.ReadAllLines("log.txt");
        await context.Response.WriteAsync($"<div><h2>Filter orders :{'\n'}</h2></div>");
        foreach(var order in resultOrders){
            await context.Response.WriteAsync($"<div><p>{order}{'\n'}</p></div>");
        }
        
        await context.Response.WriteAsync($"<div><h2>Log :{'\n'}</h2></div>");
        foreach(var log in logs){
            await context.Response.WriteAsync($"<div><p>{log}{'\n'}</p></div>");
        }
        
    }
    else
    {
        await context.Response.SendFileAsync("index.html");
    }
});
 
app.Run();