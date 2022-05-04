using GraphQL.Types;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class RecordType : AutoRegisteringObjectGraphType<Application.Features.Document.Common.Record>
    {
        public RecordType()
        {
        }
    }
}
