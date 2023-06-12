using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RedocPro.Entities.ResponsePayloads
{
    public class UserChangeResponse
    {
        /// <example>examplemail@cool.domain.com</example>
        public string Email { get; set; } = string.Empty;

        /// <example>+521234567890</example>
        public string UserName { get; set; } = string.Empty;

        /// <example>Juan Antonio</example>
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <example>Peréz Pérez</example>
        [Required]
        public string LastName { get; set; } = string.Empty;

        /// <example>01/01/2000</example>
        [Required]
        public string Birthday { get; set; } = string.Empty;

        /// <example>+525555555555</example>
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <example>64000</example>
        [Required]
        public string ZipCode { get; set; } = string.Empty;

        /// <example>P1ATYGR</example>
        [Required]
        public string LoyaltyId { get; set; } = string.Empty;

        /// <example>false</example>
        [Required]
        public bool EmailVerified { get; set; } = false;
    } 
}
