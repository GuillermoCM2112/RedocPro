﻿using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace RedocPro.Entities.ResponsePayloads
{
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