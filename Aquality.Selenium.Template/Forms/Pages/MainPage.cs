using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Template.Utilities;

namespace Aquality.Selenium.Template.Forms.Pages
{
    public class MainPage : Form
    {
        private const int IndexOfFrame = 0;

        private ITextBox FrameTextAreaElement => ElementFactory.GetTextBox(By.Id("tinymce"), "Frame");
        private ITextBox BoldText => ElementFactory.GetTextBox(By.XPath("//strong"), "Bold text");        
        private IButton SelectAllBtn => ElementFactory.GetButton(By.XPath("//div[@title='Select all']"), "Select all");
        private IButton EditBtn => ElementFactory.GetButton(By.XPath("//span[text() = 'Edit']"), "Edit");
        private IButton BoldBtn => ElementFactory.GetButton(By.XPath("//button[@title='Bold']"), "Bold");
        private ILabel PageTitle => ElementFactory.GetLabel(By.XPath("//h3"), "Page header text");

        public MainPage() : base(By.XPath("//div[@class='example']"), "Main page")
        {
        }

        public string InputRandomText()
        {
            RandomTextGenerator randomText = new RandomTextGenerator();

            SwitchToFrame(IndexOfFrame);

            string randomSentence = randomText.GetRandomSentence(Configuration.Configuration.CountOfRandomWords);

            FrameTextAreaElement.ClearAndType(randomSentence);

            return randomSentence;
        }

        public void MakeTextBold()
        {
            AqualityServices.Browser.Driver.SwitchTo().DefaultContent();

            EditBtn.Click();
            SelectAllBtn.WaitAndClick();
            BoldBtn.Click();

            SwitchToFrame(IndexOfFrame);

            FrameTextAreaElement.Click();
        }

        public bool IsTextBold() => BoldText.State.IsDisplayed;

        public string GetInputtedText() => FrameTextAreaElement.GetText();

        public string GetPageTitle() => PageTitle.Text;

        public void SwitchToFrame(int indexOfFrame) => AqualityServices.Browser.Driver.SwitchTo().Frame(indexOfFrame);
    }
}
