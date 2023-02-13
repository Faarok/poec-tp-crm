namespace Crm;

public class Order {

    public int ID { get; set; }
    public string TypePresta { get; set; } = null!;
    public int NbJours { get; set; }
    public double TjmHt { get; set; }
    public int TVA { get; set; }
    public string State { get; set; } = null!;
    public string Comment { get; set; } = null!;
    public int ClientID { get; set; }
    public Client Client { get; set; } = null!;

    public Order()
    {
    }
}