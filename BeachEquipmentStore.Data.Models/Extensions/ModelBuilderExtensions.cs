namespace BeachEquipmentStore.Data.Models.Extensions
{
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

            UserTwo.FirstName = "Nicko";
            UserTwo.LastName = "Flacko";
            UserTwo.UserName = "n.flacko@mail.com";
            UserTwo.NormalizedUserName = "N.FLACKO@MAIL.COM";
            UserTwo.Email = "n.flacko@mail.com";
            UserTwo.NormalizedEmail = "N.FLACKO@MAIL.COM";
            UserTwo.PhoneNumber = "0888202449";
            UserTwo.PasswordHash = hasher.HashPassword(UserTwo, "123123");

            UserThree.FirstName = "Stamat";
            UserThree.LastName = "Sarafov";
            UserThree.UserName = "s.sarafov@mail.com";
            UserThree.NormalizedUserName = "S.SARAFOV@MAIL.COM";
            UserThree.Email = "s.sarafov@mail.com";
            UserThree.NormalizedEmail = "S.SARAFOV@MAIL.COM";
            UserThree.PhoneNumber = "0885527733";
            UserThree.PasswordHash = hasher.HashPassword(UserThree, "123123");

            modelBuilder.Entity<ApplicationUser>().HasData(UserOne, UserTwo, UserThree);
        }

        public static void SeedAddresses(this ModelBuilder modelBuilder)
        {
            var addressOne = new Address()
            {
                Name = "ул. Кракра №3",
                Town = "София",
                ZipCode = 1000,
                CustomerId = UserOne.Id
            };

            var addressTwo = new Address()
            {
                Name = "кв. Овча Купел, ул. Рачка №9",
                Town = "София",
                ZipCode = 1000,
                CustomerId = UserTwo.Id
            };

            var addressThree = new Address()
            {
                Name = "ул. Обзорски Тигър № 33",
                Town = "Обзор",
                ZipCode = 1000,
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1JdKCD7760eDhZMyz2PMTPs8_cCRlxOIy"
            };

            var categoryUmberlla = new Category()
            {
                Id = 2,
                Name = "Чадъри",
                ImageUrl = "https://drive.google.com/uc?export=download&id=10dHA3b3yfniTLBRqTPUOoG5ViR5haXTF"
            };

            var categoryBag = new Category()
            {
                Id = 3,
                Name = "Чанти",
                ImageUrl = "https://drive.google.com/uc?export=download&id=16xAqp3w9XhGunshFMlyCkRqaklNFqjnM"
            };

            var categoryBeachToy = new Category()
            {
                Id = 4,
                Name = "Плажни играчи",
                ImageUrl = "https://drive.google.com/uc?export=download&id=167EWd3eT6d-rsAYwOf9F2Il61FydivXd"
            };

            var categorySwimmingEquipment = new Category()
            {
                Id = 5,
                Name = "Обурудвабе за плуване",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1A7wUFEC7laR2iQBYoMV2pryD4qW8D-gd"

            };

            var categoryFloaty = new Category()
            {
                Id = 6,
                Name = "Надувни",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1i9tFNjRi7OAW3lle188G4DMA2aMSjvix"
            };

            var categoryBall = new Category()
            {
                Id = 7,
                Name = "Топки",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1_2OH8K54pi-UsiYBCVjkLHRsYXTrp9Gy"
            };

            modelBuilder.Entity<Category>().HasData(categoryBag, categoryBall, categoryBeachToy, categoryFloaty, categorySwimmingEquipment, categoryTowel, categoryUmberlla);
        }

        public static void SeedManufacturers(this ModelBuilder modelBuilder)
        {
            var manufacturerVinex = new Manufacturer()
            {
                Id = 1,
                Name = "Vinex",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1ZbyZ2_AsBd35KVUfDOD-f2_D7h3134rl"
            };

            var manufacturerCoveri = new Manufacturer()
            {
                Id = 2,
                Name = "Coveri Collection",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1QALhuevKfNfYXoDy5BWciyCVmO0q0VSQ"
            };

            var manufacturerCPS = new Manufacturer()
            {
                Id = 3,
                Name = "CPS TOYS",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1FAraXYWyp2hs1Q_xATJAvz8rBc_kPWth"
            };

            var manufacturerDreamfox = new Manufacturer()
            {
                Id = 4,
                Name = "DREAMFOX",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1LRaxyxP3SGBDuWVctDyNM9XmYcSiJMWI"
            };

            var manufacturerIntex = new Manufacturer()
            {
                Id = 5,
                Name = "INTEX",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1roo-qFH5hU9-7240YmhdPuHkw-yWZxur"
            };

            var manufacturerShenzhen = new Manufacturer()
            {
                Id = 6,
                Name = "Shenzhen Befine Sports Goods",
                ImageUrl = "https://drive.google.com/uc?export=download&id=18njyWyS9wsNf-RxCBTVXbrJJuaslGi9_"
            };

            var manufacturerShui = new Manufacturer()
            {
                Id = 7,
                Name = "Shui Zhong Bao",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1U1erUAbbYU7DvFDgE0N2_ocWPle6JaD4"
            };

            var manufacturerStar = new Manufacturer()
            {
                Id = 8,
                Name = "Star",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1AjJF5Ee4jkE5oXTHaCTqT1lVL5RVd5Kg"
            };

            var manufacturerVanguard = new Manufacturer()
            {
                Id = 9,
                Name = "Vanguard Watersports",
                ImageUrl = "https://drive.google.com/uc?export=download&id=1VI10CAaFDeulnhDn99rv6_QgDdEGOfVy"
            };

            var manufacturerPublidea = new Manufacturer()
            {
                Id = 10,
                Name = "ПУБЛИИДЕЯ",
                ImageUrl = "https://drive.google.com/uc?export=download&id=12nW3Spi5yXjBb8-vtNZQsLwfpS8R95nm"
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1dfT4IZEew4CoddEGDakT-PBjw7yredbB",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1NMIiyeqiycf5b3uR53YIMXiBBWeJac16",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1u_kQta03e24rGbuGlml_sr6IeyTim7JK",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1spWbPR_54kid2eAV123eVgE_LruRdIHr",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1ToYajGycJZx6PokZvD0Da0H8y5LWh89N",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU",
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
                ImageUrl = "https://drive.google.com/uc?export=download&id=1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd",
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
