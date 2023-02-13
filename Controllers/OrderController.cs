namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpGet("{id}")]
    public Order Get(int id)
    {
        return RepoTools.repoOrder.Read(id);
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
        order.ClientName = updatedOrder.ClientName;
        order.NbJours = updatedOrder.NbJours;
        order.TjmHt = updatedOrder.TjmHt;
        order.TVA = updatedOrder.TVA;
        order.State = updatedOrder.State;
        order.Comment = updatedOrder.Comment;

        return RepoTools.repoOrder.Read(id);
    }

    [HttpDelete("{id}")]
    public List<Order> Delete(int id)
    {
        RepoTools.repoOrder.Delete(id);
        return RepoTools.repoOrder.ReadAll();
    }
}