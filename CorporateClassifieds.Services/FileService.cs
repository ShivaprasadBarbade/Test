using AutoMapper;
using CorporateClassifieds.Repository.Interfaces;
using CorporateClassifieds.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using File = CorporateClassifieds.Repository.Dapper.Entities.File;

namespace CorporateClassifieds.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public List<Guid> AddFiles(List<IFormFile> files)
        {
            try
            {
                List<Guid> fileIds = new List<Guid>();

                List<File> fileEntities = files.Select(fileItem =>
                {
                    File file = new File();

                    file.Id = Guid.NewGuid();
                    fileIds.Add(file.Id);

                    file.DateCreated = DateTime.UtcNow;
                    file.CreatedBy = Guid.NewGuid().ToString();

                    var memoryStream = new MemoryStream();
                    fileItem.CopyTo(memoryStream);

                    file.Data = memoryStream.ToArray();

                    return file;

                }).ToList();

                if (!_fileRepository.InsertFiles(fileEntities))
                    throw new Exception("Files Insertion Failed");

                return fileIds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Guid? AddFile(IFormFile file)
        {
            try
            {
                File fileEntity = new File();

                fileEntity.Id = Guid.NewGuid();

                fileEntity.DateCreated = DateTime.UtcNow;
                fileEntity.CreatedBy = Guid.NewGuid().ToString();

                var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream);

                fileEntity.Data = memoryStream.ToArray();

                if (!_fileRepository.InsertFile(fileEntity))
                    throw new Exception("Files Insertion Failed");

                return fileEntity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public byte[] GetFile(Guid id)
        {
            try
            {
                return _fileRepository.FetchFile(id).Data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
