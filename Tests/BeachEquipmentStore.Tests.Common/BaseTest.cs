//using BeachEquipmentStore.Data.Repositories;
//using Core.Common;
using Core.Enums;
//using Core.Utilities;
using Moq;
//using BeachEquipmentStore.Infrastructure.AutoMapper;
using BeachEquipmentStore.Data.Entities;
using BeachEquipmentStore.Data.Interfaces;
//using BeachEquipmentStore.Services.DocumentServices;
using System.Linq.Expressions;

namespace BeachEquipmentStore.Tests.Common
{
    public abstract class BaseTest : IDisposable
    {
        protected MockRepository _mockRepository;

        protected readonly Mock<IDatabase> _dbMockRepo;

        public BaseTest(bool registerMappings = false)
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);

            _dbMockRepo = _mockRepository.Create<IDatabase>();

            //StaticAbstractDocumentFactory.InjectDocumentFactory(new DocumentFactoryContainer());

            //if (registerMappings)
            //{
            //    AutoMapperConfig.RegisterMappings();
            //}
        }

        public void Dispose()
        {
            _mockRepository.VerifyAll();
        }

        protected Mock<IDbContextTransactionProxy> GetDbContextTransactionProxy()
        {
            Mock<IDbContextTransactionProxy> dbContextTransactionProxy = _mockRepository.Create<IDbContextTransactionProxy>();
            dbContextTransactionProxy.Setup(d => d.Dispose()).Verifiable();

            _dbMockRepo.Setup(d => d.GetTransactionObject()).Returns(dbContextTransactionProxy.Object);

            return dbContextTransactionProxy;
        }

        protected void SearchForDbMockRepoHelper<T>(IEnumerable<T> collection) where T : class
        {
            _dbMockRepo.Setup(d => d.SearchFor(It.IsAny<Expression<Func<T, bool>>>()))
                .Returns((Expression<Func<T, bool>> predicate) => collection.AsQueryable().Where(predicate));
        }

        protected List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Плажни кърпи" },
            new Category { Id = 2, Name = "Чадъри" },
            new Category { Id = 3, Name = "Чанти" },
            new Category { Id = 4, Name = "Плажни играчи" },
            new Category { Id = 5, Name = "Обурудвабе за плуване" },
            new Category { Id = 6, Name = "Надувни" },
            new Category { Id = 7, Name = "Топки" },
        };

        protected List<Manufacturer> _manufacturers = new List<Manufacturer>
        {
            new Manufacturer { Id = 1, Name = "Vinex" },
            new Manufacturer { Id = 2, Name = "Coveri Collection" },
            new Manufacturer { Id = 3, Name = "CPS TOYS" },
            new Manufacturer { Id = 4, Name = "DREAMFOX" },
            new Manufacturer { Id = 5, Name = "INTEX" },
            new Manufacturer { Id = 6, Name = "Shenzhen Befine Sports Goods" },
            new Manufacturer { Id = 7, Name = "Shui Zhong Bao" },
            new Manufacturer { Id = 8, Name = "Star" },
            new Manufacturer { Id = 9, Name = "Vanguard Watersports" },
            new Manufacturer { Id = 10, Name = "ПУБЛИИДЕЯ" },
        };

        protected List<UserRole> _userRoles = new List<UserRole>
        {
            new UserRole { Id = Guid.NewGuid(), Name = "Administrator", RoleType = UserType.Admin,
                           CanRead = true, CanWrite = true, CanDelete = true, IsActive = true },
            new UserRole { Id = Guid.NewGuid(), Name = "Customer", RoleType = UserType.Customer,
                           CanRead = true, CanWrite = false, CanDelete = false, IsActive = true },
        };

        protected void SetupCategoriesRepo(List<Category>? customList = null)
        {
            var listToUse = customList ?? _categories;

            _dbMockRepo.Setup(d => d.All<Category>()).Returns(listToUse.AsQueryable());
        }

        protected void SetupManufacturersRepo(List<Manufacturer>? customList = null)
        {
            var listToUse = customList ?? _manufacturers;

            _dbMockRepo.Setup(d => d.All<Manufacturer>()).Returns(listToUse.AsQueryable());
        }

        protected void SetupUserRolesRepo(List<UserRole>? customList = null)
        {
            var listToUse = customList ?? _userRoles;

            _dbMockRepo.Setup(d => d.SearchFor(It.IsAny<Expression<Func<UserRole, bool>>>()))
                .Returns(listToUse.AsQueryable());

            _dbMockRepo.Setup(d => d.GetNonTrackableEntity(It.IsAny<UserRole>())).Returns<UserRole>(r => r);
        }
    }
}
