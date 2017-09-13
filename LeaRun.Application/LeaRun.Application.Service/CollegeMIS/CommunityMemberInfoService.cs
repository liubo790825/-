using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:39
    /// �� ������Ա��Ϣ��
    /// </summary>
    public class CommunityMemberInfoService : RepositoryFactory<CommunityMemberInfoEntity>, CommunityMemberInfoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<CommunityMemberInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<CommunityMemberInfoEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CMI_StuNo"].IsEmpty())
            {
                string CMI_StuNo = queryParam["CMI_StuNo"].ToString();
                expression = expression.And(t => t.CMI_StuNo.Contains(CMI_StuNo));
            }
            expression = expression.And(t => !string.IsNullOrEmpty(t.CMI_Id));
            /*var queryParam = queryJson.ToJObject();
            if (!queryParam["�ֶ�1"].IsEmpty()){
                string FullHead = queryParam["�ֶ�1"].ToString();
                expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => t.CMI_Id > 0);*/
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<CommunityMemberInfoEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public CommunityMemberInfoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }

        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public CommunityMemberInfoEntity GetSingleEntity(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<CommunityMemberInfoEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["CMI_StuNo"].IsEmpty()){
                string CMI_StuNo = queryParam["CMI_StuNo"].ToString();
                expression = expression.And(t => t.CMI_StuNo.Contains(CMI_StuNo));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => !string.IsNullOrEmpty(t.CMI_Id));
            return this.BaseRepository(conn).FindEntity(expression);
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
        public void SaveForm(string conn, string keyValue, CommunityMemberInfoEntity entity)
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
