CREATE TABLE [dbo].[File]
(
	[Id]		          UNIQUEIDENTIFIER	    NOT NULL  CONSTRAINT [PK_File] PRIMARY KEY ([Id]) DEFAULT (NEWSEQUENTIALID()), 
    [Data]		          VARBINARY(MAX)		NOT NULL,
	[DateCreated]         DATETIME              NOT NULL, 
    [DateModified]        DATETIME              NULL, 
    [CreatedBy]           NVARCHAR(256)         NOT NULL, 
    [ModifiedBy]          NVARCHAR(256)         NULL, 
    [IsDeleted]           BIT                   NULL     CONSTRAINT [DF_File_IsDeleted] DEFAULT(0)
)
