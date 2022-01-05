namespace GovernmentSystem.Application.Interfaces
{
    public interface ITaxService
    {
        Task<RequestResponse> CreateTax(CreateTaxCommand command, CancellationToken cancellationToken);
        Task<RequestResponse> DeleteTax(DeleteTaxCommand command, CancellationToken cancellationToken);
        TaxResponse GetTaxById(GetTaxByIdQuery query);
        List<TaxResponse> GetTaxes(GetTaxesQuery query);
        Task<RequestResponse> UpdateTax(UpdateTaxCommand command, CancellationToken cancellationToken);
    }
}
