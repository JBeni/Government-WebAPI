namespace GovernmentSystem.Infrastructure.Files.Maps
{
    public class CitizenRecordMap : ClassMap<CitizenExport>
    {
        public CitizenRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            //Map(m => m.Active).Convert(c => c.Active ? true : false);
        }
    }
}
