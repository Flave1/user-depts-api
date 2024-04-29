using Microsoft.EntityFrameworkCore;
using UserMgtAPI.context;
using UserMgtAPI.context.models;

public interface IDepartmentRepository
{
    Task<int> CreateAsync(Department user);
    Task<Department> GetByIdAsync(int id);
    IQueryable<Department> GetAll();
    Task<Department> GetByNameAsync(string name);
    Task UpdateAsync(Department dept);
    Task DeleteAsync(int id);
}

public class DepartmentRepository : IDepartmentRepository
{
    private readonly DataContext _dbContext;

    public DepartmentRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CreateAsync(Department dept)
    {
        _dbContext.Departments.Add(dept);
        await _dbContext.SaveChangesAsync();
        return dept.Id;
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _dbContext.Departments.FindAsync(id);
    }
    public IQueryable<Department> GetAll()
    {
         return _dbContext.Departments.Where(d => d.Deleted == false);
    }
    public async Task<Department> GetByNameAsync(string name)
    {
        return await _dbContext.Departments.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToLower());
    }

    public async Task UpdateAsync(Department dept)
    {
        _dbContext.Departments.Update(dept);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user != null)
        {
            _dbContext.Departments.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}