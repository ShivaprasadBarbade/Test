CREATE TABLE [dbo].[ClassifiedField]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_ClassifiedField]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()),
    [ClassifiedId]      UNIQUEIDENTIFIER        NOT NULL, 
    [AttributeId]       UNIQUEIDENTIFIER        NOT NULL, 
    [Value]             NVARCHAR(MAX)           NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL     CONSTRAINT [DF_ClassifiedField_IsDeleted] DEFAULT(0),  
)

