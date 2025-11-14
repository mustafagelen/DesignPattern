
var transfer =new TransferTransaction() { Amount = 1000, FromIBAN = "TR1234567890", ToIBAN = "TR0987654321" };

var adapter = new JsonBankApiAdapter();

var result =adapter.ExecuteTransfer(transfer);

Console.WriteLine(result);

interface IBankApi
{
    bool ExecuteTransfer(TransferTransaction transaction);
}

class JsonBankApi : IBankApi
{
    public bool ExecuteTransfer(TransferTransaction transaction)
    {
        var json = $$"""
        {
            "ToIBAN": "{{transaction.ToIBAN}}",
            "FromIBAN": "{{transaction.FromIBAN}}",
            "Amount": {{transaction.Amount}}
        }
        """;

        Console.WriteLine($"{GetType()} worked");
        return true;
    }
}

class JsonBankApiAdapter : IBankApi
{
    private readonly JsonBankApi _jsonBankApi;
    public JsonBankApiAdapter()
    {
        _jsonBankApi = new();
    }
    public bool ExecuteTransfer(TransferTransaction transaction)
    {
        return _jsonBankApi.ExecuteTransfer(transaction);
    }
}


class XmlBankApi : IBankApi
{
    public bool ExecuteTransfer(TransferTransaction transaction)
    {
        var xml = $"""
        <Transfer>
            <ToIBAN>{transaction.ToIBAN}</ToIBAN>
            <FromIBAN>{transaction.FromIBAN}</FromIBAN>
            <Amount>{transaction.Amount}</Amount>
        </Transfer>
        """;

        Console.WriteLine($"{GetType()} worked");
        return true;
    }

}

class XmlBankApiAdapter : IBankApi
{
    private readonly XmlBankApi _xmlBankApi;
    public XmlBankApiAdapter(XmlBankApi xmlBankApi)
    {
        _xmlBankApi = xmlBankApi;
    }
    public bool ExecuteTransfer(TransferTransaction transaction)
    {
        return _xmlBankApi.ExecuteTransfer(transaction);
    }
}



class TransferTransaction
{
    public string ToIBAN { get; set; }
    public string FromIBAN { get; set; }
    public decimal Amount { get; set; }

}