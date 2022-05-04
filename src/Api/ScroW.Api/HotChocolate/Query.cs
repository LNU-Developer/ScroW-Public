using MediatR;
using ScroW.Application.Features.Information.Queries.BasicInformation;
using ScroW.Application.Features.Information.Queries.CaseStatus;

namespace ScroW.Api.HotChocolate
{
    public class Query
    {
        public async Task<BasicInformationResponse> GetBasicInformation(string organizationNumber, [Service] IMediator mediator)
        {
            return await mediator.Send(new BasicInformationQuery
            {
                OrganizationNumber = organizationNumber
            });
        }

        public async Task<CaseStatusResponse> GetCaseStatus(string organizationNumber, [Service] IMediator mediator)
        {
            return await mediator.Send(new CaseStatusQuery
            {
                OrganizationNumber = organizationNumber
            });
        }
    }
}
