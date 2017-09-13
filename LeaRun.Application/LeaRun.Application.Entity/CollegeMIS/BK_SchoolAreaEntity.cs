using System;
using System.ComponentModel.DataAnnotations.Schema;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 09:54
    /// 描 述：校区
    /// </summary>
    public class BK_SchoolAreaEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 校区ID
        /// </summary>
        /// <returns></returns>
        [Column("AREAID")]
        public string AreaId { get; set; }
        /// <summary>
        /// 校区名称
        /// </summary>
        /// <returns></returns>
        [Column("AREANAME")]
        public string AreaName { get; set; }
        /// <summary>
        /// 校区地址
        /// </summary>
        /// <returns></returns>
        [Column("AREAADDRESS")]
        public string AreaAddress { get; set; }
        /// <summary>
        /// 审核标志
        /// </summary>
        /// <returns></returns>
        [Column("CHECKMARK")]
        public string CheckMark { get; set; }
        /// <summary>
        /// 有效
        /// </summary>
        /// <returns></returns>
        [Column("ENABLEMRAK")]
        public int? EnableMrak { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.AreaId = Guid.NewGuid().ToString();//根据实际需要去修改
            this.EnableMrak = 1;                  
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.AreaId = keyValue;
                                    
        }
        #endregion
    }
}