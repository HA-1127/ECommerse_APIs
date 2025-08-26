using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs.Requests
{
    public class ForgetPasswordRequest
    {
        [Required]
        public string EmailORUserName { get; set; } = string.Empty;
    }
}
