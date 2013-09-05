﻿using System;
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
            if (!IsPostBack)
            {
                InitPage();
            }
        }
        private void InitPage()
        {
            try
            {
                this.lblAlert.Text = "";
                this.txtMain.Visible = false;
                this.lbtnUpdate.Visible = false;
                this.lbtnCancel.Visible = false;
                this.lblmain.Visible = true;
                this.ibtnTitleEdit.Visible = true;
                string keyword = Request["val"].ToString();
                DictronaryType dic = new DictronaryTypeDAL().Get(keyword);
                this.lblmain.Text = dic.DictType;
                this.txtMain.Text = dic.DictType;
                
                gridSubName.DataSource = new DictronaryDAL().QueryByType(keyword);
                gridSubName.DataBind();
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        protected void ibtnTitleEdit_Click(object sender, ImageClickEventArgs e)
        {
            this.lblmain.Visible = false;
            this.ibtnTitleEdit.Visible = false;
            this.txtMain.Visible = true;
            this.lbtnUpdate.Visible = true;
            this.lbtnCancel.Visible = true;
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            this.lblmain.Visible = true;
            this.ibtnTitleEdit.Visible = true;
            this.txtMain.Visible = false;
            this.lbtnCancel.Visible = false;
            this.lbtnUpdate.Visible = false;
            InitPage();
        }

        protected void lbtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!string.IsNullOrEmpty(txtMain.Text.Trim()))
                //{
                //    string keyword = Request["val"].ToString();
                //    DataDictOR dic = new DataDictDA().GetDataDicct(keyword);
                //    DataDictOR mainupdate = new DataDictOR();
                //    DataTable dt = new DataDictDA().SelectTitleWithoutSelf(dic.NAME.Trim());
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        if (dt.Rows[i]["name"].ToString().Trim() == txtMain.Text.Trim())
                //        {
                //            Alert("您已提交过该名称了！");
                //            return;
                //        }
                //    }
                //    mainupdate.ID = dic.ID;
                //    mainupdate.KEY_WORD = dic.KEY_WORD;
                //    mainupdate.NAME = this.txtMain.Text;
                //    new DataDictDA().UpdateDataDict(mainupdate);

                //    this.lblmain.Visible = true;
                //    this.ibtnTitleEdit.Visible = true;
                //    this.txtMain.Visible = false;
                //    this.lbtnCancel.Visible = false;
                //    this.lbtnUpdate.Visible = false;
                //    InitPage();
                //}
                //else
                //{
                //    Alert("大类名称不能为空！"); return;
                //}
            }
            catch (Exception ex)
            {
                Alert(ex);
            }
        }

        #region 子类添加
        protected void btnAddSub_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (!CheckString(txtAddSub.Text))
            //    {
            //        Alert("请勿输入特殊字符！");
            //        txtAddSub.Text = "";
            //        return;
            //    }
            //    string keyword = Request["val"].ToString();
            //    DataTable dtsub = new DataDictDA().SelectSubData(this.txtAddSub.Text, keyword);
            //    if (dtsub.Rows.Count > 0)
            //    {
            //        this.lblAlert.Text = "您已提交过该名称了！";
            //        return;
            //    }
            //    else
            //    {
            //        if (this.txtAddSub.Text.Trim().Length > 0)
            //        {
            //            DataDictOR subAdd = new DataDictOR();
            //            subAdd.KEY_WORD = keyword;
            //            subAdd.NAME = this.txtAddSub.Text;
            //            subAdd.PARENT_CODE = Guid.NewGuid().ToString();
            //            new DataDictDA().AddDataDict(subAdd);

            //            this.txtAddSub.Text = "";
            //            InitPage();
            //        }
            //        else
            //        {
            //            this.lblAlert.Text = "子类不能为空！";
            //            return;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Alert(ex);
            //}
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
            //if (((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtsubName")).Text.Trim().Length > 0)
            //{
            //    try
            //    {
            //        if (!CheckString(((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtsubName")).Text.Trim()))
            //        {
            //            Alert("请勿输入特殊字符！");
            //            return;
            //        }
            //        string oldSub = ((HiddenField)gridSubName.Rows[e.RowIndex].FindControl("hideSub")).Value;
            //        if (Request["val"].ToString() != "")
            //        {
            //            DataTable dt = new DataDictDA().SelectSubWithoutSelf(Request["val"].ToString(), oldSub);
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                if (dt.Rows[i]["name"].ToString().Trim() == ((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtsubName")).Text.Trim())
            //                {
            //                    Alert("您已提交过该名称了！");
            //                    return;
            //                }
            //            }
            //        }
            //        DataDictOR subupdating = new DataDictOR();
            //        subupdating.ID = gridSubName.DataKeys[e.RowIndex].Value.ToString();
            //        subupdating.KEY_WORD = Request["val"].ToString();
            //        subupdating.NAME = ((TextBox)gridSubName.Rows[e.RowIndex].FindControl("txtsubName")).Text;
            //        new DataDictDA().UpdateDataDict(subupdating);

            //        gridSubName.EditIndex = -1;
            //        InitPage();
            //    }
            //    catch (Exception ex)
            //    {
            //        Alert(ex);
            //    }
            //}
            //else
            //{
            //    Alert("子类名称不能为空！"); return;
            //}
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
                //new DataDictDA().DelDataDict(subId);

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
