using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LPS;
using LPS.DAL.Sys;
using LPS.Model.Sys;
using System.Collections.ObjectModel;


namespace LPS.Web.Role
{
    public partial class UserAuthEdit : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initPage();
            }
        }

        private void initPage()
        {
            initRose();//初使化角色列表

            initUserRose();
            InitUserInfo();
        }

        private void initRose()
        {
            RolesDA rs = new RolesDA();
            int Count = 0;
            cblRoseList.DataSource = rs.selectAllDateByWhere(1, 50, out Count, ""); ;
            cblRoseList.DataTextField = "RoleName";
            cblRoseList.DataValueField = "Guid";
            cblRoseList.DataBind();
        }

        private void InitUserInfo()
        {
            if (Request.QueryString["userid"] != null)
            {
                EmpolyeeOR obj = new EmpolyeeDA().selectARowDateByGuid(Request.QueryString["userid"]);
                if (obj != null)
                {
                    this.txt_ShowName.Text = obj.EmpolyeeName;
                    this.txt_LoginCode.Text = obj.EmpolyeeCode;
                }
            }
        }

        private void initUserRose()
        {
            if (null != Request.QueryString["userid"])
            {
                string userid = Request.QueryString["userid"];

                UserRolesDA rs = new UserRolesDA();
                ObservableCollection<UserRolesOR> listUserRose = rs.GetUserRoseBuyUserID(userid);
                foreach (UserRolesOR obj in listUserRose)
                {
                    checkCBList(obj.RoleGuid);
                }
            }
            else
            {
                base.Alert("获取用户ID失败！");
            }
        }

        private void checkCBList(string guid)
        {
            foreach (ListItem li in cblRoseList.Items)
            {
                if (li.Value == guid)
                {
                    li.Selected = true;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (null != Request.QueryString["userid"])
            {
                string userid = Request.QueryString["userid"].ToString();

                List<UserRolesOR> listUR = new List<UserRolesOR>();
                foreach (ListItem li in cblRoseList.Items)
                {
                    if (li.Selected)
                    {
                        UserRolesOR tur = new UserRolesOR();
                        tur.UserGuid = userid;
                        tur.RoleGuid = li.Value;
                        listUR.Add(tur);
                    }
                }
                if (listUR.Count == 0)
                {
                    base.Alert("请选择角色。");
                }
                UserRolesDA rs = new UserRolesDA();
                if (rs.AddUserRoles(listUR))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", @"<script language='javascript'>
                    $(document).ready(function(){
                        $.DialogClose('xz');
                    });
                    </script>");
                    //base.Close(true);
                }
                else
                {
                    base.Alert("授权失败！");
                }
            }
            else
            {
                base.Alert("获取用户ID失败！");
            }
        }
    }

}
