using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:39
    /// 描 述：宿舍单元信息
    /// </summary>
    public class BK_DormUnitEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
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
        /// 单元名称
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITNAME")]
        public string DormUnitName { get; set; }
        /// <summary>
        /// 单元编号
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITNO")]
        public string DormUnitNo { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITMANAGER")]
        public string DormUnitManager { get; set; }
        /// <summary>
        /// 单元类型，即：男生或女生，有些学校这里不分
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITTYPE")]
        public string DormUnitType { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER")]
        public string DormUnitOther { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER1")]
        public string DormUnitOther1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER2")]
        public string DormUnitOther2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER3")]
        public string DormUnitOther3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        [Column("DORMUNITOTHER4")]
        public string DormUnitOther4 { get; set; }

        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
                this.DormUnitId = Guid.NewGuid().ToString();//根据实际需要去修改            
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.DormUnitId = keyValue;
                                    
        }
        #endregion
    }
}