
PRINT 'Seeding Menu'
SET IDENTITY_INSERT [Nav].[Menu] ON 
INSERT [Nav].[Menu] ([MenuId], [Name], [SecurityKey]) VALUES (1, N'Web', N'WEB')
SET IDENTITY_INSERT [Nav].[Menu] OFF
GO

PRINT 'Seeding MenuItem'
SET IDENTITY_INSERT [Nav].[MenuItem] ON 
INSERT [Nav].[MenuItem] ([MenuItemId], [MenuId], [Text], [NavigateUrl], [CssClass], [SortOrder], [Enabled]) VALUES (1, 1, N'Menu Item 1', N'#', NULL, 1, 1)
INSERT [Nav].[MenuItem] ([MenuItemId], [MenuId], [Text], [NavigateUrl], [CssClass], [SortOrder], [Enabled]) VALUES (2, 1, N'Menu Item 2', N'#', NULL, 2, 1)
INSERT [Nav].[MenuItem] ([MenuItemId], [MenuId], [Text], [NavigateUrl], [CssClass], [SortOrder], [Enabled]) VALUES (3, 1, N'Menu Item 3', N'#', NULL, 3, 1)
INSERT [Nav].[MenuItem] ([MenuItemId], [MenuId], [Text], [NavigateUrl], [CssClass], [SortOrder], [Enabled]) VALUES (4, 1, N'Contacts', N'/Contact', NULL, 4, 1)
SET IDENTITY_INSERT [Nav].[MenuItem] OFF
GO