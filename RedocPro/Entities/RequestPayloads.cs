using System.ComponentModel.DataAnnotations;

namespace RedocPro.Entities.RequestPayloads
{
    public class UpdatePasswordRequest
    {
        /// <example>auth0|63af137d053f56ab291e7112</example>
        /// <summary>User Id Auth0</summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <example>th1sIsANew%%pwd</example>
        /// <summary>New password</summary>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string NewPassword { get; set; } = string.Empty;
        /// <example>th1sIsAOld%%pwd</example>
        /// <summary>Current password</summary>
        [StringLength(50, MinimumLength = 8)]
        public string CurrentPassword { get; set; } = string.Empty;
    }
    public class UpdateUserRequest
    {
        /// <example>auth0|63b477d3b85540fe7e870500</example>
        /// <summary>User Id Auth0</summary>

        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <example>examplemail@cool.domain.com</example>
        /// <summary> The email of user. </summary>
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        /// <example>+515555555555</example>
        /// <summary> The phone of user. </summary>
        public string PhoneNumber { get; set; } = string.Empty;
    }
    public class UserValidationRequest
    {
        /// <example>+515555555555</example>
        /// <summary> The phone of user. </summary>
        [Required]
        [StringLength(14, MinimumLength = 10)]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <example>x1234ABCD</example>
        /// <summary> Device Id of user. </summary>
        [Required]
        public string DeviceId { get; set; } = string.Empty;

        /// <example>A1B2C3D4E5</example>
        /// <summary> Attempt Reference. </summary>
        public string? AttemptReference { get; set; } = string.Empty;
    }
}
