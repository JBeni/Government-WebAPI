using GovernmentSystem.Application.Handlers.Citizens.Queries;
using System.Collections.Generic;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildCitizensFIle(IEnumerable<CitizenExport> records);
    }
}
