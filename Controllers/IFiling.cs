namespace SampleCoreWebApp
{
    public interface IFiling
    {
        string GetFilingTypeCode();
        decimal GetFilingTypeFee();
    }

    public class DomesticFiling : IFiling
    {
        public string GetFilingTypeCode()
        {
            return "DOF"; ;
        }

        public decimal GetFilingTypeFee()
        {
            return 10;
        }
    }

    public class ForiegnFiling : IFiling
    {
        public string GetFilingTypeCode()
        {
            return "FOF";
        }

        public decimal GetFilingTypeFee()
        {
            return 15;
        }
    }

    public class PartnerShipFiling : IFiling
    {
        public string GetFilingTypeCode()
        {
            return "PAF";
        }

        public decimal GetFilingTypeFee()
        {
            return 20;
        }
    }
}
