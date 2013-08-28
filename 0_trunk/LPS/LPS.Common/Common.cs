using System.IO;
using System.Reflection;

namespace LPS
{
    public static class Common
    {
        public static string GetAppPath(string path)
        {
            return Path.Combine(Assembly.GetExecutingAssembly().GetName().CodeBase, path);
        }

        public static string GetAppPath(string path1, string path2)
        {
            return Path.Combine(Assembly.GetExecutingAssembly().GetName().CodeBase, path1, path2);
        }

        public static string GetAppPath(string path1, string path2, string path3)
        {
            return Path.Combine(Assembly.GetExecutingAssembly().GetName().CodeBase, path1, path2, path3);
        }
    }
}
