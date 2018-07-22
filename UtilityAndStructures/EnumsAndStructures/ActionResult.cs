
namespace UtilityAndStructures.EnumsAndStructures
{
    /// <summary>
    ///To get error message and result from Action Layer
    /// </summary>
    public class ActionResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string Screenpath { get; set; }
    }
}
