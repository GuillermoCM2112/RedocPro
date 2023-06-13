using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations; 
using System.Globalization; 
//using Auth0.AuthenticationApi.Models; 
namespace RedocPro.Entities.ResponsePayloads
{
    public class AccessResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessResponse"/> class.
        /// Wrapper for Auth0 response.
        /// </summary>
        /// <param name="authResponse"> Auth0 raw response</param> 
        //public AccessResponse(AccessTokenResponse authResponse)
        public AccessResponse()
        {
            // this.AccessToken = authResponse.AccessToken;
            // this.TokenType = authResponse.TokenType;
            // this.IdToken = authResponse.IdToken;
            // this.ExpiresIn = authResponse.ExpiresIn;
            // this.RefreshToken = authResponse.RefreshToken; 
        }

        /// <example>eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZ...</example>
        [Required]
        public string AccessToken { get; set; } = string.Empty;

        /// <example>Bearer</example>
        [Required]
        public string TokenType { get; set; } = string.Empty;

        /// <example>eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZ...</example>
        [Required]
        public string IdToken { get; set; } = string.Empty;

        /// <example>86400</example>
        [Required]
        public int ExpiresIn { get; set; } = 0;

        /// <example>v1.McGUUd_CL7lc4UjVa2jlAgAG7lCyif14ItPqa_VyqXbeLfR1IpHdqu02QT3XuSsGekr0zfh3PJBszwsWGnC8lJw</example>
        [Required]
        public string RefreshToken { get; set; } = string.Empty; 
    }  
    public class UserChangeResponse
    {
        /// <example>examplemail@cool.domain.com</example>
        /// <summary> Returns email of the user </summary>
        public string Email { get; set; } = string.Empty;
        /// <example>+521234567890</example>
        /// <summary> Returns user Name of the user </summary>
        public string UserName { get; set; } = string.Empty;

        /// <example>Juan Antonio</example>
        /// <summary> Returns First Name of the user </summary>
        [Required]
        public string FirstName { get; set; } = string.Empty;

        /// <example>Peréz Pérez</example>
        /// <summary> Return Last Name of the user </summary>
        [Required]
        public string LastName { get; set; } = string.Empty;

        /// <example>01/01/2000</example>
        /// <summary> Returns birthday of the user </summary>
        [Required]
        public string Birthday { get; set; } = string.Empty;

        /// <example>+525555555555</example>
        /// <summary> Returns Phone of the user </summary>
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        /// <example>64000</example>
        /// <summary> Returns Zip Code of the user </summary>
        [Required]
        public string ZipCode { get; set; } = string.Empty;

        /// <example>P1ATYGR</example>
        /// <summary> Returns Loyalty Id of the user </summary>
        [Required]
        public string LoyaltyId { get; set; } = string.Empty;

        /// <example>false</example>
        /// <summary> Check if the user's email is verified </summary>
        [Required]
        public bool EmailVerified { get; set; } = false;
    }
    public class UserValidationResponse
    {
        public UserValidationResponse(string codeUserStatus)
        {
            this.CodeUserStatus = codeUserStatus;
        }

        /// <example>0</example>
        /// <summary> Returns the current status of the user </summary>
        [Required]
        public string CodeUserStatus { get; set; } = string.Empty;
    }
}
