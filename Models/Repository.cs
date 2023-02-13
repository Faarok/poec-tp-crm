namespace Crm;

using Microsoft.EntityFrameworkCore;

public class Repository<T> where T : class
{
    private static CrmContext _db = new CrmContext();
    private DbSet<T> _table;

    public Repository()
    {
        _table = _db.Set<T>();
        Console.WriteLine("Le repository " + typeof(T) + " est créé");
    }

    public void Create(T entity)
    {
        using (var transaction = _db.Database.BeginTransaction())
        {
            try
            {
                // Les actions à faire sur la BDD
                _table.Add(entity);
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Impossible d'ajouter la ligne.");
                transaction.Rollback();
                throw e;
            }
        }
    }

    public T Read(int id)
    {
        try
        {
            T row = _table.Find(id)!;
            return row;
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Ligne introuvable. Vérifier l'ID.");
            throw e;
        }
    }

    public List<T> ReadAll()
    {
        return _table.ToList();
    }

    public void Update()
    {
        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        using (var transaction = _db.Database.BeginTransaction())
        {
            try
            {
                // Les actions à faire sur la BDD
                T row = _table.Find(id)!;
                _table.Remove(row);
                _db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Impossible de supprimer la ligne.");
                transaction.Rollback();
                throw e;
            }
        }
    }
}