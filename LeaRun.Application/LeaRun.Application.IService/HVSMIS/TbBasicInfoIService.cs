using LeaRun.Application.Entity.HVSMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.HVSMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2016-12-08 11:06
    /// 描 述：教材基本信息（教材编号、教材名称、教材作者、版别、出版社、单价、优秀获奖教材、高职高专、教材ISBN、备注、类别、出版（印刷）时间、库存数量、书架号、初始量(针对印刷材料)）
    /// </summary>
    public interface TbBasicInfoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<TbBasicInfoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        TbBasicInfoEntity GetEntity(string conn, int keyValue);
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        void RemoveForm(string conn, string keyValue);
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        void SaveForm(string conn, string keyValue, TbBasicInfoEntity entity);
        #endregion
    }
}
