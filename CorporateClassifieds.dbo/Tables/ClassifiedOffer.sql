CREATE TABLE [dbo].[ClassifiedOffer]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_ClassifiedOffer]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [ClassifiedId]      UNIQUEIDENTIFIER        NOT NULL, 
    [UserId]            UNIQUEIDENTIFIER        NOT NULL, 
    [Amount]            DECIMAL                 NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL     CONSTRAINT [DF_ClassifiedOffer_IsDeleted] DEFAULT(0),   
)
