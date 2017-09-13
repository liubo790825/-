using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Data;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public interface BK_DormIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<BK_DormEntity> GetPageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BK_DormEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        IEnumerable<BK_DormEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        IEnumerable<BK_DormBedEntity> GetDetails(string conn, string keyValue);

        /// <summary>
        /// 查询宿舍
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        List<BK_DormEntity> GetDormName(string conn, string queryJson);

        /// <summary>
        /// 查询宿舍床位
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        List<M_BK_DormEntity> GetDormBed(string conn, string queryJson);

        /// <summary>
        /// 查询宿舍交换床位信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        List<M_BK_DormEntity> GetExchangeDormBed(string conn, string keyValue, string queryJson);

        //教师端查询宿舍
        List<BK_DormEntity> GetDormId(string conn);
        //教师端查看床位信息
        List<M_BK_DormStuInfoEntity> TeaGetDormBed(string conn, string queryJson);

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
        void SaveForm(string conn, string keyValue, BK_DormEntity entity,List<BK_DormBedEntity> entryList);
        #endregion
    }
}
