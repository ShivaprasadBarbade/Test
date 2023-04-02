using AutoMapper;
using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Models.ViewModels;
using CorporateClassifieds.Repository.Interfaces;
using CorporateClassifieds.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CorporateClassifieds.Services
{
    public class ClassifiedService
    {
        private readonly IMapper _mapper;
        private readonly IClassifiedRepository _classifiedRepository;
        private readonly IFileService _fileService;

        public ClassifiedService(IMapper mapper,IClassifiedRepository classifiedRepo,IFileService fileService)
        {
            _mapper = mapper;
            _classifiedRepository = classifiedRepo;
            _fileService = fileService;
        }
        public void AddClassified(ClassifiedFormView classifiedView)
        {
            try
            {

                Classified classified = _mapper.Map<Classified>(classifiedView);
                classified.Id = Guid.NewGuid();

                _classifiedRepository.InsertClassified(classified);

                List<ClassifiedField> classifiedFields = classifiedView.Fields.Select(fieldItem =>
                {
                    ClassifiedField classifiedField = _mapper.Map<ClassifiedField>(fieldItem);
                    classifiedField.Id = Guid.NewGuid();
                    classifiedField.ClassifiedId = classified.Id;

                    return classifiedField;
                }).ToList();

                _classifiedRepository.InsertClassifiedFields(classifiedFields, classified.AddedBy);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void UpdateClassified(ClassifiedFormView classifiedView)
        {
            try
            {
                Classified classified = _mapper.Map<Classified>(classifiedView);

                _classifiedRepository.UpdateClassified(classified);

                List<ClassifiedField> classifiedFields = classifiedView.Fields.Select(fieldItem =>
                {
                    ClassifiedField classifiedField = _mapper.Map<ClassifiedField>(fieldItem);
                    classifiedField.ClassifiedId = classified.Id;

                    return classifiedField;
                }).ToList();

                _classifiedRepository.UpdateClassifiedFields(classifiedFields, classified.AddedBy);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteClassified(Guid classifiedId,short removedBy)
        {
            try
            {
                _classifiedRepository.DeleteClassified(classifiedId, removedBy);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddAttachments(List<IFormFile> files,Guid classifiedId)
        {
            try
            {
                List<Repository.Dapper.Entities.Attachment> attachments = new List<Repository.Dapper.Entities.Attachment>();
            
                List<Guid> ids = _fileService.AddFiles(files);

                if (ids.Count == 0)
                    throw new Exception("Insertion faild");


                int i = 0;
                files.ForEach(file =>
                {
                    Repository.Dapper.Entities.Attachment attachment = new Repository.Dapper.Entities.Attachment();
                    attachment.Id = Guid.NewGuid();
                    attachment.ClassifiedId = classifiedId;
                    attachment.FileId = ids.ElementAt(i++);
                    attachment.CreatedBy = Guid.NewGuid().ToString();
                    attachment.DateCreated = DateTime.UtcNow;

                    attachments.Add(attachment);
                });

                _classifiedRepository.InsertAttachments(attachments);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public List<string> GetAttachments(Guid classifiedId)
        {
            try
            {
                List<Guid> attachmentIds = _classifiedRepository.GetAttachmentIds(classifiedId);
            
                List<string> attachmentURLs = new List<string>();

                attachmentIds.ForEach(attachmentId =>
                {
                    attachmentURLs.Add($"https://localhost:7251/api/file?id={attachmentId}");
                });

                return attachmentURLs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ClassifiedView GetClassified(Guid id)
        {
            try
            {
                Classified classified = _classifiedRepository.GetClassified(id);

                List<Repository.Dapper.Entities.ClassifiedField> classifiedFieldEntities = _classifiedRepository.GetClassifiedFields(id);

                ClassifiedView classifiedView = _mapper.Map<ClassifiedView>(classified);

                List<ClassifiedField> classifiedFields = _mapper.Map<List<ClassifiedField>>(classifiedFieldEntities);

                List<ClassifiedFieldView> classifiedFieldViews = _mapper.Map<List<ClassifiedFieldView>>(classifiedFields);
                
                classifiedView.Fields= classifiedFieldViews;

                return classifiedView;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ClassifiedCardView> GetClassifiedCards(short? type, Guid? categoryId, string? location)
        {
            try
            {
               return _classifiedRepository.GetClassifiedCards(type, categoryId, location);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
