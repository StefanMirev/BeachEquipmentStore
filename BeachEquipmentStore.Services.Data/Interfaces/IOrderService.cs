﻿using BeachEquipmentStore.Services.Data.Models.Order;

namespace BeachEquipmentStore.Services.Data.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderServiceModel> GetDataRequiredForOrder(Guid userId);

        Task GenerateOrder(Guid userId, bool hasAddress, string? addressName, string? town, int zipCode, decimal totalSum);

        Task<OrderDetailServiceModel> GetOrderDetails(string orderId);
    }
}