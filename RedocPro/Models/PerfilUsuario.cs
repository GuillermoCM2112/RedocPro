using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PerfilUsuario
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        /// <example>...</example>
        public string? prop1 { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        /// <example>...</example>
        [StringLength(50)]
        public string? prop2 { get; set; } = string.Empty;

        /// <summary>
        /// User surname.
        /// </summary>
        /// <example>...</example>
        [StringLength(50)]
        public string? prop3 { get; set; } = string.Empty;

        /// <summary>
        /// User birthday.
        /// </summary>
        /// <example>01/01/0001</example>
        public string? prop4 { get; set; } = string.Empty;

        /// <summary>
        /// User email.
        /// </summary>
        /// <example>...</example>
        public string? prop5 { get; set; }

        /// <summary>
        /// User zipCode.
        /// </summary>
        /// <example>...</example>
        public string? prop6 { get; set; } = string.Empty;

        /// <summary>
        /// User second last name.
        /// </summary>
        /// <example>...</example>
        public string? prop7 { get; set; } = string.Empty;

        /// <summary>
        /// User gender.
        /// </summary>
        /// <example>.</example>
        public string? prop8 { get; set; } = string.Empty;

        /// <summary>
        /// User attempt reference.
        /// </summary>
        /// <example>...</example>
        public string? prop9 { get; set; } = string.Empty;

        /// <summary>
        /// User device identifier.
        /// </summary>
        /// <example>...</example>
        public string? prop510 { get; set; } = string.Empty;
    }


    public class RecuperarContrasena
    {
        /// <summary>
        /// User phone number.
        /// </summary>
        /// <example>####</example>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// User new password to update.
        /// </summary>
        /// <example>...</example>
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string NewPassword { get; set; } = string.Empty;

        /// <summary>
        /// User device identifier.
        /// </summary>
        /// <example>...</example>
        public string? DeviceId { get; set; } = string.Empty;

        /// <summary>
        /// User attempt reference.
        /// </summary>
        /// <example>...</example>
        public string? AttemptReference { get; set; } = string.Empty;
    }

    public class CancelarCuenta
    {
        /// <summary>
        /// User identifier.
        /// </summary>
        /// <example>...</example>
        [Required]
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// User password.
        /// </summary>
        /// <example>...</example>
        [Required]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Reason to cancel the account.
        /// </summary>
        /// <example>...</example>
        [Required]
        [StringLength(500)]
        public string CancellationReason { get; set; } = string.Empty;
    }

    public class CancelarCuentaRespuesta
    {
        /// <summary>
        /// Property to know if the cancellation is successful.
        /// </summary>
        /// <example>true or false</example>
        [Required]
        public bool SuccessfulCancellation { get; set; } = false;
    }


    public class CambiarCuentaRespuesta
    {
        /// <summary>
        /// User email registred in the App.
        /// </summary>
        /// <example>examplemail@cool.domain.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Username registred in the App.
        /// </summary>
        /// <example>+521234567890</example>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// User first name or two names.
        /// </summary>
        /// <example>Juan Antonio</example>
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// User lastname.
        /// </summary>
        /// <example>Pérez</example>
        [Required]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// User birthday.
        /// </summary>
        /// <example>01/01/2000</example>
        [Required]
        public string Birthday { get; set; } = string.Empty;

        /// <summary>
        /// User phone number with area code.
        /// </summary>
        /// <example>+525555555555</example>
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        
        /// <summary>
        /// User zip code of address.
        /// </summary>
        /// <example>64000</example>
        [Required]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Loyalty identifier in the App.
        /// </summary>
        /// <example>P1ATYGR</example>
        [Required]
        public string LoyaltyId { get; set; } = string.Empty;

        /// <summary>
        /// User email.
        /// </summary>
        /// <example>user@email.net</example>
        [Required]
        public bool EmailVerified { get; set; } = false;

        /// <summary>
        /// User second last name.
        /// </summary>
        /// <example>Herrera</example>
        public string SecondLastName { get; set; } = string.Empty;

        /// <summary>
        /// User gender.
        /// </summary>
        /// <example>M (for Men) or W (for Woman)</example>
        [RegularExpression("[M|W]")]
        public string Gender { get; set; } = string.Empty;
    }
}
