
using PageObjects;
using UtilityAndStructures.EnumsAndStructures;
namespace BusinessObject
{
    /// <summary>
    /// LogIn Page Business Class
    /// </summary>
    public class LogInPageObjectBO : LogInPageObjectBase
    {
        /// <summary>
        /// Enter given UserId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EnterUserId(string Id)
        {
            return TextEvents().SetText(UnameId, Id, Commonenums.ElementType.IdPath);
        }

        /// <summary>
        /// Enter given password
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public ActionResult EnterPassword(string pwd)
        {
            return TextEvents().SetText(PasswordName, pwd, Commonenums.ElementType.Name);
        }

        /// <summary>
        /// Click on next button
        /// </summary>
        /// <returns></returns>
        public ActionResult ClickNext()
        {
            return ButtonEvents().ClickButtonByLocation(NextXPath, Commonenums.ElementType.xPath);
        }
    }
}
