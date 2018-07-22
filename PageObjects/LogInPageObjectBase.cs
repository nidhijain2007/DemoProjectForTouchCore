
using ActionLayer.ActionClasses;
namespace PageObjects
{
    /// <summary>
    /// LogIn Page objects and events
    /// </summary>
    public class LogInPageObjectBase
    {
        protected string UnameId = "identifierId";
        protected string NextXPath = "//span[contains(text(), 'Next')]";
        protected string PasswordName = "password";

        /// <summary>
        /// Text Events of page
        /// </summary>
        /// <returns></returns>
        protected TextBox TextEvents()
        {
            return new TextBox();
        }

        /// <summary>
        /// Button events of page
        /// </summary>
        /// <returns></returns>
        protected Button ButtonEvents()
        {
            return new Button();
        }
       
      
    }
}
