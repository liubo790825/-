using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-29 10:34
    /// 描 述：BK_DormItem
    /// </summary>
    public class BK_DormItemEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 序号
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// 宿舍Id
        /// </summary>
        /// <returns></returns>
        public string DormId { get; set; }
        /// <summary>
        /// 房间物品名称
        /// </summary>
        /// <returns></returns>
        public string DormItemName { get; set; }
        /// <summary>
        /// 物品数量
        /// </summary>
        /// <returns></returns>
        public string ItemNumber { get; set; }
        /// <summary>
        /// 物品单价
        /// </summary>
        /// <returns></returns>
        public string ItemPrice { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other1 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other2 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other3 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other4 { get; set; }
        /// <summary>
        /// 备用
        /// </summary>
        /// <returns></returns>
        public string Other5 { get; set; }
        /// <summary>
        /// 房间名
        /// </summary>
        /// <returns></returns>
        public string DormName { get; set; }
        /// <summary>
        /// 楼层Id
        /// </summary>
        /// <returns></returns>
        public string DormFloorsId { get; set; }
        /// <summary>
        /// 单元Id
        /// </summary>
        /// <returns></returns>
        public string DormUnitId { get; set; }
        /// <summary>
        /// 楼栋Id
        /// </summary>
        /// <returns></returns>
        public string DormBUildingId { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//根据实际需要去修改
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
        }
        #endregion
    }
}