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
	public partial class BaseDictronaryEdit : PageBase
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
				Dictronary m_Base = new DictronaryDAL().Get(Request.QueryString["id"]);
				//if (Request.QueryString["id"] != null)
				//    m_Line.Id = Request.QueryString["id"];
				txtDictType.Text = m_Base.DictType;//
				txtDictName.Text = m_Base.DictName;//
				txtDictValue.Text = m_Base.DictValue;//
				txtDictDesc.Text = m_Base.DictDesc;//

			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private Dictronary SetValue()
		{
			Dictronary m_Base = new Dictronary();
			m_Base.DictType = txtDictType.Text;//
			m_Base.DictName = txtDictName.Text;//
			m_Base.DictValue = txtDictValue.Text;//
			m_Base.DictDesc = txtDictDesc.Text;//

			return m_Base;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			Dictronary sg = SetValue();

			try
			{
				if (Request.QueryString["id"] == null)
				{
					new DictronaryDAL().Add(sg);
				}
				else
				{
					new DictronaryDAL().Update(sg);
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
