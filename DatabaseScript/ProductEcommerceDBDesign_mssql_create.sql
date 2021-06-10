CREATE TABLE [Products] (
	id int NOT NULL,
	productName nvarchar(250) NOT NULL,
	category_id int NOT NULL,
	subcategory_id int NOT NULL,
	PreviewImages nvarchar NOT NULL,
  CONSTRAINT [PK_PRODUCTS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Categories] (
	id int NOT NULL,
	categoryName nvarchar(250) NOT NULL,
  CONSTRAINT [PK_CATEGORIES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [SubCategories] (
	id int NOT NULL,
	subCategoryName nvarchar(250) NOT NULL,
	category_id int NOT NULL,
  CONSTRAINT [PK_SUBCATEGORIES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products_Variations] (
	id int NOT NULL,
	product_id int NOT NULL,
	variationName nvarchar(250) NOT NULL,
  CONSTRAINT [PK_PRODUCTS_VARIATIONS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products_Variations_Options] (
	id int NOT NULL,
	product_variation_id int NOT NULL,
	option_variationName nvarchar(250) NOT NULL,
  CONSTRAINT [PK_PRODUCTS_VARIATIONS_OPTIONS] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products_Stock] (
	id int NOT NULL,
	totalstockAvailable int NOT NULL,
	totalPrice float NOT NULL,
	product_combination_id bigint NOT NULL,
	unitPrice float NOT NULL,
  CONSTRAINT [PK_PRODUCTS_STOCK] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products_Combination] (
	id int NOT NULL,
	combinationString nvarchar NOT NULL,
	sku_id nvarchar NOT NULL,
	price float NOT NULL,
	unique_id nvarchar NOT NULL,
	product_id int NOT NULL,
  CONSTRAINT [PK_PRODUCTS_COMBINATION] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Images] (
	id int NOT NULL,
	smallimage nvarchar NOT NULL,
	mediumImage nvarchar NOT NULL,
	largeimage nvarchar NOT NULL,
  CONSTRAINT [PK_IMAGES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Products_Images] (
	id int NOT NULL,
	image_id int NOT NULL,
	product_variation_id int NOT NULL,
	isFeatured bit NOT NULL,
  CONSTRAINT [PK_PRODUCTS_IMAGES] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
ALTER TABLE [Products] WITH CHECK ADD CONSTRAINT [Products_fk0] FOREIGN KEY ([category_id]) REFERENCES [Categories]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products] CHECK CONSTRAINT [Products_fk0]
GO
ALTER TABLE [Products] WITH CHECK ADD CONSTRAINT [Products_fk1] FOREIGN KEY ([subcategory_id]) REFERENCES [SubCategories]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products] CHECK CONSTRAINT [Products_fk1]
GO


ALTER TABLE [SubCategories] WITH CHECK ADD CONSTRAINT [SubCategories_fk0] FOREIGN KEY ([category_id]) REFERENCES [Categories]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [SubCategories] CHECK CONSTRAINT [SubCategories_fk0]
GO

ALTER TABLE [Products_Variations] WITH CHECK ADD CONSTRAINT [Products_Variations_fk0] FOREIGN KEY ([product_id]) REFERENCES [Products]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Variations] CHECK CONSTRAINT [Products_Variations_fk0]
GO

ALTER TABLE [Products_Variations_Options] WITH CHECK ADD CONSTRAINT [Products_Variations_Options_fk0] FOREIGN KEY ([product_variation_id]) REFERENCES [Products_Variations]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Variations_Options] CHECK CONSTRAINT [Products_Variations_Options_fk0]
GO

ALTER TABLE [Products_Stock] WITH CHECK ADD CONSTRAINT [Products_Stock_fk0] FOREIGN KEY ([product_combination_id]) REFERENCES [Products_Combination]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Stock] CHECK CONSTRAINT [Products_Stock_fk0]
GO

ALTER TABLE [Products_Combination] WITH CHECK ADD CONSTRAINT [Products_Combination_fk0] FOREIGN KEY ([product_id]) REFERENCES [Products]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Combination] CHECK CONSTRAINT [Products_Combination_fk0]
GO


ALTER TABLE [Products_Images] WITH CHECK ADD CONSTRAINT [Products_Images_fk0] FOREIGN KEY ([image_id]) REFERENCES [Images]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Images] CHECK CONSTRAINT [Products_Images_fk0]
GO
ALTER TABLE [Products_Images] WITH CHECK ADD CONSTRAINT [Products_Images_fk1] FOREIGN KEY ([product_variation_id]) REFERENCES [Products_Variations_Options]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Products_Images] CHECK CONSTRAINT [Products_Images_fk1]
GO

