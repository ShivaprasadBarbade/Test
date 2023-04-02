CREATE TABLE [dbo].[Report]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_Report]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [ClassifiedId]      UNIQUEIDENTIFIER        NOT NULL, 
    [Description]       NVARCHAR(MAX)           NOT NULL, 
    [Type]              SMALLINT                NOT NULL, 
    [ReportedBy]        UNIQUEIDENTIFIER        NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL    CONSTRAINT [DF_Report_IsDeleted] DEFAULT(0),  
)
