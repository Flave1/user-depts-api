using UserMgtAPI.context.models;

public interface IDepartmentService
{
    Task<int> CreateDepartmentAsync(DepartmentCreateDto dept);
    Task<Department> GetDepartmentByIdAsync(int id);
    Task<List<DepartmentDto>> GetDepartmentsAsync();
    Task UpdateDepartmentAsync(DepartmentUpdateDto dept);
    Task DeleteDepartmentAsync(int id);
}