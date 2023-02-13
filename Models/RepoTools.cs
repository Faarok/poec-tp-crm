namespace Crm;

public static class RepoTools
{
    public static CrmContext context = new();
    public static Repository<Client> repoClient = new Repository<Client>(context);
    public static Repository<Order> repoOrder = new Repository<Order>(context);
    public static Repository<User> repoUser = new Repository<User>(context);
}