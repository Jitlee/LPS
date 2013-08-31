using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LPS.Model.Sys
{
    public class UsersOR
    {
        private string _EmpolyeeId;
        /// <summary>
        /// 
        /// </summary>
        public string EmpolyeeId
        {
            get { return _EmpolyeeId; }
            set { _EmpolyeeId = value; }
        }

        private string _EmpolyeeCode;
        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmpolyeeCode
        {
            get { return _EmpolyeeCode; }
            set { _EmpolyeeCode = value; }
        }

        private string _EmpolyeeRfid;
        /// <summary>
        /// 员工RFID
        /// </summary>
        public string EmpolyeeRfid
        {
            get { return _EmpolyeeRfid; }
            set { _EmpolyeeRfid = value; }
        }

        private string _EmpolyeeName;
        /// <summary>
        /// 员工名称
        /// </summary>
        public string EmpolyeeName
        {
            get { return _EmpolyeeName; }
            set { _EmpolyeeName = value; }
        }

        private string _EmpolyeePy;
        /// <summary>
        /// 员工拼音缩写
        /// </summary>
        public string EmpolyeePy
        {
            get { return _EmpolyeePy; }
            set { _EmpolyeePy = value; }
        }

        private string _EmpolyeeSex;
        /// <summary>
        /// 员工性别(‘男’,’女’)
        /// </summary>
        public string EmpolyeeSex
        {
            get { return _EmpolyeeSex; }
            set { _EmpolyeeSex = value; }
        }

        private DateTime _EmpolyeeBirth;
        /// <summary>
        /// 员工出生日期
        /// </summary>
        public DateTime EmpolyeeBirth
        {
            get { return _EmpolyeeBirth; }
            set { _EmpolyeeBirth = value; }
        }

        private DateTime _EmpolyeeEntryDate;
        /// <summary>
        /// 员工入职日期
        /// </summary>
        public DateTime EmpolyeeEntryDate
        {
            get { return _EmpolyeeEntryDate; }
            set { _EmpolyeeEntryDate = value; }
        }

        private string _EmpolyeePhone;
        /// <summary>
        /// 员工手机号
        /// </summary>
        public string EmpolyeePhone
        {
            get { return _EmpolyeePhone; }
            set { _EmpolyeePhone = value; }
        }

        private string _EmpolyeeEmail;
        /// <summary>
        /// 员工电子邮箱
        /// </summary>
        public string EmpolyeeEmail
        {
            get { return _EmpolyeeEmail; }
            set { _EmpolyeeEmail = value; }
        }

        private string _EmpolyeeAddress;
        /// <summary>
        /// 员工联系地址
        /// </summary>
        public string EmpolyeeAddress
        {
            get { return _EmpolyeeAddress; }
            set { _EmpolyeeAddress = value; }
        }

        private string _EmpolyeeHometown;
        /// <summary>
        /// 员工籍贯
        /// </summary>
        public string EmpolyeeHometown
        {
            get { return _EmpolyeeHometown; }
            set { _EmpolyeeHometown = value; }
        }

        private string _EmpolyeeCardId;
        /// <summary>
        /// 员工身份证号
        /// </summary>
        public string EmpolyeeCardId
        {
            get { return _EmpolyeeCardId; }
            set { _EmpolyeeCardId = value; }
        }

        private string _UserId;
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private string _UserPwd;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd
        {
            get { return _UserPwd; }
            set { _UserPwd = value; }
        }

        private DateTime _EmpolyeeCreateDate;
        /// <summary>
        /// 员工创建日期
        /// </summary>
        public DateTime EmpolyeeCreateDate
        {
            get { return _EmpolyeeCreateDate; }
            set { _EmpolyeeCreateDate = value; }
        }

        private string _EmpolyeeIsDeleted;
        /// <summary>
        /// N 表示已删除 
        /// </summary>
        public string EmpolyeeIsDeleted
        {
            get { return _EmpolyeeIsDeleted; }
            set { _EmpolyeeIsDeleted = value; }
        }

        private DateTime _EmpolyeeDeletedDate;
        /// <summary>
        /// 员工删除日期
        /// </summary>
        public DateTime EmpolyeeDeletedDate
        {
            get { return _EmpolyeeDeletedDate; }
            set { _EmpolyeeDeletedDate = value; }
        }

        /// <summary>
        /// baseempolyee构造函数
        /// </summary>
        public UsersOR()
        {

        }

        /// <summary>
        /// baseempolyee构造函数
        /// </summary>
        public UsersOR(IDataReader row)
        {
            // 
            _EmpolyeeId = row["EMPOLYEE_ID"].ToString().Trim();
            // 员工编号
            _EmpolyeeCode = row["EMPOLYEE_CODE"].ToString().Trim();
            // 员工RFID
            _EmpolyeeRfid = row["EMPOLYEE_RFID"].ToString().Trim();
            // 员工名称
            _EmpolyeeName = row["EMPOLYEE_NAME"].ToString().Trim();
            // 员工拼音缩写
            _EmpolyeePy = row["EMPOLYEE_PY"].ToString().Trim();
            // 员工性别(‘男’,’女’)
            _EmpolyeeSex = row["EMPOLYEE_SEX"].ToString().Trim();
            // 员工出生日期
            if (DBNull.Value != row["EMPOLYEE_BIRTH"])
            {
                _EmpolyeeBirth = Convert.ToDateTime(row["EMPOLYEE_BIRTH"]);
            }
            // 员工入职日期
            if (DBNull.Value != row["EMPOLYEE_ENTRY_DATE"])
            {
                _EmpolyeeEntryDate = Convert.ToDateTime(row["EMPOLYEE_ENTRY_DATE"]);
            }
            // 员工手机号
            _EmpolyeePhone = row["EMPOLYEE_PHONE"].ToString().Trim();
            // 员工电子邮箱
            _EmpolyeeEmail = row["EMPOLYEE_EMAIL"].ToString().Trim();
            // 员工联系地址
            _EmpolyeeAddress = row["EMPOLYEE_ADDRESS"].ToString().Trim();
            // 员工籍贯
            _EmpolyeeHometown = row["EMPOLYEE_HOMETOWN"].ToString().Trim();
            // 员工身份证号
            _EmpolyeeCardId = row["EMPOLYEE_CARD_ID"].ToString().Trim();
            // 用户ID
            _UserId = row["USER_ID"].ToString().Trim();
            // 用户密码
            _UserPwd = row["USER_PWD"].ToString().Trim();
            // 员工创建日期
            if (DBNull.Value != row["EMPOLYEE_CREATE_DATE"])
            {
                _EmpolyeeCreateDate = Convert.ToDateTime(row["EMPOLYEE_CREATE_DATE"]);
            }
            // N 表示已删除 
            _EmpolyeeIsDeleted = row["EMPOLYEE_IS_DELETED"].ToString().Trim();
            // 员工删除日期
            if (DBNull.Value != row["EMPOLYEE_DELETED_DATE"])
            {
                _EmpolyeeDeletedDate = Convert.ToDateTime(row["EMPOLYEE_DELETED_DATE"]);
            }
        }
    }
}
