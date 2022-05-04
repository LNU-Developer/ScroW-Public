using MediatR;
using ScroW.Application.Features.Document.Commands.CheckRecord;
using ScroW.Application.Features.Document.Commands.RegisterRecord;
using ScroW.Application.Features.Document.Common;
using ScroW.Application.Features.Token.Commands.CreateToken;

namespace ScroW.Api.HotChocolate
{
    public class Mutation
    {
        public async Task<TokenResponse> CreateToken(string organizationNumber, string socialSecurityNumber, [Service] IMediator mediator)
        {
            return await mediator.Send(new CreateTokenCommand
            {
                SocialSecurityNumber = socialSecurityNumber,
                OrganizationNumber = organizationNumber
            });
        }

        public async Task<CheckRecordResponse> CheckRecord(Guid token, RecordType type, byte[] file, [Service] IMediator mediator)
        {
            return await mediator.Send(new CheckRecordCommand
            {
                Token = token,
                File = file,
                Type = type
            });
        }

        public async Task<RegisterRecordResponse> RegisterRecord(
            Guid token,
            string signerSocialSecurityNumber,
            List<string> signerEmailAddresses,
            List<string> acknowledgementEmailAddresses,
            RecordType type,
            byte[] file, [Service] IMediator mediator)
        {
            return await mediator.Send(new RegisterRecordCommand
            {
                SignerSocialSecurityNumber = signerSocialSecurityNumber,
                SignerEmailAddresses = signerEmailAddresses,
                AcknowledgementEmailAddresses = acknowledgementEmailAddresses,
                Token = token,
                Type = type,
                File = file
            });
        }
    }
}
