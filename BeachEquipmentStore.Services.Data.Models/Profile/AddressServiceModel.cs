﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Profile
{
    public class AddressServiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Town { get; set; } = null!;

        public int ZipCode { get; set; }
    }
}
