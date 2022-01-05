namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityPaymentService
    {
        Task<RequestResponse> CreateCityPayment(CreateCityPaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityPayment(DeleteCityPaymentCommand command, CancellationToken cancellationToken);
        CityPaymentResponse GetCityPaymentById(GetCityPaymentByIdQuery query);
        List<CityPaymentResponse> GetCityPayments(GetCityPaymentsQuery query);
        Task<RequestResponse> UpdateCityPayment(UpdateCityPaymentCommand command, CancellationToken cancellationToken);
    }
}
