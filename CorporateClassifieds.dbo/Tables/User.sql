CREATE TABLE [dbo].[User]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_User]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Name]              NVARCHAR(256)           NOT NULL, 
    [Email]             NVARCHAR(256)           NOT NULL, 
    [Address]           NVARCHAR(512)           NOT NULL, 
    [Mobile]            NVARCHAR(32)            NOT NULL, 
    [Password]          NVARCHAR(256)           NOT NULL, 
    [ImageId]           UNIQUEIDENTIFIER           NULL, 
    [IsAdmin]           BIT                     NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL     CONSTRAINT [DF_User_IsDeleted] DEFAULT(0), 
)
