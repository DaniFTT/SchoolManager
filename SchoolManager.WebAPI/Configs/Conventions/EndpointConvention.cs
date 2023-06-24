using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Ardalis.Result;

namespace SchoolManager.WebAPI.Configs.Conventions
{
    public class EndpointConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.BaseType!.FullName!.Contains("BaseApiController"))
            {
                controller.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErroResponseType), StatusCodes.Status400BadRequest));
                controller.Filters.Add(new ProducesResponseTypeAttribute(typeof(ProblemDetails), StatusCodes.Status500InternalServerError));
                controller.Filters.Add(new ProducesAttribute(MediaTypeNames.Application.Json));
                controller.Filters.Add(new ConsumesAttribute(MediaTypeNames.Application.Json));
            }
        }
    }

    public class ErroResponseType
    {
        public string[]? Errors { get; set; }
        public ValidationError[]? ValidationErrors { get; set; }
    }
}
