using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：超级管理员
    /// 日 期：2016-10-17 10:36
    /// 描 述：高职员工账号生成
    /// </summary>
    public class EmpInfo2LoginUserEntity : BaseEntity
    {
        //TitleOfTechPost,DeptName,EmpFullTile,EmpSort
        #region 实体成员
        /// <summary>
        /// 职工号
        /// </summary>
        /// <returns></returns>
        public string EmpNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string EmpName { get; set; }
        /// <summary>
        /// 性别代码
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 专兼职
   
        /// </summary>
        /// 
        /// <returns></returns>
        public string EmpFullTime { get; set; }
        /// <summary>
        /// 教职工类别
        /// </summary>
        /// <returns></returns>
        public string EmpSort { get; set; }
        /// <summary>
        /// 系所（部门）代码
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        
        /// <summary>
        /// 聘任职称代码
        /// </summary>
        /// <returns></returns>
        public string TitleOfTechPost { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
       
      /// <summary>
      /// 职务工种
      /// </summary>
        public string Zhiwugongzhong { get; set; }

        public string CheckMark { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.EmpNo = Guid.NewGuid().ToString();//根据实际需要去修改
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.EmpNo = keyValue;
        }
        #endregion
    }
}