namespace GovernmentSystem.Application.Interfaces
{
    public interface ITaxService
    {
        Task<RequestResponse> CreateTax(CreateTaxCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteTax(DeleteTaxCommand command, CancellationToken cancellationToken);
        Result<TaxResponse> GetTaxById(GetTaxByIdQuery query);
        Result<TaxResponse> GetTaxes(GetTaxesQuery query);
        Task<RequestResponse> UpdateTax(UpdateTaxCommand command, CancellationToken cancellationToken);
    }
}
