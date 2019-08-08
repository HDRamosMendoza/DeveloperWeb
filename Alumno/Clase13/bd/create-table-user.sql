CREATE TABLE [dbo].[User](
	Id int IDENTITY(1,1) NOT NULL,
	FirstName nvarchar(200) NOT NULL,
	LastName nvarchar(200) NOT NULL,
	Email nvarchar(200) NOT NULL,
	[Password] nvarchar(100) NOT NULL,
	Roles [nvarchar](100) NULL,
	CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED(ID)
)