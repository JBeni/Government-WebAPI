using GovernmentSystem.Application.Citizens.Queries;
using CsvHelper.Configuration;
using System.Globalization;

namespace GovernmentSystem.Infrastructure.Files.Maps
{
    public class CitizenRecordMap : ClassMap<CitizenRecord>
    {
        public CitizenRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Active).Convert(c => c.Active ? "Yes" : "No");
        }
    }
}
