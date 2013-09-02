using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LPS.Model.Base;
using LPS.DAL.Base;
using LPS.DAL.Sys;


namespace LPS.Web.Base
{
    public partial class BaseEmpolyeeList : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            aBtnAdd.Visible = gvBaseEmpolyee.Columns[1].Visible = base.HasPermission("Edit");
            gvBaseEmpolyee.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
			this.gvBaseEmpolyee.DataSource = new EmpolyeeDA().Select("");//this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

            this.gvBaseEmpolyee.DataBind();
            this.pg.RecordCount = PageCount;
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {
				if (!new EmpolyeeDA().Delete(id))
                {
                    base.Alert("删除失败!");
                }
               
                BindGraid();
            }
        }
    }

}
