using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LPS.DAL.Base;

namespace LPS.Web.Base
{
    public partial class ParameterList : PageBase
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
            //aBtnAdd.Visible = gvBaseFarmer.Columns[1].Visible = base.HasPermission("Edit");
            //gvBaseFarmer.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
            this.gv.DataSource = new ParameterDAL().Query();//.selectAllDateByWhere(this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

            this.gv.DataBind();
            this.pg.RecordCount = PageCount;
        }

         
    }

}
