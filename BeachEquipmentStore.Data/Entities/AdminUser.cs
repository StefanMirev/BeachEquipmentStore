namespace BeachEquipmentStore.Data.Entities
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Core.Common.Constants.EntityValidationConstants.AdminUser;

    public class AdminUser : IEntity
    {
        public AdminUser()
        {
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Unicode]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UserRoleId { get; set; }
        [ForeignKey(nameof(UserRoleId))]
        public UserRole? UserRole { get; set; }

        public User User { get; set; } = null!;
    }
}
