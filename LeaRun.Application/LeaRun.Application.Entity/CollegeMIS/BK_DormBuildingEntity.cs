using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:41
    /// 描 述：宿舍楼信息
    /// </summary>
    public class BK_DormBuildingEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGID")]
        public string DormBuildingId { get; set; }
        /// <summary>
        /// 宿舍楼编号
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGNO")]
        public string DormBuildingNo { get; set; }
        /// <summary>
        /// 宿舍楼名称
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGNAME")]
        public string DormBuildingName { get; set; }
        /// <summary>
        /// 宿舍楼制度
        /// </summary>
        /// <returns></returns>
        [Column("BEDRULE")]
        public string BedRule { get; set; }
        /// <summary>
        /// 男生或女生
        /// </summary>
        /// <returns></returns>
        [Column("BUILDTYPE")]
        public string BuildType { get; set; }
        /// <summary>
        /// 楼长或管理员
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGMANAGER")]
        public string BuildingManager { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        /// <returns></returns>
        [Column("BUILDINGAREA")]
        public decimal? BuildingArea { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER")]
        public string DormBuildingOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER1")]
        public string DormBuildingOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER2")]
        public string DormBuildingOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER3")]
        public string DormBuildingOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER4")]
        public string DormBuildingOther4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER5")]
        public string DormBuildingOther5 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER6")]
        public string DormBuildingOther6 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER7")]
        public string DormBuildingOther7 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER8")]
        public string DormBuildingOther8 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGOTHER9")]
        public string DormBuildingOther9 { get; set; }

        /// <summary>
        /// 总单元数
        /// </summary>
        /// <returns></returns>
        [Column("UnitCount")]
        public int UnitCount { get; set; }

        /// <summary>
        /// 单元类型男生或女生
        /// </summary>
        /// <returns></returns>
        [Column("UnitType")]
        public string UnitType { get; set; }
        /// <summary>
        /// 单元规则
        /// </summary>
        /// <returns></returns>
        [Column("UnitTypeRule")]
        public string UnitTypeRule { get; set; }
        /// <summary>
        /// 每个单元的楼层数
        /// </summary>
        /// <returns></returns>
        [Column("FloorsCountForUnit")]
        public int FloorsCountForUnit { get; set; }
        /// <summary>
        /// 楼层规则
        /// </summary>
        /// <returns></returns>
        [Column("FloorsTypeRule")]
        public string FloorsTypeRule { get; set; }
        /// <summary>
        /// 楼层类型男生或女生
        /// </summary>
        /// <returns></returns>
        [Column("FloorsType")]
        public string FloorsType { get; set; }
        /// <summary>
        /// 每层楼的房间数
        /// </summary>
        /// <returns></returns>
        [Column("DormCountForFloor")]
        public int DormCountForFloor { get; set; }
        /// <summary>
        /// 房间规则
        /// </summary>
        /// <returns></returns>
        [Column("DormTypeRule")]
        public string DormTypeRule { get; set; }
        /// <summary>
        /// 每个房间的床位数
        /// </summary>
        /// <returns></returns>
        [Column("BedCountForDorm")]
        public int BedCountForDorm { get; set; }


        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
           this.DormBuildingId = Guid.NewGuid().ToString();//根据实际需要去修改                              
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormBuildingId = keyValue;
                                    
        }
        #endregion
    }
}