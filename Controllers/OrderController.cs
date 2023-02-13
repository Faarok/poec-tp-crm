namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    CrmContext context = new();

    [HttpGet("{id}")]
    public Order Get(int id)
    {
        Order order = RepoTools.repoOrder.Read(id);
        order.Client = RepoTools.repoClient.Read(order.ClientID);
        return order;
    }

    [HttpPost("add")]
    public List<Order> Post(Order order)
    {
        RepoTools.repoOrder.Create(order);
        return RepoTools.repoOrder.ReadAll();
    }

    [HttpPut("edit/{id}")]
    public Order Put(int id, Order updatedOrder)
    {
        Order order = RepoTools.repoOrder.Read(id);

        order.TypePresta = updatedOrder.TypePresta;
        order.NbJours = updatedOrder.NbJours;
        order.TjmHt = updatedOrder.TjmHt;
        order.TVA = updatedOrder.TVA;
        order.State = updatedOrder.State;
        order.Comment = updatedOrder.Comment;
        order.ClientID = updatedOrder.ClientID;

        return RepoTools.repoOrder.Read(id);
    }

    [HttpDelete("{id}")]
    public List<Order> Delete(int id)
    {
        RepoTools.repoOrder.Delete(id);
        return RepoTools.repoOrder.ReadAll();
    }
}