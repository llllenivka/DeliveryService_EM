namespace DeliveryService{


public class UnitTest
{
    [Fact]
    public void Test1()
    {
        string[] orders = NewOrders.GetOrders("../../../Example.txt");
        Assert.Equal(200, 200);
    }

    [Fact]
    public void Test2()
    {
        var exception = Assert.Throws<Exception>(() => NewOrders.GetOrders("errorFileName"));
        Assert.Equal("File does not exist.", exception.Message);
    }

    [Fact]
    public void Test3()
    {
        string[] ordersstring = NewOrders.GetOrders("../../../Example.txt");
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
        string[] ordersstring = NewOrders.GetOrders("../../../Example.txt");
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        string dateString = "2024-10-26 11:10:00";
        DateTime date = DateTime.Parse(dateString);
        List<OrderType> filterOrders = FilterOrders.Filter(orders, "Arbat", date);
        Assert.Equal(1, filterOrders.Count);
    }

    [Fact]
    public void Test9()
    {
        string[] ordersstring = NewOrders.GetOrders("../../../Example.txt");
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        string dateString = "2024-11-26 11:10:00";
        DateTime date = DateTime.Parse(dateString);
        var exception = Assert.Throws<Exception>(() => FilterOrders.Filter(orders, "Arbat", date));
        Assert.Equal("No such orders were found." , exception.Message);
    }

    [Fact]
    public void Test10()
    {
        string[] ordersstring = NewOrders.GetOrders("../../../Example.txt");
        List<OrderType> orders = ParsOrders.Parser(ordersstring);
        string dateString = "2024-10-26 11:10:00";
        DateTime date = DateTime.Parse(dateString);
        var exception = Assert.Throws<Exception>(() => FilterOrders.Filter(orders, "incorrect", date));
        Assert.Equal("No such orders were found." , exception.Message);
    }

}

}

