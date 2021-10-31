using System;

namespace GalaxyLib.PayloadStrategy
{
    public class DriveFileStrategy : IFileStrategy
    {
        public string GetPayload(string location)
        {
            try
            {
                return System.IO.File.ReadAllText(location);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
