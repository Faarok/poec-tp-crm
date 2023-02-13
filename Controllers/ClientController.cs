namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientController : Controller
{
    [HttpGet]
    public List<Client> Get()
    {
        return RepoTools.repoClient.ReadAll();
    }
}