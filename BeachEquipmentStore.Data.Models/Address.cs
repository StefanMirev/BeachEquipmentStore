﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BeachEquipmentStore.Common.EntityValidationConstants.Address;

namespace BeachEquipmentStore.Data.Models
{
    public class Address
    {
        public Address()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [Unicode]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Unicode]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength)]
        public string Town { get; set; } = null!;

        [Required]
        [Range(ZipCodeMinValue, ZipCodeMaxValue)]
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public ApplicationUser Customer { get; set; } = null!;
    }
}
