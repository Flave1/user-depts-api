using System.ComponentModel.DataAnnotations;

namespace UserMgtAPI.context.models
{
    public class Department : AuditTrail
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SubDepartment> SubDepartments { get; set; }
    }
}