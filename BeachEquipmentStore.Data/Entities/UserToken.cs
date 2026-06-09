namespace BeachEquipmentStore.Data.Entities
{
    using Core.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserToken
    {
        public UserToken()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public UserTokenType Type { get; set; }

        [Required]
        public string Value { get; set; } = null!;

        [Required]
        public DateTime ExpiresAt { get; set; }

        [Required]
        public bool IsUsed { get; set; } = false;

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
