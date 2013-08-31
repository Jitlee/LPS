using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LPS.Model.Sys
{
    public class UsersOR
    {

        private string _Guid;
        /// <summary>
        /// 用户身份标志ID
        /// </summary>
        public string Guid
        {
            get { return _Guid; }
            set { _Guid = value; }
        }
        
        private string _DisplayName;
        /// <summary>
        /// 用户的显示名称
        /// </summary>
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        private string _AllPathName;
        /// <summary>
        /// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
        /// </summary>
        public string AllPathName
        {
            get { return _AllPathName; }
            set { _AllPathName = value; }
        }

        private int _Status;
        /// <summary>
        /// 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
        /// </summary>
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        
        
        /// <summary>
        /// 用户的附加描述信息
        /// </summary>
        public string Description { get; set; }
        

        
        /// <summary>
        /// 关系启用时间
        /// </summary>
        public string StartTime { get; set; }
        

        
        /// <summary>
        /// 关系结束时间
        /// </summary>
        public string EndTime { get; set; }
        

        
        /// <summary>
        /// 用户的登录名称
        /// </summary>
        public string LogonName { get; set; }
        

        
        /// <summary>
        /// 用户的IC卡号
        /// </summary>
        public string IcCard { get; set; }
        

        
        /// <summary>
        /// 使用密码的加密算法
        /// </summary>
        public string PwdTypeGuid { get; set; }
        

        private string _UserPwd;
        /// <summary>
        /// 用户所使用的密码（加密存储）
        /// </summary>
        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }
              

        private string _EMail;
        /// <summary>
        /// 用户默认使用的EMAIL
        /// </summary>
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }

        private int _Postural;
        /// <summary>
        /// 用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
        /// </summary>
        public int Postural
        {
            get { return _Postural; }
            set { _Postural = value; }
        }

        private string _CreateTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        private string _ModifyTime;
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public string ModifyTime
        {
            get { return _ModifyTime; }
            set { _ModifyTime = value; }
        }

        private int _AdCount;
        /// <summary>
        /// 是否在AD中建立对应的账号
        /// </summary>
        public int AdCount
        {
            get { return _AdCount; }
            set { _AdCount = value; }
        }

        private string _PersonId;
        /// <summary>
        /// 海关人员编码
        /// </summary>
        public string PersonId
        {
            get { return _PersonId; }
            set { _PersonId = value; }
        }
        
        /// <summary>
        /// 数据范围
        /// </summary>
        public string DataArea { get; set; }
        /// <summary>
        /// 机构编号
        /// </summary>
        public string OrgNo { get; set; }
        

        /// <summary>
        /// Users构造函数
        /// </summary>
        public UsersOR()
        {

        }

        /// <summary>
        /// Users构造函数
        /// </summary>
		public UsersOR(IDataReader row)
        {
            // 用户身份标志ID
            _Guid = row["GUID"].ToString().Trim();
            
            // 用户的显示名称
            _DisplayName = row["DISPLAY_NAME"].ToString().Trim();
            
            // 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
            _AllPathName = row["ALL_PATH_NAME"].ToString().Trim();
            // 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
            _Status = Convert.ToInt32(row["STATUS"]);
            
            // 用户的附加描述信息
            Description = row["DESCRIPTION"].ToString().Trim();
            // 关系启用时间
            StartTime = row["START_TIME"].ToString().Trim();
            // 关系结束时间
            EndTime = row["END_TIME"].ToString().Trim();
            // 用户的登录名称
            LogonName = row["LOGON_NAME"].ToString().Trim();
            // 用户的IC卡号
            IcCard = row["IC_CARD"].ToString().Trim();
            
            // 用户所使用的密码（加密存储）
            _UserPwd = row["USER_PWD"].ToString().Trim();
            
            // 用户默认使用的EMAIL
            _EMail = row["E_MAIL"].ToString().Trim();
            // 用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
            if (row["POSTURAL"] != DBNull.Value)
                _Postural = Convert.ToInt32(row["POSTURAL"]);
            // 创建时间
            _CreateTime = row["CREATE_TIME"].ToString().Trim();
            // 最近修改时间
            _ModifyTime = row["MODIFY_TIME"].ToString().Trim();
            // 是否在AD中建立对应的账号
            if (row["AD_COUNT"] != DBNull.Value)
                _AdCount = Convert.ToInt32(row["AD_COUNT"]);
            // 海关人员编码
            _PersonId = row["PERSON_ID"].ToString().Trim();

            DataArea = row["DataArea"].ToString().Trim();
            OrgNo = row["OrgNo"].ToString().Trim();
            
        }

    }

}
