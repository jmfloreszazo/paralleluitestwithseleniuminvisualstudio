using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using paralleluitestwithseleniuminvisualstudio;

namespace ChromeTest
{
    [TestClass]
    public class Tests: UITest
    {

        public Tests(): base(new ChromeOptions() {})
        {
        }

        [TestMethod]
        public void Chrome_Shoud_Search_In_Google()
        {
            Shoud_Search_In_Google();
        }
        [TestMethod]
        public void Chrome_Shoud_I_Test_My_WebApp()
        {
            Shoud_I_Test_My_WebApp();
        }

    }
}
