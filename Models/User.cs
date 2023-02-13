namespace Crm;

public class User {

    public int ID { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string ConfirmedPassword { get; set; } = null!;
    public string Grants { get; set; } = null!;

    public User()
    {
         
    }
}