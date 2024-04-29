using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserMgtAPI.context.models
{
    public class Personnel : AuditTrail
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime EntryDate { get; set; }


        [ForeignKey("SubDepartmentId")]
        public int SubDepartmentId { get; set; }
        public virtual SubDepartment SubDepartment { get; set; }


        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}