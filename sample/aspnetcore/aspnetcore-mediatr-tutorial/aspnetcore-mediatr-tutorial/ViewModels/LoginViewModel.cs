using System.ComponentModel.DataAnnotations;

namespace aspnetcore_mediatr_tutorial.ViewModels
{
    public class LoginViewModel
    {
        #region Attributes

        /// <summary>
        ///
        /// </summary>
        [Required(ErrorMessage = "Email 不能为空")]
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Password { get; set; }

        #endregion Attributes
    }
}