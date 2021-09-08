CREATE TABLE [Nav].[MenuItem]
(
	[MenuItemId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [MenuId] INT NOT NULL, 
    [Text] VARCHAR(250) NOT NULL, 
    [NavigateUrl] VARCHAR(250) NULL, 
    [CssClass] NVARCHAR(50) NULL, 
    [SortOrder] INT NOT NULL, 
    [Enabled] BIT NOT NULL DEFAULT 0
)
