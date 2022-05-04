using GraphQL.Types;
using ScroW.Application.Features.Document.Commands.RegisterRecord;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class RecordInformationType : AutoRegisteringObjectGraphType<RecordInformation>
    {
        public RecordInformationType()
        {
        }
    }
}
