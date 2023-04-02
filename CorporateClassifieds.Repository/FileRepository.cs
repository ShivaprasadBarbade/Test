using AutoMapper;
using CorporateClassifieds.Repository.Dapper;
using CorporateClassifieds.Repository.Interfaces;
using File = CorporateClassifieds.Repository.Dapper.Entities.File;

namespace CorporateClassifieds.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly IDatabase _db;

        public FileRepository(IDatabase db)
        {
            _db = db;
        }

        public bool InsertFiles(List<File> files)
        {
            try
            {
                _db.Insert<File>(files);

                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public bool InsertFile(File file)
        {
            try
            {
                _db.Insert(file);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public File FetchFile(Guid id)
        {
            try
            {
                var query = @"SELECT * FROM [File] WHERE Id = @id";
                return _db.SingleOrDefault<File>(query, new {Id = id});
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
