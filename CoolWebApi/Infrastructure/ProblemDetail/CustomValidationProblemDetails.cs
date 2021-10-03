using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace CoolWebApi.Infrastructure.ProblemDetail
{
    public class CustomValidationProblemDetails : ValidationProblemDetails
    {
        public CustomValidationProblemDetails()
        {
        }

        public CustomValidationProblemDetails(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public CustomValidationProblemDetails(ModelStateDictionary modelState)
        {
            Errors = ConvertModelStateErrorsToValidationErrors(modelState);
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public new string Detail { get; set; }

        [JsonPropertyName("errors")]
        public new IEnumerable<ValidationError> Errors { get; } = new List<ValidationError>();

        private List<ValidationError> ConvertModelStateErrorsToValidationErrors(ModelStateDictionary modelStateDictionary)
        {
            List<ValidationError> validationErrors = new();

            foreach (var keyModelStatePair in modelStateDictionary)
            {
                var errors = keyModelStatePair.Value.Errors;
                switch (errors.Count)
                {
                    case 0:
                        continue;

                    case 1:
                        validationErrors.Add(new ValidationError { Code = null, Message = errors[0].ErrorMessage });
                        break;

                    default:
                        var errorMessage = string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage));
                        validationErrors.Add(new ValidationError { Message = errorMessage });
                        break;
                }
            }

            return validationErrors;
        }
    }
}