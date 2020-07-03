using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Questionnaire.Core.Exceptions;

namespace Questionnaire.Api.Filters
{
    public class ElementNotFoundAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ElementNotFoundException)
            {
                context.Result = new ObjectResult(new { error = context.Exception.Message })
                {
                    StatusCode = 404
                };
            }
        }
    }
}
