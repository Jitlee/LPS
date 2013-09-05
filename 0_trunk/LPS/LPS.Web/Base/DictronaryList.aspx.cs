using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LPS.Model.Base;
using LPS.DAL.Base;
using System.Data;


namespace LPS.Web.Base
{
    public partial class BaseDictronaryList : PageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
     
            if (!IsPostBack)
            {
                InitPage();
                //BindGraid();
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            //aBtnAdd.Visible = gvBaseDictronary.Columns[1].Visible = base.HasPermission("Edit");
            //gvBaseDictronary.Columns[2].Visible = base.HasPermission("Delete");

            //DataTable dt = new DataDictDA().SelectTitle();
            rptDataDictionaryTitle.DataSource = new DictronaryTypeDAL().Query(); ;
            rptDataDictionaryTitle.DataBind();

            dropMain.DataSource = new DictronaryTypeDAL().Query(); ;
            dropMain.DataBind();
        }

     
        protected void rptDataDictionaryTitle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
            {
                string keyword = ((HiddenField)item.FindControl("Hidden1")).Value;
                Repeater rp = item.FindControl("rptDataDictionarySub") as Repeater;
                if (rp != null)
                {
                    rp.DataSource = new DictronaryDAL().QueryByType(keyword);
                    rp.DataBind();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string keyword = dropMain.SelectedValue;
            //DataTable dtsub = new DataDictDA().SelectSubData(this.txtSub.Text, keyword);
            //if (dtsub.Rows.Count > 0)
            //{
            //    base.Alert("您已经提交过该名称了！");
            //    return;
            //}
            //else
            //{
            //    if (this.txtSub.Text != "")
            //    {
            //        DataDictOR subadd = new DataDictOR();
            //        subadd.KEY_WORD = dropMain.SelectedValue;
            //        subadd.NAME = this.txtSub.Text;
            //        subadd.PARENT_CODE = Guid.NewGuid().ToString();
            //        new DataDictDA().AddDataDict(subadd);

            //        this.txtSub.Text = "";
            //        Response.Redirect("~/DataDict/DictList.aspx");
            //    }
            //    else
            //    {
            //        base.Alert("子类不能为空!");
            //    }
            //}
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataDictDA().SelectATitle(this.txtMain.Text.Trim());
            //if (dt.Rows.Count > 0)
            //{
            //    rptDataDictionaryTitle.DataSource = dt;
            //    rptDataDictionaryTitle.DataBind();
            //}
            //else
            //{
            //    base.Alert("没有相关数据！请检查是否输入错误或文字中间有空格！");
            //    rptDataDictionaryTitle.DataSource = dt;
            //    rptDataDictionaryTitle.DataBind();
            //}
        }

        protected void lbtnDel_Click(object sender, CommandEventArgs e)
        {
            //try
            //{
            //    string key = e.CommandArgument.ToString();
            //    new DataDictDA().DelDict(key);
            //    Response.Redirect("DictList.aspx");
            //}
            //catch (Exception ex)
            //{
            //    Alert(ex.Message);
            //}
        }



        //private void BindGraid()
        //{
        //    int PageCount = 0;
        //    this.gvBaseDictronary.DataSource = new DictronaryDAL().Query();//(this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

        //    this.gvBaseDictronary.DataBind();
        //    this.pg.RecordCount = PageCount;
        //}

        //protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        //{
        //    string id = e.CommandArgument.ToString();
        //    if (e.CommandName == "delete")
        //    {
        //        new DictronaryDAL().Delete(id);
        //        BindGraid();
        //    }
        //}
    }

}
