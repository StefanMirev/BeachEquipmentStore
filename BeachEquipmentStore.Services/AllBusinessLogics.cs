namespace BeachEquipmentStore.Services
{
    using BeachEquipmentStore.Data.Entities;
    using BeachEquipmentStore.Data.Interfaces;

    public class AllBusinessLogics(IDatabase database) : IDisposable
    {
        private readonly Dictionary<Type, object> _logics = new();

        private BaseLogic<T> GetLogic<T>() where T : class
        {
            var type = typeof(T);
            if (!_logics.ContainsKey(type))
                _logics[type] = new BaseLogic<T>(database);
            return (BaseLogic<T>)_logics[type];
        }

        public BaseLogic<User> UsersBL => GetLogic<User>();
        public BaseLogic<CustomerUser> CustomerUsersBL => GetLogic<CustomerUser>();
        public BaseLogic<AdminUser> AdminUsersBL => GetLogic<AdminUser>();
        public BaseLogic<UserRole> UserRolesBL => GetLogic<UserRole>();
        public BaseLogic<UserToken> UserTokensBL => GetLogic<UserToken>();
        public BaseLogic<Address> AddressesBL => GetLogic<Address>();
        public BaseLogic<AddressLog> AddressLogsBL => GetLogic<AddressLog>();
        public BaseLogic<CartItem> CartItemsBL => GetLogic<CartItem>();
        public BaseLogic<Category> CategoriesBL => GetLogic<Category>();
        public BaseLogic<Manufacturer> ManufacturersBL => GetLogic<Manufacturer>();
        public BaseLogic<Order> OrdersBL => GetLogic<Order>();
        public BaseLogic<Product> ProductsBL => GetLogic<Product>();
        public BaseLogic<ProductLog> ProductLogsBL => GetLogic<ProductLog>();
        public BaseLogic<ProductOrder> ProductOrdersBL => GetLogic<ProductOrder>();

        public void Dispose() => _logics.Clear();
    }
}
