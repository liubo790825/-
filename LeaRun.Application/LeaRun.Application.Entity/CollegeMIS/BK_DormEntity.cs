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
    public class BK_DormEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        [Column("DORMID")]
        public string DormId { get; set; }
        /// <summary>
        /// 楼层序号
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSID")]
        public string DormFloorsId { get; set; }
        /// <summary>
        /// 单元序号
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITID")]
        public string DormUnitId { get; set; }
        /// <summary>
        /// 宿舍楼ID号
        /// </summary>
        /// <returns></returns>
        [Column("DORMBUILDINGID")]
        public string DormBuildingId { get; set; }
        /// <summary>
        /// 宿舍名称
        /// </summary>
        /// <returns></returns>
        [Column("DORMNAME")]
        public string DormName { get; set; }
        /// <summary>
        /// 宿舍编号
        /// </summary>
        /// <returns></returns>
        [Column("DORMNO")]
        public string DormNo { get; set; }
        /// <summary>
        /// 标准
        /// </summary>
        /// <returns></returns>
        [Column("STANDARD")]
        public string standard { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        /// <returns></returns>
        [Column("PRICE")]
        public decimal Price { get; set; }
        /// <summary>
        /// 床位总和
        /// </summary>
        /// <returns></returns>
        [Column("BEDS")]
        public int? Beds { get; set; }
        /// <summary>
        /// 星级
        /// </summary>
        /// <returns></returns>
        [Column("STARLEVEL")]
        public int? StarLevel { get; set; }
        /// <summary>
        /// 是否带卫生间（普通间，带卫生间高档间）
        /// </summary>
        /// <returns></returns>
        [Column("ADVANCEDMARK")]
        public string AdvancedMark { get; set; }
        /// <summary>
        /// 宿舍电话
        /// </summary>
        /// <returns></returns>
        [Column("DORMTEL")]
        public string DormTel { get; set; }
        /// <summary>
        /// 宿舍IP地址
        /// </summary>
        /// <returns></returns>
        [Column("DORMIP")]
        public string DormIp { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER")]
        public string DormOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER1")]
        public string DormOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER2")]
        public string DormOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER3")]
        public string DormOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMOTHER4")]
        public string DormOther4 { get; set; }

        /// <summary>
        /// 已使用床位数
        /// </summary>
        /// <returns></returns>
        [Column("UsedBeds")]
        public int UsedBeds { get; set; }
        /// <summary>
        /// 未使用床位数
        /// </summary>
        /// <returns></returns>
        [Column("NotUseBeds")]
        public int NotUseBeds { get; set; }
        /// <summary>
        /// 专业ID号
        /// </summary>
        /// <returns></returns>
        [Column("MajorId")]
        public string MajorId { get; set; }
        /// <summary>
        /// 详细专业ID号
        /// </summary>
        /// <returns></returns>
        [Column("MajorDetailId")]
        public string MajorDetailId { get; set; }
        /// <summary>
        /// 班级ID号
        /// </summary>
        /// <returns></returns>
        [Column("ClassInfoId")]
        public string ClassInfoId { get; set; }
        /// <summary>
        /// 已分发床位
        /// </summary>
        /// <returns></returns>
        [Column("DistributeBeds")]
        public int DistributeBeds { get; set; }
        /// <summary>
        /// 未分发床位
        /// </summary>
        /// <returns></returns>
        [Column("NotDistributeBeds")]
        public int NotDistributeBeds { get; set; }




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