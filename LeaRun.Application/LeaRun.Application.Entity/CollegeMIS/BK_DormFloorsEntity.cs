using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:37
    /// 描 述：宿舍楼层信息
    /// </summary>
    public class BK_DormFloorsEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
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
        /// 宿舍楼层名称
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSNAME")]
        public string DormFloorsName { get; set; }
        /// <summary>
        /// 宿舍楼层编号
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSNO")]
        public string DormFloorsNo { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSMANAGER")]
        public string DormFloorsManager { get; set; }
        /// <summary>
        /// 类型，即：男生或女生
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSTYPE")]
        public string DormFloorsType { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER")]
        public string DormFloorsOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER1")]
        public string DormFloorsOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER2")]
        public string DormFloorsOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER3")]
        public string DormFloorsOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMFLOORSOTHER4")]
        public string DormFloorsOther4 { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.DormFloorsId = Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormFloorsId = keyValue;
                                    
        }
        #endregion
    }
}