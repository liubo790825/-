using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：唐和江
    /// 日 期：2016-10-24 12:31
    /// 描 述：InfoPlace
    /// </summary>
    public class InfoPlaceEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? PlaceId { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        /// <returns></returns>
        public string PlaceCode { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        public string PlaceName { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        /// <returns></returns>
        public string PlaceAddress { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        /// <returns></returns>
        public string PlaceStatus { get; set; }
        /// <summary>
        /// 校区
        /// </summary>
        /// <returns></returns>
        public string CampusName { get; set; }
        /// <summary>
        /// 容量
        /// </summary>
        /// <returns></returns>
        public int? Capacity { get; set; }
        /// <summary>
        /// 楼名
        /// </summary>
        /// <returns></returns>
        public string BuildingName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        /// <returns></returns>
        public string PlaceType { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.PlaceId = 0;// Guid.NewGuid().ToString();//根据实际需要去修改
                                    
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.PlaceId = keyValue;
                                    
        }
        #endregion
    }
}