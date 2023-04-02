﻿CREATE TABLE [dbo].[Classified]
(
    [Id]                UNIQUEIDENTIFIER        NOT NULL CONSTRAINT [PK_Classified]  PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Type]              SMALLINT                NOT NULL, 
    [CategoryId]        UNIQUEIDENTIFIER           NOT NULL, 
    [Price]             DECIMAL                 NOT NULL, 
    [Title]             NVARCHAR(512)           NOT NULL, 
    [Description]       NVARCHAR(MAX)           NOT NULL, 
    [AddedOn]           DATETIME                NOT NULL, 
    [AddedBy]           UNIQUEIDENTIFIER        NOT NULL, 
    [Duration]          INT                     NOT NULL,
    [ViewCount]         INT                     NOT NULL,
    [RemovedBy]         SMALLINT                NULL, 
    [RemovedOn]         DATETIME                NULL, 
    [DeletedReason]     NVARCHAR(MAX)           NULL, 
    [ShowContact]       BIT                     NOT NULL, 
    [DateCreated]       DATETIME                NOT NULL, 
    [DateModified]      DATETIME                NULL, 
    [CreatedBy]         NVARCHAR(256)           NOT NULL, 
    [ModifiedBy]        NVARCHAR(256)           NULL, 
    [IsDeleted]         BIT                     NULL    CONSTRAINT [DF_Classified_IsDeleted] DEFAULT(0),
)