using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Servers
    {
        private static readonly Lazy<Servers> lazyInstance = new Lazy<Servers>(() => new Servers());
        private readonly List<string> serverList = new List<string>();
        private readonly object lockObject = new object();

        public static Servers Instance => lazyInstance.Value;

        private Servers()
        {
            
        }

        public bool AddServer(string serverAddress)
        {
            if (!IsValidServerAddress(serverAddress))
                return false;

            lock (lockObject)
            {
                if (!serverList.Contains(serverAddress))
                {
                    serverList.Add(serverAddress);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<string> GetHttpServers()
        {
            lock (lockObject)
            {
                return serverList.Where(s => s.StartsWith("http://")).ToList();
            }
        }

        public List<string> GetHttpsServers()
        {
            lock (lockObject)
            {
                return serverList.Where(s => s.StartsWith("https://")).ToList();
            }
        }

        private bool IsValidServerAddress(string serverAddress)
        {
            return serverAddress.StartsWith("http://") || serverAddress.StartsWith("https://");
        }
    }
}
