using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-09 15:29
    /// �� ����BK_AdvisoryAnswer
    /// </summary>
    public class BK_AdvisoryAnswerService : RepositoryFactory<BK_AdvisoryAnswerEntity>, BK_AdvisoryAnswerIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_AdvisoryAnswerEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_AdvisoryAnswerEntity>();
             //�ο�����
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }*/
             //������ֶ�2���ֶ�3Ҳ����д...
             //expression = expression.And(t => t.AId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_AdvisoryAnswerEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_AdvisoryAnswerEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }


        /// <summary>
        /// ��ʦѧ���˻�ȡ�ظ��б�2017-8-10������
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">ѧ��ID��</param>
        /// <returns></returns>
        public IEnumerable<BK_AdvisoryAnswerEntity> GetMyAnswer(string conn, Pagination pagination, string queryJson)
        {
            string stuInfoId = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                stuInfoId = queryParam["stuInfoId"].ToString();
            }

            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select * ");
            strsql.Append(@"  from BK_AdvisoryAnswer");
            strsql.Append(@"  where 1=1");
            

            strsql.Append(string.Format(" and stuInfoId='{0}'", stuInfoId));
            return this.BaseRepository(conn).FindList(strsql.ToString(), pagination).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_AdvisoryAnswerEntity entity)
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
