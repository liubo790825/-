using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-26 23:21
    /// 描 述：CommunityMembers
    /// </summary>
    public class CommunityMembersEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// CM_Id
        /// </summary>
        /// <returns></returns>
        public string CM_Id { get; set; }
        /// <summary>
        /// C_Id
        /// </summary>
        /// <returns></returns>
        public string C_Id { get; set; }
        /// <summary>
        /// CR_Id
        /// </summary>
        /// <returns></returns>
        public string CR_Id { get; set; }
        /// <summary>
        /// CMI_Id
        /// </summary>
        /// <returns></returns>
        public string CMI_Id { get; set; }
        /// <summary>
        /// CM_JoinDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_JoinDate { get; set; }
        /// <summary>
        /// CM_OutDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CM_OutDate { get; set; }
        /// <summary>
        /// CM_IsOut
        /// </summary>
        /// <returns></returns>
        public bool? CM_IsOut { get; set; }
        /// <summary>
        /// CM_Remark
        /// </summary>
        /// <returns></returns>
        public string CM_Remark { get; set; }
        /// <summary>
        /// CR_Name
        /// </summary>
        /// <returns></returns>
        public string CR_Name { get; set; }
        /// <summary>
        /// C_Name
        /// </summary>
        /// <returns></returns>
        public string C_Name { get; set; }
        /// <summary>
        /// C_Chairman
        /// </summary>
        /// <returns></returns>
        public string C_Chairman { get; set; }
        /// <summary>
        /// C_Type
        /// </summary>
        /// <returns></returns>
        public string C_Type { get; set; }
        /// <summary>
        /// C_BuidDate
        /// </summary>
        /// <returns></returns>
        public DateTime? C_BuidDate { get; set; }
        /// <summary>
        /// C_Briefing
        /// </summary>
        /// <returns></returns>
        public string C_Briefing { get; set; }
        /// <summary>
        /// C_Address
        /// </summary>
        /// <returns></returns>
        public string C_Address { get; set; }
        /// <summary>
        /// C_Tel
        /// </summary>
        /// <returns></returns>
        public string C_Tel { get; set; }
        /// <summary>
        /// CMI_StuNo
        /// </summary>
        /// <returns></returns>
        public string CMI_StuNo { get; set; }
        /// <summary>
        /// CMI_StuName
        /// </summary>
        /// <returns></returns>
        public string CMI_StuName { get; set; }
        /// <summary>
        /// CMI_Gender
        /// </summary>
        /// <returns></returns>
        public string CMI_Gender { get; set; }
        /// <summary>
        /// CMI_Birthday
        /// </summary>
        /// <returns></returns>
        public DateTime? CMI_Birthday { get; set; }
        /// <summary>
        /// CMI_IdNo
        /// </summary>
        /// <returns></returns>
        public string CMI_IdNo { get; set; }
        /// <summary>
        /// CMI_Photo
        /// </summary>
        /// <returns></returns>
        public string CMI_Photo { get; set; }
        /// <summary>
        /// CMI_DeptNo
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptNo { get; set; }
        /// <summary>
        /// CMI_DeptName
        /// </summary>
        /// <returns></returns>
        public string CMI_DeptName { get; set; }
        /// <summary>
        /// CMI_MajorNo
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorNo { get; set; }
        /// <summary>
        /// CMI_MajorName
        /// </summary>
        /// <returns></returns>
        public string CMI_MajorName { get; set; }
        /// <summary>
        /// CMI_ClassNo
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassNo { get; set; }
        /// <summary>
        /// CMI_ClassName
        /// </summary>
        /// <returns></returns>
        public string CMI_ClassName { get; set; }
        /// <summary>
        /// CMI_Phone
        /// </summary>
        /// <returns></returns>
        public string CMI_Phone { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.CM_Id = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CM_Id = keyValue;
                                    
        }
        #endregion
    }
}