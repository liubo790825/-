using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 12:29
    /// 描 述：换床申请
    /// </summary>
    public interface BK_AppChangeBedIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<BK_AppChangeBedEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BK_AppChangeBedEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BK_AppChangeBedEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// 查询宿舍交换记录信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BK_AppChangeBedEntity> SelectAppChangeBed(string conn, string queryJson);
        /// <summary>
        /// 查询我的宿舍交换记录信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<M_BK_AppChangeBedEntity> DormExchangeGetMyInfo(string conn, string queryJson);

        /// <summary>
        /// 对我的交换申请
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<M_BK_AppChangeBedEntity> GetMyExchangeList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// 教师端获取交换申请
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<M_BK_AppChangeBedEntity> TeaGetDormExchangeList(string conn, Pagination pagination);

        /// <summary>
        /// 教师端获取宿舍交换申请记录数
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        IEnumerable<M_BK_NumberEntity> TeaNumber(string conn);
        /// <summary>
        /// 宿舍交换双方学生信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<M_BK_AppChangeBedEntity> DormExchangeStuInfo(string conn, string queryJson);
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
        void SaveForm(string conn, string keyValue, BK_AppChangeBedEntity entity);
        #endregion
    }
}
