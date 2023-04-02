using AutoMapper;
using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Models.ViewModels;
using CorporateClassifieds.Repository.Dapper;
using CorporateClassifieds.Repository.Interfaces;
using Dapper;
using System.Data;
using static Slapper.AutoMapper;

namespace CorporateClassifieds.Repository
{
    public class ClassifiedRepository : IClassifiedRepository
    {
        private readonly IMapper _mapper;
        private readonly IDatabase _db;
        public ClassifiedRepository(IMapper mapper, IDatabase database)
        {
            _mapper = mapper;
            _db = database;
        }
        public void InsertClassified(Classified classified)
        {
            try
            {
                Dapper.Entities.Classified classfiedDataModel = _mapper.Map<Dapper.Entities.Classified>(classified);
                classfiedDataModel.ViewCount = 0;
                classfiedDataModel.DateCreated = DateTime.UtcNow;
                classfiedDataModel.CreatedBy = classified.AddedBy.ToString();

                //var query = @"INSERT INTO Classified
                //            VALUES(@Id, @Type, @CategoryId, @Price, @Title, @Description, @Duration, @AddedOn, @AddedBy, @RemovedBy, @RemovedOn, @DeletedReason, @showContact, @DateCreated, @DateModified, @CreatedBy, @ModifiedBy, @IsDeleted)";
                _db.Insert(classfiedDataModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertClassifiedFields(List<ClassifiedField> Fields,Guid userId)
        {
            try
            {
                List<Dapper.Entities.ClassifiedField> classifiedFields = Fields.Select(fieldItem =>
                {
                    Dapper.Entities.ClassifiedField classfiedField = _mapper.Map<Dapper.Entities.ClassifiedField>(fieldItem);
                    classfiedField.CreatedBy = userId.ToString();
                    classfiedField.DateCreated = DateTime.UtcNow;

                    return classfiedField;
                }).ToList();

                _db.Insert<Dapper.Entities.ClassifiedField>(classifiedFields);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public void InsertAttachments(List<Dapper.Entities.Attachment> attachments)
        {
            try
            {
                _db.Insert<Dapper.Entities.Attachment>(attachments);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void UpdateClassifiedFields(List<ClassifiedField> Fields, Guid userId)
        {
            try
            {
                if (Fields.Count == 0)
                    throw new Exception("ClassifiedField List is Empty");

                var query = "SELECT * FROM ClassifiedField WHERE ClassifiedId = @Id";

                List<Dapper.Entities.ClassifiedField> existingClassifiedFields = _db.Fetch<Dapper.Entities.ClassifiedField>(query, new { Id = Fields.FirstOrDefault().ClassifiedId }).ToList();

                List<Dapper.Entities.ClassifiedField> classifiedFields = _mapper.Map<List<ClassifiedField>, List<Dapper.Entities.ClassifiedField>>(Fields, existingClassifiedFields);
                    
               classifiedFields = classifiedFields.Select(fieldItem =>
                {
                    Dapper.Entities.ClassifiedField classfiedField = _mapper.Map<Dapper.Entities.ClassifiedField>(fieldItem);
                    classfiedField.ModifiedBy = userId.ToString();
                    classfiedField.DateModified = DateTime.UtcNow;

                    return classfiedField;

                }).ToList();

                foreach(var classifiedField in classifiedFields)
                    _db.UpdatePartial(classifiedField, Item => new { Item.Value,Item.IsRequired });
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void UpdateClassified(Classified classified)
        {
            try
            {
                var existingClassified = this._db.SingleOrDefault<Dapper.Entities.Classified>("SELECT * From Classified WHERE Id = @Id", new { Id = classified.Id });

                if (existingClassified == null)
                    throw new Exception("Classified Not foud");

                Dapper.Entities.Classified classfiedDataModel = _mapper.Map<Classified, Dapper.Entities.Classified>(classified, existingClassified);
                classfiedDataModel.DateModified = DateTime.UtcNow;
                classfiedDataModel.ModifiedBy = classified.AddedBy.ToString();
                
                _db.UpdatePartial(classfiedDataModel, item => new {item.Type,item.CategoryId,item.Price,item.Title,item.Description,item.Duration,item.ShowContact,item.DateModified,item.ModifiedBy});
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeleteClassified(Guid classifiedId,short removedBy)
        {
            try
            {
                var existingClassified = this._db.SingleOrDefault<Dapper.Entities.Classified>("SELECT * From Classified WHERE Id = @Id", new { Id = classifiedId });

                if (existingClassified == null)
                    throw new Exception("Classified Not foud");

                existingClassified.RemovedBy = removedBy;
                existingClassified.RemovedOn = DateTime.UtcNow;
                existingClassified.DateModified= DateTime.UtcNow;
                existingClassified.ModifiedBy = Guid.NewGuid().ToString();
                existingClassified.IsDeleted = true;

                _db.UpdatePartial(existingClassified,item => new { item.RemovedBy,item.RemovedOn,item.ModifiedBy,item.DateModified,item.IsDeleted});

                DeleteClassifiedFields(classifiedId);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public void DeleteClassifiedFields(Guid classifiedId)
        {
            try
            {
                List<Dapper.Entities.ClassifiedField> existingClassifiedFields = this._db.Fetch<Dapper.Entities.ClassifiedField>("SELECT * From ClassifiedField WHERE ClassifiedId = @Id", new { Id = classifiedId }).ToList();

                if (existingClassifiedFields == null)
                    throw new Exception("ClassifiedField Not foud");

                foreach (var classifiedField in existingClassifiedFields)
                {
                    classifiedField.IsDeleted = true;
                    classifiedField.ModifiedBy = Guid.NewGuid().ToString();
                    classifiedField.DateModified = DateTime.UtcNow;
                    _db.UpdatePartial(classifiedField, item => new { item.IsDeleted, item.ModifiedBy, item.DateModified });
                }
            }
            catch(Exception) 
            { 
                throw; 
            }
        }
        public List<Guid> GetAttachmentIds(Guid classifiedId)
        {
            try
            {
                var query = @"SELECT FileId FROM [Attachment] WHERE ClassifiedId = @classifiedId";

                return _db.Fetch<Guid>(query, new { classifiedId }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Classified GetClassified(Guid id)
        {
            try
            {
                return _db.SingleOrDefault<Classified>("SELECT * FROM Classified WHERE Id = @Id", new {Id = id});
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Dapper.Entities.ClassifiedField> GetClassifiedFields(Guid classifiedId)
        {
            try
            {
                return _db.Fetch<Dapper.Entities.ClassifiedField>("SELECT * FROM ClassifiedField WHERE ClassifiedId = @Id", new { Id = classifiedId }).ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<ClassifiedCardView> GetClassifiedCards(short? type,Guid? categoryId,string? location)
        {
            try
            {

                var query = $"SELECT * FROM ClassifiedCardView";

                var classifiedCards = _db.Fetch<ClassifiedCardView>("ClassifiedCard",new {Type = type,CategoryId = categoryId,Location = location}, CommandType.StoredProcedure).ToList();

                foreach (var classifiedCard in classifiedCards)
                {
                    classifiedCard.ImageId = _db.FirstOrDefault<Guid>("SELECT FileId from Attachment WHERE ClassifiedId = @Id", new { Id = classifiedCard.Id });
                }

                return classifiedCards.Where(e => e.RemovedBy == 0).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
