using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Questionnaire.Api.Filters
{
    public class CatchAllExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(new { error = context.Exception.Message })
            {
                StatusCode = 500
            };
        }
    }
}
