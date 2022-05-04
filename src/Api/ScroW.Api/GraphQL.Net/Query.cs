using GraphQL;
using GraphQL.Types;
using MediatR;
using ScroW.Api.GraphQL.Net.Types;
using ScroW.Application.Features.Information.Queries.BasicInformation;
using ScroW.Application.Features.Information.Queries.CaseStatus;

namespace ScroW.Api.GraphQL.Net
{
    public class Query : ObjectGraphType
    {
        public Query(IMediator mediator)
        {
            FieldAsync<BasicInformationResponseType>(
                Name = "basicInformation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "organizationNumber" }),
                resolve: async x =>
                {
                    return await mediator.Send(new BasicInformationQuery
                    {
                        OrganizationNumber = x.GetArgument<string>("organizationNumber")
                    });
                });
            FieldAsync<CaseStatusResponseType>(
                Name = "caseStatus",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "organizationNumber" }),
                resolve: async x =>
                {
                    return await mediator.Send(new CaseStatusQuery
                    {
                        OrganizationNumber = x.GetArgument<string>("organizationNumber")
                    });
                });
        }
    }
}
