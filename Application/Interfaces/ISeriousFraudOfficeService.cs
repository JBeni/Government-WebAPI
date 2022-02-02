namespace GovernmentSystem.Application.Interfaces
{
    public interface ISeriousFraudOfficeService
    {
        Task<RequestResponse> CreateSeriousFraudOffice(CreateSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteSeriousFraudOffice(DeleteSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        Result<SeriousFraudOfficeResponse> GetSeriousFraudOfficeById(GetSeriousFraudOfficeByIdQuery query);
        Result<SeriousFraudOfficeResponse> GetSeriousFraudOffices(GetSeriousFraudOfficesQuery query);
        Task<RequestResponse> UpdateSeriousFraudOffice(UpdateSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
    }
}
