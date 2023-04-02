CREATE TABLE [dbo].[Comment]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_Comments]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [AddedBy]           UNIQUEIDENTIFIER        NOT NULL, 
    [ClassifiedId]      UNIQUEIDENTIFIER        NOT NULL, 
    [ParentCommentId]   UNIQUEIDENTIFIER        NULL, 
    [Message]           NVARCHAR(MAX)           NOT NULL, 
    [AddedOn]           DATETIME                NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL     CONSTRAINT [DF_Comments_IsDeleted] DEFAULT(0), 
)
