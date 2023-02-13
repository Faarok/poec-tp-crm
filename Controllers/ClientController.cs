namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    [HttpGet]
    public List<Client> Get()
    {
        return RepoTools.repoClient.ReadAll();
    }
    
    [HttpGet("{id}")]
    public Client Get(int id)
    {
        return RepoTools.repoClient.Read(id);
    }

    [HttpPost("add")]
    public List<Client> Get(Client client)
    {
        RepoTools.repoClient.Create(client);
        return RepoTools.repoClient.ReadAll();
    }

    [HttpPut("edit/{id}")]
    public Client Put(int id, Client updateClient)
    {
        Client client = RepoTools.repoClient.Read(id);
        client.Name = updateClient.Name;
        client.State = updateClient.State;
        client.TVA = updateClient.TVA;
        client.TotalCaHt = updateClient.TotalCaHt;
        client.Comment = updateClient.Comment;

        return RepoTools.repoClient.Read(id);
    }

    [HttpDelete("{id}")]
    public List<Client> Delete(int id)
    {
        RepoTools.repoClient.Delete(id);
        return RepoTools.repoClient.ReadAll();
    }
}