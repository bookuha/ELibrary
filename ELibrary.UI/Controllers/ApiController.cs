using System.Collections.Generic;
using System.Linq;
using ELibrary.Application.Contracts.Common;
using ELibrary.Domain.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ELibrary.UI.Controllers
{
    public class ApiController : ControllerBase
    {
        protected ApiController()
        {
        }

        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0) return Problem();

            if (errors.All(error => error.ErrorType == ErrorTypes.Validation)) return ValidationProblem(errors);

            var firstError = errors[0];

            return Problem(firstError);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Message);

            return ValidationProblem(modelStateDictionary);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.ErrorType switch
            {
                ErrorTypes.Conflict => StatusCodes.Status409Conflict,
                ErrorTypes.Validation => StatusCodes.Status400BadRequest,
                ErrorTypes.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Message);
        }
    }
}