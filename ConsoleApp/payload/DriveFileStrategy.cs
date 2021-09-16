namespace PayloadStrategy
{
    public class DriveFileStrategy : IFileStrategy
    {
        public string GetPayload(string location)
        {
            return System.IO.File.ReadAllText(location);
        }
    }
}
