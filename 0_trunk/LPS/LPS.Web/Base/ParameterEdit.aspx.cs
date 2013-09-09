using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using LPS.Model.Base;
using LPS.DAL.Base;

namespace LPS.Web.Base
{
    public partial class ParameterEdit : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                    LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                ParameterOR m_Base = new ParameterDAL().Get(Request.QueryString["id"]);

                lblParamName.Text = m_Base.ParamName;//等级名称
                lblParamDesc.Text = m_Base.ParamDesc;

                string strParamType= Request.QueryString["ParamType"];
                txtParamValue.Text = m_Base.ParamValue;
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        private ParameterOR SetValue()
        {
            ParameterOR m_Base = new ParameterOR();
            m_Base.ParamCode = Request.QueryString["id"];
            m_Base.ParamValue = txtParamValue.Text;
            return m_Base;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            ParameterOR sg = SetValue();

            try
            {
                new ParameterDAL().Update(sg);
                base.Close("tr");
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }
    }
}
