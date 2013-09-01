using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LPS.DAL.Sys;

namespace LPS.Web.Role
{
    public partial class UserAuthList : PageBase
    {
        private UserRolesDA m_UserR = new UserRolesDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pagenavigate1.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                if (null != Session["ListPageIndexUserAuth"])
                {
                    pagenavigate1.PageIndex = Convert.ToInt32(Session["ListPageIndexUserAuth"]);
                }
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            gvDataList.Columns[1].Visible = base.CanAdd;
        }

        private void BindGraid()
        {
            int recourtCount = 0;
            string where = " 1=1";
            if (txtUserName.Text.Trim() != "")
            {
                where += string.Format(" and USER_NAME like '%{0}%'", txtUserName.Text.Trim());
            }
            if (txtdept.Text.Trim() != "")
            {
                where += string.Format(" and deptNmae like '%{0}%'", txtdept.Text.Trim());
            }
            this.gvDataList.DataSource = m_UserR.GetUserRosetList(this.pagenavigate1.PageIndex, this.pagenavigate1.PageSize, out recourtCount, where); ;
            this.gvDataList.DataBind();
            this.pagenavigate1.RecordCount = recourtCount;
        }
        protected void PageChanged(object sender, EventArgs e)
        {
            Session.Clear();
            Session["ListPageIndexUserAuth"] = pagenavigate1.PageIndex;

            BindGraid();/*加查询条件string.Empty*/
        }

        protected void button_search_Click(object sender, EventArgs e)
        {
            BindGraid();
        }

      
    }

}