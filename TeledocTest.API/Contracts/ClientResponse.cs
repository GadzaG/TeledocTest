using TeledocTest.Core.Models;

namespace TeledocTest.API.Contracts
{
    public record ClientResponse(
        Guid Id,
        string Title,
        string INN,
        Core.Models.Type Type,
        List<Founder> Founders
        );
}
