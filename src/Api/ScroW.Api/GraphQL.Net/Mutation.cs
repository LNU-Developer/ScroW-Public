using GraphQL;
using GraphQL.Types;
using MediatR;
using ScroW.Api.GraphQL.Net.Types;
using ScroW.Application.Features.Document.Commands.CheckRecord;
using ScroW.Application.Features.Document.Commands.RegisterRecord;
using ScroW.Application.Features.Token.Commands.CreateToken;

namespace ScroW.Api.GraphQL.Net
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(IMediator mediator)
        {
            FieldAsync<TokenResponseType>(
                Name = "createToken",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "organizationNumber" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "socialSecurityNumber" }
                ),
                resolve: async x =>
                {
                    return await mediator.Send(new CreateTokenCommand
                    {
                        OrganizationNumber = x.GetArgument<string>("organizationNumber"),
                        SocialSecurityNumber = x.GetArgument<string>("socialSecurityNumber")
                    });
                });
            FieldAsync<RegisterRecordResponseType>(
                Name = "registerRecord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "signerSocialSecurityNumber" },
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "signerEmailAddresses" },
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "acknowledgementEmailAddresses" },
                    new QueryArgument<NonNullGraphType<ListGraphType<ByteGraphType>>> { Name = "file" },
                    new QueryArgument<NonNullGraphType<EnumerationGraphType<Application.Features.Document.Common.RecordType>>> { Name = "type" },
                    new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "token" }
                ),
                resolve: async x =>
                {
                    return await mediator.Send(new RegisterRecordCommand
                    {
                        SignerSocialSecurityNumber = x.GetArgument<string>("signerSocialSecurityNumber"),
                        SignerEmailAddresses = x.GetArgument<List<string>>("signerEmailAddresses"),
                        AcknowledgementEmailAddresses = x.GetArgument<List<string>>("acknowledgementEmailAddresses"),
                        File = x.GetArgument<byte[]>("file"),
                        Type = x.GetArgument<Application.Features.Document.Common.RecordType>("type"),
                        Token = x.GetArgument<Guid>("token")
                    });
                });
            FieldAsync<CheckRecordResponseType>(
                Name = "checkRecord",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<ByteGraphType>>> { Name = "file" },
                    new QueryArgument<NonNullGraphType<EnumerationGraphType<Application.Features.Document.Common.RecordType>>> { Name = "type" },
                    new QueryArgument<NonNullGraphType<GuidGraphType>> { Name = "token" }
                ),
                resolve: async x =>
                {
                    return await mediator.Send(new CheckRecordCommand
                    {
                        File = x.GetArgument<byte[]>("file"),
                        Type = x.GetArgument<Application.Features.Document.Common.RecordType>("type"),
                        Token = x.GetArgument<Guid>("token")
                    });
                });
        }
    }
}
