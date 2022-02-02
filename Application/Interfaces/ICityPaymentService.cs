namespace GovernmentSystem.Application.Interfaces
{
    public interface ICityPaymentService
    {
        Task<RequestResponse> CreateCityPayment(CreateCityPaymentCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteCityPayment(DeleteCityPaymentCommand command, CancellationToken cancellationToken);
        Result<CityPaymentResponse> GetCityPaymentById(GetCityPaymentByIdQuery query);
        Result<CityPaymentResponse> GetCityPayments(GetCityPaymentsQuery query);
        Task<RequestResponse> UpdateCityPayment(UpdateCityPaymentCommand command, CancellationToken cancellationToken);
    }
}
