ALTER TABLE [User] ALTER COLUMN PasswordSalt nvarchar(256)
GO
ALTER TABLE [User] ALTER COLUMN PasswordHash nvarchar(256)
GO