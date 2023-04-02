namespace CorporateClassifieds.Repository.Interfaces
{
    public interface IFileRepository
    {
        Dapper.Entities.File FetchFile(Guid id);
        bool InsertFiles(List<Dapper.Entities.File> files);
        bool InsertFile(Dapper.Entities.File file);
    }
}