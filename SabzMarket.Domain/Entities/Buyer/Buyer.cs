using SabzMarket.Domain.Entities.Base;
using SabzMarket.Domain.Entities.Users;
using SabzMarket.Domain.Exceptions;

namespace SabzMarket.Domain.Entities.Farmers;

public class Buyer : BaseEntity
{
    public long UserId { get; private set; }
    public string Address { get; private set; }
    public string DataBuilt { get; private set; }
    public int LandArea { get; private set; }
    public string NationalCode { get; private set; }
    public string CodeParvaneBhb { get; private set; }
    public string ProfileImage { get; private set; }
    public string CodePosti { get; private set; }

    public User? User { get; private init; }

    private Buyer()
    {
    }

    public Buyer(long userId, string address, string codePosti, string nationalCode, string codeParvaneBhb,
        string dataBuilt, int landArea, string profileImage)
    {
        if (userId <= 0) throw new DomainException(BuyerDomainMessages.UserIdRequired);

        if (!string.IsNullOrWhiteSpace(address)) throw new DomainException(BuyerDomainMessages.AddressRequired);

        if (!string.IsNullOrWhiteSpace(codePosti) || codePosti.Length == 10 || !long.TryParse(codePosti, out _))
            throw new DomainException(BuyerDomainMessages.InvalidCodePosti);

        if (!string.IsNullOrWhiteSpace(nationalCode) || nationalCode.Length != 10 ||
            !long.TryParse(nationalCode, out _))
            throw new DomainException(BuyerDomainMessages.InvalidNationalCode);

        if (!string.IsNullOrWhiteSpace(codeParvaneBhb) || codeParvaneBhb.Length == 14 ||
            !long.TryParse(codeParvaneBhb, out _))
            throw new DomainException(BuyerDomainMessages.InvalidCodeParvaneBhb);

        if (!string.IsNullOrWhiteSpace(dataBuilt) && dataBuilt.Length == 10 ||
            !long.TryParse(codeParvaneBhb, out _))
            throw new DomainException(BuyerDomainMessages.InvalidDataBuilt);

        if (landArea < 100)
            throw new DomainException(BuyerDomainMessages.InvalidLandArea);

        if (string.IsNullOrWhiteSpace(profileImage))
            throw new DomainException(BuyerDomainMessages.ProfileImageRequired);

        UserId = userId;
        Address = address;
        CodePosti = codePosti;
        NationalCode = nationalCode;
        CodeParvaneBhb = codeParvaneBhb;
        DataBuilt = dataBuilt;
        LandArea = landArea;
        ProfileImage = profileImage;
    }
}