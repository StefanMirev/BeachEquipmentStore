using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachEquipmentStore.Data.Migrations
{
    public partial class RemovedDeliveryAndInvoiceEntitiesAndAddedTheirPropsToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Delivery_DeliveryId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("456f69db-d921-4a7a-9192-91c999f18630"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("7439caac-51df-4fab-a961-6cebfc673e0e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("c1875788-fbd4-45dc-9ef3-12180ced6e37"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5782db19-484f-4a53-95ef-737c078ffc85"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0276433b-ac3d-4f65-94dd-9f3a6c21f81c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c3a7267-1781-44de-9685-0c7ed2b1904b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14d02d32-1062-46f6-980b-967074767197"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("152d4bd3-50d5-43c6-81df-277492819724"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("323b3fb7-7c55-41ff-a6cc-92bd65ca6c69"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3bed584a-2bef-4273-8af0-44d68e6222d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("43f218cb-c755-4f6f-a21d-580e4662cc75"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("483d3254-6edc-4a0f-92fd-38e1fab92147"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("54be0afb-5ca3-4952-8acb-10531fb41b69"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5ca0e2b2-e073-4f88-ac22-19c0c8cc1a4b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6068b931-607d-4c76-a092-b4dd96a5e803"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64a23533-426e-4f86-9c86-c9cb922ccbae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6bcdff10-1bd7-41a9-beff-dac01770f7fd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f99cfb2-c6e4-4394-a30c-94f7f27073cc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7193cc52-f814-4d6d-971e-b7540a113155"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("720eb3a4-0342-4366-94eb-627fa6df5c9b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("781524bc-f5fe-43fb-a2e0-d03c4e105a6d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cf6e55c-4b8e-4a77-a727-9c69edb554f6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7ef26416-a164-4c36-a0ec-f6acf34f4b89"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8125ddd1-2204-4a67-af19-dd48b2b1d4b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84143b97-8118-494c-8221-ee013a2624de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90405e7d-8d8b-4c15-84b5-aec552852906"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("91be7e4c-90bd-4475-9aaa-117f3daa4f5e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("945a612a-9526-41f7-ad73-442bb61f2f93"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95634ddf-e61f-47dc-850a-06c162f5328e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("99d87409-f5db-4ca6-8ab2-3fcf0f72fff3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a6081e7-0d3e-4f27-b5d3-a54fd3223330"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9dca588f-7302-4c20-85b0-ce1bac5b39cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a219801f-7e7d-4bbf-9bab-65db61c80930"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a4bc438f-9843-4273-939b-0300ea1935ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b9ee4c2a-ca60-45b7-a7c2-3562a65413bb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bad27a0a-f67d-434b-849d-3b2f3a6f1141"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c96adea1-9cd1-4320-bf12-2b41f3c45650"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cbd7e66a-cfe5-43b5-b856-3488f7d94a55"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dbcf10a8-8e97-4cb2-a850-b4e55b4e9a3b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0b0ef72-b90c-4d23-b5fb-32c835c1995e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4a32b16-21b3-4016-964a-8f564d69e592"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e59264b6-8652-456d-91ef-727079ef4b66"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb0d758c-9bdb-4048-883c-428c2f04a7c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("efbcab1b-b26e-4036-8d0f-de4e3147898a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7452c5f5-129b-4a4a-a27b-23fde138d1e7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd2db4d7-59ec-470e-b324-26f3a9fe8c4e"));

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShippingDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("15bcb714-7459-4823-aa10-13c3f7eaa7d9"), 0, "f01ff8d0-52b7-4536-97df-e836243b6efd", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEPLPyvXIezkHN99yjaLoL0rmTaUmzdzTd8PBfF5xV7NmycunxYtg9GNNUQepEuqh8g==", "0876596224", false, null, false, "p.petrov@mail.com" },
                    { new Guid("8af86ac5-a04d-43f7-b9d8-80103571b85e"), 0, "2f2740aa-c22d-4196-9b80-d808fa2d47c5", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAEANYwHfEqKGd1cCZ1/tScgc5IVtB3k05q2fWFqapHtXqWmSx6CiQVlLzT90cLn7DOg==", "0885527733", false, null, false, "s.sarafov@mail.com" },
                    { new Guid("9aa1ce27-2438-48a9-a15c-2e77789632b2"), 0, "b9c4a747-66a9-4247-b342-91cb31fee983", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEEz3WEI5t5jOVtJ054B4054dO6//ZL/1/+GPIez6O3KWfUzIphVbn7BKV+tQRpeY8g==", "0888202449", false, null, false, "n.flacko@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("0c2dc64e-bc02-42cb-a022-c4b655952c52"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("1254fcb5-25b6-4073-98ab-4355d568aaa3"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://drive.google.com/uc?export=download&id=1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("13093b91-283d-431f-bf75-5c0eca8616a8"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://drive.google.com/uc?export=download&id=1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("15523f24-a93a-4324-8287-b937288912e5"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://drive.google.com/uc?export=download&id=1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("17466f3e-96b6-4849-932b-b5a984c741db"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://drive.google.com/uc?export=download&id=1dfT4IZEew4CoddEGDakT-PBjw7yredbB", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("1bd65455-b1d6-4a10-ac6b-ae8ca6110293"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://drive.google.com/uc?export=download&id=1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 },
                    { new Guid("1c92caba-eb8f-4dfb-b7b3-88c33620019a"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://drive.google.com/uc?export=download&id=1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 },
                    { new Guid("26e75fa6-0c4b-4f61-a4c7-f764ef61ab61"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://drive.google.com/uc?export=download&id=16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU", 1, "Vinex - Лопата за пясък", 3.20m, 40 },
                    { new Guid("277a0760-8b1f-44c7-bec0-b46869543b86"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://drive.google.com/uc?export=download&id=1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 },
                    { new Guid("2b2e2922-0e1f-4b3c-93e3-610dadf35bfe"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://drive.google.com/uc?export=download&id=1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("2b70d7dc-d758-4159-8e02-e0db34c78758"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("37a2d803-23c5-4d68-a684-3b2d87d64bbd"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://drive.google.com/uc?export=download&id=1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("449795d6-0eed-46cc-adf1-4f6ddf8088e6"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://drive.google.com/uc?export=download&id=1spWbPR_54kid2eAV123eVgE_LruRdIHr", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("4579110d-ed62-4ead-9ce2-4e14bd5f00e4"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://drive.google.com/uc?export=download&id=1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("47906bda-8aee-4af9-b97a-ad63cf85f064"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://drive.google.com/uc?export=download&id=1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("4995562b-3a5e-4bd8-85db-c45d0e5c7e48"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("53c63190-9daa-40e0-93b0-d57a92312db1"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://drive.google.com/uc?export=download&id=1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("564df454-cc4c-48b2-9e4b-d0ffbf9f7489"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://drive.google.com/uc?export=download&id=1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("59121ab8-69e5-4478-bec7-3cd1ef20c81c"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1NMIiyeqiycf5b3uR53YIMXiBBWeJac16", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("5e584d77-2723-4cb0-a233-f145b47b2ef7"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("63cfd2e8-598f-4479-9d5a-deea6c54f980"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("7897f639-e081-4554-abb6-056a836e3f44"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://drive.google.com/uc?export=download&id=12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("7f15b120-10d2-4d8a-8069-1c09e961fc38"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("86734748-9644-4021-b290-9b0b17aee804"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("86e0cf9a-963d-4ef9-b75d-23afb1bc7234"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://drive.google.com/uc?export=download&id=1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("938f2c91-d41d-48a6-92fb-c0445977cf20"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://drive.google.com/uc?export=download&id=1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("985819fa-905c-4747-ae75-a5c5245b3e31"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://drive.google.com/uc?export=download&id=1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("9b56fdfd-5cb1-4b28-99d5-7f13be3e61c4"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("a311b71c-659f-4b1b-87c4-3aa7d6bbc7e9"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1ToYajGycJZx6PokZvD0Da0H8y5LWh89N", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("aeedf1dd-d700-4006-80d4-7cc44b07c29b"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://drive.google.com/uc?export=download&id=1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("bc2295bb-04fb-4e7e-b17a-c6fe780f4b2a"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://drive.google.com/uc?export=download&id=1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("cbbd922f-496f-4a6a-88d7-91b5e84f99bf"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://drive.google.com/uc?export=download&id=1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("daa24eea-eed3-47d9-9bf7-a607ed1c242f"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://drive.google.com/uc?export=download&id=15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("db7c0173-47dd-4ed2-a303-8611a4354512"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("e0fad13e-f966-44ce-9f07-59df9965fc45"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://drive.google.com/uc?export=download&id=1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("e68e54f3-e441-4fd6-b0a0-a79183964ed4"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1u_kQta03e24rGbuGlml_sr6IeyTim7JK", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("eca9327b-0a19-4b76-9950-937f6a88f4cf"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://drive.google.com/uc?export=download&id=1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("f1609e4e-8719-4e3f-8bd6-ed5738727ddc"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("fae43385-8474-4826-bf13-0ed65640a40b"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://drive.google.com/uc?export=download&id=1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[] { new Guid("fe91ace3-b96f-470a-840d-ff0576ee3a8b"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("0cf51f30-3e66-4d7e-9dcd-03386a9deb06"), new Guid("15bcb714-7459-4823-aa10-13c3f7eaa7d9"), "ул. Кракра №3", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("39ca37aa-7faa-4ca8-8b68-cc28265e269c"), new Guid("9aa1ce27-2438-48a9-a15c-2e77789632b2"), "ул. Обзорски Тигър № 33", "Обзор", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("d4afb857-ff55-4a87-95c3-a1f73584c263"), new Guid("9aa1ce27-2438-48a9-a15c-2e77789632b2"), "кв. Овча Купел, ул. Рачка №9", "София", 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("0cf51f30-3e66-4d7e-9dcd-03386a9deb06"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("39ca37aa-7faa-4ca8-8b68-cc28265e269c"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("d4afb857-ff55-4a87-95c3-a1f73584c263"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8af86ac5-a04d-43f7-b9d8-80103571b85e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c2dc64e-bc02-42cb-a022-c4b655952c52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1254fcb5-25b6-4073-98ab-4355d568aaa3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("13093b91-283d-431f-bf75-5c0eca8616a8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15523f24-a93a-4324-8287-b937288912e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("17466f3e-96b6-4849-932b-b5a984c741db"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1bd65455-b1d6-4a10-ac6b-ae8ca6110293"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c92caba-eb8f-4dfb-b7b3-88c33620019a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("26e75fa6-0c4b-4f61-a4c7-f764ef61ab61"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("277a0760-8b1f-44c7-bec0-b46869543b86"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b2e2922-0e1f-4b3c-93e3-610dadf35bfe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b70d7dc-d758-4159-8e02-e0db34c78758"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37a2d803-23c5-4d68-a684-3b2d87d64bbd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("449795d6-0eed-46cc-adf1-4f6ddf8088e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4579110d-ed62-4ead-9ce2-4e14bd5f00e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("47906bda-8aee-4af9-b97a-ad63cf85f064"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4995562b-3a5e-4bd8-85db-c45d0e5c7e48"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("53c63190-9daa-40e0-93b0-d57a92312db1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("564df454-cc4c-48b2-9e4b-d0ffbf9f7489"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("59121ab8-69e5-4478-bec7-3cd1ef20c81c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e584d77-2723-4cb0-a233-f145b47b2ef7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("63cfd2e8-598f-4479-9d5a-deea6c54f980"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7897f639-e081-4554-abb6-056a836e3f44"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7f15b120-10d2-4d8a-8069-1c09e961fc38"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86734748-9644-4021-b290-9b0b17aee804"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86e0cf9a-963d-4ef9-b75d-23afb1bc7234"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("938f2c91-d41d-48a6-92fb-c0445977cf20"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("985819fa-905c-4747-ae75-a5c5245b3e31"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9b56fdfd-5cb1-4b28-99d5-7f13be3e61c4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a311b71c-659f-4b1b-87c4-3aa7d6bbc7e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aeedf1dd-d700-4006-80d4-7cc44b07c29b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bc2295bb-04fb-4e7e-b17a-c6fe780f4b2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cbbd922f-496f-4a6a-88d7-91b5e84f99bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("daa24eea-eed3-47d9-9bf7-a607ed1c242f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("db7c0173-47dd-4ed2-a303-8611a4354512"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0fad13e-f966-44ce-9f07-59df9965fc45"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e68e54f3-e441-4fd6-b0a0-a79183964ed4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eca9327b-0a19-4b76-9950-937f6a88f4cf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1609e4e-8719-4e3f-8bd6-ed5738727ddc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fae43385-8474-4826-bf13-0ed65640a40b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe91ace3-b96f-470a-840d-ff0576ee3a8b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("15bcb714-7459-4823-aa10-13c3f7eaa7d9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9aa1ce27-2438-48a9-a15c-2e77789632b2"));

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrackingNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5782db19-484f-4a53-95ef-737c078ffc85"), 0, "9a988d26-6f05-4430-b296-ad3692a9a5ea", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAEB4CZAaJTTSxoK2YToKjOha1p/UzaO+/0Ju5mmFG5kz6XW3C1ad8EM/2hOrLWl8ugg==", "0885527733", false, null, false, "s.sarafov@mail.com" },
                    { new Guid("7452c5f5-129b-4a4a-a27b-23fde138d1e7"), 0, "abcf2db2-cdbd-43a3-a7e4-bfde4ae669db", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEFpM115LgyRgGTl3b038KT1J7vbZw0V6fGS7faaIg68b0jTCmfQWmgwqXyNYR4H0ug==", "0888202449", false, null, false, "n.flacko@mail.com" },
                    { new Guid("cd2db4d7-59ec-470e-b324-26f3a9fe8c4e"), 0, "21e10688-cded-459f-8eb8-f80240c18fa8", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEO29ZV8Or8bDfgcjbABUPsQ7xHXZSicC5ZdMRm0qQj1FXDMum7Tg/nwKlN2DD2ZraA==", "0876596224", false, null, false, "p.petrov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("0276433b-ac3d-4f65-94dd-9f3a6c21f81c"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://drive.google.com/uc?export=download&id=1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("0c3a7267-1781-44de-9685-0c7ed2b1904b"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://drive.google.com/uc?export=download&id=1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("14d02d32-1062-46f6-980b-967074767197"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://drive.google.com/uc?export=download&id=1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 },
                    { new Guid("152d4bd3-50d5-43c6-81df-277492819724"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://drive.google.com/uc?export=download&id=1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 },
                    { new Guid("323b3fb7-7c55-41ff-a6cc-92bd65ca6c69"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1u_kQta03e24rGbuGlml_sr6IeyTim7JK", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("3bed584a-2bef-4273-8af0-44d68e6222d7"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://drive.google.com/uc?export=download&id=1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("43f218cb-c755-4f6f-a21d-580e4662cc75"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://drive.google.com/uc?export=download&id=1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("483d3254-6edc-4a0f-92fd-38e1fab92147"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://drive.google.com/uc?export=download&id=1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("54be0afb-5ca3-4952-8acb-10531fb41b69"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("5ca0e2b2-e073-4f88-ac22-19c0c8cc1a4b"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://drive.google.com/uc?export=download&id=1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("6068b931-607d-4c76-a092-b4dd96a5e803"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://drive.google.com/uc?export=download&id=1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("64a23533-426e-4f86-9c86-c9cb922ccbae"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1ToYajGycJZx6PokZvD0Da0H8y5LWh89N", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("6bcdff10-1bd7-41a9-beff-dac01770f7fd"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("6f99cfb2-c6e4-4394-a30c-94f7f27073cc"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://drive.google.com/uc?export=download&id=1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("7193cc52-f814-4d6d-971e-b7540a113155"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1NMIiyeqiycf5b3uR53YIMXiBBWeJac16", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("720eb3a4-0342-4366-94eb-627fa6df5c9b"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://drive.google.com/uc?export=download&id=1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("781524bc-f5fe-43fb-a2e0-d03c4e105a6d"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("7cf6e55c-4b8e-4a77-a727-9c69edb554f6"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://drive.google.com/uc?export=download&id=1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("7ef26416-a164-4c36-a0ec-f6acf34f4b89"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 },
                    { new Guid("8125ddd1-2204-4a67-af19-dd48b2b1d4b4"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://drive.google.com/uc?export=download&id=1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("84143b97-8118-494c-8221-ee013a2624de"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://drive.google.com/uc?export=download&id=1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("90405e7d-8d8b-4c15-84b5-aec552852906"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://drive.google.com/uc?export=download&id=1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("91be7e4c-90bd-4475-9aaa-117f3daa4f5e"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://drive.google.com/uc?export=download&id=1dfT4IZEew4CoddEGDakT-PBjw7yredbB", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("945a612a-9526-41f7-ad73-442bb61f2f93"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("95634ddf-e61f-47dc-850a-06c162f5328e"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://drive.google.com/uc?export=download&id=1spWbPR_54kid2eAV123eVgE_LruRdIHr", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("99d87409-f5db-4ca6-8ab2-3fcf0f72fff3"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://drive.google.com/uc?export=download&id=1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("9a6081e7-0d3e-4f27-b5d3-a54fd3223330"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("9dca588f-7302-4c20-85b0-ce1bac5b39cb"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("a219801f-7e7d-4bbf-9bab-65db61c80930"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://drive.google.com/uc?export=download&id=1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("a4bc438f-9843-4273-939b-0300ea1935ad"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://drive.google.com/uc?export=download&id=1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 },
                    { new Guid("b9ee4c2a-ca60-45b7-a7c2-3562a65413bb"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://drive.google.com/uc?export=download&id=16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU", 1, "Vinex - Лопата за пясък", 3.20m, 40 },
                    { new Guid("bad27a0a-f67d-434b-849d-3b2f3a6f1141"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("c96adea1-9cd1-4320-bf12-2b41f3c45650"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://drive.google.com/uc?export=download&id=1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 },
                    { new Guid("cbd7e66a-cfe5-43b5-b856-3488f7d94a55"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://drive.google.com/uc?export=download&id=15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("dbcf10a8-8e97-4cb2-a850-b4e55b4e9a3b"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("e0b0ef72-b90c-4d23-b5fb-32c835c1995e"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://drive.google.com/uc?export=download&id=1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("e4a32b16-21b3-4016-964a-8f564d69e592"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("e59264b6-8652-456d-91ef-727079ef4b66"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("eb0d758c-9bdb-4048-883c-428c2f04a7c8"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://drive.google.com/uc?export=download&id=1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[] { new Guid("efbcab1b-b26e-4036-8d0f-de4e3147898a"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://drive.google.com/uc?export=download&id=12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("456f69db-d921-4a7a-9192-91c999f18630"), new Guid("cd2db4d7-59ec-470e-b324-26f3a9fe8c4e"), "ул. Кракра №3", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("7439caac-51df-4fab-a961-6cebfc673e0e"), new Guid("7452c5f5-129b-4a4a-a27b-23fde138d1e7"), "кв. Овча Купел, ул. Рачка №9", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("c1875788-fbd4-45dc-9ef3-12180ced6e37"), new Guid("7452c5f5-129b-4a4a-a27b-23fde138d1e7"), "ул. Обзорски Тигър № 33", "Обзор", 1000 });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_CustomerId",
                table: "Delivery",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Delivery_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
