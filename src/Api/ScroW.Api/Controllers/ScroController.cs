using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ScroW.Application.Features.Information.Queries.BasicInformation;
using ScroW.Application.Features.Information.Queries.CaseStatus;
using ScroW.Application.Features.Token.Commands.CreateToken;
using ScroW.Application.Features.Document.Commands.CheckRecord;
using ScroW.Application.Features.Document.Common;
using ScroW.Application.Features.Document.Commands.RegisterRecord;
using ScroW.Application.Features.Common;

namespace ScroW.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorMessage), 400)]
    [ProducesResponseType(typeof(ErrorMessage), 403)]
    [ProducesResponseType(typeof(ErrorMessage), 404)]
    [ProducesResponseType(typeof(ErrorMessage), 500)]
    [ProducesResponseType(typeof(ErrorMessage), 503)]
    [ProducesResponseType(typeof(ErrorMessage), 504)]
    public class ScroController : ControllerBase
    {
        public readonly IMediator mediator;

        public ScroController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("BasicInformation/{organizationNumber}")]
        [ProducesResponseType(typeof(BasicInformationResponse), 200)]
        public async Task<IActionResult> BasicInformationAsync([Required][FromRoute] string organizationNumber)
        {
            return Ok(await mediator.Send(new BasicInformationQuery
            {
                OrganizationNumber = organizationNumber
            }));
        }

        [HttpGet("CaseStatus/{organizationNumber}")]
        [ProducesResponseType(typeof(CaseStatusResponse), 200)]
        public async Task<IActionResult> CaseStatusAsync([Required][FromRoute] string organizationNumber)
        {
            return Ok(await mediator.Send(new CaseStatusQuery
            {
                OrganizationNumber = organizationNumber
            }));
        }

        [HttpPost("CreateToken")]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        public async Task<IActionResult> CreateTokenAsync([Required][FromBody] CreateTokenCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPost("CheckRecord/{token}")]
        [ProducesResponseType(typeof(CheckRecordResponse), 200)]
        public async Task<IActionResult> CheckRecordAsync([Required][FromRoute] Guid token, [Required] RecordType type, [Required][FromBody] byte[] file)
        {
            return Ok(await mediator.Send(new CheckRecordCommand
            {
                Token = token,
                File = file,
                Type = type
            }));
        }

        [HttpPost("RegisterRecord/{token}")]
        [ProducesResponseType(typeof(RegisterRecordResponse), 200)]
        public async Task<IActionResult> RegisterRecordAsync(
            [Required][FromRoute] Guid token,
            [Required] string signerSocialSecurityNumber,
            [Required] List<string> signerEmailAddresses,
            [Required] List<string> acknowledgementEmailAddresses,
            [Required] RecordType type,
            [Required][FromBody] byte[] file)
        {
            return Ok(await mediator.Send(new RegisterRecordCommand
            {
                SignerSocialSecurityNumber = signerSocialSecurityNumber,
                SignerEmailAddresses = signerEmailAddresses,
                AcknowledgementEmailAddresses = acknowledgementEmailAddresses,
                Token = token,
                Type = type,
                File = file
            }));
        }
    }
}