using NUnit.Framework;
using Aquality.Selenium.Template.Forms.Pages;

namespace iFrameTests
{
    [TestFixture]
    public class Tests: BaseTest
    {
        [Test]
        public void CardsAreFilled()
        {
            MainPage mainPage = new MainPage();
            Assert.AreEqual(mainPage.InputRandomText(), mainPage.InputtedText());

            mainPage.GetTextBold();
            Assert.IsTrue(mainPage.IsTextBold());
        }        
    }
}