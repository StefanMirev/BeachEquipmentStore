namespace BeachEquipmentStore.Data.Entities
{
    using Core.Enums;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using static Core.Common.Constants.EntityValidationConstants.UserRole;

    public class UserRole
    {
        public UserRole()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Unicode]
        [StringLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        [DisplayName("Role Type")]
        public UserType RoleType { get; set; }

        [Required]
        [DisplayName("Can Read")]
        public bool CanRead { get; set; } = false;

        [Required]
        [DisplayName("Can Write")]
        public bool CanWrite { get; set; } = false;

        [Required]
        [DisplayName("Can Delete")]
        public bool CanDelete { get; set; } = false;

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
