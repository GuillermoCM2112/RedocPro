using System.ComponentModel.DataAnnotations;

namespace RedocPro.Entities.RequestPayloads
{
    public class UpdatePasswordRequest
    {
        /// <example>auth0|63af137d053f56ab291e7112</example>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <example>th1sIsANew%%pwd</example>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string NewPassword { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 8)]
        public string CurrentPassword { get; set; } = string.Empty;
    }
}
