using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-14 09:17
    /// 描 述：学生请假表
    /// </summary>
    public class BK_StuLeaveBLL
    {
        private BK_StuLeaveIService service = new BK_StuLeaveService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region 构造方法指定要连的数据库
        public BK_StuLeaveBLL()
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
        public IEnumerable<BK_StuLeaveEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuLeaveEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuLeaveEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }

        //获取请假信息
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveInfo(Pagination pagination, string queryJson)
        {
            return service.GetStuLeaveInfo(conEntity.DbConnection, pagination, queryJson);
        }
        //获取单条请假记录详细信息
        public IEnumerable<BK_StuLeaveEntity> GetStuLeaveResultInfo( string queryJson)
        {
            return service.GetStuLeaveResultInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 获取请假学生列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public List<BK_StuLeaveEntity> GetStuLeaveList(Pagination pagination)
        {
            return service.GetStuLeaveList(conEntity.DbConnection, pagination);
        }


        /// <summary>
        /// 获取未审核学生请假列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public List<BK_StuLeaveEntity> GetNotReviewStuLeaveList(Pagination pagination, string queryJson)
        {
            return service.GetNotReviewStuLeaveList(conEntity.DbConnection, pagination, queryJson);
        }
        /// <summary>
        /// 获取已审核学生请假列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public List<BK_StuLeaveEntity> GetReviewStuLeaveList(Pagination pagination, string queryJson)
        {
            return service.GetReviewStuLeaveList(conEntity.DbConnection, pagination, queryJson);
        }
        /// <summary>
        /// 查询请假学生班级专业等信息
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public List<M_BK_NumberEntity> GetStuLeaveMajorClassInfo(string queryJson)
        {
            return service.GetStuLeaveMajorClassInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 记录数量
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<M_BK_NumberEntity> Number()
        {
            return service.Number(conEntity.DbConnection);
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
        public void SaveForm(string keyValue, BK_StuLeaveEntity entity)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
