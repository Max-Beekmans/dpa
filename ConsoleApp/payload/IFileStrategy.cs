namespace PayloadStrategy
{
    public interface IFileStrategy : IStrategy
    {
        string GetPayload(string location);
    }
}
