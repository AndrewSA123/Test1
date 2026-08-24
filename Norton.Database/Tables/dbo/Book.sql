CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Author] NVARCHAR(200) NOT NULL, 
    [PublishedDate] DATE NOT NULL, 
    [Genre] NVARCHAR(MAX) NOT NULL, 
    [Price] DECIMAL NOT NULL
)
