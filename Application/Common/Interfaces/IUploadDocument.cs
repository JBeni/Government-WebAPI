using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IUploadDocument
    {
        Task Upload(List<IFormFile> documents);
    }
}
