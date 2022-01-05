namespace GovernmentSystem.Application.Interfaces
{
    public interface IPublicServantSeriousFraudOfficeservice
    {
        Task<RequestResponse> CreatePublicServantSeriousFraudOffice(CreatePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeletePublicServantSeriousFraudOffice(DeletePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
        PublicServantSeriousFraudOfficeResponse GetPublicServantSeriousFraudOfficeById(GetPublicServantSeriousFraudOfficeByIdQuery query);
        List<PublicServantSeriousFraudOfficeResponse> GetPublicServantSeriousFraudOffices(GetPublicServantSeriousFraudOfficesQuery query);
        Task<RequestResponse> UpdatePublicServantSeriousFraudOffice(UpdatePublicServantSeriousFraudOfficeCommand command, CancellationToken cancellationToken);
    }
}
