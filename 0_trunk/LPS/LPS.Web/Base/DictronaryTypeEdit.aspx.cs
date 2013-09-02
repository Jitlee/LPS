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
	public partial class BaseDictronaryTypeEdit : PageBase
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
				DictronaryType m_Base = new DictronaryTypeDAL().Get(Request.QueryString["id"]);

				txtDictTypeName.Text = m_Base.DictTypeName;//
				txtDictTypeDesc.Text = m_Base.DictTypeDesc;//

			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private DictronaryType SetValue()
		{
			DictronaryType m_Base = new DictronaryType();
			m_Base.DictTypeName = txtDictTypeName.Text;//
			m_Base.DictTypeDesc = txtDictTypeDesc.Text;//

			return m_Base;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			DictronaryType sg = SetValue();

			try
			{
				if (Request.QueryString["id"] == null)
				{
					new DictronaryTypeDAL().Add(sg);
				}
				else
				{
					new DictronaryTypeDAL().Update(sg);
				}
				base.Close("tr");
			}
			catch (Exception ex)
			{
				base.Alert(ex.Message);
			}
		}
	}
}
