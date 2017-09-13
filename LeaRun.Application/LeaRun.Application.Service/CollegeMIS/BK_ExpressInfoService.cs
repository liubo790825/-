using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-17 14:05
    /// �� ����֪ͨ������Ϣ
    /// </summary>
    public class BK_ExpressInfoService : RepositoryFactory<BK_ExpressInfoEntity>, BK_ExpressInfoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_ExpressInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_ExpressInfoEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["ExpressCompany"].IsEmpty()){
                 string ExpressCompany = queryParam["ExpressCompany"].ToString();
                 expression = expression.And(t => t.ExpressCompany.Contains(ExpressCompany));
             }
            if (!queryParam["ExpressNo"].IsEmpty())
            {
                string ExpressNo = queryParam["ExpressNo"].ToString();
                expression = expression.And(t => t.ExpressNo.Equals(ExpressNo));
            }
            if (!queryParam["Stuno"].IsEmpty())
            {
                string Stuno = queryParam["Stuno"].ToString();
                expression = expression.And(t => t.Stuno.Equals(Stuno));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Equals(NoticeNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["BeginTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                DateTime BeginTime = queryParam["BeginTime"].ToDate();
                DateTime EndTime = queryParam["EndTime"].ToDate();
                expression = expression.And(t => t.SendTime>= BeginTime && t.SendTime<=EndTime);
            }

            //������ֶ�2���ֶ�3Ҳ����д...
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_ExpressInfoEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_ExpressInfoEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_ExpressInfoEntity>();
            //�ο�����
            var queryParam = keyValue.ToJObject();
            if (!queryParam["ID"].IsEmpty())
            {
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Equals(ID));
            }

            if (!queryParam["ExpressCompany"].IsEmpty())
            {
                string ExpressCompany = queryParam["ExpressCompany"].ToString();
                expression = expression.And(t => t.ExpressCompany.Contains(ExpressCompany));
            }
            if (!queryParam["ExpressNo"].IsEmpty())
            {
                string ExpressNo = queryParam["ExpressNo"].ToString();
                expression = expression.And(t => t.ExpressNo.Equals(ExpressNo));
            }
            if (!queryParam["Stuno"].IsEmpty())
            {
                string Stuno = queryParam["Stuno"].ToString();
                expression = expression.And(t => t.Stuno.Equals(Stuno));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Equals(NoticeNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            return this.BaseRepository(conn).FindEntity(expression);
            //return this.BaseRepository(conn).FindEntity(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_ExpressInfoEntity entity)
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
