
using PageObjects;
using UtilityAndStructures.EnumsAndStructures;
namespace BusinessObject
{
    /// <summary>
    /// Home page Business Class
    /// </summary>
    public class HomePageBO : HomePageObjectBase
    {
        /// <summary>
        /// Enter text on Search box on home page
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public ActionResult EnterSearchText(string Value)
        {
            return TextEvents().SetText(SearchTextId, Value, Commonenums.ElementType.IdPath);
        }
        /// <summary>
        /// Press Enter on Search box on home page
        /// </summary>
        /// <returns></returns>
        public ActionResult PressEnter()
        {
            return TextEvents().PressEnter(SearchTextId, Commonenums.ElementType.IdPath);
        }

        /// <summary>
        /// Click on GMail Icon of page(Issue: as we are facing issue when we login through automation it shows security concerns)
        /// </summary>
        /// <returns></returns>
        public ActionResult ClickGMailIcon()
        {
            return ButtonEvents().ClickButton(GMailIconXPath, Commonenums.ElementType.xPath);
        }

        /// <summary>
        /// Launch Email by given EmailSubject
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public ActionResult LaunchEMail(string Value)
        {
            return ButtonEvents().ClickButtonByLocation("(//span[contains(text(), '" + Value + "')])[2]", Commonenums.ElementType.xPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult RefreshGMailPage()
        {
            return ElementEvents().RefreshWebPage();
        }
      

        /// <summary>
        /// verify Compose Button is visible
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyComposeButton()
        {
            return ElementEvents().VerifyElementPresent(ComposeXPath, Commonenums.ElementType.xPath);
        }
    }
}
