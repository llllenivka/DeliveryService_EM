namespace DeliveryService{


public class UnitTest
{
    [Fact]
    public void Test1()
    {
        string[] orders = NewOrders.GetOrders();
        Assert.Equal(200, 200);
    }

    [Fact]
    public void Test3()
    {
        string[] ordersstring = NewOrders.GetOrders();
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        Assert.Equal(200 , orders.Count);
    }

    [Fact]
    public void Test4()
    {
        string[] ordersstring = new string[] { };
        var exception = Assert.Throws<Exception>(() => ParsOrders.Parser(ordersstring));
        Assert.Equal("File is empty." , exception.Message);
    }


    [Fact]
    public void Test5()
    {
        string[] ordersstring = new string[] {"Incorrect Number Order|89.89|Arbat|2022-02-02 23:23:23" };
        var exception = Assert.Throws<Exception>(() => ParsOrders.Parser(ordersstring));
        Assert.Equal("Incorrect order number." , exception.Message);
    }

    [Fact]
    public void Test6()
    {
        string[] ordersstring = new string[] {"1|Incorrect Weight Order|Arbat|2022-02-02 23:23:23" };
        var exception = Assert.Throws<Exception>(() => ParsOrders.Parser(ordersstring));
        Assert.Equal("Incorrect order weight." , exception.Message);
    }

    [Fact]
    public void Test7()
    {
        string[] ordersstring = new string[] {"1|89.89|Arbat|Incorrect Date Order"};
        var exception = Assert.Throws<Exception>(() => ParsOrders.Parser(ordersstring));
        Assert.Equal("Incorrect order data." , exception.Message);
    }

    [Fact]
    public void Test8()
    {
        string[] ordersstring = NewOrders.GetOrders();
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        var data = new DataForFilter {
            CityDistrict = "Arbat",
            FirstDeliveryDateTime = DateTime.Parse("2024-10-26 11:10:00"),
            DeliveryLog = "exampleLog.txt",
            DeliveryOrder = "exampleOrder.txt"
        };
        List<OrderType> filterOrders = FilterOrders.Filter(orders, data);
        Assert.Equal(1, filterOrders.Count);
    }

    [Fact]
    public void Test9()
    {
        string[] ordersstring = NewOrders.GetOrders();
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        var data = new DataForFilter {
            CityDistrict = "Arbat",
            FirstDeliveryDateTime = DateTime.Parse("2024-11-26 11:10:00"),
            DeliveryLog = "exampleLog.txt",
            DeliveryOrder = "exampleOrder.txt"
        };
        var exception = Assert.Throws<Exception>(() => FilterOrders.Filter(orders, data));
        Assert.Equal("No such orders were found." , exception.Message);
    }

    [Fact]
    public void Test10()
    {
        string[] ordersstring = NewOrders.GetOrders();
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        var data = new DataForFilter {
            CityDistrict = "Incorrect",
            FirstDeliveryDateTime = DateTime.Parse("2024-11-26 11:10:00"),
            DeliveryLog = "exampleLog.txt",
            DeliveryOrder = "exampleOrder.txt"
        };
        var exception = Assert.Throws<Exception>(() => FilterOrders.Filter(orders, data));
        Assert.Equal("No such orders were found." , exception.Message);
    }

}

}

