using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachEquipmentStore.Data.Migrations
{
    public partial class AddedCrationAndUpdateDatesToEntitiesAndPrimaryAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3f32193e-4a6d-4b79-b241-4d9aa6c2e8a5"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("77581a26-3535-45f3-b119-1e0daaf25941"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("a3771fd9-e6b0-4434-baca-d2721ee9c7e9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("78b8aac7-b589-46b2-a8a0-145cf77bc8df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0455d510-5fd7-4b29-bbf2-dd427f9c9d03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08b4327f-9eb3-4732-8058-483a9b70d765"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0cec1507-a629-4ed2-a483-fcc0ac84b4d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("125ac41c-65d1-401e-8825-46d193ff6cdd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1339da9b-82cb-4670-ba55-c49f281d1161"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1365c748-0341-4482-bfae-3f946ce74878"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18985da9-1607-4dff-88ba-6c6e0162d0ca"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18a5c412-1555-477f-b77d-7d493704f991"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1e2902c3-ca63-4a45-a4ae-aec0a5ace868"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("20d8f378-3729-4534-bcfa-5d0f5538b700"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("290d18a3-a466-4d06-bddb-cdb3e6f1afb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fe6af5f-baee-4dc1-9322-0e0e8fa5062e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("42b96eaf-05c5-4a4a-9288-9fa4f9b3435b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("491cd95b-92d9-47e1-8d2e-c89149d0fccc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4b71df7a-2824-4e9d-8162-f3e458dca235"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("523c9a67-0ac2-406c-aa8d-b6e7a33d208d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("55f69f5a-0e04-4d62-8f5b-45419cca2a0b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("56bf2f6f-1352-4eea-8da6-dba3256096b7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5c493ca0-eb60-4c01-b530-6d85a2ba2045"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d3fda40-ac4c-4552-9172-8aa1d8da4463"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("607c0c28-57cf-43cf-87c3-a3103fd248d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("651d8dc2-0d4a-4320-97e1-350d0b391714"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6dbcb1de-8082-4787-be51-98e1653bc601"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e872a30-de80-4db0-a0fb-bf9d28910fa8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("784106e3-be6b-4799-ba25-14ed4a03b0fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("850d9a82-cd77-400d-a9c0-d4c0186d9fd3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8fbc8a5e-3613-4b2a-b1da-5c1f072cddb4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("930a9416-2342-4f6c-aafb-d19ffb9919f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3a9b2d9-8682-4747-a083-abb0b1ac414b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a3d456ac-c3f3-43e2-92a4-0765b52b3c32"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a648aa92-4329-43d2-81eb-ec780b5b8f52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b09a64b5-dc68-46e1-a3fa-58dd7b2aa810"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c6e7bbb2-e3dc-44bf-9aca-5dfb86d5f153"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cefe05e5-157d-45f6-8f1a-da33bd6dbe91"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d04c49fb-3603-4f85-9828-a6d2f10c434e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d19e6ace-9306-4f06-9b17-50c7bb875c9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d490ab6a-c48e-4f5b-b49f-50efa22639dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e747a5f0-593e-482e-84fc-b9d02d6dbf37"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f10a4d58-7bd1-4388-9d11-fd7682cde5af"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f62d4be2-3ac0-4294-b11f-e4ae72b86cf4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("306517b5-0a82-4049-b784-70cdba612c98"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4722015-9eb1-46dd-bc52-7492fa5196d4"));

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ProductOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Manufacturers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Manufacturers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CartItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimaryAddress",
                table: "Addresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Addresses",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IsPrimaryAddress",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("306517b5-0a82-4049-b784-70cdba612c98"), 0, "c88ad39f-fdb0-4291-9747-17a9c55e9ec6", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEKWn3r0fCnyEGi4EYjUDZzPmVWFJLVmcwXPXvzsv85Gt/zlGWh9+/ggTfBzH5SsKjA==", "0888202449", false, "5baef856-f07b-4405-a454-b4bd33016ed0", false, "n.flacko@mail.com" },
                    { new Guid("78b8aac7-b589-46b2-a8a0-145cf77bc8df"), 0, "2fe40daa-f671-49d8-a5d7-7333b84408ee", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAENlm3ZeG9FntSUOvjjJkWw6aD75zQDcuDSmhdjCwpsIntTSJjQWjzhEl2x3d1pk5zQ==", "0885527733", false, "fe7fbb42-b2de-4d2d-bd75-ec4b6444d46b", false, "s.sarafov@mail.com" },
                    { new Guid("a4722015-9eb1-46dd-bc52-7492fa5196d4"), 0, "ad8e5d9a-4e5e-44d2-8ad6-a2cb01f033e0", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEEZm+P5F6T9gPXLgOp4xiNqYew9NKpWDlW/pLTt08siKKvQL7m6moU2HWJGecEMbRw==", "0876596224", false, "fe938581-f53b-4d95-951a-ebb07ce38ab6", false, "p.petrov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("0455d510-5fd7-4b29-bbf2-dd427f9c9d03"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/3h3MV9H/Ball-Miami.jpg", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("08b4327f-9eb3-4732-8058-483a9b70d765"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://i.ibb.co/9v2Qr7q/Swimming-Snorkel-Adults.jpg", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("0cec1507-a629-4ed2-a483-fcc0ac84b4d3"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/qnd7sVN/Ball-Water-Polo.jpg", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("125ac41c-65d1-401e-8825-46d193ff6cdd"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://i.ibb.co/y0PGtTq/Swimming-Goggles-Adult.jpg", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("1339da9b-82cb-4670-ba55-c49f281d1161"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://i.ibb.co/jf72Vv7/Toy-Water-Gun.jpg", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("1365c748-0341-4482-bfae-3f946ce74878"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://i.ibb.co/cw3903C/Toy-Bucket-Plain.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("18985da9-1607-4dff-88ba-6c6e0162d0ca"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://i.ibb.co/LPnV4tL/BagPoppy.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("18a5c412-1555-477f-b77d-7d493704f991"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://i.ibb.co/hZnkbPF/Swimming-Cap.jpg", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 },
                    { new Guid("1e2902c3-ca63-4a45-a4ae-aec0a5ace868"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://i.ibb.co/LkpTB85/Towel-Shark.jpg", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("20d8f378-3729-4534-bcfa-5d0f5538b700"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://i.ibb.co/86dL7D5/Toy-Bucket-Square.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("290d18a3-a466-4d06-bddb-cdb3e6f1afb6"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://i.ibb.co/y08sGtL/Towel-Plain-Blue.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("3fe6af5f-baee-4dc1-9322-0e0e8fa5062e"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://i.ibb.co/8bQ32MJ/Bag-Orchid.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("42b96eaf-05c5-4a4a-9288-9fa4f9b3435b"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/Sv0DmBy/Umbrella-Plants.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("491cd95b-92d9-47e1-8d2e-c89149d0fccc"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/HgMXxMb/Ball-Beach-Palms.jpg", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("4b71df7a-2824-4e9d-8162-f3e458dca235"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://i.ibb.co/BsKqYC7/Swimming-Goggles-Children.jpg", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("523c9a67-0ac2-406c-aa8d-b6e7a33d208d"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://i.ibb.co/Fn52s1n/Towel-Mermaid.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("55f69f5a-0e04-4d62-8f5b-45419cca2a0b"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://i.ibb.co/6Xj3SVh/Towel-Dolphin.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("56bf2f6f-1352-4eea-8da6-dba3256096b7"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/vvtYT55/Umberlla-Plams.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("5c493ca0-eb60-4c01-b530-6d85a2ba2045"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://i.ibb.co/cX57F5w/Toy-Bucket-Cartoon.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("5d3fda40-ac4c-4552-9172-8aa1d8da4463"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://i.ibb.co/WHxnBfw/Toy-Shovel.jpg", 1, "Vinex - Лопата за пясък", 3.20m, 40 },
                    { new Guid("607c0c28-57cf-43cf-87c3-a3103fd248d1"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://i.ibb.co/5vfvRwN/Toy-Bucket-Disney.jpg", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("651d8dc2-0d4a-4320-97e1-350d0b391714"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://i.ibb.co/K7LDFSq/Floaty-Wings.jpg", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("6dbcb1de-8082-4787-be51-98e1653bc601"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://i.ibb.co/H2wNG86/Floaty-Turtle-Babies.jpg", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("6e872a30-de80-4db0-a0fb-bf9d28910fa8"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://i.ibb.co/RhKgqG2/BagClams.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("784106e3-be6b-4799-ba25-14ed4a03b0fd"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/xFGh6x2/Swimming-Fins-Children.jpg", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("850d9a82-cd77-400d-a9c0-d4c0186d9fd3"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/6vxZ7wZ/Umbrella-Plain.jpg", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("8fbc8a5e-3613-4b2a-b1da-5c1f072cddb4"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://i.ibb.co/BZYy30X/Bag-Anchor.jpg", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("930a9416-2342-4f6c-aafb-d19ffb9919f1"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://i.ibb.co/j5MMjgM/Floaty-Unicorn.jpg", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("a3a9b2d9-8682-4747-a083-abb0b1ac414b"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://i.ibb.co/vZN4MxL/Swimming-Fins-Adult.jpg", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("a3d456ac-c3f3-43e2-92a4-0765b52b3c32"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://i.ibb.co/G0WBydZ/Floaty-Bed.jpg", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("a648aa92-4329-43d2-81eb-ec780b5b8f52"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://i.ibb.co/BCMvsmq/Towen-Plain-Pink.jpg", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("b09a64b5-dc68-46e1-a3fa-58dd7b2aa810"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://i.ibb.co/2MFJmGv/Bag-Watermellon.jpg", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("c6e7bbb2-e3dc-44bf-9aca-5dfb86d5f153"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://i.ibb.co/XpYVKZ4/Towen-Seaside.jpg", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("cefe05e5-157d-45f6-8f1a-da33bd6dbe91"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://i.ibb.co/pQJZTcp/Ball-Bora-Bora.jpg", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 },
                    { new Guid("d04c49fb-3603-4f85-9828-a6d2f10c434e"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://i.ibb.co/PsLkswc/Floaty-Crocodile.jpg", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("d19e6ace-9306-4f06-9b17-50c7bb875c9a"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://i.ibb.co/Ycbbt1d/Swimming-Mask.jpg", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 },
                    { new Guid("d490ab6a-c48e-4f5b-b49f-50efa22639dd"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://i.ibb.co/FYgw02D/Swimming-Snorkel-Children.jpg", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("e747a5f0-593e-482e-84fc-b9d02d6dbf37"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://i.ibb.co/ZmM9rZP/Umbrella-Starfish.jpg", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("f10a4d58-7bd1-4388-9d11-fd7682cde5af"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://i.ibb.co/7tz51mq/Floaty-Melon.jpg", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[] { new Guid("f62d4be2-3ac0-4294-b11f-e4ae72b86cf4"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://i.ibb.co/1dzzG9V/Floaty-Ice-Cream.jpg", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("3f32193e-4a6d-4b79-b241-4d9aa6c2e8a5"), new Guid("306517b5-0a82-4049-b784-70cdba612c98"), "ул. Обзорски Тигър № 33", "Обзор", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("77581a26-3535-45f3-b119-1e0daaf25941"), new Guid("a4722015-9eb1-46dd-bc52-7492fa5196d4"), "ул. Кракра №3", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("a3771fd9-e6b0-4434-baca-d2721ee9c7e9"), new Guid("306517b5-0a82-4049-b784-70cdba612c98"), "кв. Овча Купел, ул. Рачка №9", "София", 1000 });
        }
    }
}
