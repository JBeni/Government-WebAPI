namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildCitizensFIle(IEnumerable<CitizenExport> records);
    }
}
