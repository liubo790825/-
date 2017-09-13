using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 15:36
    /// 描 述：InfoClass
    /// </summary>
    public class InfoClassEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? ClassId { get; set; }
        /// <summary>
        /// 班号
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// 校区
        /// </summary>
        /// <returns></returns>
        public string SchoolArea { get; set; }
        /// <summary>
        /// 系部
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// 专业
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// 学生数量
        /// </summary>
        /// <returns></returns>
        public int? StuNum { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// 合班号
        /// </summary>
        /// <returns></returns>
        public string MergeClassNo { get; set; }
        /// <summary>
        /// 合班名
        /// </summary>
        /// <returns></returns>
        public string MergeClassname { get; set; }
        /// <summary>
        /// 是否合班
        /// </summary>
        /// <returns></returns>
        public byte? IsMerged { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ClassId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.ClassId = keyValue;
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.ClassId = keyValue;

        }
        #endregion
    }
}