using LeaRun.Application.Entity.FlowManage;
using LeaRun.Application.IService.FlowManage;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;

namespace LeaRun.Application.Service.FlowManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-09-08 15:44
    /// 描 述：WF_ProcessNodes
    /// </summary>
    public class WF_ProcessNodesService : RepositoryFactory<WF_ProcessNodesEntity>, WF_ProcessNodesIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<WF_ProcessNodesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<WF_ProcessNodesEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["F_ProcessId"].IsEmpty()){
                 string F_ProcessId = queryParam["F_ProcessId"].ToString();
                 expression = expression.And(t => t.F_ProcessId.Equals(F_ProcessId));
             }
            if (!queryParam["F_PreviousId"].IsEmpty())
            {
                string F_PreviousId = queryParam["F_PreviousId"].ToString();
                expression = expression.And(t => t.F_PreviousId.Equals(F_PreviousId));
            }
            if (!queryParam["F_NodeName"].IsEmpty())
            {
                string F_NodeName = queryParam["F_NodeName"].ToString();
                expression = expression.And(t => t.F_NodeName.Contains(F_NodeName));
            }
            if (!queryParam["F_NodeType"].IsEmpty())
            {
                string F_NodeType = queryParam["F_NodeType"].ToString();
                expression = expression.And(t => t.F_NodeType.Equals(F_NodeType));
            }
            if (!queryParam["F_UserList"].IsEmpty())
            {
                string F_UserList = queryParam["F_UserList"].ToString();
                expression = expression.And(t => t.F_UserList.Contains(F_UserList));
            }


            return this.BaseRepository().FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<WF_ProcessNodesEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<WF_ProcessNodesEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["F_ProcessId"].IsEmpty())
            {
                string F_ProcessId = queryParam["F_ProcessId"].ToString();
                expression = expression.And(t => t.F_ProcessId.Equals(F_ProcessId));
            }
            if (!queryParam["F_NodeId"].IsEmpty())
            {
                string F_NodeId = queryParam["F_NodeId"].ToString();
                expression = expression.And(t => t.F_NodeId.Equals(F_NodeId));
            }

            if (!queryParam["F_PreviousId"].IsEmpty())
            {
                string F_PreviousId = queryParam["F_PreviousId"].ToString();
                expression = expression.And(t => t.F_PreviousId.Equals(F_PreviousId));
            }
            if (!queryParam["F_NodeName"].IsEmpty())
            {
                string F_NodeName = queryParam["F_NodeName"].ToString();
                expression = expression.And(t => t.F_NodeName.Contains(F_NodeName));
            }
            if (!queryParam["F_NodeType"].IsEmpty())
            {
                string F_NodeType = queryParam["F_NodeType"].ToString();
                expression = expression.And(t => t.F_NodeType.Equals(F_NodeType));
            }
            if (!queryParam["F_UserList"].IsEmpty())
            {
                string F_UserList = queryParam["F_UserList"].ToString();
                expression = expression.And(t => t.F_UserList.Contains(F_UserList));
            }
            return this.BaseRepository().FindList(expression).ToList();//.FindList(expression).ToList();//.IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public WF_ProcessNodesEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm( string keyValue, WF_ProcessNodesEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository().Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository().Insert(entity);
            }
        }
        #endregion
    }
}
