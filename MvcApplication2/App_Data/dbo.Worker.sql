CREATE TABLE [dbo].[Workers] (
    [IdWorker] INT        IDENTITY (1, 1) NOT NULL,
    [login]    NCHAR (50) NOT NULL,
    [fio]      NCHAR (50) NOT NULL,
    [workExp]  INT        NOT NULL,
    [salary]   INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([IdWorker] ASC)
);

