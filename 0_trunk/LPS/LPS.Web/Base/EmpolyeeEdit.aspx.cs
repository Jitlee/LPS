using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using LPS.Model.Sys;
using LPS.DAL.Sys;


namespace LPS.Web.Base
{
	public partial class BaseEmpolyeeEdit : PageBase
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
                EmpolyeeOR m_Base = new EmpolyeeDA().selectARowDateByGuid(Request.QueryString["id"]);

				txtEmpolyeeCode.Text = m_Base.EmpolyeeCode;//员工编号
				txtEmpolyeeRfid.Text = m_Base.EmpolyeeRfid;//员工RFID
				txtEmpolyeeName.Text = m_Base.EmpolyeeName;//员工名称
				txtEmpolyeePy.Text = m_Base.EmpolyeePy;//员工拼音缩写
                dpdEmpolyeeSex.Text = m_Base.EmpolyeeSex;//员工性别
				txtEmpolyeeBirth.Text = m_Base.EmpolyeeBirth.ToString();//员工出生日期
				txtEmpolyeeEntryDate.Text = m_Base.EmpolyeeEntryDate.ToString();//员工入职日期
				txtEmpolyeePhone.Text = m_Base.EmpolyeePhone;//员工手机号
				txtEmpolyeeEmail.Text = m_Base.EmpolyeeEmail;//员工电子邮箱
				txtEmpolyeeAddress.Text = m_Base.EmpolyeeAddress;//员工联系地址
				txtEmpolyeeHometown.Text = m_Base.EmpolyeeHometown;//员工籍贯
				txtEmpolyeeCardId.Text = m_Base.EmpolyeeCardId;//员工身份证号
				txtUserId.Text = m_Base.UserId;//用户ID
				txtUserPwd.Text = m_Base.UserPwd;//用户密码
			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private EmpolyeeOR SetValue()
		{

			EmpolyeeOR m_Base = new EmpolyeeOR();
			m_Base.EmpolyeeCode = txtEmpolyeeCode.Text;//员工编号
			m_Base.EmpolyeeRfid = txtEmpolyeeRfid.Text;//员工RFID
			m_Base.EmpolyeeName = txtEmpolyeeName.Text;//员工名称
			m_Base.EmpolyeePy = txtEmpolyeePy.Text;//员工拼音缩写
            m_Base.EmpolyeeSex = dpdEmpolyeeSex.Text;//员工性别
            if (!string.IsNullOrEmpty(txtEmpolyeeBirth.Text))
            {
                m_Base.EmpolyeeBirth = Convert.ToDateTime(txtEmpolyeeBirth.Text);//员工出生日期
            }
            if (!string.IsNullOrEmpty(txtEmpolyeeEntryDate.Text))
            {
                m_Base.EmpolyeeEntryDate = Convert.ToDateTime(txtEmpolyeeEntryDate.Text);//员工入职日期
            }
			m_Base.EmpolyeePhone = txtEmpolyeePhone.Text;//员工手机号
			m_Base.EmpolyeeEmail = txtEmpolyeeEmail.Text;//员工电子邮箱
			m_Base.EmpolyeeAddress = txtEmpolyeeAddress.Text;//员工联系地址
			m_Base.EmpolyeeHometown = txtEmpolyeeHometown.Text;//员工籍贯
			m_Base.EmpolyeeCardId = txtEmpolyeeCardId.Text;//员工身份证号
			m_Base.UserId = txtUserId.Text;//用户ID
			m_Base.UserPwd = txtUserPwd.Text;//用户密码

			return m_Base;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			EmpolyeeOR sg = SetValue();

			try
			{
				if (Request.QueryString["id"] == null)
				{
					new EmpolyeeDA().Insert(sg);
				}
				else
				{
					new EmpolyeeDA().Update(sg);
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
