using System.Data;
using Microsoft.EntityFrameworkCore;
using UserMgtAPI.context.models;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<int> CreateDepartmentAsync(DepartmentCreateDto dpt)
    {
        Department dept = null;
        dept = await _departmentRepository.GetByNameAsync(dpt.Name);

        if (dept != null)
            throw new DuplicateNameException("Department with this Name already exist");

        dept = new Department();
        dept.Name = dpt.Name;

        return await _departmentRepository.CreateAsync(dept);
    }

    public async Task<Department> GetDepartmentByIdAsync(int Id)
    {
        return await _departmentRepository.GetByIdAsync(Id);
    }
    public async Task<List<DepartmentDto>> GetDepartmentsAsync()
    {
        return await _departmentRepository.GetAll().Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name
        }).ToListAsync();
    }

    public async Task UpdateDepartmentAsync(DepartmentUpdateDto dept)
    {
        Department dpt = await _departmentRepository.GetByNameAsync(dept.Name);

        if (dept == null)
            throw new ArgumentException("Department not found");

        dpt.Name = dpt.Name;
        await _departmentRepository.UpdateAsync(dpt);
    }

    public async Task DeleteDepartmentAsync(int Id)
    {
        await _departmentRepository.DeleteAsync(Id);
    }
}
