CREATE TABLE [dbo].[Category]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL    CONSTRAINT [PK_Category]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Title]             NVARCHAR(1024)          NOT NULL, 
    [Description]       NVARCHAR(MAX)           NOT NULL, 
    [AddedBy]           UNIQUEIDENTIFIER        NOT NULL, 
    [AddedOn]           DATETIME                NOT NULL, 
    [Icon]              SMALLINT                NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL        CONSTRAINT [DF_Category_IsDeleted] DEFAULT(0),
)
