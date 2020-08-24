using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DutyFree.Web.Class
{
    public class SecurityRightAttribute : ActionFilterAttribute
    {
        private readonly string _expectedRole;

        public SecurityRightAttribute(string expectedRole)
        {
            _expectedRole = expectedRole;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionState.CurrentUser != null && _expectedRole == SessionState.CurrentUser.Role.ToString())
            {
                return;
            }
            else
            {
                var context = new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData());
                var urlHelper = new UrlHelper(context);
                var url = urlHelper.Action("Index", "Home");
                HttpContext.Current.Response.Redirect(url);
            }
        }
    }
}