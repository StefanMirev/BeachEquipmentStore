IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_SeedDatabase')
BEGIN
    DROP PROCEDURE sp_SeedDatabase;
END;

BEGIN
	EXEC('CREATE PROCEDURE sp_SeedDatabase
        AS
        BEGIN TRY
		    DECLARE @UsersInsertCount INT = 0;
			DECLARE @AddressesInsertCount INT = 0;
			DECLARE @CategoriesInsertCount INT = 0;
			DECLARE @ManufacturersInsertCount INT = 0;
			DECLARE @ProductsInsertCount INT = 0;

		    PRINT ''Seeding process started.'';

			DECLARE @UserOneHash VARCHAR(255), @UserTwoHash VARCHAR(255), @UserThreeHash VARCHAR(255);

			SET @UserOneHash = CONVERT(VARCHAR(255), HASHBYTES(''SHA2_256'', ''123123''), 2);
			SET @UserTwoHash = CONVERT(VARCHAR(255), HASHBYTES(''SHA2_256'', ''123123''), 2);
			SET @UserThreeHash = CONVERT(VARCHAR(255), HASHBYTES(''SHA2_256'', ''123123''), 2);

	-- Start Insert Users
			BEGIN TRANSACTION

            IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetUsers] WHERE [Email] = ''p.petrov@mail.com'')
            BEGIN
                INSERT INTO [dbo].[AspNetUsers] (
					[Id]
					,[FirstName]
					,[LastName]
					,[UserName]
					,[NormalizedUsername]
					,[Email]
					,[NormalizedEmail]
					,[PhoneNumber]
					,[PasswordHash]
					,[SecurityStamp]
					,[CreatedAt]
					,[EmailConfirmed]
					,[PhoneNumberConfirmed]
					,[TwoFactorEnabled]
					,[LockoutEnabled]
					,[AccessFailedCount]
					)
					VALUES (
						NEWID()
						,''Petar''
						,''Petrov''
						,''p.petrov@mail.com''
						,''P.PETROV@MAIL.COM''
						,''p.petrov@mail.com''
						,''P.PETROV@MAIL.COM''
						,''0876596224''
						,@UserOneHash
						,NEWID()
						,GETDATE()
						,1
						,1
						,1
						,0
						,0
						);

				SET @UsersInsertCount = @UsersInsertCount + 1;
            END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetUsers] WHERE [Email] = ''n.flacko@mail.com'')
            BEGIN
                INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PhoneNumber], [PasswordHash], [SecurityStamp], [CreatedAt], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount])
					VALUES (NEWID(), ''Nicko'', ''Flacko'', ''n.flacko@mail.com'', ''N.FLACKO@MAIL.COM'', ''n.flacko@mail.com'', ''N.FLACKO@MAIL.COM'', ''0888202449'', @UserTwoHash, NEWID(), GETDATE(), 1, 1, 1, 0, 0);
				SET @UsersInsertCount = @UsersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetUsers] WHERE [Email] = ''s.sarafov@mail.com'')
            BEGIN
                INSERT INTO [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUsername], [Email], [NormalizedEmail], [PhoneNumber], [PasswordHash], [SecurityStamp], [CreatedAt], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount])
					VALUES (NEWID(), ''Stamat'', ''Sarafov'', ''s.sarafov@mail.com'', ''S.SARAFOV@MAIL.COM'', ''s.sarafov@mail.com'', ''S.SARAFOV@MAIL.COM'', ''0885527733'', @UserThreeHash, NEWID(), GETDATE(), 1, 1, 1, 0, 0);
				SET @UsersInsertCount = @UsersInsertCount + 1;
			END;
			
			COMMIT TRANSACTION

			PRINT ''Inserted '' + CAST(@UsersInsertCount AS VARCHAR(10)) + '' users into AspNetUsers table.'';

	-- End Insert Users

	-- Start Insert Addresses
			BEGIN TRANSACTION

			DECLARE @UserOneId UNIQUEIDENTIFIER, @UserTwoId UNIQUEIDENTIFIER, @UserThreeId UNIQUEIDENTIFIER;

			SELECT @UserOneId = Id FROM AspNetUsers WHERE Email = ''p.petrov@mail.com'';
			SELECT @UserTwoId = Id FROM AspNetUsers WHERE Email = ''n.flacko@mail.com'';
			SELECT @UserThreeId = Id FROM AspNetUsers WHERE Email = ''s.sarafov@mail.com'';

		    IF @UserOneId IS NOT NULL
			BEGIN
				IF NOT EXISTS (SELECT 1 FROM [dbo].[Addresses] WHERE [CustomerId] = @UserOneId)
				BEGIN
					INSERT INTO [dbo].[Addresses] (
						[Id]
						,[Name]
						,[Town]
						,[ZipCode]
						,[CustomerId]
						,[CreatedAt]
						,[IsPrimaryAddress]
						) 
						VALUES (
							NEWID()
							,''ул. Кракра №3''
							,''София''
							,''1000''
							,@UserOneId
							,GETDATE()
							,1
							);
					SET @AddressesInsertCount = @AddressesInsertCount + 1;
				END
			END;

			IF @UserTwoId IS NOT NULL
			BEGIN
				IF NOT EXISTS (SELECT 1 FROM [dbo].[Addresses] WHERE [CustomerId] = @UserTwoId)
				BEGIN
					INSERT INTO [dbo].[Addresses] ([Id], [Name], [Town], [ZipCode], [CustomerId], [CreatedAt], [IsPrimaryAddress]) 
						VALUES (NEWID(), ''кв. Овча Купел, ул. Рачка №9'', ''София'', ''1000'', @UserTwoId, GETDATE(), 1);
					SET @AddressesInsertCount = @AddressesInsertCount + 1;
				END
			END;

			IF @UserThreeId IS NOT NULL
            BEGIN
				IF NOT EXISTS (SELECT 1 FROM [dbo].[Addresses] WHERE [CustomerId] = @UserThreeId)
				BEGIN
					INSERT INTO [dbo].[Addresses] ([Id], [Name], [Town], [ZipCode], [CustomerId], [CreatedAt], [IsPrimaryAddress]) 
						VALUES (NEWID(), ''ул. Обзорски Тигър № 33'', ''София'', ''1000'', (SELECT Id FROM AspNetUsers WHERE Email = ''s.sarafov@mail.com''), GETDATE(), 1);
					SET @AddressesInsertCount = @AddressesInsertCount + 1;
				END
			END;

			COMMIT TRANSACTION

			PRINT ''Inserted '' + CAST(@AddressesInsertCount AS VARCHAR(10)) + '' addresses into Addresses table.'';

	-- End Insert Addresses

	-- Start Insert Categories
			SET IDENTITY_INSERT Categories ON;

			BEGIN TRANSACTION

            IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 1)
			BEGIN
				INSERT INTO [dbo].[Categories] (
					[Id]
					,[Name]
					,[ImageUrl]
					,[CreatedAt]
					)
					VALUES (
						1
						,''Плажни кърпи''
						,''https://i.ibb.co/w6CNrfd/Towel-Category.webp''
						,GETDATE()
						);
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 2)
			BEGIN
				INSERT INTO [dbo].[Categories]([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (2, ''Чадъри'', ''https://i.ibb.co/t4KWPCP/Umbrella-Category.jpg'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 3)
			BEGIN
				INSERT INTO [dbo].[Categories]([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (3, ''Чанти'', ''https://i.ibb.co/vv0FD1X/Bag-Category.webp'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 4)
			BEGIN
				INSERT INTO [dbo].[Categories]([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (4, ''Плажни играчи'', ''https://i.ibb.co/6nHY7VJ/Beach-Toy-Category.webp'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 5)
			BEGIN
				INSERT INTO [dbo].[Categories](Id, [Name], [ImageUrl], CreatedAt)
					VALUES (5, ''Обурудвабе за плуване'', ''https://i.ibb.co/JkDDZkb/Swimming-Equipment-Category.jpg'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 6)
			BEGIN
				INSERT INTO [dbo].[Categories]([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (6, ''Надувни'', ''https://i.ibb.co/JxJ4CSM/Floaty-Category.webp'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Categories] WHERE [Id] = 7)
			BEGIN
				INSERT INTO [dbo].[Categories]([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (7, ''Топки'', ''https://i.ibb.co/rHY9wjG/Ball-Category.jpg'', GETDATE());
				SET @CategoriesInsertCount = @CategoriesInsertCount + 1;
			END;
			
			SET IDENTITY_INSERT Categories OFF;

			COMMIT TRANSACTION

			PRINT ''Inserted '' + CAST(@CategoriesInsertCount AS VARCHAR(10)) + '' categories into Categories table.'';

	-- End Insert Categories

	-- Start Insert Manufacturers
			SET IDENTITY_INSERT Manufacturers ON;

			BEGIN TRANSACTION

            IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 1)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] (
					[Id]
					,[Name]
					,[ImageUrl]
					,[CreatedAt]
					)
					VALUES (
						1
						,''Vinex''
						,''https://i.ibb.co/7WJYhkr/Vinex-Manufacturer.jpg''
						,GETDATE()
						);
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 2)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (2, ''Coveri Collection'', ''https://i.ibb.co/JpRqHbV/Covari-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 3)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (3, ''CPS TOYS'', ''https://i.ibb.co/nQHgsJG/Cps-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 4)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (4, ''DREAMFOX'', ''https://i.ibb.co/1nkCLZw/Dreamfox.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 5)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (5, ''INTEX'', ''https://i.ibb.co/s2Y1245/Intex-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 6)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (6, ''Shenzhen Befine Sports Goods'', ''https://i.ibb.co/QQ486yn/Shenzhen-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 7)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (7, ''Shui Zhong Bao'', ''https://i.ibb.co/K7N6Z0D/Shui-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 8)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (8, ''Star'', ''https://i.ibb.co/CKCRztx/Star-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 9)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (9, ''Vanguard Watersports'', ''https://i.ibb.co/bPDRFNJ/Vanguard-Manufacturer.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Manufacturers] WHERE [Id] = 10)
			BEGIN
				INSERT INTO [dbo].[Manufacturers] ([Id], [Name], [ImageUrl], [CreatedAt])
					VALUES (10, ''ПУБЛИИДЕЯ'', ''https://i.ibb.co/6PPhfyV/Publidea.jpg'', GETDATE());
				SET @ManufacturersInsertCount= @ManufacturersInsertCount + 1;
			END;

			COMMIT TRANSACTION

			SET IDENTITY_INSERT Manufacturers OFF;

			PRINT ''Inserted '' + CAST(@ManufacturersInsertCount AS VARCHAR(10)) + '' manufacturers into Manufacturers table.'';

	-- End Insert Manufacturers

	-- Start Insert Products
			BEGIN TRANSACTION

            IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 57532)
			BEGIN
				INSERT INTO [dbo].[Products] (
					[Id]
					,[Name]
					,[Description]
					,[ImageUrl]
					,[Barcode]
					,[Price]
					,[Stock]
					,[CategoryId]
					,[ManufacturerId]
					,[CreatedAt]
					)
					VALUES (
						NEWID()
						,''Плажна хавлия DREAMFOX 75 x 170 cm.''
						,''Памучна детска плажна хавлия с изобразени акула и рибки. Грамаж: 380 гр.''
						,''https://i.ibb.co/LkpTB85/Towel-Shark.jpg''
						,57532
						,12.00
						,50
						,1
						,4
						,GETDATE()
						);
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 38527)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна хавлия DREAMFOX 75 x 150 cm.'', ''Микрофибърна плажна хавлия с изоображение на морско дъно с 2 делфина и с надпис Bulgaria.'', ''https://i.ibb.co/6Xj3SVh/Towel-Dolphin.jpg'', 38527, 4.80, 100, 1, 4, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 57523)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна хавлия DREAMFOX 70 x 140 cm.'', ''Памучна плажна хавлия с котвички, синя. Грамаж: 360 гр.'', ''https://i.ibb.co/y08sGtL/Towel-Plain-Blue.jpg'', 57523, 9.30, 50, 1, 4, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 57526)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна хавлия DREAMFOX 70 x 140 cm.'', ''Памучна плажна хавлия с ананаси, розова. Грамаж: 360 гр.'', ''https://i.ibb.co/BCMvsmq/Towen-Plain-Pink.jpg'', 57526, 9.30, 50, 1, 4, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56130)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна хавлия DREAMFOX 75 x 150 cm.'', ''Микрофибърна плажна хавлия с изоображение на русалка и надписи.'', ''https://i.ibb.co/Fn52s1n/Towel-Mermaid.jpg'', 56130, 5.00, 100, 1, 4, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 58922)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна хавлия DREAMFOX 75 x 150 cm.'', ''Микрофибърна плажна хавлия с изоображение на китара поставена на плаж.'', ''https://i.ibb.co/XpYVKZ4/Towen-Seaside.jpg'', 58922, 4.80, 100, 1, 4, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 55555)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Пкажен чадър ПУБЛИИДЕЯ, тъмно-зелен.'', ''Чадърите на "Публиидея" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV25. Моže лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.'', ''https://i.ibb.co/6vxZ7wZ/Umbrella-Plain.jpg'', 55555, 14.85, 25, 2, 10, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 44443)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажен чадър ПУБЛИИДЕЯ, палми'', ''Чадърите на "Публиидея" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Моže лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.'', ''https://i.ibb.co/vvtYT55/Umberlla-Plams.jpg'', 44443, 6.80, 25, 2, 10, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 44442)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажен чадър ПУБЛИИДЕЯ, растения'', ''Чадърите на "Публиидея" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Моžе лecнo дa бъдe нагласен в кoятo и дa e пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.'', ''https://i.ibb.co/Sv0DmBy/Umbrella-Plants.jpg'', 44442, 7.50, 25, 2, 10, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 44444)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажен чадър ПУБЛИИДЕЯ, морски звезди'', ''Чадърите на "Публиидея" са перфектният аксесоар за горещите дни на плажа и ще Ви предпази парещите слънчеви лъчи. Лeceн е зa мoнтиpaнe, ocигypявa зaщитa oт cлънчeвитe лъчи UV20+. Моžе лecнo дa бъдe нагласен в кoятo и дa е пocoкa, блaгoдapeниe нa чупещошд рамо. Диаметър: 100 см.'', ''https://i.ibb.co/ZmM9rZP/Umbrella-Starfish.jpg'', 44444, 6.80, 25, 2, 10, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56718)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна Coveri Collection 53х37х19'', ''Плажна чанта с плетени дръжки и изообразени дини и черни палмови листа на бял фон.'', ''https://i.ibb.co/2MFJmGv/Bag-Watermellon.jpg'', 56718, 8.50, 30, 3, 2, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56724)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна чанта Coveri Collection 53х37х19'', ''Плажна чанта с плетени дръжки и изообразени котва на син фон с рози.'', ''https://i.ibb.co/BZYy30X/Bag-Anchor.jpg'', 56724, 8.50, 30, 3, 2, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56723)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна чанта Coveri Collection 53х37х19'', ''Плажна чанта с плетени дръжки и изообразени макове на черно-бял фон.'', ''https://i.ibb.co/LPnV4tL/BagPoppy.jpg'', 56723, 8.50, 30, 3, 2, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56721)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна чанта Coveri Collection 53х37х19'', ''Плажна чанта с плетени дръжки и изообразени миди и рулове на бял фон.'', ''https://i.ibb.co/RhKgqG2/BagClams.jpg'', 56721, 8.50, 30, 3, 2, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56720)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плажна чанта Coveri Collection 53х37х19'', ''Плажна чанта с плетени дръжки и изообразени орхидеи на бял фон.'', ''https://i.ibb.co/8bQ32MJ/Bag-Orchid.jpg'', 56720, 8.50, 30, 3, 2, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 18040)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Vinex - Комплект кофичка за пясък Дисни'', ''Комплектът съдържа гребло, лопатка, сито и формичка риба. Кофичката е с диаметър 29см.'', ''https://i.ibb.co/5vfvRwN/Toy-Bucket-Disney.jpg'', 18040, 8.25, 16, 4, 1, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 17005)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Vinex - Комплект кофичка за пясък Дисни'', ''Комплектът съдържа гребло, лопатка, сито и формички риба и костенурка. Кофичката е с диаметър 26см.'', ''https://i.ibb.co/cw3903C/Toy-Bucket-Plain.jpg'', 17005, 6.00, 16, 4, 1, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 10805)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Vinex - Комплект кофичка за пясък Дисни'', ''Комплектът съдържа гребло, лопатка, сито и формички риба, костенурка, мида и морска звезда. Кофичката е с диаметър 26см.'', ''https://i.ibb.co/cX57F5w/Toy-Bucket-Cartoon.jpg'', 10805, 10.50, 16, 4, 1, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 33306)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Vinex - Комплект кофичка за пясък Дисни'', ''Комплектът съдържа гребло, лопатка, сито, лейка и три формички замък. Кофичката е квадратна, с размери 16 х 16 см.'', ''https://i.ibb.co/86dL7D5/Toy-Bucket-Square.jpg'', 33306, 6.40, 15, 4, 1, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 36113)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Vinex - Лопата за пясък'', ''Лопата за пясък, дървена дръжка с дължина 62 см.'', ''https://i.ibb.co/WHxnBfw/Toy-Shovel.jpg'', 36113, 3.20, 40, 4, 1, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 58849)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Воден пистолет CPS TOYS 50см'', ''Воден пистолет CPS TOYS, асортимент 38 см. Механизъм на помпата - функция помпане, дължина: 38 см, обем на резервоара: 900 мл, изстрелва водата до 8 метра!'', ''https://i.ibb.co/jf72Vv7/Toy-Water-Gun.jpg'', 58849, 7.40, 40, 4, 3, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 42178)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Маска за плуване за цяло лице Shenzhen Befine Sports Goods ReefRider'', ''Плувна маска за цяло лице в мрежа S, M силикон, синьо, електрикаво зелено, черно'', ''https://i.ibb.co/Ycbbt1d/Swimming-Mask.jpg'', 42178, 33.00, 30, 5, 6, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 59139)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плавници Vanguard Watersports Super Sport, 35-37 номер'', ''Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!'', ''https://i.ibb.co/xFGh6x2/Swimming-Fins-Children.jpg'', 59139, 19.00, 50, 5, 9, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 42181)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Плавници Vanguard Watersports Mega Sport, 39-43 номер'', ''Плавниците cа подходящи за гмуркане или тренировки по плуване. Tяхната площ ще даде възможноcт на вcеки любител на водните приключения да cе движи много по-бързо!'', ''https://i.ibb.co/vZN4MxL/Swimming-Fins-Adult.jpg'', 42181, 19.50, 40, 5, 9, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 24040)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Шапка за плуване Vanguard Watersports, текстил'', ''Шапка за плуване, текстил. Размери: 21 х 12 см.'', ''https://i.ibb.co/hZnkbPF/Swimming-Cap.jpg'', 24040, 1.35, 70, 5, 9, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 31386)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Очила за плуване за деца Shenzhen Befine Sports Goods Fun Goggles'', ''Плувни очила, силикон, цветни, здраво прелепващи 13 см.'', ''https://i.ibb.co/BsKqYC7/Swimming-Goggles-Children.jpg'', 31386, 4.50, 30, 5, 6, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 51375)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Очила за плуване за възрастни Shenzhen Befine Sports Goods Water Sport'', ''Плувни очила за възрастни, широки, черен силикон 18х8 см.'', ''https://i.ibb.co/y0PGtTq/Swimming-Goggles-Adult.jpg'', 51375, 7.00, 20, 5, 6, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 42174)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Детски шнорхел Shenzhen Befine Sports Goods Hi-Flo'', ''Мундщук от поливинилхлорид за меко и удобно прилягане. Дихателна тръба със среден диаметър и дължина 42 см. Дизайн идеален за деца.'', ''https://i.ibb.co/FYgw02D/Swimming-Snorkel-Children.jpg'', 42174, 3.65, 30, 5, 6, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 42172)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Шнорхел Shenzhen Befine Sports Goods Easy-Flow'', ''Шнорхел за възрастни с удобен термопластичен гумен мундщукшнорхел. Дихателна тръба с висококачествена P.V.C. изработка и дължина 42 см.'', ''https://i.ibb.co/9v2Qr7q/Swimming-Snorkel-Adults.jpg'', 42172, 5.50, 20, 5, 6, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 58546)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Надуваема играчка Алигатор INTEX LIL'''' Gator Ride-on, малък'', ''Алигаторите нe ca тoлкoвa cтpaшни кoлкoтo cи миcлитe. Сeгa имaтe възмoжнocт дa ce зaбaвлявaтe c eдин oт тях в бaceйнa, морeто или дори и нa cушaтa. Алигаторът e c paзмepи, кoитo ca cхoдни c тeзи нa иcтинcкитe му cъбpaтя и e гoтoв зa мнoгo игpи c вaшият мaлчугaн. Изработен е от качествен винил и има 1 здрaва дръжка за захващане зa по-голямa уcтойчивоcт и cигурноcт нa дeтeто. Размер: 168 х 86 см.'', ''https://i.ibb.co/PsLkswc/Floaty-Crocodile.jpg'', 58546, 19.85, 15, 6, 5, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 49230)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Детски надуваем пояс INTEX Пони-Еднорог'', ''Какво може да направи плуването в басейна или в морето още по-забавно? Например ако детето влезе във водата с пояс с брокат със забавен дизайн във формата на еднорог. Размер: 90 см.'', ''https://i.ibb.co/j5MMjgM/Floaty-Unicorn.jpg'', 49230, 11.80, 15, 6, 5, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 36727)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Надуваем поясн Диня Shui Zhong Bao Watermelon'', ''Надуваем остров с диаметър 70 см. Свеж дизайн. Въже за захващане.'', ''https://i.ibb.co/7tz51mq/Floaty-Melon.jpg'', 36727, 4.20, 12, 6, 7, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 56113)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Бебешки надуваем пояс - проходилка Shui Zhong Bao Turtle'', ''Изработен е от качествен винил и има 4 въздушни камери, голям външен пръстен за по-голяма стабилност и отвори за крачетата на детето, които осигуряват неговата безопасност и предотвратяват вероятността от изхлузване от пояса.'', ''https://i.ibb.co/H2wNG86/Floaty-Turtle-Babies.jpg'', 56113, 5.75, 15, 6, 7, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 58762)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Надуваем дюшек сладолед - фунийка INTEX, 224 Х 107см'', ''Насладете се на почивката със забавния надуваем дюшек във формата на близалка от Intex. Той е достатъчно голям, за да се чувствате удобно и комфортно върху него. Можете да го ползвате и в басейна и на плажа. Изработен е от висококачествен винил, което го прави устойчив на надраскване и разкъсване.'', ''https://i.ibb.co/1dzzG9V/Floaty-Ice-Cream.jpg'', 58762, 14.50, 10, 6, 5, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 59720)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Надуваем дюшек INTEX, 183 х 69 х 25см'', ''Отпуснете се в басейна и се забавлявайте на следващото парти това лято с този надуваем дюшек. Забавният дизайн създава освежаващо и забавно настроение, докато релаксирате на слънце през цялото лято.'', ''https://i.ibb.co/G0WBydZ/Floaty-Bed.jpg'', 59720, 10.60, 10, 6, 5, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 58786)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Надуваем дюшек Ангелски крила INTEX'', ''Надуваем дюшек Ангелски крила INTEX. Размери и тегло - Размери: 251 x 106 см.; Тегло: 3.47 кг.'', ''https://i.ibb.co/K7LDFSq/Floaty-Wings.jpg'', 58786, 47.70, 10, 6, 5, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 101730)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Star  - Волейболна топка Miami Beach, 21см'', ''Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.'', ''https://i.ibb.co/3h3MV9H/Ball-Miami.jpg'', 101730, 6.30, 10, 7, 8, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 101019)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Star  - Волейболна топка Bora Bora, 21см'', ''Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.'', ''https://i.ibb.co/pQJZTcp/Ball-Bora-Bora.jpg'', 101019, 6.30, 10, 7, 8, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 101090)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Star  - Волейболна топка Beach Volley, 21см'', ''Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.'', ''https://i.ibb.co/HgMXxMb/Ball-Beach-Palms.jpg'', 101090, 6.30, 10, 7, 8, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			IF NOT EXISTS (SELECT 1 FROM [dbo].[Products] WHERE Barcode = 101011)
			BEGIN
				INSERT INTO [dbo].[Products] ([Id], [Name], [Description], [ImageUrl], [Barcode], [Price], [Stock], [CategoryId], [ManufacturerId], [CreatedAt])
					VALUES (NEWID(), ''Star  - Волейболна топка Water Polo, 21см'', ''Висококачествена топка с диаметър 21см. Игрите с топка ще помогнат на децата да задоволят естественото си желание за движение по забавен начин. Те използват енергията си по подходящ начин - активното движение на чист въздух е полезно за здравето и в същото време носи радост от играта.'', ''https://i.ibb.co/qnd7sVN/Ball-Water-Polo.jpg'', 101011, 6.15, 10, 7, 8, GETDATE());
				SET @ProductsInsertCount= @ProductsInsertCount + 1;
			END;

			COMMIT TRANSACTION

			PRINT ''Inserted '' + CAST(@ProductsInsertCount AS VARCHAR(10)) + '' products into Products table.'';

	-- End Insert Products

			PRINT ''Seeding completed for all entities.'';
        END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			
			PRINT ''Error occurred: '' + ERROR_MESSAGE();
		END CATCH')
END;

GO

EXEC sp_SeedDatabase;