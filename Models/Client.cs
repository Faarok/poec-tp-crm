namespace Crm;

public class Client {

    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public string State { get; set; } = null!;
    public int TVA { get; set; }
    public double TotalCaHt { get; set; }
    public string Comment { get; set; } = null!;
    public List<Order>? OrderList;

    public Client()
    {
    }
}