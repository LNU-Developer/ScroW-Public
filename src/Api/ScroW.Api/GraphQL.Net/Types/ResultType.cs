using GraphQL.Types;
using ScroW.Application.Features.Document.Commands.CheckRecord;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class ResultType : AutoRegisteringObjectGraphType<Result>
    {
        public ResultType()
        {
        }
    }
}
