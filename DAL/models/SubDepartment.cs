using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgtAPI.context.models
{
    public class SubDepartment : AuditTrail
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}