using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-06 09:47
    /// 描 述：新生数据导入      报到确认后的学生数据导入到此表中      同时分班（分配班号） 、学号
    /// </summary>
    public class BK_StuInfoBLL
    {
        private BK_StuInfoIService service = new BK_StuInfoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region 构造方法指定要连的数据库
        public BK_StuInfoBLL()
        {
            SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
            conEntity = databaseLinkBLL.GetEntity("9914ca66-d5ae-4a26-9353-76bddea33179");
        }
        #endregion
        #region 获取数据

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public DataTable GetTablePageList(Pagination pagination, string queryJson)
        {
            return service.GetTablePageList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// 根据日期来统计新生报到的数据
        /// 刘波 2017年8月4日17:21:12
        /// </summary>
        /// <param name="conn">连接字符串</param>
        /// <param name="pagination">页参数</param>
        /// <param name="queryJson">查询条件</param>
        /// <returns></returns>
        public DataTable GetNewStuCountPageList(Pagination pagination, string queryJson)
        {
            return service.GetNewStuCountPageList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// 学生端手机登录(by allen)
        /// </summary>
        /// <param name="username">身份证号</param>
        /// <param name="pass">密码</param>
        /// <returns></returns>
        public BK_StuInfoEntity StuLogin(string username, string pass)
        {
            return service.StuLogin(conEntity.DbConnection, username, pass);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="queryJson">主键值</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntityByWhere( string queryJson)
        {
            return service.GetEntityByWhere(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public List<BK_StuInfoEntity> GetList( string queryJson)
        {
            return service.GetList(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_StuSocRelaEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }


        /// 查询我的室友
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public List<M_BK_DormStuInfoEntity> GetMyDormers(string queryJson)
        {
            return service.GetMyDormers(conEntity.DbConnection, queryJson);
        }


        /// 查询我的同班同学
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public IEnumerable<BK_StuInfoEntity> GetMyClassmatesList(Pagination pagination, string queryJson)
        {
            return service.GetMyClassmatesList(conEntity.DbConnection, pagination, queryJson);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(conEntity.DbConnection,keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BK_StuInfoEntity entity,List<BK_StuSocRelaEntity> entryList)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity, entryList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
