using CoolWebApi.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CoolWebApi.Models
{
    public class DummyModel : IValidatableObject
    {
        [Display(ResourceType = typeof(DisplayNameResource), Name = "FirstName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [StringLength(32, MinimumLength = 3, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "StringLengthError")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "LastName")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(32, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MaxLengthError")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(DisplayNameResource), Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "RequiredError")]
        [MaxLength(128, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MaxLengthError")]
        public string Email { get; set; }

        [JsonIgnore]
        public string FullName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Email.Contains("dummy"))
                yield return new ValidationResult(string.Format(
                    ErrorMessageResource.DummyIsForbidenError, DisplayNameResource.Email));
        }
    }
}