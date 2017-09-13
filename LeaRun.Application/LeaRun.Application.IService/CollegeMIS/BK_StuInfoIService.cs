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
    /// 日 期：2017-06-06 09:47
    /// 描 述：新生数据导入      报到确认后的学生数据导入到此表中      同时分班（分配班号） 、学号
    /// </summary>
    public interface BK_StuInfoIService
    {
        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        DataTable GetTablePageList(string conn, Pagination pagination, string queryJson);
        /// <summary>
        /// 根据日期来统计新生报到的数据
        /// 刘波 2017年8月4日17:21:12
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <param name="pagination">页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        DataTable GetNewStuCountPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// 学生端手机登录(by allen)
        /// </summary>
        /// <param name="username">身份证号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        BK_StuInfoEntity StuLogin(string conn, string username, string pass);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        IEnumerable<BK_StuInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        List<BK_StuInfoEntity> GetList(string conn,  string queryJson);


        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        BK_StuInfoEntity GetEntity(string conn, string keyValue);
        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="queryJson">主键值</param>
        /// <returns></returns>
        BK_StuInfoEntity GetEntityByWhere(string conn, string queryJson);
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        IEnumerable<BK_StuSocRelaEntity> GetDetails(string conn, string keyValue);



        /// <summary>
        /// 查询我的室友
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        List<M_BK_DormStuInfoEntity> GetMyDormers(string conn, string queryJson);


        /// <summary>
        /// 查询我的同学
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        IEnumerable<BK_StuInfoEntity> GetMyClassmatesList(string conn, Pagination pagination, string queryJson);


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
        void SaveForm(string conn, string keyValue, BK_StuInfoEntity entity,List<BK_StuSocRelaEntity> entryList);
        #endregion
    }
}
