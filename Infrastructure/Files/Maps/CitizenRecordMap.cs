using CsvHelper.Configuration;
using System.Globalization;
using GovernmentSystem.Application.BusinessLogic.Handlers.Citizens.Queries;

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
