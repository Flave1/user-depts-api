namespace UserMgtAPI.context.models
{
    public class AuditTrail
    {
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}