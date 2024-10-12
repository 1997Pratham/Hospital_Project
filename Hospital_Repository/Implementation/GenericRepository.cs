using Hospital_Repository;
using Hospital_Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    internal DbSet<T> DbSet;
    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }

    public void add(T entity)
    {
        DbSet.Add(entity);
    }

    public async Task<T> addAsync(T entity)
    {
        DbSet.Add(entity);
        return entity;
    }

    public void delete(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Deleted)
        {
            DbSet.Attach(entity);
        }
    }

    public async Task<T> deleteAsync(T entity)
    {
        if (_context.Entry(entity).State == EntityState.Deleted)
        {
            DbSet.Attach(entity);
        }
        DbSet.Remove(entity);
        return entity;
    }
    private bool disposed = false;
    public void Dispose()
    {
        disposed = (true);
        GC.SuppressFinalize(this);
    }
    private void dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }


    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
     Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
     string includeProperties = "")
    {
        IQueryable<T> query = DbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }
    public T GetbyId(int id)
    {
        return DbSet.Find(id);
    }

    public async Task<T> GetbyIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public void update(T entity)
    {
        DbSet.Update(entity);
        _context.Entry(entity).State = EntityState.Modified;

    }


    //public async Task<T> UpdateAsync(T entity)
    //{
    //    DbSet.Attach(entity);
    //    _context.Entry(entity).State = EntityState.Modified;
    //    return Task.FromResult(entity);
    //}

    Task IGenericRepository<T>.updateAsync(T entity)
    {
        DbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(entity);
    }

    Task IGenericRepository<T>.deleteAsync(T entity)
    {
        throw new NotImplementedException();
    }
}

