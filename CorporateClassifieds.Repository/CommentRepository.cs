//using AutoMapper;
//using CorporateClassifieds.Models.CoreModels;
//using CorporateClassifieds.Repository.Dapper;
//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CorporateClassifieds.Repository
//{
//    public class CommentRepository
//    {
//        public DapperDBContext _dBContext;

//        private readonly Mapper _mapperConfig;

//        public CommentRepository(DapperDBContext dBContext,MapperConfig mapperConfig)
//        {
//            this._dBContext = dBContext;
//            this._mapperConfig = mapperConfig.GetMapper();

//        }
//        public void AddComment(Comment comment)
//        {
//            var query = @"INSERT INTO Comments ([AddedBy],[ClassifiedId],[ParentCommentId],[Message],[AddedOn],[DateCreated],[DateModified],[DateDeleted],[CreatedBy],[ModifiedBy],[IsDeleted],[DeletedBy])
//                          VALUES(@AddedBy, @ClassifiedBy, @ParentCommentId, @Message, @AddedOn, @DateCreated, @DateModified, @DateDeleted, @CreatedBy, @ModifiedBy, @@IsDeleted, @DeletedBy) ";
//            _dBContext.Db.Execute(query, comment);
//        }
//    }
//}
