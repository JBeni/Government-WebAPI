using CsvHelper;
using GovernmentSystem.Application.Handlers.Citizens.Queries;
using GovernmentSystem.Application.Common.Interfaces;
using GovernmentSystem.Infrastructure.Files.Maps;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GovernmentSystem.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildCitizensFIle(IEnumerable<CitizenRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Context.RegisterClassMap<CitizenRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
