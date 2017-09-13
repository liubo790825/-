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
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-09-08 15:44
    /// �� ����WF_ProcessNodes
    /// </summary>
    public class WF_ProcessNodesService : RepositoryFactory<WF_ProcessNodesEntity>, WF_ProcessNodesIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<WF_ProcessNodesEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<WF_ProcessNodesEntity>();
             //�ο�����
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
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public List<WF_ProcessNodesEntity> GetList(string queryJson)
        {
            var expression = LinqExtensions.True<WF_ProcessNodesEntity>();
            //�ο�����
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
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public WF_ProcessNodesEntity GetEntity(string keyValue)
        {
            return this.BaseRepository().FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            this.BaseRepository().Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
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
