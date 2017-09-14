using System;
namespace ImageAccessor
{
    internal class ImageIdManager
    {
        public static string GenerateNewId()
        {
            string guid = Guid.NewGuid().ToString("N");     // always 32 character length
            return string.Format("{0}_{1}", guid, Environment.TickCount);
        }
    }
}