CREATE TABLE [LegoTheme](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED ([id] ASC)
);
CREATE TABLE [LegoSet](
	[id] [nvarchar](50) NOT NULL,
	[name] [nvarchar](250) NOT NULL,
	[year] [int] NOT NULL,
	[pieces] [int] NOT NULL,
	[minifigs] [int] NOT NULL,
	[minage] [int] NULL,
	[imageURL] [nvarchar](500) NULL,
	[retailprice] [float] NULL,
	[themeId] [int] NOT NULL,
    CONSTRAINT [PK_Set] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [FK_Set_Theme] FOREIGN KEY([themeId])REFERENCES [LegoTheme] ([id])
);



