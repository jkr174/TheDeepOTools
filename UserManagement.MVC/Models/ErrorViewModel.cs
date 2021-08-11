/* Name:    Jovany Romo
 * Date:    6/3/2021
 * Summary: Default error view model for MVC
 */

namespace TheDeepOTools.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
