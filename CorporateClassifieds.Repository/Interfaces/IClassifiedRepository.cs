using CorporateClassifieds.Models.CoreModels;
using CorporateClassifieds.Models.Enums;
using CorporateClassifieds.Models.ViewModels;

namespace CorporateClassifieds.Repository.Interfaces
{
    public interface IClassifiedRepository
    {
        void InsertClassified(Classified classified);

        void InsertClassifiedFields(List<ClassifiedField> classifiedFields,Guid userId);

        void InsertAttachments(List<Dapper.Entities.Attachment> attachments);

        void UpdateClassified(Classified classified);

        void UpdateClassifiedFields(List<ClassifiedField> Fields, Guid userId);

        void DeleteClassified(Guid classifiedId, short removedBy);

        List<Guid> GetAttachmentIds(Guid classifiedId);

        Classified GetClassified(Guid id);

        List<Dapper.Entities.ClassifiedField> GetClassifiedFields(Guid classifiedId);

        List<ClassifiedCardView> GetClassifiedCards(short? type, Guid? categoryId, string? location);
    }
}