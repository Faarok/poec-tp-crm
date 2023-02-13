namespace Crm;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet("{id}")]
    public User Get(int id)
    {
        return RepoTools.repoUser.Read(id);
    }

    [HttpPost("add")]
    public List<User> Post(User User)
    {
        RepoTools.repoUser.Create(User);
        return RepoTools.repoUser.ReadAll();
    }

    [HttpPut("edit/{id}")]
    public User Put(int id, User updatedUser)
    {
        User User = RepoTools.repoUser.Read(id);

        User.Email = updatedUser.Email;
        User.Password = updatedUser.Password;
        User.FirstName = updatedUser.FirstName;
        User.LastName = updatedUser.LastName;
        User.ConfirmedPassword = updatedUser.ConfirmedPassword;
        User.Grants = User.Grants;

        return RepoTools.repoUser.Read(id);
    }

    [HttpDelete("{id}")]
    public List<User> Delete(int id)
    {
        RepoTools.repoUser.Delete(id);
        return RepoTools.repoUser.ReadAll();
    }
}