using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;

namespace LeaRun.Application.IService.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public interface BK_ClassInfoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<BK_ClassInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        List<BK_ClassInfoEntity> GetList(string conn, string queryJson);
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        List<BK_StuInfoEntity> GetDetails_old(string conn, string keyValue);
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BK_ClassInfoEntity GetEntity(string conn, string keyValue);

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        IEnumerable<BK_StuInfoEntity> GetDetails(string conn, string keyValue);
        /// <summary>
        ///  以List的方式获取子表详细信息
        /// </summary>
        /// <param name="keyValue">班级号</param>
        /// <returns></returns>
        List<BK_StuInfoEntity> GetListDetails(string conn, string keyValue);
        #endregion

        #region 提交数据

        /// <summary>
        /// 添加学生到班级
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="classid">班级ID号</param>
        /// <param name="stuinfoid">学生ID号</param>
        /// <returns></returns>
        int InsertStuCls(string conn, string classid, List<BK_StuInfoEntity> entryList);

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
        void SaveForm(string conn, string keyValue, BK_ClassInfoEntity entity,List<BK_StuClassEntity> entryList);
        #endregion
    }
}
