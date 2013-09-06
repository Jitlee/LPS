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
            }
        }

        private void InitPage()
        {  
            rptDataDictionaryTitle.DataSource = new DictronaryTypeDAL().Query();
            rptDataDictionaryTitle.DataBind(); 
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

        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            rptDataDictionaryTitle.DataSource = new DictronaryTypeDAL().Query(txtMain.Text.Trim());
            rptDataDictionaryTitle.DataBind();
            
             
        }
         
        
    }

}
