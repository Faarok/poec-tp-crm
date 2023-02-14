namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{

    [HttpGet]
    public List<Order> Get()
    {
        foreach(var order in RepoTools.repoOrder.ReadAll())
        {
            if(RepoTools.repoClient.Read(order.ClientID) != null)
            {
                order.Client = RepoTools.repoClient.Read(order.ClientID);
            }
        }

        return RepoTools.repoOrder.ReadAll();
    }

    [HttpGet("{id}")]
    public Order Get(int id)
    {
        return RepoTools.repoOrder.Read(id);
    }

    [HttpPost("add")]
    public List<Order> Post(Order newOrder)
    {
        newOrder.Client = RepoTools.repoClient.Read(newOrder.ClientID);
        RepoTools.repoOrder.Create(newOrder);
        
        return RepoTools.repoOrder.ReadAll();
    }

    [HttpPut("edit/{id}")]
    public Order Put(int id, Order updatedOrder)
    {
        Order order = RepoTools.repoOrder.Read(id);
        updatedOrder.Client = RepoTools.repoClient.Read(updatedOrder.ClientID);

        order.TypePresta = updatedOrder.TypePresta;
        order.NbJours = updatedOrder.NbJours;
        order.TjmHt = updatedOrder.TjmHt;
        order.TVA = updatedOrder.TVA;
        order.State = updatedOrder.State;
        order.Comment = updatedOrder.Comment;
        order.ClientID = updatedOrder.ClientID;
        order.Client = updatedOrder.Client;

        return RepoTools.repoOrder.Read(id);
    }

    [HttpDelete("{id}")]
    public List<Order> Delete(int id)
    {
        RepoTools.repoOrder.Delete(id);
        return RepoTools.repoOrder.ReadAll();
    }
}