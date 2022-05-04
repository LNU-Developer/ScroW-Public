using ScroW.Application.Features.Information.Queries.BasicInformation;
using ScroW.Application.Features.Information.Queries.CaseStatus;
using ScroW.Application.Features.Token.Commands.CreateToken;

namespace ScroW.Api.PerformanceTests.Models
{
    public static class MockResponse
    {
        public static BasicInformationResponse GetExpectedBasicInformationResponse()
        {
            return new BasicInformationResponse
            {
                OrganizationNumber = "1234567890",
                Name = "Aktiebolaget Specifik Konsult",
                Status = new List<Status>(),
                FinancialPeriods = new List<FinancialPeriod>()
                {
                    new FinancialPeriod()
                    {
                        Start = new DateTime(2016,1,1),
                        End = new DateTime(2016,12,31),
                        IsAudiorReportRequired = AuditRequirementType.Yes
                    },
                    new FinancialPeriod()
                    {
                        Start = new DateTime(2015,1,1),
                        End = new DateTime(2015,12,31),
                        IsAudiorReportRequired = AuditRequirementType.No
                    },
                    new FinancialPeriod()
                    {
                        Start = new DateTime(2014,1,1),
                        End = new DateTime(2014,12,31),
                        IsAudiorReportRequired = AuditRequirementType.No
                    },
                },
                Representatives = new List<Representative>()
                {
                    new Representative()
                    {
                        FirstName = "Kalle",
                        Name = "Karlsson",
                        SocialSecurityNumber = "190101010001",
                        OtherIdentity = null,
                        Duties = new List<Duty>()
                        {
                            new Duty()
                            {
                                Code = "VD",
                                Text = "verkställande direktör"
                            },
                            new Duty()
                            {
                                Code = "LE",
                                Text = "styrelseledamot"
                            },
                        },
                    },
                    new Representative()
                    {
                        FirstName = "Mary Jane",
                        Name = "Olsen",
                        SocialSecurityNumber = null,
                        OtherIdentity = "19010102",
                        Duties = new List<Duty>()
                        {
                            new Duty()
                            {
                                Code = "LE",
                                Text = "styrelseledamot"
                            },
                            new Duty()
                            {
                                Code = "OF",
                                Text = "ordförande"
                            },
                        },
                    },
                    new Representative()
                    {
                        FirstName = null,
                        Name = "Revisor AB",
                        SocialSecurityNumber = null,
                        OtherIdentity = "5500112233",
                        Duties = new List<Duty>()
                        {
                            new Duty()
                            {
                                Code = "REV",
                                Text = "revisor"
                            },
                        },
                    },
                    new Representative()
                    {
                        FirstName = "Calle",
                        Name = "Carlsson",
                        SocialSecurityNumber = "190101030001",
                        OtherIdentity = null,
                        Duties = new List<Duty>()
                        {
                            new Duty()
                            {
                                Code = "REVH",
                                Text = "huvudansvarig revisor"
                            },
                        },
                    },
                },
            };
        }
        public static CaseStatusResponse GetExpectedCaseStatusResponse()
        {
            return new CaseStatusResponse
            {
                OrganizationNumber = "1234567890",
                Name = "Aktiebolaget Specifik Konsult",
                Retrieved = DateTime.Parse("2022-04-23T10:09:46.401+02:00"),
                Time = DateTime.Parse("0001-01-01T00:00:00.0002017"),
                Type = CaseStatusType.Submitted,
                CaseNumber = "9123458/2017",
                FinancialPeriod = null
            };
        }

        public static TokenResponse GetExpectedCreateTokenResponse()
        {
            return new TokenResponse
            {
                Token = Guid.Parse("9569065c-9198-4d8d-a89d-ddaaed11de47"),
                AgreementText = @"
                                Ett Eget utrymme har nu skapats för det Företag som Du har angett. Genom att använda funktionerna på denna sida ingår
                                Företaget genom Användaren avtal om begärt Eget utrymme med Bolagsverket. Utrymmet kan därefter användas så att årsredovisningshandlingar
                                laddas upp för automatisk kontroll eller för inlämning. Vid uppladdning för inlämning anges en företrädare för Företaget som får ett
                                meddelande när årsredovisningen nått Företagets Eget utrymme om att det är dags att elektroniskt\r\n  1. logga in med en e-legitimation som
                                Bolagsverket godtar i företagets Eget utrymme,\r\n  2. skriva under ett fastställelseintyg och en bestyrkandemening, och\r\n  3. skicka den
                                färdiga handlingen från utrymmet till Bolagsverkets mottagningsfunktion så att ett registreringsärende startar hos Bolagsverket.\r\n\r\n
                                För Eget utrymme hos Bolagsverket gäller de allmänna villkor som visas via denna länk, http://www.bolagsverket.se/digital-arsredovisning-villkor.
                                Genom att ta del av villkoren och acceptera dem sluter Du avtal för Företagets räkning om Eget utrymme. Samtidigt intygar Du att Du
                                har tagit del av villkoren och är behörig att företräda Företaget på detta sätt.",
                AgreementChangeDate = new DateTime(2019, 6, 3)
            };
        }
    }
}