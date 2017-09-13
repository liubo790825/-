using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 15:59
    /// 描 述：床位信息
    /// </summary>
    public class BK_DormBedEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string BedId { get; set; }
        /// <summary>
        /// 宿舍ID号
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// 楼层ID号
        /// </summary>
        /// <returns></returns>
        public string DormFloorsId { get; set; }
        /// <summary>
        /// 宿舍楼单元ID号
        /// </summary>
        /// <returns></returns>
        public string DormUnitId { get; set; }
        /// <summary>
        /// 宿舍楼ID号
        /// </summary>
        /// <returns></returns>
        public string DormBuildingId { get; set; }
        /// <summary>
        /// 床位名称
        /// </summary>
        /// <returns></returns>
        public string BedName { get; set; }
        /// <summary>
        /// 床位编号
        /// </summary>
        /// <returns></returns>
        public string BedNo { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        public decimal? BedPrice { get; set; }
        /// <summary>
        /// 是否占用
        /// </summary>
        /// <returns></returns>
        public string IsDwell { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string BedOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string BedOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string BedOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string BedOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string BedOther4 { get; set; }

        /// <summary>
        /// 是否分发，0未分，1已分
        /// </summary>
        /// <returns></returns>
        public int IsDistribute { get; set; }
        /// <summary>
        /// 是否使用，0未使用，1已使用
        /// </summary>
        /// <returns></returns>
        public int IsUsed { get; set; }
        /// <summary>
        /// 专业ID号
        /// </summary>
        /// <returns></returns>
        public string MajorId { get; set; }
        /// <summary>
        /// 详细专业ID号
        /// </summary>
        /// <returns></returns>
        public string MajorDetailId { get; set; }
        /// <summary>
        /// 班级ID号
        /// </summary>
        /// <returns></returns>
        public string ClassInfoId { get; set; }
        /// <summary>
        /// 学生ID号
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }





        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.BedId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.BedId = keyValue;
                                    
        }
        #endregion
    }
}