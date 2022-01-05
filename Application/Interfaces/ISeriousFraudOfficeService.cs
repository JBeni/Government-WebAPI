namespace GovernmentSystem.Application.Interfaces
{
    public interface ISeriousFraudOfficeService
    {
        Task<RequestResponse> CreateSeriousFraudOffice(CreateSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteSeriousFraudOffice(DeleteSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        SeriousFraudOfficeResponse GetSeriousFraudOfficeById(GetSeriousFraudOfficeByIdQuery query);
        List<SeriousFraudOfficeResponse> GetSeriousFraudOffices(GetSeriousFraudOfficesQuery query);
        Task<RequestResponse> UpdateSeriousFraudOffice(UpdateSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
    }
}
