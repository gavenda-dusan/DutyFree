using DutyFree.Core.Entities.Users;
using System.Web;

namespace DutyFree.Web.Class
{
    public class SessionState
    {
        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session == null)
                {
                    return null;
                }
                return (User)HttpContext.Current.Session["User"];
            }
            set { HttpContext.Current.Session["User"] = value; }
        }
    }
}