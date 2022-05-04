using GraphQL.Types;
using ScroW.Application.Features.Information.Queries.BasicInformation;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class StatusType : AutoRegisteringObjectGraphType<Status>
    {
        public StatusType()
        {
        }
    }
}
