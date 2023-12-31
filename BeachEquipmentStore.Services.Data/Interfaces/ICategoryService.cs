﻿using BeachEquipmentStore.Services.Data.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryServiceModel>> GetAllCategoriesAsync();
    }
}
