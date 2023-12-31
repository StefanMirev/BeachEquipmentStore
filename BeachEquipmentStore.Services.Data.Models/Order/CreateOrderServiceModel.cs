﻿using BeachEquipmentStore.Services.Data.Models.Product;
using BeachEquipmentStore.Services.Data.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Models.Order
{
    public class CreateOrderServiceModel
    {
        public CreateOrderServiceModel()
        {
            this.Products = new List<ProductServiceModel>();
        }

        public UserInfoServiceModel UserInfo { get; set; } = null!;

       public AddressServiceModel? UserAddress { get; set; }

        public List<ProductServiceModel> Products { get; set; } 
    }
}
