using System.ComponentModel.DataAnnotations;

namespace RedocPro.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class PerfilUsuario
    {
        /// <summary>
        /// User identifier
        /// </summary>
        /// <example>...</example>
        public string? prop1 { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        /// <example>...</example>
        public string? prop2 { get; set; } = string.Empty;

        /// <summary>
        /// User surname
        /// </summary>
        /// <example>...</example>
        public string? prop3 { get; set; } = string.Empty;

        /// <summary>
        /// User birthday
        /// </summary>
        /// <example>01/01/0001</example>
        public string? prop4 { get; set; } = string.Empty;

        /// <summary>
        /// User email
        /// </summary>
        /// <example>...</example>
        public string? prop5 { get; set; }

        /// <summary>
        /// User zipCode
        /// </summary>
        /// <example>...</example>
        public string? prop6 { get; set; } = string.Empty;

        /// <summary>
        /// User second last name
        /// </summary>
        /// <example>...</example>
        public string? prop7 { get; set; } = string.Empty;

        /// <summary>
        /// User gender
        /// </summary>
        /// <example>.</example>
        public string? prop8 { get; set; } = string.Empty;

        /// <summary>
        /// User attempt reference
        /// </summary>
        /// <example>...</example>
        public string? prop9 { get; set; } = string.Empty;

        /// <summary>
        /// User device identifier
        /// </summary>
        /// <example>...</example>
        public string? prop510 { get; set; } = string.Empty;
    }
}
