namespace BeachEquipmentStore.Data.Extensions
{
    using BeachEquipmentStore.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public static class ModelBuilderExtensions
    {
        private static ApplicationUser UserOne = new ApplicationUser();
        private static ApplicationUser UserTwo = new ApplicationUser();
        private static ApplicationUser UserThree = new ApplicationUser();

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            UserOne.FirstName = "Petar";
            UserOne.LastName = "Petrov";
            UserOne.UserName = "p.petrov@mail.com";
            UserOne.NormalizedUserName = "P.PETROV@MAIL.COM";
            UserOne.Email = "p.petrov@mail.com";
            UserOne.NormalizedEmail = "P.PETROV@MAIL.COM";
            UserOne.PhoneNumber = "0876596224";
            UserOne.PasswordHash = hasher.HashPassword(UserOne, "123123");
            UserOne.SecurityStamp = Guid.NewGuid().ToString("D");

            UserTwo.FirstName = "Nicko";
            UserTwo.LastName = "Flacko";
            UserTwo.UserName = "n.flacko@mail.com";
            UserTwo.NormalizedUserName = "N.FLACKO@MAIL.COM";
            UserTwo.Email = "n.flacko@mail.com";
            UserTwo.NormalizedEmail = "N.FLACKO@MAIL.COM";
            UserTwo.PhoneNumber = "0888202449";
            UserTwo.PasswordHash = hasher.HashPassword(UserTwo, "123123");
            UserTwo.SecurityStamp = Guid.NewGuid().ToString("D");

            UserThree.FirstName = "Stamat";
            UserThree.LastName = "Sarafov";
            UserThree.UserName = "s.sarafov@mail.com";
            UserThree.NormalizedUserName = "S.SARAFOV@MAIL.COM";
            UserThree.Email = "s.sarafov@mail.com";
            UserThree.NormalizedEmail = "S.SARAFOV@MAIL.COM";
            UserThree.PhoneNumber = "0885527733";
            UserThree.PasswordHash = hasher.HashPassword(UserThree, "123123");
            UserThree.SecurityStamp = Guid.NewGuid().ToString("D");

            modelBuilder.Entity<ApplicationUser>().HasData(UserOne, UserTwo, UserThree);
        }

        public static void SeedAddresses(this ModelBuilder modelBuilder)
        {
            var addressOne = new Address()
            {
                Name = "ул. Кракра №3",
                Town = "София",
                ZipCode = "1000",
                CustomerId = UserOne.Id
            };

            var addressTwo = new Address()
            {
                Name = "кв. Овча Купел, ул. Рачка №9",
                Town = "София",
                ZipCode = "1000",
                CustomerId = UserTwo.Id
            };

            var addressThree = new Address()
            {
                Name = "ул. Обзорски Тигър № 33",
                Town = "Обзор",
                ZipCode = "1000",
                CustomerId = UserTwo.Id
            };

            modelBuilder.Entity<Address>().HasData(addressOne, addressTwo, addressThree);
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            var categoryTowel = new Category()
            {
                Id = 1,
                Name = "Плажни кърпи",
                ImageUrl = "https://i.ibb.co/w6CNrfd/Towel-Category.webp"
            };

            var categoryUmberlla = new Category()
            {
                Id = 2,
                Name = "Чадъри",
                ImageUrl = "https://i.ibb.co/t4KWPCP/Umbrella-Category.jpg"
            };

            var categoryBag = new Category()
            {
                Id = 3,
                Name = "Чанти",
                ImageUrl = "https://i.ibb.co/vv0FD1X/Bag-Category.webp"
            };

            var categoryBeachToy = new Category()
            {
                Id = 4,
                Name = "Плажни играчи",
                ImageUrl = "https://i.ibb.co/6nHY7VJ/Beach-Toy-Category.webp"
            };

            var categorySwimmingEquipment = new Category()
            {
                Id = 5,
                Name = "Обурудвабе за плуване",
                ImageUrl = "https://i.ibb.co/JkDDZkb/Swimming-Equipment-Category.jpg"

            };

            var categoryFloaty = new Category()
            {
                Id = 6,
                Name = "Надувни",
                ImageUrl = "https://i.ibb.co/JxJ4CSM/Floaty-Category.webp"
            };

            var categoryBall = new Category()
            {
                Id = 7,
                Name = "Топки",
                ImageUrl = "https://i.ibb.co/rHY9wjG/Ball-Category.jpg"
            };

            modelBuilder.Entity<Category>().HasData(categoryBag, categoryBall, categoryBeachToy, categoryFloaty, categorySwimmingEquipment, categoryTowel, categoryUmberlla);
        }

        public static void SeedManufacturers(this ModelBuilder modelBuilder)
        {
            var manufacturerVinex = new Manufacturer()
            {
                Id = 1,
                Name = "Vinex",
                ImageUrl = "https://i.ibb.co/7WJYhkr/Vinex-Manufacturer.jpg"
            };

            var manufacturerCoveri = new Manufacturer()
            {
                Id = 2,
                Name = "Coveri Collection",
                ImageUrl = "https://i.ibb.co/JpRqHbV/Covari-Manufacturer.jpg"
            };

            var manufacturerCPS = new Manufacturer()
            {
                Id = 3,
                Name = "CPS TOYS",
                ImageUrl = "https://i.ibb.co/nQHgsJG/Cps-Manufacturer.jpg"
            };

            var manufacturerDreamfox = new Manufacturer()
            {
                Id = 4,
                Name = "DREAMFOX",
                ImageUrl = "https://i.ibb.co/1nkCLZw/Dreamfox.jpg"
            };

            var manufacturerIntex = new Manufacturer()
            {
                Id = 5,
                Name = "INTEX",
                ImageUrl = "https://i.ibb.co/s2Y1245/Intex-Manufacturer.jpg"
            };

            var manufacturerShenzhen = new Manufacturer()
            {
                Id = 6,
                Name = "Shenzhen Befine Sports Goods",
                ImageUrl = "https://i.ibb.co/QQ486yn/Shenzhen-Manufacturer.jpg"
            };

            var manufacturerShui = new Manufacturer()
            {
                Id = 7,
                Name = "Shui Zhong Bao",
                ImageUrl = "https://i.ibb.co/K7N6Z0D/Shui-Manufacturer.jpg"
            };

            var manufacturerStar = new Manufacturer()
            {
                Id = 8,
                Name = "Star",
                ImageUrl = "https://i.ibb.co/CKCRztx/Star-Manufacturer.jpg"
            };

            var manufacturerVanguard = new Manufacturer()
            {
                Id = 9,
                Name = "Vanguard Watersports",
                ImageUrl = "https://i.ibb.co/bPDRFNJ/Vanguard-Manufacturer.jpg"
            };

            var manufacturerPublidea = new Manufacturer()
            {
                Id = 10,
                Name = "ПУБЛИИДЕЯ",
                ImageUrl = "https://i.ibb.co/6PPhfyV/Publidea.jpg"
            };

            modelBuilder.Entity<Manufacturer>().HasData(manufacturerVinex, manufacturerCoveri, manufacturerCPS, manufacturerDreamfox, manufacturerIntex, manufacturerPublidea, manufacturerShenzhen, manufacturerShui, manufacturerStar, manufacturerVanguard);
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var allProducts = new HashSet<Product>();

            var productOne = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 75 x 170 cm.",
                ManufacturerId = 4,
                Description = "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.",
                ImageUrl = "https://i.ibb.co/LkpTB85/Towel-Shark.jpg",
                Barcode = 57532,
                Price = 12.00m,
                Stock = 50,
                CategoryId = 1
            };
            allProducts.Add(productOne);

            var productTwo = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 75 x 150 cm.",
                ManufacturerId = 4,
                Description = "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.",
                ImageUrl = "https://i.ibb.co/6Xj3SVh/Towel-Dolphin.jpg",
                Barcode = 38527,
                Price = 4.80m,
                Stock = 100,
                CategoryId = 1
            };
            allProducts.Add(productTwo);

            var productThree = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 70 x 140 cm.",
                ManufacturerId = 4,
                Description = "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.",
                ImageUrl = "https://i.ibb.co/y08sGtL/Towel-Plain-Blue.jpg",
                Barcode = 57523,
                Price = 9.30m,
                Stock = 50,
                CategoryId = 1
            };
            allProducts.Add(productThree);

            var productFour = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 70 x 140 cm.",
                ManufacturerId = 4,
                Description = "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.",
                ImageUrl = "https://i.ibb.co/BCMvsmq/Towen-Plain-Pink.jpg",
                Barcode = 57526,
                Price = 9.30m,
                Stock = 50,
                CategoryId = 1
            };
            allProducts.Add(productFour);

            var productFive = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 75 x 150 cm.",
                ManufacturerId = 4,
                Description = "Микрофибърна плажна хавлия с изоображение на русалка и надписи.",
                ImageUrl = "https://i.ibb.co/Fn52s1n/Towel-Mermaid.jpg",
                Barcode = 56130,
                Price = 5.00m,
                Stock = 100,
                CategoryId = 1
            };
            allProducts.Add(productFive);

            var productSix = new Product()
            {
                Name = "Плажна хавлия DREAMFOX 75 x 150 cm.",
                ManufacturerId = 4,
                Description = "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.",
                ImageUrl = "https://i.ibb.co/XpYVKZ4/Towen-Seaside.jpg",
                Barcode = 58922,
                Price = 4.80m,
                Stock = 100,
                CategoryId = 1
            };
            allProducts.Add(productSix);

            var productSeven = new Product()
            {
                Name = "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.",
                ManufacturerId = 10,
                Description = "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.",
                ImageUrl = "https://i.ibb.co/6vxZ7wZ/Umbrella-Plain.jpg",
                Barcode = 55555,
                Price = 14.85m,
                Stock = 25,
                CategoryId = 2
            };
            allProducts.Add(productSeven);

            var productEight = new Product()
            {
                Name = "Плажен чадър ПУБЛИИДЕЯ, палми",
                ManufacturerId = 10,
                Description = "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.",
                ImageUrl = "https://i.ibb.co/vvtYT55/Umberlla-Plams.jpg",
                Barcode = 44443,
                Price = 6.80m,
                Stock = 25,
                CategoryId = 2
            };
            allProducts.Add(productEight);

            var productNine = new Product()
            {
                Name = "Плажен чадър ПУБЛИИДЕЯ, растения",
                ManufacturerId = 10,
                Description = "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.",
                ImageUrl = "https://i.ibb.co/Sv0DmBy/Umbrella-Plants.jpg",
                Barcode = 44442,
                Price = 7.50m,
                Stock = 25,
                CategoryId = 2
            };
            allProducts.Add(productNine);

            var productTen = new Product()
            {
                Name = "Плажен чадър ПУБЛИИДЕЯ, морски звезди",
                ManufacturerId = 10,
                Description = "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.",
                ImageUrl = "https://i.ibb.co/ZmM9rZP/Umbrella-Starfish.jpg",
                Barcode = 44444,
                Price = 6.80m,
                Stock = 25,
                CategoryId = 2
            };
            allProducts.Add(productTen);

            var productEleven = new Product()
            {
                Name = "Плажна Coveri Collection 53х37х19",
                ManufacturerId = 2,
                Description = "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.",
                ImageUrl = "https://i.ibb.co/2MFJmGv/Bag-Watermellon.jpg",
                Barcode = 56718,
                Price = 8.50m,
                Stock = 30,
                CategoryId = 3
            };
            allProducts.Add(productEleven);

            var productTwelve = new Product()
            {
                Name = "Плажна чанта Coveri Collection 53х37х19",
                ManufacturerId = 2,
                Description = "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ",
                ImageUrl = "https://i.ibb.co/BZYy30X/Bag-Anchor.jpg",
                Barcode = 56724,
                Price = 8.50m,
                Stock = 30,
                CategoryId = 3
            };
            allProducts.Add(productTwelve);

            var productThirteen = new Product()
            {
                Name = "Плажна чанта Coveri Collection 53х37х19",
                ManufacturerId = 2,
                Description = "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.",
                ImageUrl = "https://i.ibb.co/LPnV4tL/BagPoppy.jpg",
                Barcode = 56723,
                Price = 8.50m,
                Stock = 30,
                CategoryId = 3
            };
            allProducts.Add(productThirteen);

            var productFourteen = new Product()
            {
                Name = "Плажна чанта Coveri Collection 53х37х19",
                ManufacturerId = 2,
                Description = "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.",
                ImageUrl = "https://i.ibb.co/RhKgqG2/BagClams.jpg",
                Barcode = 56721,
                Price = 8.50m,
                Stock = 30,
                CategoryId = 3
            };
            allProducts.Add(productFourteen);

            var productFifteen = new Product()
            {
                Name = "Плажна чанта Coveri Collection 53х37х19",
                ManufacturerId = 2,
                Description = "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.",
                ImageUrl = "https://i.ibb.co/8bQ32MJ/Bag-Orchid.jpg",
                Barcode = 56720,
                Price = 8.50m,
                Stock = 30,
                CategoryId = 3
            };
            allProducts.Add(productFifteen);

            var productSixteen = new Product()
            {
                Name = "Vinex - Комплект кофичка за пясък Дисни",
                ManufacturerId = 1,
                Description = "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.",
                ImageUrl = "https://i.ibb.co/5vfvRwN/Toy-Bucket-Disney.jpg",
                Barcode = 18040,
                Price = 8.25m,
                Stock = 16,
                CategoryId = 4
            };
            allProducts.Add(productSixteen);

            var productSeventeen = new Product()
            {
                Name = "Vinex - Комплект кофичка за пясък Дисни",
                ManufacturerId = 1,
                Description = "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.",
                ImageUrl = "https://i.ibb.co/cw3903C/Toy-Bucket-Plain.jpg",
                Barcode = 17005,
                Price = 6.00m,
                Stock = 16,
                CategoryId = 4
            };
            allProducts.Add(productSeventeen);

            var productEighteen = new Product()
            {
                Name = "Vinex - Комплект кофичка за пясък Дисни",
                ManufacturerId = 1,
                Description = "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.",
                ImageUrl = "https://i.ibb.co/cX57F5w/Toy-Bucket-Cartoon.jpg",
                Barcode = 10805,
                Price = 10.50m,
                Stock = 16,
                CategoryId = 4
            };
            allProducts.Add(productEighteen);

            var productNineteen = new Product()
            {
                Name = "Vinex - Комплект кофичка за пясък Дисни",
                ManufacturerId = 1,
                Description = " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.",
                ImageUrl = "https://i.ibb.co/86dL7D5/Toy-Bucket-Square.jpg",
                Barcode = 33306,
                Price = 6.40m,
                Stock = 15,
                CategoryId = 4
            };
            allProducts.Add(productNineteen);

            var productTwenty = new Product()
            {
                Name = "Vinex - Лопата за пясък",
                ManufacturerId = 1,
                Description = "Лопата за пясък, дървена дръжка с дължина 62 см.",
                ImageUrl = "https://i.ibb.co/WHxnBfw/Toy-Shovel.jpg",
                Barcode = 36113,
                Price = 3.20m,
                Stock = 40,
                CategoryId = 4
            };
            allProducts.Add(productTwenty);

            var productTwentyOne = new Product()
            {
                Name = "Воден пистолет CPS TOYS 50см",
                ManufacturerId = 3,
                Description = "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!",
                ImageUrl = "https://i.ibb.co/jf72Vv7/Toy-Water-Gun.jpg",
                Barcode = 58849,
                Price = 7.40m,
                Stock = 40,
                CategoryId = 4
            };
            allProducts.Add(productTwentyOne);

            var productTwentyTwo = new Product()
            {
                Name = "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider",
                ManufacturerId = 6,
                Description = "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно",
                ImageUrl = "https://i.ibb.co/Ycbbt1d/Swimming-Mask.jpg",
                Barcode = 42178,
                Price = 33.00m,
                Stock = 30,
                CategoryId = 5
            };
            allProducts.Add(productTwentyTwo);

            var productTwentyThree = new Product()
            {
                Name = "Плавници Vanguard Watersports Super Sport, 35-37 номер",
                ManufacturerId = 9,
                Description = "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!",
                ImageUrl = "https://i.ibb.co/xFGh6x2/Swimming-Fins-Children.jpg",
                Barcode = 59139,
                Price = 19.00m,
                Stock = 50,
                CategoryId = 5
            };
            allProducts.Add(productTwentyThree);

            var productTwentyFour = new Product()
            {
                Name = "Плавници Vanguard Watersports Mega Sport, 39-43 номер",
                ManufacturerId = 9,
                Description = "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!",
                ImageUrl = "https://i.ibb.co/vZN4MxL/Swimming-Fins-Adult.jpg",
                Barcode = 42181,
                Price = 19.50m,
                Stock = 40,
                CategoryId = 5
            };
            allProducts.Add(productTwentyFour);

            var productTwentyFive = new Product()
            {
                Name = "Шапка за плуване Vanguard Watersports, текстил",
                ManufacturerId = 9,
                Description = "Шапка за плуване, текстил. Размери: 21 х 12 см.",
                ImageUrl = "https://i.ibb.co/hZnkbPF/Swimming-Cap.jpg",
                Barcode = 24040,
                Price = 1.35m,
                Stock = 70,
                CategoryId = 5
            };
            allProducts.Add(productTwentyFive);

            var productTwentySix = new Product()
            {
                Name = "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles",
                ManufacturerId = 6,
                Description = "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ",
                ImageUrl = "https://i.ibb.co/BsKqYC7/Swimming-Goggles-Children.jpg",
                Barcode = 31386,
                Price = 4.50m,
                Stock = 30,
                CategoryId = 5
            };
            allProducts.Add(productTwentySix);

            var productTwentySeven = new Product()
            {
                Name = "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport",
                ManufacturerId = 6,
                Description = "Плувни очила за възрастни, широки, черен силикон 18х8 см.",
                ImageUrl = "https://i.ibb.co/y0PGtTq/Swimming-Goggles-Adult.jpg",
                Barcode = 51375,
                Price = 7.00m,
                Stock = 20,
                CategoryId = 5
            };
            allProducts.Add(productTwentySeven);

            var productTwentyEight = new Product()
            {
                Name = "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo",
                ManufacturerId = 6,
                Description = "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.",
                ImageUrl = "https://i.ibb.co/FYgw02D/Swimming-Snorkel-Children.jpg",
                Barcode = 42174,
                Price = 3.65m,
                Stock = 30,
                CategoryId = 5
            };
            allProducts.Add(productTwentyEight);

            var productTwentyNine = new Product()
            {
                Name = "Шнорхел Shenzhen Befine Sports Goods Easy-Flow",
                ManufacturerId = 6,
                Description = "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.",
                ImageUrl = "https://i.ibb.co/9v2Qr7q/Swimming-Snorkel-Adults.jpg",
                Barcode = 42172,
                Price = 5.50m,
                Stock = 20,
                CategoryId = 5
            };
            allProducts.Add(productTwentyNine);

            var productThirty = new Product()
            {
                Name = "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък",
                ManufacturerId = 5,
                Description = "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.",
                ImageUrl = "https://i.ibb.co/PsLkswc/Floaty-Crocodile.jpg",
                Barcode = 58546,
                Price = 19.85m,
                Stock = 15,
                CategoryId = 6
            };
            allProducts.Add(productThirty);

            var productThirtyOne = new Product()
            {
                Name = "Детски надуваем пояс INTEX Пони-Еднорог",
                ManufacturerId = 5,
                Description = "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.",
                ImageUrl = "https://i.ibb.co/j5MMjgM/Floaty-Unicorn.jpg",
                Barcode = 49230,
                Price = 11.80m,
                Stock = 15,
                CategoryId = 6
            };
            allProducts.Add(productThirtyOne);

            var productThirtyTwo = new Product()
            {
                Name = "Надуваем поясн Диня Shui Zhong Bao Watermelon",
                ManufacturerId = 7,
                Description = "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.",
                ImageUrl = "https://i.ibb.co/7tz51mq/Floaty-Melon.jpg",
                Barcode = 36727,
                Price = 4.20m,
                Stock = 12,
                CategoryId = 6
            };
            allProducts.Add(productThirtyTwo);

            var productThirtyThree = new Product()
            {
                Name = "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle",
                ManufacturerId = 7,
                Description = "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.",
                ImageUrl = "https://i.ibb.co/H2wNG86/Floaty-Turtle-Babies.jpg",
                Barcode = 56113,
                Price = 5.75m,
                Stock = 15,
                CategoryId = 6
            };
            allProducts.Add(productThirtyThree);

            var productThirtyFour = new Product()
            {
                Name = "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см",
                ManufacturerId = 5,
                Description = "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.",
                ImageUrl = "https://i.ibb.co/1dzzG9V/Floaty-Ice-Cream.jpg",
                Barcode = 58762,
                Price = 14.50m,
                Stock = 10,
                CategoryId = 6
            };
            allProducts.Add(productThirtyFour);

            var productThirtyFive = new Product()
            {
                Name = "Надуваем дюшек INTEX, 183 х 69 х 25см",
                ManufacturerId = 5,
                Description = "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.",
                ImageUrl = "https://i.ibb.co/G0WBydZ/Floaty-Bed.jpg",
                Barcode = 59720,
                Price = 10.60m,
                Stock = 10,
                CategoryId = 6
            };
            allProducts.Add(productThirtyFive);

            var productThirtySix = new Product()
            {
                Name = "Надуваем дюшек Ангелски крила INTEX",
                ManufacturerId = 5,
                Description = "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.",
                ImageUrl = "https://i.ibb.co/K7LDFSq/Floaty-Wings.jpg",
                Barcode = 58786,
                Price = 47.70m,
                Stock = 10,
                CategoryId = 6
            };
            allProducts.Add(productThirtySix);

            var productThirtySeven = new Product()
            {
                Name = "Star  - Волейболна топка Miami Beach, 21см",
                ManufacturerId = 8,
                Description = "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.",
                ImageUrl = "https://i.ibb.co/3h3MV9H/Ball-Miami.jpg",
                Barcode = 101730,
                Price = 6.30m,
                Stock = 10,
                CategoryId = 7
            };
            allProducts.Add(productThirtySeven);

            var productThirtyEight = new Product()
            {
                Name = "Star  - Волейболна топка Bora Bora, 21см",
                ManufacturerId = 8,
                Description = "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.",
                ImageUrl = "https://i.ibb.co/pQJZTcp/Ball-Bora-Bora.jpg",
                Barcode = 101019,
                Price = 6.30m,
                Stock = 10,
                CategoryId = 7
            };
            allProducts.Add(productThirtyEight);

            var productThirtyNine = new Product()
            {
                Name = "Star  - Волейболна топка Beach Volley, 21см",
                ManufacturerId = 8,
                Description = "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.",
                ImageUrl = "https://i.ibb.co/HgMXxMb/Ball-Beach-Palms.jpg",
                Barcode = 101090,
                Price = 6.30m,
                Stock = 10,
                CategoryId = 7
            };
            allProducts.Add(productThirtyNine);

            var productFourty = new Product()
            {
                Name = "Star  - Волейболна топка Water Polo, 21см",
                ManufacturerId = 8,
                Description = "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.",
                ImageUrl = "https://i.ibb.co/qnd7sVN/Ball-Water-Polo.jpg",
                Barcode = 101011,
                Price = 6.15m,
                Stock = 10,
                CategoryId = 7
            };
            allProducts.Add(productFourty);

            modelBuilder.Entity<Product>().HasData(allProducts);
        }
    }
}
