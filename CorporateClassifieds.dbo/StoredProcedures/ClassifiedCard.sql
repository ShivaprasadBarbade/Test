CREATE Procedure [dbo].[ClassifiedCard]
    @Type smallint,
    @CategoryId nvarchar(max),
    @Location nvarchar(256)

As
SELECT       Classified.Id,
             Classified.Title,
             Classified.[Type],
             Classified.Addedon,
             Price,
             Categoryid,
             Category.Icon          AS CategoryIcon,
             Classified.[Description],
             RemovedBy,
             Duration,
             [User].[Address]                As Location,
             [User].id              AS UserId,
             [User].[NAME]          AS PublishedBy,
             [User].Imageid         AS ProfileImageId,
             OfferData.Offercount,
             CommentData.Commentcount
FROM   Classified
       INNER JOIN Category
               ON Classified.Categoryid = Category.id 
                  ANd Classified.Type = COALESCE(NULLIF(@Type,''), Classified.Type)  
                  AND Category.Id = COALESCE(NULLIF(@CategoryId,''), Category.id)
       INNER JOIN [User]
               ON [User].id = Classified.addedby
                  AND Classified.isdeleted = 0
                  AND Address = COALESCE(NULLIF(@Location, ''), [User].Address)
       LEFT JOIN (SELECT Count(Comment.id) AS CommentCount,
                         Comment.Classifiedid
                  FROM   Comment
                  GROUP  BY Comment.Classifiedid) AS CommentData
              ON CommentData.Classifiedid = Classified.id
       LEFT JOIN (SELECT Count(Classifiedoffer.id) AS OfferCount,
                         Classifiedoffer.Classifiedid
                  FROM   Classifiedoffer
                  GROUP  BY Classifiedoffer.Classifiedid) AS OfferData
              ON OfferData.Classifiedid = Classified.id 



