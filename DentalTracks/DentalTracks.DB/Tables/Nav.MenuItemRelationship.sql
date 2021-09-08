CREATE TABLE [Nav].[MenuItemRelationship]
(
	[MenuItemRelationshipId] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [MenuItemId] INT NOT NULL, 
    [ParentMenuItemId] INT NOT NULL, 
    [SecurityLevel] INT NOT NULL
)
