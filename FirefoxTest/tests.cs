using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using paralleluitestwithseleniuminvisualstudio;

namespace FirefoxTest
{
    [TestClass]
    public class Tests: UITest
    {

        public Tests(): base(new FirefoxOptions())
        {
        }

        [TestMethod]
        public void Firefox_Shoud_Search_In_Google()
        {
            Shoud_Search_In_Google();
        }
        [TestMethod]
        public void Firefox_Shoud_I_Test_My_WebApp()
        {
            Shoud_I_Test_My_WebApp();
        }
    }
}
