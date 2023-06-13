using Newtonsoft.Json;
using RedocPro.Descriptions;
using RedocPro.Redoc;
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
        [SwaggerSchema(Description = PropertiesDescriptions.EmailDescription)]
        [SwaggerSchemaExample("+521234567890")]
        public string Email { get; set; } = string.Empty;
        
		[SwaggerSchema(Description = PropertiesDescriptions.UserNameDescription)]
        [SwaggerSchemaExample("+521234567890")]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.FirstNameDescription)]
        [SwaggerSchemaExample("Juan Antonio")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.LastNameDescription)]
        [SwaggerSchemaExample("Peréz Pérez")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.BirthdayDescription)]
        [SwaggerSchemaExample("01/01/2000")]
        public string Birthday { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.PhoneNumber)]
        [SwaggerSchemaExample("+525555555555")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.ZipCodeDescription)]
        [SwaggerSchemaExample("64000")]
        public string ZipCode { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.LoyaltyIdDescription)]
        [SwaggerSchemaExample("P1ATYGR")]
        public string LoyaltyId { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.EmailVerifiedDescription)]
        [SwaggerSchemaExample("False")]
        public bool EmailVerified { get; set; } = false;
    }
    public class UserValidationResponse
    {
        public UserValidationResponse(string codeUserStatus)
        {
            this.CodeUserStatus = codeUserStatus;
        }

        [Required]
        [SwaggerSchema(Description = PropertiesDescriptions.CodeUserStatusDescription)]
        [SwaggerSchemaExample("0")]
        public string CodeUserStatus { get; set; } = string.Empty;
    }
    public class LatestTaCResponse
    {
        [Required]
        [SwaggerSchema(Description = "Date accepted Tac Version")]
        [SwaggerSchemaExample("21/03/2023")]
        public string AcceptDate { get; set; } = string.Empty;

        [Required]
        [SwaggerSchema(Description = "Version TaC")]
        [SwaggerSchemaExample("V1.0")]
        public string Version { get; set; } = string.Empty;
    }

    public class AddTaCVersionResponse
    {
        [Required]
        [SwaggerSchema(Description = "Tac Version Successful Accept")]
        [SwaggerSchemaExample("true")]
        public bool SuccessfulAccept { get; set; } = false;
    }
}
