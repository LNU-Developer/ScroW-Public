using GraphQL.Types;
using Schema = GraphQL.Types.Schema;

namespace ScroW.Api.GraphQL.Net
{
    public class ScroWSchema : Schema
    {
        public ScroWSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = (Query)provider.GetRequiredService(typeof(Query)) ?? throw new InvalidOperationException();
            Mutation = (Mutation)provider.GetService(typeof(Mutation)) ?? throw new InvalidOperationException();
        }
    }
}