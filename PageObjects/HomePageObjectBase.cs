using ActionLayer.ActionClasses;
using System.Configuration;

namespace PageObjects
{
    /// <summary>
    /// Home page objects and events Base Class
    /// </summary>
    public class HomePageObjectBase
    {
        protected string ComposeXPath = "//div[contains(text(), 'COMPOSE')]";
        protected string RecipientsXPath = "//div[contains(text(), 'Recipients')]";
        protected string SubjectId = ":a4";
        protected string MessageId = ":4r";
        protected string SearchTextId = "gbqfq";
        protected string GMailIconXPath = "(//*[contains(@href,'"+ ConfigurationManager.AppSettings["URL"]+"')])[2]";
        protected string SendButton = "//div[contains(text(), 'Send')]";
        /// <summary>
        /// TextBox events on page
        /// </summary>
        /// <returns></returns>
        protected TextBox TextEvents()
        {
            return new TextBox();
        }

        /// <summary>
        /// Button events on page
        /// </summary>
        /// <returns></returns>
        protected Button ButtonEvents()
        {
            return new Button();
        }

        /// <summary>
        /// Element Events on page
        /// </summary>
        /// <returns></returns>
        protected VerifyElement ElementEvents()
        {
            return new VerifyElement();
        }
    }
}
