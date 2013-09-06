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
	public partial class BaseFarmerEdit : PageBase
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
				Farmer m_Base = new FarmerDAL().Get(Request.QueryString["id"]);

				txtFarmarCode.Text = m_Base.FarmarCode;//烟农编码
				txtFarmerRfid.Text = m_Base.FarmerRfid;//烟农RFID标识
				txtFarmerName.Text = m_Base.FarmerName;//烟农名称
				txtFarmerPy.Text = m_Base.FarmerPy;//烟农拼音缩写
				txtFarmerPhone.Text = m_Base.FarmerPhone;//烟农电话
				txtFarmerEmail.Text = m_Base.FarmerEmail;//烟农电子邮箱
				txtFarmerAddress.Text = m_Base.FarmerAddress;//烟农地址
				txtFarmerRmark.Text = m_Base.FarmerRmark;//备注
				dpdFarmerSex.Text = m_Base.FarmerSex;//性别
				txtFarmerBirth.Text = m_Base.FarmerBirth.HasValue ? m_Base.FarmerBirth.Value.ToString("yyyy-MM-dd") : "";//出生日期
				txtFarmerCardId.Text = m_Base.FarmerCardId;//身份证       
				//txtFarmerIsDeleted.Text = m_Base.FarmerIsDeleted;//是否删除        

			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private Farmer SetValue()
		{
			Farmer m_Base = new Farmer();
			m_Base.FarmarCode = txtFarmarCode.Text;//烟农编码
			m_Base.FarmerRfid = txtFarmerRfid.Text;//烟农RFID标识
			m_Base.FarmerName = txtFarmerName.Text;//烟农名称
			m_Base.FarmerPy = txtFarmerPy.Text;//烟农拼音缩写
			m_Base.FarmerPhone = txtFarmerPhone.Text;//烟农电话
			m_Base.FarmerEmail = txtFarmerEmail.Text;//烟农电子邮箱
			m_Base.FarmerAddress = txtFarmerAddress.Text;//烟农地址
			m_Base.FarmerRmark = txtFarmerRmark.Text;//备注
			m_Base.FarmerSex = dpdFarmerSex.Text;//性别
			if (!string.IsNullOrEmpty(txtFarmerBirth.Text))
			{
				m_Base.FarmerBirth = Convert.ToDateTime(txtFarmerBirth.Text);//出生日期
			}
			m_Base.FarmerCardId = txtFarmerCardId.Text;//身份证
			//m_Base.FarmerCreateDate = Convert.ToDateTime(txtFarmerCreateDate.Text);//创建日期
			//m_Base.FarmerIsDeleted = txtFarmerIsDeleted.Text;//是否删除
			//m_Base.FarmerDeletedDate = Convert.ToDateTime(txtFarmerDeletedDate.Text);//删除日期

			return m_Base;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			Farmer sg = SetValue();

			try
			{
				if (Request.QueryString["id"] == null)
				{
					new FarmerDAL().Add(sg);
				}
				else
				{
					new FarmerDAL().Update(sg);
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
