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
using System.Collections.ObjectModel;


namespace LPS.Web.Base
{
	public partial class BaseDictronaryEdit : PageBase
	{

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }
        }
        private void InitPage()
        {
            try
            {
                this.lblmain.Visible = true;
               
                string keyword = Request["val"].ToString();
                DictronaryType dic = new DictronaryTypeDAL().Get(keyword);
                this.lblmain.Text = dic.DictType;
                              
                gridSubName.DataSource = new DictronaryDAL().QueryByType(keyword);
                gridSubName.DataBind();
                gridSubName.EditIndex = -1;
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        #region 子类添加
        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            Dictronary subupdating = new Dictronary();
            subupdating.DictCode = txtDictCode.Text;
            subupdating.DictType = Request.QueryString["val"];
            subupdating.DictName = txtDictName.Text;
            subupdating.DictDesc = txtDictDesc.Text;
            ObservableCollection<Dictronary> List = new DictronaryDAL().QueryByType(Request["val"]);
            foreach (Dictronary obj in List)
            {
                if (obj.DictCode == subupdating.DictCode)
                {
                    Alert("您已提交过该编号了！");
                    return;
                }
            }

            new DictronaryDAL().Add(subupdating);
            txtDictCode.Text = "";
            txtDictName.Text = "";
            txtDictDesc.Text = "";
            InitPage();

        }
        #endregion

        #region 子类编辑
        protected void gridSubName_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridSubName.EditIndex = e.NewEditIndex;
            InitPage();
        }
        #endregion

        #region  子类更新
        protected void gridSubName_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string strCode=((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtDictCode")).Text.Trim();
            if (strCode.Length > 0)
            {
                try
                {
                    if (!CheckString(strCode))
                    {
                        Alert("请勿输入特殊字符！");
                        return;
                    }
                    string oldSub = ((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtOldSubName")).Text;
                    if (Request["val"].ToString() != "")
                    {
                        ObservableCollection<Dictronary> List = new DictronaryDAL().SelectSubWithoutSelf(Request["val"], oldSub);
                        foreach (Dictronary obj in List)
                        {
                            if (obj.DictCode == strCode)
                            {
                                Alert("您已提交过该名称了！");
                                return;
                            }
                        }
                    }
                    Dictronary subupdating = new Dictronary();

                    subupdating.DictCode = strCode;
                    subupdating.DictType = Request.QueryString["val"];
                    subupdating.DictName = ((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtDictName")).Text;
                    subupdating.DictDesc = ((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtDictDesc")).Text;

                    new DictronaryDAL().Update(subupdating,oldSub);

                    gridSubName.EditIndex = -1;
                    InitPage();
                }
                catch (Exception ex)
                {
                    Alert(ex);
                }
            }
            else
            {
                Alert("子类名称不能为空！"); return;
            }
        }
        #endregion

        #region  子类取消更新
        protected void gridSubName_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            gridSubName.EditIndex = -1;
            InitPage();
        }
        #endregion

        #region 子类删除
        protected void gridSubName_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string subId = gridSubName.DataKeys[e.RowIndex].Value.ToString();
                new DictronaryDAL().Delete(subId);
                InitPage();
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }
        #endregion

        #region check
        private bool CheckString(string s)
        {
            string[] arrStr = { "'", ";", ".", ",", "\"", ":", "~", "*", "%", "!", "@", "^", "&", "(", ")", "+", "-", "=", "\\", "/", "^", "|" };
            if (s.Trim().Length > 0)
            {
                string[] arr = s.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arrStr.Length; j++)
                    {
                        if (arr[i] == arrStr[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

	}
}
