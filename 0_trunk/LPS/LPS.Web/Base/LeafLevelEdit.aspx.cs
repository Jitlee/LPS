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
	public partial class BaseLeafLevelEdit : PageBase
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
				LeafLevel m_Base = new LeafLevelDAL().Get(Request.QueryString["id"]);
				txtLeafLevelName.Text = m_Base.LeafLevelName;//等级名称
				txtLeafLevelDesc.Text = m_Base.LeafLevelDesc;//等级描述
				txtLeafLevelPrice.Text = m_Base.LeafLevelPrice.ToString();//烟叶等级价格
				txtLeafLevelSort.Text = m_Base.LeafLevelSort.ToString();//排序
				txtLeafLevelIsDeleted.Text = m_Base.LeafLevelIsDeleted;//是否删除


			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private LeafLevel SetValue()
		{
			LeafLevel m_Base = new LeafLevel();
			m_Base.LeafLevelName = txtLeafLevelName.Text;//等级名称
			m_Base.LeafLevelDesc = txtLeafLevelDesc.Text;//等级描述
			m_Base.LeafLevelPrice = Convert.ToDouble(txtLeafLevelPrice.Text);//烟叶等级价格
			m_Base.LeafLevelSort = Convert.ToInt32(txtLeafLevelSort.Text);//排序



			return m_Base;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			LeafLevel sg = SetValue();

			try
			{
				if (Request.QueryString["id"] == null)
				{
					new LeafLevelDAL().Add(sg);
				}
				else
				{
					new LeafLevelDAL().Update(sg);
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
