namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Data.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class AllBusinessLogics(DbContext context)
    {
        private BaseLogic<T> GetLogic<T>() where T : class
            => new BaseLogic<T>(new Database<T>(context));

        public BaseLogic<Address> AddressesBL => GetLogic<Address>();
        public BaseLogic<AddressLog> AddressLogsBL => GetLogic<AddressLog>();
        public BaseLogic<ApplicationUser> UsersBL => GetLogic<ApplicationUser>();
        public BaseLogic<CartItem> CartItemsBL => GetLogic<CartItem>();
        public BaseLogic<Category> CategoriesBL => GetLogic<Category>();
        public BaseLogic<Manufacturer> ManufacturersBL => GetLogic<Manufacturer>();
        public BaseLogic<Order> OrdersBL => GetLogic<Order>();
        public BaseLogic<Product> ProductsBL => GetLogic<Product>();
        public BaseLogic<ProductLog> ProductLogsBL => GetLogic<ProductLog>();
        public BaseLogic<ProductOrder> ProductOrdersBL => GetLogic<ProductOrder>();
    }
}
