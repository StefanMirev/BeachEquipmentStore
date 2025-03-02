using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachEquipmentStore.Data.Migrations
{
    public partial class ChangedZipCodeTypeAddressAndOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2ba8d222-9501-490e-b4d3-fbd0e53131f0"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a0eb0f58-00f3-4f00-91ba-bc6ed1aa18db"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("de3bb989-6d49-4f11-8113-ca0d70bfccea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c721b444-85f6-4ed0-ab38-4ee57164d4bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("00595e61-e366-4ba0-8912-5755aab38300"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08b77dd4-fec1-4e24-8108-64583423f04e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ba1f449-3e50-4022-b0a4-a83a110ef4d2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0f30c4aa-1624-415f-9c88-dea00f5964ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("313e431e-65fc-4c1e-9d9d-363b764d4e7f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("33070e7c-055f-4a8b-86f8-7a64bcfada22"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("377b49a5-5dad-4c8c-a11c-496cc3868810"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("387795ce-3a33-4864-b3e9-7c5f93779d36"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("397b42b7-2ccb-43e9-882c-bc5a58f4ca56"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3e66d821-1bbb-446f-adb4-c480b09512cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3f987ddd-517e-4093-868a-24fd8504c45d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("419de771-8456-44a7-854d-c32c7d29c66a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("429ac0e3-d016-4daa-a146-6b33ac1107a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("458353ba-4042-43fb-bdd4-74ce6d320df4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4e87766e-246f-470b-bec7-e537fc0085fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e64307e-5501-43ff-9730-51a9c7a42468"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("703f98c9-c87d-4254-8971-852c1cd950dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("775ba055-eec9-416e-8dfd-ea1cc680bb3d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7c091438-9bf9-4c4f-9b03-8a03b041b1a0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8187e83a-bf2f-4076-b5bd-151aa009ada3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("81bd866b-81ed-4f27-a9d0-bbd7c35badc7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("881f3736-b18b-4462-855c-ef04a4179bd2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f21f133-0bee-499a-99cc-00ca1da2f602"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f53bbac-ae6b-4064-bc63-4fc58cf3c11d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a05a0b7e-cbf4-4616-92e3-328c3f0ae779"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a19aa385-e48c-4c74-966c-7fa1c6e2a7a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b15ebf26-a758-4da1-866f-f11ca8c4b845"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b2d7ca4d-7fe3-4fee-b789-7e680c8ba4f6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b6c24e23-f742-4532-9521-e47e869ed830"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7aff813-19de-4a67-bb59-4d1ea6db7118"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c7350597-79cd-45ac-9ff1-e9635b57966a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d63b2f1f-32e4-478b-a757-2d579755e948"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d8fe7d3f-e197-4d5f-8f41-d95487419c2d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db8990fc-bbf1-45e0-9732-a64bfe743024"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ddef6760-a0f6-4323-badc-259a5727ea6a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0de7594-2437-44d7-9c8e-74cf3e319dcc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec2a7b54-28ed-42e1-be4f-a1560e7dd450"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ed0a1b2c-c31a-42aa-932b-3fdc56c7030d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fcc42273-0a13-4c94-9de8-6511cd55ec54"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fee21581-2eca-47a1-afe6-6f50842aa026"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("854fc105-371f-40cb-a425-1e7bc09f0be8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e1e31b12-9ad2-43c2-adf1-24d1ebf5eb51"));

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("1333e5de-de27-4dd9-8c3b-9729120875f7"), 0, "34b7f4f8-a7fe-4dde-acd9-e4f26968a788", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAECkra6l6ZCm+BRsTxNN64SbS/1NbFMcgB10e49eT1dV1w6cdBaEMpNzp5yH8Fv/rSw==", "0885527733", false, "5cdbb0ee-93fc-49d0-b57a-7312cfda0b21", false, null, "s.sarafov@mail.com" },
                    { new Guid("354b218f-737e-4e15-8ac6-31f2ddce1bf3"), 0, "9a173d26-4ddd-4bd7-8533-6ea1a10b4473", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEKnj2nwrKaD7S86jlgw2dLP6v/WE1aocaebZWKL+vKDHHsMRIs3+fK3/ukM1w3YN0Q==", "0888202449", false, "b6e005a3-5608-4fac-8023-6857b09acb8a", false, null, "n.flacko@mail.com" },
                    { new Guid("d5890133-9d6c-45f5-9cf1-ed5bec5283a5"), 0, "1240383c-44fa-49c7-b851-860c8a1a5903", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEBR4hxae70IUFqd1svQqQS983RCgg1ZhfWE4Ib3YosA2WZdz66Vn+X9oE3scHED1lQ==", "0876596224", false, "92dde85d-d454-4218-a668-cf6c788b9823", false, null, "p.petrov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedAt", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("007d4b15-2323-4da0-8e03-f8f632aba51a"), 42181, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/vZN4MxL/Swimming-Fins-Adult.jpg", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40, null },
                    { new Guid("05db1855-26d4-4760-93f9-296ea43f84cb"), 56720, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://i.ibb.co/8bQ32MJ/Bag-Orchid.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("095b8e46-6ffd-43d4-ad52-8479a5f548ad"), 58786, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://i.ibb.co/K7LDFSq/Floaty-Wings.jpg", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10, null },
                    { new Guid("0d04a781-f5d4-49af-8b98-60c8c8e6d359"), 58546, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://i.ibb.co/PsLkswc/Floaty-Crocodile.jpg", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15, null },
                    { new Guid("0daf0630-579c-4645-ad7c-61c1a6052b59"), 42178, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://i.ibb.co/Ycbbt1d/Swimming-Mask.jpg", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30, null },
                    { new Guid("1c241822-55c4-48d1-b3d2-87feb90225f1"), 31386, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://i.ibb.co/BsKqYC7/Swimming-Goggles-Children.jpg", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30, null },
                    { new Guid("2725955c-ffc7-4fb4-a34e-811282428939"), 57523, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://i.ibb.co/y08sGtL/Towel-Plain-Blue.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50, null },
                    { new Guid("27908932-1e83-4cd0-b876-865eec6dfa1b"), 58922, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://i.ibb.co/XpYVKZ4/Towen-Seaside.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100, null },
                    { new Guid("498c2c9a-e2d8-4740-ba15-4accc3efaeb4"), 44442, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/Sv0DmBy/Umbrella-Plants.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25, null },
                    { new Guid("4b3b7fe3-576b-4fca-bc19-86ccc3e546f5"), 49230, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://i.ibb.co/j5MMjgM/Floaty-Unicorn.jpg", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15, null },
                    { new Guid("4ddf3c93-3654-4985-94e0-290c20273de0"), 44444, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/ZmM9rZP/Umbrella-Starfish.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25, null },
                    { new Guid("5e13589a-8e62-44da-af19-61b3292327ab"), 101019, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/pQJZTcp/Ball-Bora-Bora.jpg", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10, null },
                    { new Guid("63af8bca-e175-46a4-bdcf-5f04958ec93c"), 18040, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://i.ibb.co/5vfvRwN/Toy-Bucket-Disney.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16, null },
                    { new Guid("6450b670-e79b-4c28-a4a3-05cc126431b7"), 58762, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://i.ibb.co/1dzzG9V/Floaty-Ice-Cream.jpg", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10, null },
                    { new Guid("7313bd44-543c-4093-95d5-c0985f49f211"), 56113, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://i.ibb.co/H2wNG86/Floaty-Turtle-Babies.jpg", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15, null },
                    { new Guid("746b797d-1aa5-4ea1-96f8-1963a9291c6a"), 59139, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/xFGh6x2/Swimming-Fins-Children.jpg", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50, null },
                    { new Guid("765548ca-b74c-4da4-a53d-232aad39237c"), 56721, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://i.ibb.co/RhKgqG2/BagClams.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("76ebac44-2902-4282-aee5-006ac8678949"), 57526, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://i.ibb.co/BCMvsmq/Towen-Plain-Pink.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50, null },
                    { new Guid("76f5ee0a-1e97-4e0c-97bf-841c68cbac16"), 33306, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://i.ibb.co/86dL7D5/Toy-Bucket-Square.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15, null },
                    { new Guid("7b9b3a77-6eaa-4fa1-8a8f-9c395d71b7dd"), 56718, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://i.ibb.co/2MFJmGv/Bag-Watermellon.jpg", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("7cf4cc85-7726-449f-ae09-94f44ed9adf2"), 59720, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://i.ibb.co/G0WBydZ/Floaty-Bed.jpg", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10, null },
                    { new Guid("8097c563-06f0-4472-94a5-f9d5bf37b92a"), 42172, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://i.ibb.co/9v2Qr7q/Swimming-Snorkel-Adults.jpg", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20, null },
                    { new Guid("8f62190f-c09c-464c-a199-35cfe91a446b"), 58849, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://i.ibb.co/jf72Vv7/Toy-Water-Gun.jpg", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40, null },
                    { new Guid("983a9b95-75cd-47ef-911b-6c3a78b26259"), 36727, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://i.ibb.co/7tz51mq/Floaty-Melon.jpg", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12, null },
                    { new Guid("9b3202a6-2e34-4841-a44c-92e9dc10aaa9"), 101090, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/HgMXxMb/Ball-Beach-Palms.jpg", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10, null },
                    { new Guid("ad373b6b-0893-4404-9dff-2f788521c4a9"), 55555, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/6vxZ7wZ/Umbrella-Plain.jpg", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25, null },
                    { new Guid("b0e7d14a-1d5d-405e-ba98-a70188034032"), 57532, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://i.ibb.co/LkpTB85/Towel-Shark.jpg", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50, null },
                    { new Guid("bc3237b3-09f8-40a0-97e2-2adda45fb558"), 38527, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://i.ibb.co/6Xj3SVh/Towel-Dolphin.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100, null },
                    { new Guid("c0e261a9-8661-4e1b-8ac2-60ac39285cd0"), 10805, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://i.ibb.co/cX57F5w/Toy-Bucket-Cartoon.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16, null },
                    { new Guid("d0eb795e-9b38-4215-8831-45e09f16118e"), 42174, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://i.ibb.co/FYgw02D/Swimming-Snorkel-Children.jpg", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30, null },
                    { new Guid("d415fd07-661b-423b-8ff5-0a58582d41fe"), 17005, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://i.ibb.co/cw3903C/Toy-Bucket-Plain.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16, null },
                    { new Guid("d515c7bf-78e6-4479-9fcf-d3a8f0efdca2"), 101011, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/qnd7sVN/Ball-Water-Polo.jpg", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10, null },
                    { new Guid("d9cc394b-9919-4ee9-9b5c-64e39c402c53"), 56723, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://i.ibb.co/LPnV4tL/BagPoppy.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("e58d6b02-631e-4bf3-80c4-1e26ec31268a"), 56130, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://i.ibb.co/Fn52s1n/Towel-Mermaid.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100, null },
                    { new Guid("e70a2fd2-9fa0-4579-84b9-d2025953dd84"), 101730, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/3h3MV9H/Ball-Miami.jpg", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10, null },
                    { new Guid("e7bf66dd-5890-4db5-912a-04a6c4b3c4d7"), 51375, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://i.ibb.co/y0PGtTq/Swimming-Goggles-Adult.jpg", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20, null },
                    { new Guid("ef5c2e7c-61d4-460f-9145-4132bb35dd0f"), 36113, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://i.ibb.co/WHxnBfw/Toy-Shovel.jpg", 1, "Vinex - Лопата за пясък", 3.20m, 40, null },
                    { new Guid("fc01887b-10ae-4112-9c98-c4cc1abdfd9d"), 24040, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://i.ibb.co/hZnkbPF/Swimming-Cap.jpg", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70, null },
                    { new Guid("fd6517bf-24cd-4321-8619-08268770171b"), 56724, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://i.ibb.co/BZYy30X/Bag-Anchor.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedAt", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { new Guid("ff134386-e823-41c3-9ef3-13127fba3ce1"), 44443, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/vvtYT55/Umberlla-Plams.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25, null });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("2140c7a6-de56-4a10-9554-c30148a6ae2d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d5890133-9d6c-45f5-9cf1-ed5bec5283a5"), false, "ул. Кракра №3", "София", null, "1000" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("93a57f0e-b56f-4f84-8927-441c446c4e5e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("354b218f-737e-4e15-8ac6-31f2ddce1bf3"), false, "ул. Обзорски Тигър № 33", "Обзор", null, "1000" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("af41d4e4-34cb-4192-b849-a9d81fea7cca"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("354b218f-737e-4e15-8ac6-31f2ddce1bf3"), false, "кв. Овча Купел, ул. Рачка №9", "София", null, "1000" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("2140c7a6-de56-4a10-9554-c30148a6ae2d"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("93a57f0e-b56f-4f84-8927-441c446c4e5e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("af41d4e4-34cb-4192-b849-a9d81fea7cca"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1333e5de-de27-4dd9-8c3b-9729120875f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("007d4b15-2323-4da0-8e03-f8f632aba51a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("05db1855-26d4-4760-93f9-296ea43f84cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("095b8e46-6ffd-43d4-ad52-8479a5f548ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d04a781-f5d4-49af-8b98-60c8c8e6d359"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0daf0630-579c-4645-ad7c-61c1a6052b59"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c241822-55c4-48d1-b3d2-87feb90225f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2725955c-ffc7-4fb4-a34e-811282428939"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27908932-1e83-4cd0-b876-865eec6dfa1b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("498c2c9a-e2d8-4740-ba15-4accc3efaeb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b3b7fe3-576b-4fca-bc19-86ccc3e546f5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ddf3c93-3654-4985-94e0-290c20273de0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e13589a-8e62-44da-af19-61b3292327ab"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("63af8bca-e175-46a4-bdcf-5f04958ec93c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6450b670-e79b-4c28-a4a3-05cc126431b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7313bd44-543c-4093-95d5-c0985f49f211"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("746b797d-1aa5-4ea1-96f8-1963a9291c6a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("765548ca-b74c-4da4-a53d-232aad39237c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76ebac44-2902-4282-aee5-006ac8678949"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76f5ee0a-1e97-4e0c-97bf-841c68cbac16"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b9b3a77-6eaa-4fa1-8a8f-9c395d71b7dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf4cc85-7726-449f-ae09-94f44ed9adf2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8097c563-06f0-4472-94a5-f9d5bf37b92a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f62190f-c09c-464c-a199-35cfe91a446b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("983a9b95-75cd-47ef-911b-6c3a78b26259"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b3202a6-2e34-4841-a44c-92e9dc10aaa9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ad373b6b-0893-4404-9dff-2f788521c4a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b0e7d14a-1d5d-405e-ba98-a70188034032"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc3237b3-09f8-40a0-97e2-2adda45fb558"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0e261a9-8661-4e1b-8ac2-60ac39285cd0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d0eb795e-9b38-4215-8831-45e09f16118e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d415fd07-661b-423b-8ff5-0a58582d41fe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d515c7bf-78e6-4479-9fcf-d3a8f0efdca2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9cc394b-9919-4ee9-9b5c-64e39c402c53"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e58d6b02-631e-4bf3-80c4-1e26ec31268a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e70a2fd2-9fa0-4579-84b9-d2025953dd84"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7bf66dd-5890-4db5-912a-04a6c4b3c4d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ef5c2e7c-61d4-460f-9145-4132bb35dd0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc01887b-10ae-4112-9c98-c4cc1abdfd9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fd6517bf-24cd-4321-8619-08268770171b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ff134386-e823-41c3-9ef3-13127fba3ce1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("354b218f-737e-4e15-8ac6-31f2ddce1bf3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d5890133-9d6c-45f5-9cf1-ed5bec5283a5"));

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Addresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("854fc105-371f-40cb-a425-1e7bc09f0be8"), 0, "0da4c43a-1526-4d5e-b799-e11445ea075a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEG23hUPlU0KheyLQsxVagoBV0RUSZNU8aXdVEcfC74K8WILq2sFjrrtOSq4K9D1Xjg==", "0888202449", false, "d4d59c00-d681-44e3-9a7e-c1734f07bcd6", false, null, "n.flacko@mail.com" },
                    { new Guid("c721b444-85f6-4ed0-ab38-4ee57164d4bf"), 0, "07e1a1e6-7c29-4bc5-8e72-918a23ba7c73", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAEOc28g0b33ZYvtZ63pHKSidUK3eBldyCLydcpC4SMJFBoXeyy4IhfmMG+BkE0NxgmA==", "0885527733", false, "45fff9bc-612f-44cc-9134-02aa661e4ed9", false, null, "s.sarafov@mail.com" },
                    { new Guid("e1e31b12-9ad2-43c2-adf1-24d1ebf5eb51"), 0, "44afbfa8-f120-4e24-a420-76c25a7f672c", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEOdrJFPIFwjCUxAj1QV+y2yGOcc8tKSiPSeyy9PnyB17xlTug6UHPSffR6jtgNz6ww==", "0876596224", false, "df33cc02-7b8f-4500-807a-9fc4237610c0", false, null, "p.petrov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedAt", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("00595e61-e366-4ba0-8912-5755aab38300"), 49230, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://i.ibb.co/j5MMjgM/Floaty-Unicorn.jpg", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15, null },
                    { new Guid("08b77dd4-fec1-4e24-8108-64583423f04e"), 59720, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://i.ibb.co/G0WBydZ/Floaty-Bed.jpg", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10, null },
                    { new Guid("0ba1f449-3e50-4022-b0a4-a83a110ef4d2"), 56723, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://i.ibb.co/LPnV4tL/BagPoppy.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("0f30c4aa-1624-415f-9c88-dea00f5964ab"), 56113, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://i.ibb.co/H2wNG86/Floaty-Turtle-Babies.jpg", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15, null },
                    { new Guid("313e431e-65fc-4c1e-9d9d-363b764d4e7f"), 57523, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://i.ibb.co/y08sGtL/Towel-Plain-Blue.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50, null },
                    { new Guid("33070e7c-055f-4a8b-86f8-7a64bcfada22"), 56721, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://i.ibb.co/RhKgqG2/BagClams.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("377b49a5-5dad-4c8c-a11c-496cc3868810"), 10805, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://i.ibb.co/cX57F5w/Toy-Bucket-Cartoon.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16, null },
                    { new Guid("387795ce-3a33-4864-b3e9-7c5f93779d36"), 42172, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://i.ibb.co/9v2Qr7q/Swimming-Snorkel-Adults.jpg", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20, null },
                    { new Guid("397b42b7-2ccb-43e9-882c-bc5a58f4ca56"), 101011, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/qnd7sVN/Ball-Water-Polo.jpg", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10, null },
                    { new Guid("3e66d821-1bbb-446f-adb4-c480b09512cf"), 44443, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/vvtYT55/Umberlla-Plams.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25, null },
                    { new Guid("3f987ddd-517e-4093-868a-24fd8504c45d"), 24040, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://i.ibb.co/hZnkbPF/Swimming-Cap.jpg", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70, null },
                    { new Guid("419de771-8456-44a7-854d-c32c7d29c66a"), 101019, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/pQJZTcp/Ball-Bora-Bora.jpg", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10, null },
                    { new Guid("429ac0e3-d016-4daa-a146-6b33ac1107a0"), 58922, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://i.ibb.co/XpYVKZ4/Towen-Seaside.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100, null },
                    { new Guid("458353ba-4042-43fb-bdd4-74ce6d320df4"), 36113, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://i.ibb.co/WHxnBfw/Toy-Shovel.jpg", 1, "Vinex - Лопата за пясък", 3.20m, 40, null },
                    { new Guid("4e87766e-246f-470b-bec7-e537fc0085fe"), 18040, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://i.ibb.co/5vfvRwN/Toy-Bucket-Disney.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16, null },
                    { new Guid("5e64307e-5501-43ff-9730-51a9c7a42468"), 51375, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://i.ibb.co/y0PGtTq/Swimming-Goggles-Adult.jpg", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20, null },
                    { new Guid("703f98c9-c87d-4254-8971-852c1cd950dd"), 58849, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://i.ibb.co/jf72Vv7/Toy-Water-Gun.jpg", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40, null },
                    { new Guid("775ba055-eec9-416e-8dfd-ea1cc680bb3d"), 59139, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/xFGh6x2/Swimming-Fins-Children.jpg", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50, null },
                    { new Guid("7c091438-9bf9-4c4f-9b03-8a03b041b1a0"), 56130, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://i.ibb.co/Fn52s1n/Towel-Mermaid.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100, null },
                    { new Guid("8187e83a-bf2f-4076-b5bd-151aa009ada3"), 42178, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://i.ibb.co/Ycbbt1d/Swimming-Mask.jpg", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30, null },
                    { new Guid("81bd866b-81ed-4f27-a9d0-bbd7c35badc7"), 58762, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://i.ibb.co/1dzzG9V/Floaty-Ice-Cream.jpg", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10, null },
                    { new Guid("881f3736-b18b-4462-855c-ef04a4179bd2"), 56720, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://i.ibb.co/8bQ32MJ/Bag-Orchid.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("8f21f133-0bee-499a-99cc-00ca1da2f602"), 33306, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://i.ibb.co/86dL7D5/Toy-Bucket-Square.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15, null },
                    { new Guid("8f53bbac-ae6b-4064-bc63-4fc58cf3c11d"), 58546, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://i.ibb.co/PsLkswc/Floaty-Crocodile.jpg", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15, null },
                    { new Guid("a05a0b7e-cbf4-4616-92e3-328c3f0ae779"), 31386, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://i.ibb.co/BsKqYC7/Swimming-Goggles-Children.jpg", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30, null },
                    { new Guid("a19aa385-e48c-4c74-966c-7fa1c6e2a7a3"), 58786, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://i.ibb.co/K7LDFSq/Floaty-Wings.jpg", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10, null },
                    { new Guid("b15ebf26-a758-4da1-866f-f11ca8c4b845"), 42174, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://i.ibb.co/FYgw02D/Swimming-Snorkel-Children.jpg", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30, null },
                    { new Guid("b2d7ca4d-7fe3-4fee-b789-7e680c8ba4f6"), 56724, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://i.ibb.co/BZYy30X/Bag-Anchor.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("b6c24e23-f742-4532-9521-e47e869ed830"), 55555, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/6vxZ7wZ/Umbrella-Plain.jpg", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25, null },
                    { new Guid("b7aff813-19de-4a67-bb59-4d1ea6db7118"), 17005, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://i.ibb.co/cw3903C/Toy-Bucket-Plain.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16, null },
                    { new Guid("c7350597-79cd-45ac-9ff1-e9635b57966a"), 38527, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://i.ibb.co/6Xj3SVh/Towel-Dolphin.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100, null },
                    { new Guid("d63b2f1f-32e4-478b-a757-2d579755e948"), 42181, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/vZN4MxL/Swimming-Fins-Adult.jpg", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40, null },
                    { new Guid("d8fe7d3f-e197-4d5f-8f41-d95487419c2d"), 101090, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/HgMXxMb/Ball-Beach-Palms.jpg", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10, null },
                    { new Guid("db8990fc-bbf1-45e0-9732-a64bfe743024"), 57532, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://i.ibb.co/LkpTB85/Towel-Shark.jpg", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50, null },
                    { new Guid("ddef6760-a0f6-4323-badc-259a5727ea6a"), 101730, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/3h3MV9H/Ball-Miami.jpg", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10, null },
                    { new Guid("e0de7594-2437-44d7-9c8e-74cf3e319dcc"), 44444, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/ZmM9rZP/Umbrella-Starfish.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25, null },
                    { new Guid("ec2a7b54-28ed-42e1-be4f-a1560e7dd450"), 56718, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://i.ibb.co/2MFJmGv/Bag-Watermellon.jpg", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30, null },
                    { new Guid("ed0a1b2c-c31a-42aa-932b-3fdc56c7030d"), 57526, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://i.ibb.co/BCMvsmq/Towen-Plain-Pink.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50, null },
                    { new Guid("fcc42273-0a13-4c94-9de8-6511cd55ec54"), 44442, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/Sv0DmBy/Umbrella-Plants.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "CreatedAt", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { new Guid("fee21581-2eca-47a1-afe6-6f50842aa026"), 36727, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://i.ibb.co/7tz51mq/Floaty-Melon.jpg", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12, null });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("2ba8d222-9501-490e-b4d3-fbd0e53131f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("854fc105-371f-40cb-a425-1e7bc09f0be8"), false, "ул. Обзорски Тигър № 33", "Обзор", null, 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("a0eb0f58-00f3-4f00-91ba-bc6ed1aa18db"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("854fc105-371f-40cb-a425-1e7bc09f0be8"), false, "кв. Овча Купел, ул. Рачка №9", "София", null, 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsPrimaryAddress", "Name", "Town", "UpdatedAt", "ZipCode" },
                values: new object[] { new Guid("de3bb989-6d49-4f11-8113-ca0d70bfccea"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e1e31b12-9ad2-43c2-adf1-24d1ebf5eb51"), false, "ул. Кракра №3", "София", null, 1000 });
        }
    }
}
