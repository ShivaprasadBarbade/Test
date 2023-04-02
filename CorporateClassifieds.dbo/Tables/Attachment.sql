CREATE TABLE [dbo].[Attachment]
(
    [Id]                  UNIQUEIDENTIFIER      NOT NULL CONSTRAINT [PK_Attachment]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()),
    [ClassifiedId]        UNIQUEIDENTIFIER      NOT NULL, 
    [FileId]              UNIQUEIDENTIFIER      NOT NULL, 
    [DateCreated]         DATETIME              NOT NULL, 
    [DateModified]        DATETIME              NULL, 
    [CreatedBy]           NVARCHAR(256)         NOT NULL, 
    [ModifiedBy]          NVARCHAR(256)         NULL, 
    [IsDeleted]           BIT                   NULL     CONSTRAINT [DF_Attachment_IsDeleted] DEFAULT(0),
)
