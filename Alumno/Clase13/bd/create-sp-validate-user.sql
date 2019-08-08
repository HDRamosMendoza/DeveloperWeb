CREATE PROCEDURE [dbo].[ValidateUser]
	@email varchar(200),
	@password varchar(100)
AS
BEGIN
SELECT [Id]
	,[Email]
	,[FirstName]
	,[LastName]
	,[Roles]
FROM [dbo].[User]
WHERE [Email]=@email AND [Password]=@password
END