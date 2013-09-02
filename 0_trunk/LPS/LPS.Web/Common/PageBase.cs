using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using LPS.Model.Sys;
using LPS.DAL.Sys;
using System.Collections.ObjectModel;

namespace LPS.Web
{
    public partial class PageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {

            string url = PageUrl.ToUpper().Trim();

            if (_IsAuthenticate)
            {
                string rawUrl = PageRawUrl.ToUpper().Trim();
                if (!Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == url
                    || p.MOD_URL.ToUpper().Trim() == rawUrl))
                {
                    b_MissingParameter("无权访问该页面.");
                }
            }

            base.OnLoad(e);
        }


        public PageBase()
        {
            //权限控制
            //// Access();
        }

        #region 权限管理

        /// <summary>
        /// 当前用户的登陆名
        /// </summary>
        public string UserId
        {
            get
            {
                return CurrentUser.UserId;
            }
        }

        private void Access()
        {
            if (null == Session["CurrentUser"])
            {
                Server.Transfer("~/Login.aspx");
            }
        }
        /// <summary>
        /// 当前用户的显示名称
        /// </summary>
        public string UserName
        {
            get
            {
                return CurrentUser.EmpolyeeName;
            }
        }

        private EmpolyeeOR _CurrentUser;
        /// <summary>
        /// 当前用户信息
        /// </summary>
        public EmpolyeeOR CurrentUser
        {
            get
            {
                if (null == _CurrentUser)
                {
                    if (null == Session["CurrentUser"])
                    {
                        if (null != HttpContext.Current.Request.Cookies["CurrentUser"]
                            && null != HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"]
                            && (!string.IsNullOrEmpty(HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"])))
                        {
                            _CurrentUser = new EmpolyeeDA().selectARowDateByGuid(HttpContext.Current.Request.Cookies["CurrentUser"].Values["UserID"]);
                            Session["CurrentUser"] = _CurrentUser;
                        }
                        else
                        {
                            if (_IsAjaxPage)
                            {
                                throw new Exception("无法获取当前登录用户的信息,请重新登陆.");
                            }
                            else
                            {
                                HttpContext.Current.Response.Redirect("~/main/OutOffTime.aspx");
                            }
                        }
                    }
                    else
                    {
                        _CurrentUser = (EmpolyeeOR)Session["CurrentUser"];
                    }
                }
                return _CurrentUser;
            }
        }

        private bool _IsAuthenticate = true;
        /// <summary>
        /// 是事进行权限验证
        /// </summary>
        protected bool IsAuthenticate
        {
            set { _IsAuthenticate = value; }
        }

        private bool _IsAjaxPage = false;

        protected bool IsAjaxPage
        {
            set { _IsAjaxPage = value; }
        }

        private ObservableCollection<VHC_USER_PERMISSIONS> _Permissions;

        /// <summary>
        /// 当前用户的权限列表
        /// </summary>
        public ObservableCollection<VHC_USER_PERMISSIONS> Permissions
        {
            get
            {
                if (null == _Permissions)
                {
                    if (null == Session["UserPermissions"])
                    {
                        _Permissions = new UserPermissionsDA().GetListByUserID(UserId);
                        if (_Permissions.Count == 0)
                        {
                            b_Reload("未授权，无法访问该系统.");
                        }
                        Session["UserPermissions"] = _Permissions;
                    }
                    else
                    {
                        _Permissions = (ObservableCollection<VHC_USER_PERMISSIONS>)Session["UserPermissions"];
                    }
                }
                return _Permissions;
            }
        }

        private bool? _CanAdd;
        /// <summary>
        /// 是否拥有添加权限
        /// </summary>
        protected bool CanAdd
        {
            get
            {
                if (!_CanAdd.HasValue)
                {
                    _CanAdd = HasPermission("Edit");
                }
                return _CanAdd.Value;
            }
        }

        private bool? _CanDelete;
        /// <summary>
        /// 是否有删除权限
        /// </summary>
        protected bool CanDelete
        {
            get
            {
                if (!_CanDelete.HasValue)
                {
                    _CanDelete = HasPermission("Delete");
                    if (!_CanDelete.Value
                        && Regex.IsMatch(PageUrl,
                        "Add.aspx",
                        RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
                    {
                        string url = Regex.Replace(PageUrl, "Add.aspx", "List.aspx?Delete", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToUpper().Trim();
                        _CanDelete = HasPermissionFullWord(url);
                    }
                }
                return _CanDelete.Value;
            }
        }

        private bool? m_IsAdmin;
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsAdmin
        {
            get
            {
                if (!m_IsAdmin.HasValue)
                {
                    m_IsAdmin = Permissions.Any(p => p.MOD_URL == "admin");
                }
                return m_IsAdmin.Value;

            }
        }



        private bool? _CanApproval;
        /// <summary>
        /// 是否有审核权限
        /// </summary>
        protected bool CanApproval
        {
            get
            {
                if (!_CanApproval.HasValue)
                {
                    _CanApproval = HasPermission("Approval");
                }
                return _CanApproval.Value;
            }
        }

        /// <summary>
        /// 判断当前用户是否拥有指定的权限
        /// </summary>
        /// <param name="permission">权限名称</param>
        /// <returns></returns>
        protected bool HasPermission(string permission)
        {
            string url = Regex.Replace(PageUrl, "List.aspx", permission + ".aspx", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace).ToUpper().Trim();

            if (Permissions.Any(p => p.MOD_URL.ToUpper() == (PageUrl + "?" + permission).ToUpper()))
            {
                return true;
            }
            else if (Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == url))
            {
                return true;
            }
            else if (Permissions.Any(p => p.MOD_URL == permission))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断当前用户是否拥有指定的权限，全字匹配
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        protected bool HasPermissionFullWord(string permission)
        {
            if (Permissions.Any(p => p.MOD_URL.ToUpper().Trim() == permission.ToUpper().Trim()))
            {
                return true;
            }
            return false;
        }


        private string _PageUrl;
        protected string PageUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_PageUrl))
                {
                    _PageUrl = GetPageUrl();
                }
                return _PageUrl;
            }
        }

        private string _PageRawUrl;
        protected string PageRawUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_PageRawUrl))
                {
                    _PageRawUrl = GetPageRawUrl();
                }
                return _PageRawUrl;
            }
        }


        /// <summary>
        /// 获取页面的相对路径
        /// </summary>
        /// <returns></returns>
        protected string GetPageUrl()
        {
            Regex reg = new Regex("(?i)(?<=Root).*$");
            string appl_md_path = Request.ServerVariables.Get("APPL_MD_PATH").ToString();
            string virtualDirectory = reg.Match(appl_md_path).Value;
            string filePath = Regex.Replace(Request.FilePath, virtualDirectory, "", RegexOptions.IgnoreCase);

            filePath = Regex.Replace(filePath, "^[/]?", "");
            return filePath;
        }

        /// <summary>
        /// 获取页面的相对路径
        /// 包括QueryString
        /// </summary>
        /// <returns></returns>
        protected string GetPageRawUrl()
        {
            Regex reg = new Regex("(?i)(?<=Root).*$");
            string appl_md_path = Request.ServerVariables.Get("APPL_MD_PATH").ToString();
            string virtualDirectory = reg.Match(appl_md_path).Value;
            string filePath = Regex.Replace(Request.RawUrl, virtualDirectory, "", RegexOptions.IgnoreCase);
            filePath = Regex.Replace(filePath, "^[/]?", "");
            return filePath;
        }

        #endregion

        #region 公用方法

        private JavaScriptSerializer _Serializer;

        public TSource Deserialize<TSource>(string input)
        {
            if (null == _Serializer)
            {
                _Serializer = new JavaScriptSerializer();
            }
            return _Serializer.Deserialize<TSource>(Server.UrlDecode(input));
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        protected void b_MissingParameter()
        {
            Server.Transfer("~/main/MissingParameter.aspx");
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        /// <param name="msg"></param>
        protected void b_MissingParameter(string msg)
        {
            Server.Transfer("~/main/MissingParameter.aspx?msg=" + Server.UrlEncode(msg));
        }

        /// <summary>
        /// 页面缺乏参数时，跳转到提示页面
        /// </summary>
        /// <param name="msg"></param>
        protected void b_Reload(string msg)
        {
            Server.Transfer("~/main/OutoffTime.aspx?msg=" + Server.UrlEncode(msg));
        }

        //protected string RenderControl(Control control)
        //{
        //    Page page = new Page();
        //    HtmlForm form = new HtmlForm();
        //    control.EnableViewState = false;
        //    // Deshabilitar la validación de eventos, sólo asp.net 2
        //    page.EnableEventValidation = false;
        //    // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        //    page.DesignerInitialize();
        //    page.Controls.Add(form);
        //    form.Controls.Add(control);
        //    StringBuilder sBuilder = new StringBuilder();
        //    using (StringWriter sWriter = new StringWriter(sBuilder))
        //    {
        //        using (HtmlTextWriter html = new HtmlTextWriter(sWriter))
        //        {
        //            string id = control.ID;
        //            page.RenderControl(html);
        //            return sBuilder.ToString();
        //        }
        //    }
        //}

        /// <summary>
        /// 关闭当前窗口，可设置是否刷新父窗体(只限JQuery打开的窗体)或返回值
        /// 如果参数为System.Boolean类型则表示是否刷新父窗体(只限JQuery打开的窗体)
        /// 如果参数为System.String类型则表示有返回值
        /// </summary>
        /// <param name="arg0"></param>
        protected void Close(object arg0)
        {
            string str = arg0.ToString();
            string type = arg0.GetType().FullName;

            if (type == "System.Boolean")
            {
                str = str.ToLower();
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function(){$.DialogClose(" + str + ");});</script>");
            }
            else if (type == "System.String")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>$(document).ready(function(){$.DialogClose('" + str + "');});</script>");
            }
            else
            {
                throw new Exception("PageBase.Colse(object)的参数类型只能为System.Boolean或System.String类型");
            }
        }
        /// <summary>
        /// 弹出提示窗口，没有加修改大小
        /// </summary>
        /// <param name="msg"></param>
        protected void AlertNormal(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");
        }
        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void AlertAndClose(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){window.setTimeout(function () {alert('" + msg + "');$.DialogClose('Error');});</script>");
        }

        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void Alert(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");
        }
        /// <summary>
        /// 弹出提示窗口
        /// </summary>
        /// <param name="msg"></param>
        protected void Alert(Exception ex)
        {
            string msg = ex.Message;
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "",
                "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");
        }
        #endregion

        #region 页面主题
        void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "Default";
        }
        #endregion


        public string GetStr(string sObj, int intLen)
        {
            if (sObj.Length > intLen)
            {
                return sObj.Substring(0, intLen) + "…";
            }
            return sObj;
        }


        /// <summary>
        /// 产生新的编号
        /// </summary>
        /// <param name="code">得到的最大的字符串</param>
        /// <returns>返回构造之后最大的编号</returns>
        public static string retCodeToStringFormat(string code)
        {
            string str = string.Empty;
            string strNum = string.Empty;
            /*str.Substring(0, 2)获取前两个字母比如KC20100001中的BX*/
            /*str.Substring(2, str.Length - 2)获取除BX以外的其余字母*/
            //string s1 = code.Substring(DateTime.Now.Year.ToString().Length + 1, code.Length - 5);
            //string result = (Convert.ToInt32(code.Substring(DateTime.Now.Year.ToString().Length + 2, 4)) + 1).ToString();
            string ss = code.Substring(DateTime.Now.ToString("yyyy").Length, 5);
            string result = (Convert.ToInt32(ss) + 1).ToString();
            if (result.Length == 1)
            {
                strNum = string.Format("0000{0}", result);
            }
            else if (result.Length == 2)
            {
                strNum = string.Format("000{0}", result);
            }
            else if (result.Length == 3)
            {
                strNum = string.Format("00{0}", result);
            }
            else if (result.Length == 4)
            {
                strNum = string.Format("0{0}", result);
            }
            else
            {
                strNum = result;
            }
            str = string.Format("{0}{1}", System.DateTime.Now.ToString("yyyy"), strNum);
            return str;
        }


        public bool CompareDateTime(string date1, string date2)
        {
            if (!string.IsNullOrEmpty(date1.ToString().Trim()) && !string.IsNullOrEmpty(date2.ToString().Trim()))
            {
                if (DateTime.Parse(date1) > DateTime.Parse(date2))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsNumber(string itemValue)
        {
            string regExValue = "^[0-9]+$";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(regExValue);
            if (regex.IsMatch(itemValue))
                return true;
            else
                return false;
        }
       
        public string GetChartImagePath()
        {
            string path = Server.MapPath("..\\Upload");
            if (!path.EndsWith("\\"))
            {
                path += "\\";
            }
            return path;
        }
        
        #region 导出数据
        public void GetGridTableExcel(GridView grid, int startIndex, string strfaileName)
        {
            string dePath = Server.MapPath("../Upload/Teplate.xls");
            string toPath = Server.MapPath("../Upload/Excel");
            string temurl = Guid.NewGuid().ToString() + ".xls";
            toPath += toPath.EndsWith("\\") ? "" : "\\" + temurl;
            System.IO.File.Copy(dePath, toPath);

            string clounInfo = string.Empty;

            string strCreateTable = "CREATE TABLE Sheet1 (";
            int counter = 0;
            for (int k = startIndex; k < grid.Columns.Count; k++)
            {
                if (grid.Columns[k].Visible == true)
                {
                    string strTmp = grid.Columns[k].HeaderText.Trim();
                    if (string.IsNullOrEmpty(strTmp)) return;

                    if (counter == 0)
                    {
                        clounInfo = "[" + strTmp + "]";
                        strCreateTable += string.Format("[{0}] char(255)", strTmp);
                    }
                    else
                    {
                        clounInfo += ",[" + strTmp + "]";
                        strCreateTable += string.Format(",[{0}] char(255)", strTmp);
                    }
                    counter++;
                }
            }
            strCreateTable += ")";
            List<string> listSql = new List<string>();
            foreach (GridViewRow row in grid.Rows)
            {
                counter = 0;
                string strSql = string.Format("INSERT INTO [Sheet1$] ({0})  values (", clounInfo);
                for (int i = startIndex; i < row.Cells.Count; i++)
                {
                    if (grid.Columns[i].Visible == true)
                    {
                        string html = row.Cells[i].Text.Trim();
                        html = Regex.Replace(html, "<[^>]+>", "").Replace("&nbsp;", " ");
                        if (counter == 0)
                        {
                            strSql += string.Format("'{0}'", html);
                        }
                        else
                        {
                            strSql += string.Format(",'{0}'", html);
                        }
                        counter++;
                        //sb.AppendFormat("<td>{0}</td>", string.IsNullOrEmpty(html) ? " " : html);
                    }//if                  
                }//for
                strSql += ")";
                listSql.Add(strSql);

            }


            string mystring = "Provider=Microsoft.Jet.Oledb.4.0;Data Source = " + toPath + ";Extended Properties=Excel 8.0";
            OleDbConnection cnnxls = new OleDbConnection(mystring);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnnxls;

            cnnxls.Open();
            cmd.CommandText = strCreateTable;
            cmd.ExecuteNonQuery();
            foreach (string strSql in listSql)
            {
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            if (cnnxls.State == ConnectionState.Open)
                cnnxls.Close();
            if (cmd != null)
                cmd.Dispose();
            cnnxls.Dispose();

            string path = "..\\Upload\\Excel\\" + temurl;
            Response.Redirect(string.Format("../Main/downFile.aspx?path={0}&name={1}.xls", path, Server.HtmlEncode(strfaileName)));
        }

        public void TableExcel(DataTable dt, string[] ColumnsName, string[] Columns, string strfaileName)
        {
            string dePath = Server.MapPath("../Upload/Teplate.xls");
            string toPath = Server.MapPath("../Upload/Excel");
            string temurl = Guid.NewGuid().ToString() + ".xls";
            toPath += toPath.EndsWith("\\") ? "" : "\\" + temurl;
            System.IO.File.Copy(dePath, toPath);

            string clounInfo = string.Empty;

            string strCreateTable = "CREATE TABLE Sheet1 (";
            int counter = 0;
            foreach (string strTmp in ColumnsName)
            {
                if (counter == 0)
                {
                    clounInfo = "[" + strTmp + "]";
                    strCreateTable += string.Format("[{0}] char(255)", strTmp);
                    counter++;
                }
                else
                {
                    clounInfo += ",[" + strTmp + "]";
                    strCreateTable += string.Format(",[{0}] char(255)", strTmp);
                }
            }
            strCreateTable += ")";

            List<string> listSql = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                counter = 0;
                string strSql = string.Format("INSERT INTO [Sheet1$] ({0})  values (", clounInfo);
                foreach (string str in Columns)
                {
                    string html = row[str].ToString();
                    //html = Regex.Replace(html, "<[^>]+>", "").Replace("&nbsp;", " ");
                    if (counter == 0)
                    {
                        strSql += string.Format("'{0}'", html);
                    }
                    else
                    {
                        strSql += string.Format(",'{0}'", html);
                    }
                    counter++;
                }//foreach
                strSql += ")";
                listSql.Add(strSql);
            }

            string mystring = "Provider=Microsoft.Jet.Oledb.4.0;Data Source = " + toPath + ";Extended Properties=Excel 8.0";
            OleDbConnection cnnxls = new OleDbConnection(mystring);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = cnnxls;

            cnnxls.Open();
            cmd.CommandText = strCreateTable;
            cmd.ExecuteNonQuery();
            foreach (string strSql in listSql)
            {
                cmd.CommandText = strSql;
                cmd.ExecuteNonQuery();
            }
            if (cnnxls.State == ConnectionState.Open)
                cnnxls.Close();
            if (cmd != null)
                cmd.Dispose();
            cnnxls.Dispose();

            string path = "..\\Upload\\Excel\\" + temurl;
            Response.Redirect(string.Format("../Main/downFile.aspx?path={0}&name={1}.xls", path, Server.HtmlEncode(strfaileName)));
        }
        #endregion
    }
}