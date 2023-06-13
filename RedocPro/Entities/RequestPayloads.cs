using RedocPro.Descriptions;
using RedocPro.Redoc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace RedocPro.Entities.RequestPayloads
{
    public class LoginRequest
    {
        /// <summary>
        /// The username can be a phone number or an email.
        /// </summary>
        /// <example>+515555555555</example>
        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Username { get; set; } = string.Empty;

        /// <example>thisIsA%%pwd0</example>
        [Required]
        public string Password { get; set; } = string.Empty;

        /// <example>a3f3a772-f9af-4162-8ac3-8d79ad</example>
        [Required]
        public string DeviceId { get; set; } = string.Empty;

        /// <example>A1B2C3D4E5</example>
        public string? AttemptReference { get; set; } = string.Empty;
    }

    public class SignupRequest
    {
        /// <example>Juan Antonio</example>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        /// <example>Peréz Pérez</example>
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Surname { get; set; } = string.Empty;

        /// <example>+525555555555</example>
        [Required]
        [StringLength(14, MinimumLength = 10)]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <example>examplemail@cool.domain.com</example>
        // [EmailAddress]
        // [RegularExpression(PayloadConstants.EmailRegex, ErrorMessage = PayloadConstants.InvalidEmail)]
        // [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        /// <example>01/04/1993</example>
        [Required]
        public string Birthday { get; set; } = string.Empty;

        /// <example>thisIsA%%pwd0</example>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        /// <example>a3f3a772-f9af-4162-8ac3-8d79ad</example>
        [Required]
        public string DeviceId { get; set; } = string.Empty;

        /// <example>A1B2C3D4E5</example>
        public string? AttemptReference { get; set; } = string.Empty;
    }

    public class RefreshRequest
    {
        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.RefreshToken)]
        [SwaggerSchemaExample("v1.McGUUd_CL7lc4UjVa2jlAgAG7lCyif14ItPqa_VyqXbeLfR1IpHdqu02QT3XuSsGekr0zfh3PJBszwsWGnC8lJw")]
        public string RefreshToken { get; set; } = string.Empty;
    }

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
