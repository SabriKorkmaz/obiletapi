using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace obilet.Attribute
{
    public class SessionAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var authToken = HttpContext.Current.Request.Headers["auth-token"];

            if (string.IsNullOrEmpty(authToken))
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}