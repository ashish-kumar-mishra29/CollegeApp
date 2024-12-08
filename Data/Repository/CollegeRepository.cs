using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Data.Repository;

public class CollegeRepository<T> : ICollegeRepository<T> where T : class
{
    private CollegeDBContext _dbContext;
    private DbSet<T> _dbSet;
    
    public CollegeRepository(CollegeDBContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).FirstOrDefaultAsync();
    }

    public async Task<T> GetByNameAsync(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).FirstOrDefaultAsync();
    }

    public async Task<T> CreateAsync(T dbRecord)
    {
        await _dbSet.AddAsync(dbRecord);
        await _dbContext.SaveChangesAsync();
        return dbRecord;
    }

    public async Task<T> UpdateAsync(T dbRecord)
    {
       _dbContext.Update(dbRecord);
        await _dbContext.SaveChangesAsync();
        return dbRecord;
    }

    public async Task<bool> DeleteAsync(T dbRecord)
    {
        _dbSet.Remove(dbRecord);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}