CREATE TABLE [dbo].[CategoryField]
(
    [Id]            UNIQUEIDENTIFIER        NOT NULL    CONSTRAINT [PK_CategoryField]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Name]          NVARCHAR(256)           NOT NULL, 
    [Type]          SMALLINT                NOT NULL, 
    [IsRequired]    BIT                     NOT NULL, 
    [CategoryId]    UNIQUEIDENTIFIER        NOT NULL, 
    [DateCreated]   DATETIME                NOT NULL, 
    [DateModified]  DATETIME                NULL, 
    [CreatedBy]     NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]    NVARCHAR(256)           NULL, 
    [IsDeleted]     BIT                     NULL        CONSTRAINT [DF_CategoryField_IsDeleted] DEFAULT(0), 
)

