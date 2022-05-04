using GraphQL.Types;
using ScroW.Application.Features.Token.Commands.CreateToken;

namespace ScroW.Api.GraphQL.Net.Types
{
    public class TokenResponseType : AutoRegisteringObjectGraphType<TokenResponse>
    {
        public TokenResponseType()
        {
        }
    }
}
