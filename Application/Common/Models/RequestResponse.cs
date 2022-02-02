namespace GovernmentSystem.Application.Common.Models
{
    public class RequestResponse
    {
        public bool Successful { get; set; } = false;
        public string? Error { get; set; } = null;
        public Guid EntityId { get; set; } = default(Guid);

        public static RequestResponse Success(Guid id = default(Guid))
        {
            return new RequestResponse { Successful = true, EntityId = id, Error = null };
        }

        public static RequestResponse Failure(string error, Guid id = default(Guid))
        {
            return new RequestResponse { Successful = false, EntityId = id, Error = error };
        }
    }
}
