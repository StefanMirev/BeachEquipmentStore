using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachEquipmentStore.Data.Migrations
{
    public partial class SeededDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0f145dcb-a166-41e9-82f2-c814f8a93e9d"), 0, "b01f8e0e-2173-4e97-8e60-59b6b3a3db4b", "n.flacko@mail.com", false, "Nicko", "Flacko", false, null, "n.flacko@mail.com", "n.flacko@mail.com", "AQAAAAEAACcQAAAAEM+lL3TdxwC4mbFiKjdzM24KzADTdM1W6sL6O6pjeBjy2vhf3X/VT3Vy3vamUfquhA==", null, false, null, false, "n.flacko@mail.com" },
                    { new Guid("8cee753d-4b6e-42fb-9841-2e8b5e9c6eb8"), 0, "904707bd-512d-47e0-9b22-388c90a107f4", "p.petrov@mail.com", false, "Petar", "Petrov", false, null, "p.petrov@mail.com", "p.petrov@mail.com", "AQAAAAEAACcQAAAAEADcAIUnt8CbMMBFsJwuF/Y9RNHKLKQ7hoERlzx2SeBLONmR3G0oZ61fmk7M1tb25g==", null, false, null, false, "p.petrov@mail.com" },
                    { new Guid("c3e98537-479f-4936-8af4-066181b328f7"), 0, "b4554082-d4ed-4566-abbc-f451d4401bfd", "s.sarafov@mail.com", false, "Stamat", "Sarafov", false, null, "s.sarafov@mail.com", "s.sarafov@mail.com", "AQAAAAEAACcQAAAAEAgpDepUbl1V3qZ7QKvKPEq1pN9JTv0yRNOfeXHZybsviTmQLPE7ceYKyFhT6N8jIA==", null, false, null, false, "s.sarafov@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "Towel", null },
                    { 2, "Umbrella", null },
                    { 3, "Bag", null },
                    { 4, "Beach Toy", null },
                    { 5, "Swimming Equipment", null },
                    { 6, "Floaty", null },
                    { 7, "Ball", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "CategoryId", "Description", "ImageUrl", "ManufacturerName", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("01a4f244-7f2d-4cfb-bf9a-4838625adb74"), 101090, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/file/d/15hRmMAyIkXWcYw8PEVU8OTuRHWIsKVIU/view?usp=drive_link", "Star", "Star  - Волейболна топка Beach Volley, 21см", 6.30m, 10 },
                    { new Guid("06baa812-69ef-4f26-b14c-66a6d6d86561"), 42178, 5, "Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно", "https://drive.google.com/file/d/1sJxETpJF_FUSyeCO1b4WZXIrgvZjMfQz/view?usp=drive_link", "Shenzhen Befine Sports Goods", "Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider", 33.00m, 30 },
                    { new Guid("09fcc4af-5067-46f2-93c0-514bb44b864c"), 31386, 5, "Плувни очила, силикон, цветни, здраво прелепващи 13 см. ", "https://drive.google.com/file/d/1nS0CyhxqSuY2D1R_jaxCbN9IiSI4F62p/view?usp=drive_link", "Shenzhen Befine Sports Goods", "Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles", 4.50m, 30 },
                    { new Guid("0a54ed73-d034-48ec-8794-421eb75c7027"), 101011, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/file/d/1Oygb8XuKN23Jloa9nCfWbEOGiiZmOhdd/view?usp=drive_link", "Star", "Star  - Волейболна топка Water Polo, 21см", 6.15m, 10 },
                    { new Guid("2306717d-3d88-4d9f-ab28-7848f5189433"), 10805, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.", "https://drive.google.com/file/d/1JjBWp9oO8b9j8EOH9c4LKPg1NrsLoUQG/view?usp=drive_link", "Bhalla International", "Bhalla International - Комплект кофичка за пясък Дисни", 10.50m, 16 },
                    { new Guid("232921d1-fba1-42af-a876-3622ac713711"), 101019, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/file/d/1o-NUO6kzfL2bRghOK21Nu0M9qdduDpW4/view?usp=drive_link", "Star", "Star  - Волейболна топка Bora Bora, 21см", 6.30m, 10 },
                    { new Guid("243ae335-fd35-4100-b196-c659e1b3dce2"), 44444, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/file/d/1S-SjmPB2kfixmsIlSWYhYJch_9xqVK0A/view?usp=drive_link", "ПУБЛИИДЕЯ", "Плажен чадър ПУБЛИИДЕЯ, морски звезди", 6.80m, 25 },
                    { new Guid("249313f1-1422-445d-8a16-ef811da3dee9"), 42181, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/file/d/1wfcyQO9cHxFYAf-XXfE0DJQjeojKCEnm/view?usp=drive_link", "Vanguard Watersports", "Плавници Vanguard Watersports Mega Sport, 39-43 номер", 19.50m, 40 },
                    { new Guid("25b81a48-248a-4d3a-97dd-177e946785dd"), 33306, 4, " Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.", "https://drive.google.com/file/d/1LbA7ETiJBsPWSoxG2jRZz9BHZd91mqHU/view?usp=drive_link", "Bhalla International", "Bhalla International - Комплект кофичка за пясък Дисни", 6.40m, 15 },
                    { new Guid("28276ce4-ac70-4d41-a2ac-a6c63a5ce112"), 59720, 6, "Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.", "https://drive.google.com/file/d/1lJ8i3WaCL53t0pOO5F_7eJxxdWaH5v82/view?usp=drive_link", "INTEX", "Надуваем дюшек INTEX, 183 х 69 х 25см", 10.60m, 10 },
                    { new Guid("2b8477b5-3308-410c-8ea5-3800ef44fe2a"), 36727, 6, "Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.", "https://drive.google.com/file/d/1JkLtx0CX48PtHvBwe9wHKmOULBSh_zNJ/view?usp=drive_link", "Shui Zhong Bao", "Надуваем поясн Диня Shui Zhong Bao Watermelon", 4.20m, 12 },
                    { new Guid("36aa7b4e-c14b-47f7-af8f-a0fe1dd33bff"), 42172, 5, "Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.", "https://drive.google.com/file/d/1C9Y9oufHYoCX_vLi11RMZdvCpO9QIMTX/view?usp=drive_link", "Shenzhen Befine Sports Goods", "Шнорхел Shenzhen Befine Sports Goods Easy-Flow", 5.50m, 20 },
                    { new Guid("37065dd4-f1ff-436e-908f-4f5487cd0086"), 36113, 4, "Лопата за пясък, дървена дръжка с дължина 62 см.", "https://drive.google.com/file/d/16sOlSA_p-RfVy4nrdsvQWqsFxhyf1rhU/view?usp=drive_link", "Bhalla International", "Bhalla International - Лопата за пясък", 3.20m, 40 },
                    { new Guid("510438af-3648-4a5d-830d-bed1ffbecd4d"), 42174, 5, "Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.", "https://drive.google.com/file/d/1e-Uh-JIgG65zKjRMtJjnEkkIabVNMNAP/view?usp=drive_link", "Shenzhen Befine Sports Goods", "Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo", 3.65m, 30 },
                    { new Guid("564924bd-cd48-41e5-9229-497a2b846220"), 101730, 7, "Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.", "https://drive.google.com/file/d/1ToYajGycJZx6PokZvD0Da0H8y5LWh89N/view?usp=drive_link", "Star", "Star  - Волейболна топка Miami Beach, 21см", 6.30m, 10 },
                    { new Guid("60adf7ac-0f74-44d9-849b-6469f526fa6e"), 56130, 1, "Микрофибърна плажна хавлия с изоображение на русалка и надписи.", "https://drive.google.com/file/d/1Yp_6Hqt9ZonWq42xy8fU--Uacx1tkxXH/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 75 x 150 cm.", 5.00m, 100 },
                    { new Guid("6f7428c8-aacb-4a82-aef3-e5e4ec29cc4a"), 57523, 1, "Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.", "https://drive.google.com/file/d/1ZJXJwrHzVu1ptT0qk99CKB3IAJv324dd/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("73b3dd8b-09e3-4e5a-92b6-cbca72e3a3e1"), 56720, 3, "Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.", "https://drive.google.com/file/d/1adYxmlrmBP1xxUCMSUHr1hzxgyB_V27e/view?usp=drive_link", "Coveri Collection", "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("77966e06-3756-4dd3-b20e-42ad2686fc1d"), 57532, 1, "Памучна детска плажна хавлия с изообразени акула и рибки. Грамаж: 380 гр.", "https://drive.google.com/file/d/1PYh4hEw0qfRH8mDV5fsetWNsk7M5O2pM/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 75 x 170 cm.", 12.00m, 50 },
                    { new Guid("79450932-c1cd-4758-a39c-b987ca763718"), 24040, 5, "Шапка за плуване, текстил. Размери: 21 х 12 см.", "https://drive.google.com/file/d/1UdlrRM5yS8ly-EHrcnxlAjZ9o6gyVJys/view?usp=drive_link", "Vanguard Watersports", "Шапка за плуване Vanguard Watersports, текстил", 1.35m, 70 },
                    { new Guid("816e6dc9-395c-4564-bab6-d9bcb9f8d288"), 58786, 6, "Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.", "https://drive.google.com/file/d/1hp_tZy8e3a2Cftw8b92YW8Gzop0-0wU1/view?usp=drive_link", "INTEXT", "Надуваем дюшек Ангелски крила INTEX", 47.70m, 10 },
                    { new Guid("85e004c2-97b3-435d-811c-134531801a70"), 56718, 3, "Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.", "https://drive.google.com/file/d/12boBcMRZIpNh9RHSF3hyMASdtpKv8gMH/view?usp=drive_link", "Coveri Collection", "Плажна Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("8c025ee1-1118-43a0-b7f9-5ce0d2d4615a"), 44443, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/file/d/1oVbyay6s_Ntr_sj_A18X_FO0w_WmdrVQ/view?usp=drive_link", "ПУБЛИИДЕЯ", "Плажен чадър ПУБЛИИДЕЯ, палми", 6.80m, 25 },
                    { new Guid("8cedf6ed-c6e2-4b8d-ac59-10b3b04a4327"), 18040, 4, "Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.", "https://drive.google.com/file/d/1sQ_5ozky2WPN8SW5c9bMvr-zPV2U9atS/view?usp=drive_link", "Bhalla International", "Bhalla International - Комплект кофичка за пясък Дисни", 8.25m, 16 },
                    { new Guid("a353b862-3b99-448f-a079-4d633edc83c7"), 56723, 3, "Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.,,53х37х19 см.", "https://drive.google.com/file/d/1EI1p_s8zneNfoFyswCEYo-LBG97G5foZ/view?usp=drive_link", "Coveri Collection", "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("a5514002-86f9-4ac5-bb16-6be6321541dc"), 17005, 4, "Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.", "https://drive.google.com/file/d/1u_kQta03e24rGbuGlml_sr6IeyTim7JK/view?usp=drive_link", "Bhalla International", "Bhalla International - Комплект кофичка за пясък Дисни", 6.00m, 16 },
                    { new Guid("aceee187-c44c-4634-8913-9f301c237656"), 58849, 4, "Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!", "https://drive.google.com/file/d/1aasYu2UAFcDPLa6fV-pcOjlpOCXf1xgL/view?usp=drive_link", "CPS TOYS", "Воден пистолет CPS TOYS 50см", 7.40m, 40 },
                    { new Guid("b7a153ae-a939-4818-98c9-e8020025556d"), 49230, 6, "Кaквo мoжe дa нaпpaви плувaнeтo в бaceйнa или в мopeтo oщe пo-зaбaвнo? Нaпpимep aкo дeтeтo влeзe във вoдaтa с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.", "https://drive.google.com/file/d/1tDKCXmwpMGz6xseWKB8vWZvdMvow_SrR/view?usp=drive_link", "Shui Zhong Bao", "Детски надуваем пояс INTEX Пони-Еднорог", 11.80m, 15 },
                    { new Guid("ba1b2162-6cc7-48fb-a8ab-41f764e6f23c"), 57526, 1, "Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.", "https://drive.google.com/file/d/1jjuQ2_r0SZ0QXRLjRFBnuhNIEKtPy1ZF/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 70 x 140 cm.", 9.30m, 50 },
                    { new Guid("c84153e0-b15b-49f8-ae71-7d84bbb5cdb3"), 56113, 6, "Изработен е от качествен винил и има 4 въздушни камери, голям външeн пpъcтeн зa по-голямa cтaбилноcт и отвоpи зa кpaчeтaтa нa дeтeто, които оcигуpявaт нeговaтa бeзопacноcт и пpeдотвpaтявaт вepоятноcттa от изхлузване от пояca.", "https://drive.google.com/file/d/1l-4jA8i9_cKkRwVqIcPayyx7RjECP9tB/view?usp=drive_link", "Shui Zhong Bao", "Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle", 5.75m, 15 },
                    { new Guid("cf0e748d-5d73-43f8-ae9d-95c62213438b"), 38527, 1, "Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.", "https://drive.google.com/file/d/1ae-zH1gOHkFhigYFkQMz8L25bZq7LcRF/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("dce38c78-6b86-4d3d-8c0e-50df3c2e5f8e"), 51375, 5, "Плувни очила за възрастни, широки, черен силикон 18х8 см.", "https://drive.google.com/file/d/1AKwwgKcCo1oKSLdLI8TrEjsE2y2Serux/view?usp=drive_link", "Shenzhen Befine Sports Goods", "Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport", 7.00m, 20 },
                    { new Guid("e0f12f99-62d2-4d94-9036-e883757c426f"), 58546, 6, "Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.", "https://drive.google.com/file/d/1spWbPR_54kid2eAV123eVgE_LruRdIHr/view?usp=drive_link", "INTEXT", "Надуваема играчка Алигатор INTEX LIL' Gator Ride-on, малък", 19.85m, 15 },
                    { new Guid("e1c2eb58-5a86-495e-846d-3d15c483c35a"), 59139, 5, "Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!", "https://drive.google.com/file/d/1zGEEZkv8QtIt_HSyBbPimT8mPaUZs8aI/view?usp=drive_link", "Vanguard Watersports", "Плавници Vanguard Watersports Super Sport, 35-37 номер", 19.00m, 50 },
                    { new Guid("e7980739-455e-4c40-888a-b73b4488caee"), 56724, 3, "Плажна чанта с плетени дръжки и изообразени котва на син фон с рози. ", "https://drive.google.com/file/d/1XL6OqirslpRwE0yS-3Jjn_SnDTBsedSc/view?usp=drive_link", "Coveri Collection", "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 },
                    { new Guid("e89dfa86-3269-4870-9374-9dcda5c29751"), 58922, 1, "Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.", "https://drive.google.com/file/d/1dfT4IZEew4CoddEGDakT-PBjw7yredbB/view?usp=drive_link", "DREAMFOX", "Плажна хавлия DREAMFOX 75 x 150 cm.", 4.80m, 100 },
                    { new Guid("ea6a93de-f5fe-4185-bc85-c397afbffb08"), 44442, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/file/d/1mrbRxFOHCZAJIHd83oLjKRuAMdqimIO1/view?usp=drive_link", "ПУБЛИИДЕЯ", "Плажен чадър ПУБЛИИДЕЯ, растения", 7.50m, 25 },
                    { new Guid("eb33dd10-b17e-42f9-ad18-29dffde33f80"), 58762, 6, "Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.", "https://drive.google.com/file/d/1LlSdpiheEAzizyC8CTE6W5p-PqOM3aIM/view?usp=drive_link", "INTEX", "Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см", 14.50m, 10 },
                    { new Guid("f1112f56-b171-43ed-887c-43f30cff9600"), 55555, 2, "Чадърите на \"Публиидея\" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Moжe лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.", "https://drive.google.com/file/d/1NMIiyeqiycf5b3uR53YIMXiBBWeJac16/view?usp=drive_link", "ПУБЛИИДЕЯ", "Плажен чадър ПУБЛИИДЕЯ, тъмно-зелен.", 14.85m, 25 },
                    { new Guid("f68e4d39-c46a-4b82-9ce6-bfddd12343fe"), 56721, 3, "Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.", "https://drive.google.com/file/d/15DkwJKv2YFkzVRMBR-z6mY9lTYSEwCsk/view?usp=drive_link", "Coveri Collection", "Плажна чанта Coveri Collection 53х37х19", 8.50m, 30 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f145dcb-a166-41e9-82f2-c814f8a93e9d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8cee753d-4b6e-42fb-9841-2e8b5e9c6eb8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c3e98537-479f-4936-8af4-066181b328f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("01a4f244-7f2d-4cfb-bf9a-4838625adb74"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("06baa812-69ef-4f26-b14c-66a6d6d86561"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09fcc4af-5067-46f2-93c0-514bb44b864c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0a54ed73-d034-48ec-8794-421eb75c7027"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2306717d-3d88-4d9f-ab28-7848f5189433"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("232921d1-fba1-42af-a876-3622ac713711"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("243ae335-fd35-4100-b196-c659e1b3dce2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("249313f1-1422-445d-8a16-ef811da3dee9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("25b81a48-248a-4d3a-97dd-177e946785dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("28276ce4-ac70-4d41-a2ac-a6c63a5ce112"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2b8477b5-3308-410c-8ea5-3800ef44fe2a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("36aa7b4e-c14b-47f7-af8f-a0fe1dd33bff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("37065dd4-f1ff-436e-908f-4f5487cd0086"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("510438af-3648-4a5d-830d-bed1ffbecd4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("564924bd-cd48-41e5-9229-497a2b846220"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("60adf7ac-0f74-44d9-849b-6469f526fa6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f7428c8-aacb-4a82-aef3-e5e4ec29cc4a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("73b3dd8b-09e3-4e5a-92b6-cbca72e3a3e1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77966e06-3756-4dd3-b20e-42ad2686fc1d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("79450932-c1cd-4758-a39c-b987ca763718"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("816e6dc9-395c-4564-bab6-d9bcb9f8d288"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("85e004c2-97b3-435d-811c-134531801a70"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8c025ee1-1118-43a0-b7f9-5ce0d2d4615a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8cedf6ed-c6e2-4b8d-ac59-10b3b04a4327"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a353b862-3b99-448f-a079-4d633edc83c7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5514002-86f9-4ac5-bb16-6be6321541dc"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aceee187-c44c-4634-8913-9f301c237656"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7a153ae-a939-4818-98c9-e8020025556d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba1b2162-6cc7-48fb-a8ab-41f764e6f23c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c84153e0-b15b-49f8-ae71-7d84bbb5cdb3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cf0e748d-5d73-43f8-ae9d-95c62213438b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dce38c78-6b86-4d3d-8c0e-50df3c2e5f8e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e0f12f99-62d2-4d94-9036-e883757c426f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e1c2eb58-5a86-495e-846d-3d15c483c35a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e7980739-455e-4c40-888a-b73b4488caee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e89dfa86-3269-4870-9374-9dcda5c29751"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea6a93de-f5fe-4185-bc85-c397afbffb08"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("eb33dd10-b17e-42f9-ad18-29dffde33f80"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f1112f56-b171-43ed-887c-43f30cff9600"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f68e4d39-c46a-4b82-9ce6-bfddd12343fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
