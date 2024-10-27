// namespace Test;
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

}

}

