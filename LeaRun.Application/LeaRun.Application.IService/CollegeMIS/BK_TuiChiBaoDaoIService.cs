using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-03 09:59
    /// 描 述：BK_TuiChiBaoDao
    /// </summary>
    public interface BK_TuiChiBaoDaoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<BK_TuiChiBaoDaoEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        IEnumerable<BK_TuiChiBaoDaoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BK_TuiChiBaoDaoEntity GetEntity(string conn, string keyValue);


        /// <summary>
        /// 查询推迟报到学生班级信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        //List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn);
        List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn);

        /// <summary>
        /// 查询推迟报到学生信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        List<M_BK_TuiChiBaoDaoEntity> GetTuiChiInfo(string conn, string queryJson);


        /// <summary>
        /// 记录数量
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        List<M_BK_NumberEntity> Number(string conn);


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
        void SaveForm(string conn, string keyValue, BK_TuiChiBaoDaoEntity entity);
        #endregion
    }
}
