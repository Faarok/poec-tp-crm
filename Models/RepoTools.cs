namespace Crm;

public static class RepoTools
{
    public static Repository<Client> repoClient = new();
    public static Repository<Order> repoOrder = new();
    public static Repository<User> repoUser = new();
}