using Microsoft.AspNetCore.Http;

namespace CorporateClassifieds.Services.Interfaces
{
    public interface IFileService
    {
        Guid? AddFile(IFormFile file);
        List<Guid> AddFiles(List<IFormFile> files);
        byte[] GetFile(Guid id);
    }
}