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
    public class M_BK_DormEntity : BaseEntity
    {
        #region 实体成员
        
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        /// <returns></returns>
        public string StuInfoId { get; set; }
        /// <summary>
        /// 宿舍名称
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// 床位Id
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// 床位名
        /// </summary>
        /// <returns></returns>
        public string BedName{get;set;}
        /// <summary>
        /// 学生名
        /// </summary>
        /// <returns></returns>
        public string StuName{get;set;}
        /// <summary>
        /// 专业名
        /// </summary>
        /// <returns></returns>
        public string MajorDetailName{get;set;}
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
        /// 班级号
        /// </summary>
        /// <returns></returns>
        public string ClassNo{get;set;}
        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string telephone { get; set; }
        /// <summary>
        /// 学号
        /// </summary>
        /// <returns></returns>
        [Column("TELEPHONE")]
        public string StuNo { get; set; }



        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.DormId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormId = keyValue;
                                    
        }
        #endregion
    }
}