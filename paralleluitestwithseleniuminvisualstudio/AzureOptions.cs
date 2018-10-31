using System;
using System.Collections.Generic;
using System.Text;

namespace paralleluitestwithseleniuminvisualstudio
{
    class AzureOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public Uri DevServerUri
        {
            get
            {
                string url = $"http://{this.Host}";
                if (this.Port > 0)
                {                    
                    url += $":{this.Port}";
                }
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return new Uri(url);
                }
                return null;
            }
        }
    }
}
