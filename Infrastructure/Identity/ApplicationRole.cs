using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public Guid? CreatorId { get; set; }
        public DateTime? CreationTime { get; set; }
        public Guid? ModifierId { get; set; }
        public DateTime? ModificationTime { get; set; }
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
