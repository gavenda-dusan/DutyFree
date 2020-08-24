using System.Web.Mvc;
using System.Web.Security;
using DutyFree.Web.Class;
using DutyFree.Web.AppServices.Users;
using System.Threading.Tasks;
using DutyFree.Core.Entities.Users;

namespace DutyFree.Web.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IUserAppService _userAppService;

        public SecurityController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult LoginAction(User user)
        {
            FormsAuthentication.SetAuthCookie(user.UserID.ToString(), false);
            SessionState.CurrentUser = user;
            return null;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var vm = _userAppService.GetViewModel();

            return View(vm);
        }

        [Authorize]
        public JsonResult Logout()
        {
            SingOutAndClearSession();
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Google(string idToken)
        {
            var userAccessTokenValidationResponse = await _userAppService.ValidateIDToken(idToken);
            if (!userAccessTokenValidationResponse.IsValid)
            {
                return null;
            }
            else
            {
                var loginOrRegisterResult = _userAppService.LoginOrRegister(userAccessTokenValidationResponse.AccessTokenResponse);
                if (loginOrRegisterResult != null)
                {
                    LoginAction(loginOrRegisterResult);
                }
            }

            return null;
        }

        private void SingOutAndClearSession()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
        }
    }
}