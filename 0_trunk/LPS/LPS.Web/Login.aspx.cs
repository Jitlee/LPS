using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using LPS.Model.Sys;
using LPS.DAL.Sys;
using System.Collections.ObjectModel;
namespace LPS.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, ImageClickEventArgs e)
        {
			EmpolyeeOR user;
			try
			{
				user = new EmpolyeeDA().sp_UserLogin(tbxUserCode.Text, tbxPassword.Text);
			}
			catch (Exception ex)
			{
				Alert(ex.Message.Replace("'", "").Replace("\r\n", ""));
				return;
			}
			Session["CurrentUser"] = user;
			HttpCookie cookieGuid = new HttpCookie("CurrentUser");
			cookieGuid.Expires = DateTime.Now.AddHours(9);

			cookieGuid.Values.Add("UserID", user.EmpolyeeId);
			cookieGuid.Values.Add("LoginName", user.EmpolyeeCode);
			cookieGuid.Values.Add("UserName", user.EmpolyeeName);
			cookieGuid.Values.Add("Password", user.UserPwd);
			cookieGuid.Path = "/";
			Response.AppendCookie(cookieGuid);

            ObservableCollection<VHC_USER_PERMISSIONS> _Permissions = new UserPermissionsDA().GetListByUserID(user.EmpolyeeId);
            if (_Permissions.Count == 0)
            {
                Alert("未授权，无法访问该系统。");
                return;
            }
            Session["UserPermissions"] = _Permissions;
			Response.Redirect("~/Main/Default.aspx");
        }

        protected void Alert(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "LoginAlert", "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");

        }
    }
}