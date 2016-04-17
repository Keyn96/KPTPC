CREATE TABLE [dbo].[Worker]
(
	[IdWorker] INT NOT NULL PRIMARY KEY IDENTITY, 
    [login] NCHAR(50) NOT NULL, 
    [fio] NCHAR(50) NOT NULL, 
    [workExp] INT NOT NULL, 
    [salary] INT NOT NULL
)
