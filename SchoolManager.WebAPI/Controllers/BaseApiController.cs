using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using SchoolManager.WebAPI.Configs.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManager.WebAPI.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected ResultHandler<TCommandResult> HandleResult<TCommandResult>(Result<TCommandResult> result)
        {
            return new ResultHandler<TCommandResult>(result)
                .OnSuccess(OnSuccess)
                .OnNotFound(OnNotFound)
                .OnConflict(OnConflict)
                .OnError(OnError)
                .OnInvalid(OnInvalid);
        }


        protected virtual ActionResult OnSuccess<TCommandResult>(TCommandResult value)
        {
            return Ok(value);
        }

        protected virtual ActionResult OnSuccess<TCommandResult>()
        {
            return NoContent();
        }

        protected virtual ActionResult OnNotFound(IEnumerable<string>? errors)
        {
            return BadRequest(GetErrorObject(errors: errors));
        }

        protected virtual ActionResult OnConflict(IEnumerable<string>? errors)
        {
            return BadRequest(GetErrorObject(errors: errors));
        }

        protected virtual ActionResult OnError(IEnumerable<string>? errors)
        {
            return BadRequest(GetErrorObject(errors: errors));
        }

        protected virtual ActionResult OnInvalid(IEnumerable<ValidationError>? validationErrors)
        {
            return BadRequest(GetErrorObject(validationErrors: validationErrors));
        }

        private object GetErrorObject(IEnumerable<string>? errors = null, IEnumerable<ValidationError>? validationErrors = null)
        {
            return new
            {
                Errors = errors ?? Array.Empty<string>(),
                ValidationErros = validationErrors ?? Array.Empty<ValidationError>()
            };
        }
    }
}
