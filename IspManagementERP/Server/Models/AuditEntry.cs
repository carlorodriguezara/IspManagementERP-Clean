using System;

namespace IspManagementERP.Server.Models
{
    public class AuditEntry
    {
        public int Id { get; set; }
        public string Actor { get; set; } = "";
        public string TargetUserId { get; set; } = "";
        public string Action { get; set; } = "";
        public string Detail { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
