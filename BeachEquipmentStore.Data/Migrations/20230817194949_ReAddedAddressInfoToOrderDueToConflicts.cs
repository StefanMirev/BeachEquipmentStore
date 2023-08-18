using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachEquipmentStore.Data.Migrations
{
    public partial class ReAddedAddressInfoToOrderDueToConflicts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("196eab30-a57e-4a75-94f0-19c96c8937f0"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("3a7dab5f-31d2-48d1-a7f8-1179e3b7bfa7"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("f07beed3-f6fe-41c2-a70a-6d0d586b147d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("642e7e1c-ea78-4124-85c0-f607a5706700"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("082a1f85-d28b-4789-9cb5-307997144632"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("095a29d7-1cc7-43f5-ad1d-3ae5558ef2a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b275f43-678c-4bb6-8ce9-cd6ef6087f83"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("11b6f680-b148-4c74-82f1-40c1db8ce2c9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("19b65a72-8a1e-46cc-ae0b-ffba4697fbe6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2415e294-d06f-4e6d-b79a-6358487c3635"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2bee5b79-784e-4c72-bcc1-c817c208b114"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3ecdc0a6-d6d6-4463-95fb-ae2b800900e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("447801da-a3c9-48d9-8a4a-5da01f62f7e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46673771-b49b-4185-ba2c-e93890009ed4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("48f7985f-0012-44e6-bd70-8816f0873b87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("490b7384-ca60-4a46-bbcc-71aca872efd7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4f972698-1207-44cd-b724-360ad671c987"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5154ce81-61d4-4b1b-b775-5fb38ea32ef7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5536363a-a23a-43c9-89b1-98525284874e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57722833-6c0a-4710-be2d-98ed633da56a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5993cc6d-dec9-461c-babd-d18b3a51d284"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("730ecab6-8215-425d-b3e9-9574ca2421be"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75a3ac9b-d03d-44e3-b8d3-00260b122f9f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82933766-5629-4737-a89f-2cc790027fa4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8707da55-a71d-48d4-bfd2-f083288f8b12"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8dca73e9-97da-45ba-8b7a-df01e9b08822"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93953521-f62e-4578-9988-89beb6ac1541"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93d80c6e-75cd-4829-945b-952dde37ded1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a37414e9-8f50-4b1b-aa1e-0ca24bfaaa4f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a86aee9c-52fd-41c5-86f5-322eb68da6c8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c03f94d9-00ee-46d5-b65d-7056a36766a5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cbd1aae5-4c94-4183-aadd-7154b0e424aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cecfd1a6-5502-4c8a-9e8d-9fe025719f64"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d757677d-8011-45dd-8083-d75ab1800727"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ddfe34a2-651a-4a3d-8359-92fa217647cc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1cfea10-044e-4783-a48c-1d3b3da440f3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e500f8e6-28d7-494b-9dd1-3da0da83d708"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ecaf6a48-26ed-4ac5-bdd9-27b9f8733c8f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f23515f3-0bc2-406a-bea2-aa7299dd68ad"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f687edd0-6dfa-4e61-8f55-68f3a896bf0c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("faf19a48-6524-4a63-98c9-b06d8ec916ae"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc7d9ec7-7c96-4345-8d03-a9867a5fd263"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fe00e606-7acb-4af4-ab62-b09381fd5703"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffc514d6-7e9e-4c2b-9328-6b3bc2c82c86"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("54cffa15-f634-4229-a42b-a353a182eefb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cd897834-21d3-4e6c-86da-23b1d961363b"));

            migrationBuilder.AddColumn<string>(
                name: "AddressName",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TownName",
                table: "Orders",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("01e09b5f-de35-4afb-8c28-6788b4080809"), 0, "1a27e0f8-2084-4e3f-aecf-0442b0c58af8", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEGVPSZ3wcA5ujHR7zHPyVsKl3P+q1hT48qlqf+1+2Rio37SIJ93Rh+URGVepCqV5Ug==", "0876596224", false, null, false, "p.petrov@mail.com" },
                    { new Guid("8cbdaa45-24b8-4e18-8d44-1ad08cde7b26"), 0, "7c09f343-0c97-4c21-b692-fb3cfee69662", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAEMQ22VQeZg62mgpXo58BdzDLxcq742fzqVcDf4P4+cKiA0U9ICrYFJBdklQ9Pj+WGw==", "0885527733", false, null, false, "s.sarafov@mail.com" },
                    { new Guid("e73ae685-0dc3-4f0a-bbdb-eb92a3a38302"), 0, "7a9b0f15-aa7a-4ee7-a08e-7553ebb4e460", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAEKu2GwEMLT71QSG/xOEWACb12X1WUCdo7L3nYt5nw/DXTYSZoKiu9QVbrYZHW6Dd/A==", "0888202449", false, null, false, "n.flacko@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("009da7f8-e987-435c-8887-fe4a62ee018a"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://drive.google.com/uc?export=download&id=1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("14932280-4864-44e2-9d6b-2d23d0391f99"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://drive.google.com/uc?export=download&id=1spWbPR_54kid2eAV123eVgE_LruRdIHr", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("197b824d-d18c-4662-9849-01b3f17724d3"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://drive.google.com/uc?export=download&id=16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU", 1, "Vinex - Лопата за пясък", 3.20m, 40 },
                    { new Guid("1c70d25f-dd44-4fe5-ba43-609219297fb1"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1u_kQta03e24rGbuGlml_sr6IeyTim7JK", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("1ddb9590-894c-485d-968a-7ac0bd67e587"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://drive.google.com/uc?export=download&id=1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 },
                    { new Guid("23427f59-7cd2-4eaa-bda4-e09aa42d18d8"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("354ba31a-2aba-45f6-8a60-9a0d1cc98bea"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1ToYajGycJZx6PokZvD0Da0H8y5LWh89N", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("3677a066-6440-40d9-b4cc-2f2616318b28"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://drive.google.com/uc?export=download&id=1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("40b0afd7-501e-4a2d-9038-10d09bd3afd4"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://drive.google.com/uc?export=download&id=1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("57bce037-f81b-4883-9d2a-e8dc48adc037"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("587350d6-7969-4dab-a9f9-913d5d79dd11"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://drive.google.com/uc?export=download&id=1dfT4IZEew4CoddEGDakT-PBjw7yredbB", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("5d080500-1281-4cf2-abf0-ec63c2abceb0"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://drive.google.com/uc?export=download&id=1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("5e02ae59-e86f-492d-94d1-5362c9d05069"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://drive.google.com/uc?export=download&id=1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("64958846-c833-4edc-ba72-a6d092fd5cf0"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("762f2561-4de4-4179-b908-c3507aa620e4"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://drive.google.com/uc?export=download&id=1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("76758a76-d7c4-45c8-9f5d-ca782c94a433"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://drive.google.com/uc?export=download&id=1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("7b6abb1f-ba59-40dd-8540-2aa43886f680"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://drive.google.com/uc?export=download&id=12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("7bb74373-2401-4bee-be48-22f0cf100b62"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://drive.google.com/uc?export=download&id=1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("80b836f5-faf8-4eee-ba7f-09d3d6f0650e"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("84ad6191-f21d-4783-ab4a-cd136885ab2b"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://drive.google.com/uc?export=download&id=1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("925c3da1-b37a-4398-bf2a-efcfcc238c05"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1NMIiyeqiycf5b3uR53YIMXiBBWeJac16", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("934a68a2-5be6-4dd4-9df8-7b6a9857a9f1"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://drive.google.com/uc?export=download&id=1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("97d63ae5-55da-4907-a40e-ed1af60bc8c5"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("9bead1dc-9031-4fc4-bacf-db8f825c060b"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("9e7b82c3-c310-4bdf-9eb4-b537be932cbe"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://drive.google.com/uc?export=download&id=1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 },
                    { new Guid("a1ff79be-1978-42a6-8b25-a8e94c1e9489"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://drive.google.com/uc?export=download&id=1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("a211d265-b17c-47b9-b6be-7966f64bb225"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("a6c79a5d-795c-46c9-b462-9d6b82825ea8"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://drive.google.com/uc?export=download&id=1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("a8570f9c-0ae9-4970-9177-9498b8bc75bc"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://drive.google.com/uc?export=download&id=15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("aad6566a-3a90-40c6-b8f1-2c1d605ca160"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://drive.google.com/uc?export=download&id=1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("c98c048c-2130-4c0d-a0b4-7950a253272b"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://drive.google.com/uc?export=download&id=1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 },
                    { new Guid("cca15e42-1118-4892-95fb-1155af07bab2"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://drive.google.com/uc?export=download&id=1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("d84b9683-c6b9-427f-b05d-cf48f61309de"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("d9797e25-2e54-470a-b3f2-9ae963acb0e6"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 },
                    { new Guid("e4147d80-1ebf-4789-88cf-477ed3261637"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://drive.google.com/uc?export=download&id=1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("e5481ad4-3900-41ef-b2fd-b16d973aa36c"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("e7718124-5086-4767-97a2-8b8e5804e089"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("f2bd2bc0-ab2e-4193-99e0-3f75f591395f"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://drive.google.com/uc?export=download&id=1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("feb5050e-3a39-4c41-8e06-5aea9474b550"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://drive.google.com/uc?export=download&id=1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[] { new Guid("ffbba546-22dd-4d18-9c64-51057d29896c"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://drive.google.com/uc?export=download&id=1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("19aed63f-d616-4a8a-beb9-08cd7c58c4aa"), new Guid("e73ae685-0dc3-4f0a-bbdb-eb92a3a38302"), "ул. Обзорски Тигър № 33", "Обзор", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("b6ba34c2-a655-4b75-ab54-3bc43322cee6"), new Guid("01e09b5f-de35-4afb-8c28-6788b4080809"), "ул. Кракра №3", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("ec3442f0-c6bc-437b-bd60-1fcb31269c3e"), new Guid("e73ae685-0dc3-4f0a-bbdb-eb92a3a38302"), "кв. Овча Купел, ул. Рачка №9", "София", 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("19aed63f-d616-4a8a-beb9-08cd7c58c4aa"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("b6ba34c2-a655-4b75-ab54-3bc43322cee6"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("ec3442f0-c6bc-437b-bd60-1fcb31269c3e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8cbdaa45-24b8-4e18-8d44-1ad08cde7b26"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("009da7f8-e987-435c-8887-fe4a62ee018a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14932280-4864-44e2-9d6b-2d23d0391f99"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("197b824d-d18c-4662-9849-01b3f17724d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1c70d25f-dd44-4fe5-ba43-609219297fb1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1ddb9590-894c-485d-968a-7ac0bd67e587"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("23427f59-7cd2-4eaa-bda4-e09aa42d18d8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("354ba31a-2aba-45f6-8a60-9a0d1cc98bea"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3677a066-6440-40d9-b4cc-2f2616318b28"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("40b0afd7-501e-4a2d-9038-10d09bd3afd4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("57bce037-f81b-4883-9d2a-e8dc48adc037"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("587350d6-7969-4dab-a9f9-913d5d79dd11"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d080500-1281-4cf2-abf0-ec63c2abceb0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5e02ae59-e86f-492d-94d1-5362c9d05069"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("64958846-c833-4edc-ba72-a6d092fd5cf0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("762f2561-4de4-4179-b908-c3507aa620e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("76758a76-d7c4-45c8-9f5d-ca782c94a433"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b6abb1f-ba59-40dd-8540-2aa43886f680"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bb74373-2401-4bee-be48-22f0cf100b62"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("80b836f5-faf8-4eee-ba7f-09d3d6f0650e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("84ad6191-f21d-4783-ab4a-cd136885ab2b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("925c3da1-b37a-4398-bf2a-efcfcc238c05"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("934a68a2-5be6-4dd4-9df8-7b6a9857a9f1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("97d63ae5-55da-4907-a40e-ed1af60bc8c5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9bead1dc-9031-4fc4-bacf-db8f825c060b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9e7b82c3-c310-4bdf-9eb4-b537be932cbe"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1ff79be-1978-42a6-8b25-a8e94c1e9489"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a211d265-b17c-47b9-b6be-7966f64bb225"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a6c79a5d-795c-46c9-b462-9d6b82825ea8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a8570f9c-0ae9-4970-9177-9498b8bc75bc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aad6566a-3a90-40c6-b8f1-2c1d605ca160"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c98c048c-2130-4c0d-a0b4-7950a253272b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cca15e42-1118-4892-95fb-1155af07bab2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d84b9683-c6b9-427f-b05d-cf48f61309de"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9797e25-2e54-470a-b3f2-9ae963acb0e6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e4147d80-1ebf-4789-88cf-477ed3261637"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5481ad4-3900-41ef-b2fd-b16d973aa36c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7718124-5086-4767-97a2-8b8e5804e089"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f2bd2bc0-ab2e-4193-99e0-3f75f591395f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("feb5050e-3a39-4c41-8e06-5aea9474b550"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ffbba546-22dd-4d18-9c64-51057d29896c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("01e09b5f-de35-4afb-8c28-6788b4080809"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e73ae685-0dc3-4f0a-bbdb-eb92a3a38302"));

            migrationBuilder.DropColumn(
                name: "AddressName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TownName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("54cffa15-f634-4229-a42b-a353a182eefb"), 0, "ebe98c5a-aaf6-4a7a-a121-a94af9d1776a", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "N.FLACKO@MAIL.COM", "N.FLACKO@MAIL.COM", "AQAAAAEAACcQAAAAENSIzYcsghZKV8R8cD3yZUDCaO+zTsMkLbar0B73X/SwZwJL6FHjnKDnLASz/DZ8XQ==", "0888202449", false, null, false, "n.flacko@mail.com" },
                    { new Guid("642e7e1c-ea78-4124-85c0-f607a5706700"), 0, "52a4984e-75e7-40fa-b085-8af183fad87e", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "S.SARAFOV@MAIL.COM", "S.SARAFOV@MAIL.COM", "AQAAAAEAACcQAAAAEJVMYvH2DA4kuCzDPPIfTBPbAhhHIDSeekAbJdOtkR/5foXH2Dl6ePRSN9rDSDbRhQ==", "0885527733", false, null, false, "s.sarafov@mail.com" },
                    { new Guid("cd897834-21d3-4e6c-86da-23b1d961363b"), 0, "c518004c-e2bb-4ad0-8d9d-8b9a943ddc7a", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "P.PETROV@MAIL.COM", "P.PETROV@MAIL.COM", "AQAAAAEAACcQAAAAEDp5cEL7aEK0UvHYByHCDbYal2yjK9/1ZUoo+8LbKqjYWpzwZ8Z33h16inauAwOfgQ==", "0876596224", false, null, false, "p.petrov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("082a1f85-d28b-4789-9cb5-307997144632"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A", 10, "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("095a29d7-1cc7-43f5-ad1d-3ae5558ef2a5"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://drive.google.com/uc?export=download&id=1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82", 5, "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("0b275f43-678c-4bb6-8ce9-cd6ef6087f83"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://drive.google.com/uc?export=download&id=1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p", 6, "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("11b6f680-b148-4c74-82f1-40c1db8ce2c9"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU", 8, "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("19b65a72-8a1e-46cc-ae0b-ffba4697fbe6"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://drive.google.com/uc?export=download&id=1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM", 5, "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 },
                    { new Guid("2415e294-d06f-4e6d-b79a-6358487c3635"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://drive.google.com/uc?export=download&id=1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM", 4, "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("2bee5b79-784e-4c72-bcc1-c817c208b114"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://drive.google.com/uc?export=download&id=1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz", 6, "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 },
                    { new Guid("3ecdc0a6-d6d6-4463-95fb-ae2b800900e5"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://drive.google.com/uc?export=download&id=1spWbPR_54kid2eAV123eVgE_LruRdIHr", 5, "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("447801da-a3c9-48d9-8a4a-5da01f62f7e4"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://drive.google.com/uc?export=download&id=15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("46673771-b49b-4185-ba2c-e93890009ed4"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://drive.google.com/uc?export=download&id=12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH", 2, "Плажна Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("48f7985f-0012-44e6-bd70-8816f0873b87"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://drive.google.com/uc?export=download&id=1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ", 7, "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 },
                    { new Guid("490b7384-ca60-4a46-bbcc-71aca872efd7"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("4f972698-1207-44cd-b724-360ad671c987"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm", 9, "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("5154ce81-61d4-4b1b-b775-5fb38ea32ef7"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1", 10, "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("5536363a-a23a-43c9-89b1-98525284874e"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://drive.google.com/uc?export=download&id=1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux", 6, "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("57722833-6c0a-4710-be2d-98ed633da56a"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG", 1, "Vinex - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("5993cc6d-dec9-461c-babd-d18b3a51d284"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ", 10, "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("730ecab6-8215-425d-b3e9-9574ca2421be"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1ToYajGycJZx6PokZvD0Da0H8y5LWh89N", 8, "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("75a3ac9b-d03d-44e3-b8d3-00260b122f9f"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd", 8, "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("82933766-5629-4737-a89f-2cc790027fa4"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.", "https://drive.google.com/uc?export=download&id=1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("8707da55-a71d-48d4-bfd2-f083288f8b12"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://drive.google.com/uc?export=download&id=1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1", 5, "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("8dca73e9-97da-45ba-8b7a-df01e9b08822"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://drive.google.com/uc?export=download&id=1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("93953521-f62e-4578-9988-89beb6ac1541"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://drive.google.com/uc?export=download&id=1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL", 3, "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("93d80c6e-75cd-4829-945b-952dde37ded1"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/uc?export=download&id=1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI", 9, "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("a37414e9-8f50-4b1b-aa1e-0ca24bfaaa4f"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/uc?export=download&id=1NMIiyeqiycf5b3uR53YIMXiBBWeJac16", 10, "Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("a86aee9c-52fd-41c5-86f5-322eb68da6c8"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://drive.google.com/uc?export=download&id=1u_kQta03e24rGbuGlml_sr6IeyTim7JK", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("c03f94d9-00ee-46d5-b65d-7056a36766a5"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://drive.google.com/uc?export=download&id=1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP", 6, "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("cbd1aae5-4c94-4183-aadd-7154b0e424aa"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://drive.google.com/uc?export=download&id=16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU", 1, "Vinex - Лопата за пясък", 3.20m, 40 },
                    { new Guid("cecfd1a6-5502-4c8a-9e8d-9fe025719f64"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://drive.google.com/uc?export=download&id=1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("d757677d-8011-45dd-8083-d75ab1800727"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://drive.google.com/uc?export=download&id=1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX", 6, "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("ddfe34a2-651a-4a3d-8359-92fa217647cc"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://drive.google.com/uc?export=download&id=1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS", 1, "Vinex - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("e1cfea10-044e-4783-a48c-1d3b3da440f3"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://drive.google.com/uc?export=download&id=1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU", 1, "Vinex - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("e500f8e6-28d7-494b-9dd1-3da0da83d708"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://drive.google.com/uc?export=download&id=1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("ecaf6a48-26ed-4ac5-bdd9-27b9f8733c8f"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://drive.google.com/uc?export=download&id=1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e", 2, "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("f23515f3-0bc2-406a-bea2-aa7299dd68ad"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://drive.google.com/uc?export=download&id=1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR", 5, "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("f687edd0-6dfa-4e61-8f55-68f3a896bf0c"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://drive.google.com/uc?export=download&id=1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB", 7, "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("faf19a48-6524-4a63-98c9-b06d8ec916ae"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://drive.google.com/uc?export=download&id=1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF", 4, "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("fc7d9ec7-7c96-4345-8d03-a9867a5fd263"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/uc?export=download&id=1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4", 8, "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 },
                    { new Guid("fe00e606-7acb-4af4-ab62-b09381fd5703"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://drive.google.com/uc?export=download&id=1dfT4IZEew4CoddEGDakT-PBjw7yredbB", 4, "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerId", "Name", "Price", "Stock" },
                values: new object[] { new Guid("ffc514d6-7e9e-4c2b-9328-6b3bc2c82c86"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://drive.google.com/uc?export=download&id=1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys", 9, "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("196eab30-a57e-4a75-94f0-19c96c8937f0"), new Guid("cd897834-21d3-4e6c-86da-23b1d961363b"), "ул. Кракра №3", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("3a7dab5f-31d2-48d1-a7f8-1179e3b7bfa7"), new Guid("54cffa15-f634-4229-a42b-a353a182eefb"), "кв. Овча Купел, ул. Рачка №9", "София", 1000 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CustomerId", "Name", "Town", "ZipCode" },
                values: new object[] { new Guid("f07beed3-f6fe-41c2-a70a-6d0d586b147d"), new Guid("54cffa15-f634-4229-a42b-a353a182eefb"), "ул. Обзорски Тигър № 33", "Обзор", 1000 });
        }
    }
}
