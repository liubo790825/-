using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Application.Code;
using LeaRun.Util;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-07-19 16:33
    /// �� ��������������Ȩ��
    /// </summary>
    public class BK_AuthorizeNewStuRegFlowService : RepositoryFactory<BK_AuthorizeNewStuRegFlowEntity>, BK_AuthorizeNewStuRegFlowIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_AuthorizeNewStuRegFlowEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
           

            var expression = LinqExtensions.True<BK_AuthorizeNewStuRegFlowEntity>();
            //�ο�����
            /*var queryParam = queryJson.ToJObject();
            if (!queryParam["�ֶ�1"].IsEmpty()){
                string FullHead = queryParam["�ֶ�1"].ToString();
                expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
            }*/
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => t.EnabledMark==1);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_AuthorizeNewStuRegFlowEntity> GetList(string conn, string queryJson)
        {
            string username = OperatorProvider.Provider.Current().UserName;//�õ���ǰ�û�������
            string userid = OperatorProvider.Provider.Current().UserId;//�õ���ǰ�û���ID��
            var expression = LinqExtensions.True<BK_AuthorizeNewStuRegFlowEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["FlowId"].IsEmpty()){
                string FlowId = queryParam["FlowId"].ToString();
                expression = expression.And(t => t.FlowId.Contains(FlowId));
            }
            if (userid != "System")
            {
                expression = expression.And(t => t.UserId == userid);
            }
            expression = expression.And(t => t.EnabledMark == 1);
            return this.BaseRepository(conn).FindList(expression).ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_AuthorizeNewStuRegFlowEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_AuthorizeNewStuRegFlowEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
