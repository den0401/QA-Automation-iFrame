using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Template.Utilities;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage : Form
    {
        private const int _indexOfFrame = 0;

        private ITextBox FrameTextAreaElement => ElementFactory.GetTextBox(By.Id("tinymce"), "Frame");
        private ITextBox BoldText => ElementFactory.GetTextBox(By.XPath("//strong"), "Bold text");        
        private IButton SelectAllBtn => ElementFactory.GetButton(By.XPath("//div[@title='Select all']"), "Select all button");
        private IButton EditBtn => ElementFactory.GetButton(By.XPath("//span[text() = 'Edit']"), "Edit button");
        private IButton BoldBtn => ElementFactory.GetButton(By.XPath("//button[@title='Bold']"), "Bold button");

        public MainPage() : base(By.XPath("//div[@class='example']"), "Main page")
        {
        }

        public string InputRandomText()
        {
            RandomTextGenerator randomText = new RandomTextGenerator();

            SwitchToFrame(_indexOfFrame);

            string randomSentence = randomText.GetRandomSentence(Configuration.Configuration.CountOfRandomWords);

            FrameTextAreaElement.ClearAndType(randomSentence);

            return randomSentence;
        }

        public void GetTextBold()
        {
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();

            EditBtn.Click();
            SelectAllBtn.WaitAndClick();
            BoldBtn.Click();

            SwitchToFrame(_indexOfFrame);

            FrameTextAreaElement.Click();
        }

        public bool IsTextBold() => BoldText.State.IsDisplayed;

        public string InputtedText() => FrameTextAreaElement.GetText();

        public void SwitchToFrame(int indexOfFrame) => AqualityServices.Browser.Driver.SwitchTo().Frame(indexOfFrame);
    }
}
