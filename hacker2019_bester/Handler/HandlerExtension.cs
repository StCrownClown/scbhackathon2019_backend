using System;
using System.Linq;

namespace hacker2019_bester.Handler
{
    public class HandlerExtension
    {
        public static string GetErrorMessage(Exception ex)
        {
            return ErrorHandlingMiddleware.GetErrorMessage(ex).First().Key.errorMessage;
        }
    }
}
