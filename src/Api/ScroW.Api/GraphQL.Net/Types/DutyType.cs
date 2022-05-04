using GraphQL.Types;
using ScroW.Application.Features.Information.Queries.BasicInformation;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class DutyType : AutoRegisteringObjectGraphType<Duty>
    {
        public DutyType()
        {
        }
    }
}