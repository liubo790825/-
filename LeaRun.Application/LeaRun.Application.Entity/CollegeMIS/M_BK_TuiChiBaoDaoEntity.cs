using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public class M_BK_TuiChiBaoDaoEntity : BaseEntity
    {
        #region 实体成员

        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string TuiChiId { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string telephone { get; set; }
        /// <summary>
        /// 推迟报到原因
        /// </summary>
        /// <returns></returns>
        public string Reason { get; set; }
        /// <summary>
        /// 推迟报到时间
        /// </summary>
        /// <returns></returns>
        public DateTime? TuiChiTime { get; set; }
        /// <summary>
        /// 民族号
        /// </summary>
        /// <returns></returns>
        public string NationalityNo{get;set;}
        /// <summary>
        /// 来源地区号
        /// </summary>
        /// <returns></returns>
        public string ProvinceNo{get;set;}
        /// <summary>
        /// 提交记录时间
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther { get; set; }
        /// <summary>
        /// 班级号ClassNo
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther1 { get; set; }
        /// <summary>
        /// 班级名ClassName
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther2 { get; set; }
        /// <summary>
        /// 头像图片
        /// </summary>
        /// <returns></returns>
        public string HeadImg { get; set; }


        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.TuiChiId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.TuiChiId = keyValue;
                                    
        }
        #endregion
    }
}