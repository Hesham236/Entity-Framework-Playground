IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Employees] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220921120507_initialCreate', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [Employees];
GO

CREATE TABLE [AuditEntery] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Action] nvarchar(max) NULL,
    CONSTRAINT [PK_AuditEntery] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Blogs] (
    [Id] int NOT NULL IDENTITY,
    [Url] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220925111029_AddTableAuditEnteryAndTableBlogs', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NULL,
    [Content] nvarchar(max) NULL,
    [BlogsId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Blogs_BlogsId] FOREIGN KEY ([BlogsId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Post_BlogsId] ON [Post] ([BlogsId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220925111132_AddTablePosts', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogs] ADD [Addedon] datetime2 NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220925123852_AddColumnAddon', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Books] (
    [Name] nvarchar(450) NOT NULL,
    [author] nvarchar(450) NOT NULL,
    [BookKey] int NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Name], [author])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927101942_AddingTableBooks', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Blogs] ADD [Rating] int NOT NULL DEFAULT 2;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927102052_EditTableBlogs', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Addedon');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Blogs] ADD DEFAULT (GETDATE()) FOR [Addedon];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927121929_defaultvalues', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Authors] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927123956_AddTableAuthor', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Authors] ADD [DisplayName] AS [FirstName] + ' ' + [LastName];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927125339_DisplayNameColumn', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [AuditEntery] DROP CONSTRAINT [PK_AuditEntery];
GO

EXEC sp_rename N'[AuditEntery]', N'Auditenteries';
GO

ALTER TABLE [Auditenteries] ADD CONSTRAINT [PK_Auditenteries] PRIMARY KEY ([Id]);
GO

CREATE TABLE [Categories] (
    [Id] tinyint NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928083812_AddTableCategory', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Post] DROP CONSTRAINT [FK_Post_Blogs_BlogsId];
GO

ALTER TABLE [Post] DROP CONSTRAINT [PK_Post];
GO

EXEC sp_rename N'[Post]', N'Posts';
GO

EXEC sp_rename N'[Posts].[IX_Post_BlogsId]', N'IX_Posts_BlogsId', N'INDEX';
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Blogs]') AND [c].[name] = N'Url');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Blogs] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Blogs] ALTER COLUMN [Url] nvarchar(200) NOT NULL;
GO

ALTER TABLE [Posts] ADD CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]);
GO

CREATE TABLE [BlogImages] (
    [Id] int NOT NULL IDENTITY,
    [Image] nvarchar(max) NOT NULL,
    [caption] nvarchar(100) NOT NULL,
    [BlogForeignKey] int NOT NULL,
    CONSTRAINT [PK_BlogImages] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BlogImages_Blogs_BlogForeignKey] FOREIGN KEY ([BlogForeignKey]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_BlogImages_BlogForeignKey] ON [BlogImages] ([BlogForeignKey]);
GO

ALTER TABLE [Posts] ADD CONSTRAINT [FK_Posts_Blogs_BlogsId] FOREIGN KEY ([BlogsId]) REFERENCES [Blogs] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928102252_BlogAndBlogImageTables', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Posts] DROP CONSTRAINT [FK_Posts_Blogs_BlogsId];
GO

DROP INDEX [IX_Posts_BlogsId] ON [Posts];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Posts]') AND [c].[name] = N'BlogsId');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Posts] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Posts] DROP COLUMN [BlogsId];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928183315_allisback', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tag] (
    [TagId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([TagId])
);
GO

CREATE TABLE [PostTag] (
    [TagId] nvarchar(450) NOT NULL,
    [PostId] int NOT NULL,
    [AddedOn] datetime2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT [PK_PostTag] PRIMARY KEY ([PostId], [TagId]),
    CONSTRAINT [FK_PostTag_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTag_Tag_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([TagId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_PostTag_TagId] ON [PostTag] ([TagId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928205719_manytomany', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Persons] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(450) NOT NULL,
    [LastName] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
);
GO

CREATE INDEX [IX_Blogs_Url] ON [Blogs] ([Url]);
GO

CREATE INDEX [IX_Persons_FirstName_LastName] ON [Persons] ([FirstName], [LastName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928215743_CompositeIndexForPersonTable', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Url') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] ON;
INSERT INTO [Blogs] ([Id], [Url])
VALUES (1, N'www.google.com');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Url') AND [object_id] = OBJECT_ID(N'[Blogs]'))
    SET IDENTITY_INSERT [Blogs] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220928221151_InsertingIntoBlogs', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Stocks] (
    [Id] int NOT NULL IDENTITY,
    [StockName] nvarchar(max) NOT NULL,
    [StockCount] int NOT NULL,
    CONSTRAINT [PK_Stocks] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220929101718_AddStockTable', N'6.0.9');
GO

COMMIT;
GO

