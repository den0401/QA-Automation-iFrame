using NUnit.Framework;
using Aquality.Selenium.Template.Forms.Pages;
using Aquality.Selenium.Template.Configuration;

namespace iFrameTests
{
    [TestFixture]
    public class Tests: BaseTest
    {
        [Test]
        public void InputtedTextIsBold()
        {
            MainPage mainPage = new MainPage();
            Assert.AreEqual(Configuration.PageTitle, mainPage.GetPageTitle(), "Page title is not displayed");
            Assert.AreEqual(mainPage.InputRandomText(), mainPage.GetInputtedText(), "Inputted text and created random text are not equal!");

            mainPage.MakeTextBold();
            Assert.IsTrue(mainPage.IsTextBold(), "Text is not bold!");
        }        
    }
}