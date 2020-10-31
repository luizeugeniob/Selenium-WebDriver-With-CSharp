using System.IO;
using System.Reflection;

namespace EAuction.Selenium.Helpers
{
    public static class TestHelper
    {
        public static string ExecutablePath()
            => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
