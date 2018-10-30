using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace paralleluitestwithseleniuminvisualstudio
{
    internal class SeleniumOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string BrowserName { get; set; }
        public Uri WebDriverUri
        {
            get
            {
                string url = $"http://{this.Host}:{this.Port}/wd/hub";
                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    return new Uri(url);
                }

                return null;
            }
        }
    }

}
