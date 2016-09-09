namespace MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces
{
    public interface IChecksumGenerator
    {
        string CalculateHash(string input);
    }
}
