CREATE TABLE [dbo].[Chat]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_Chat]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Message]           NVARCHAR(MAX)           NOT NULL, 
    [AddedOn]           DATETIME                NOT NULL, 
    [OfferId]           UNIQUEIDENTIFIER        NOT NULL, 
    [AddedBy]           UNIQUEIDENTIFIER        NOT NULL, 
    [ClassifiedId]      UNIQUEIDENTIFIER        NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL     CONSTRAINT [DF_Chat_IsDeleted] DEFAULT(0),
)

