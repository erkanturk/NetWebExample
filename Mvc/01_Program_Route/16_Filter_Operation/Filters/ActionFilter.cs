using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _16_Filter_Operation.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //işlem sonrası
            Debug.WriteLine("Action Executed.");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //işlem sırası
            Debug.WriteLine("Action Executing");
        }
    }
}
