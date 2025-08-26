using System.ComponentModel.DataAnnotations;

namespace ECommerce.API.DTOs.Requests
{
    public class ResendEmailConfirmationRequest
    {
        [Required]
        public string EmailORUserName { get; set; } = string.Empty;
    }
}
