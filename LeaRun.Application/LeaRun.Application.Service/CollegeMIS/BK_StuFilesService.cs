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
    /// �� �ڣ�2017-08-17 17:53
    /// �� ����ѧ����������
    /// </summary>
    public class BK_StuFilesService : RepositoryFactory<BK_StuFilesEntity>, BK_StuFilesIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuFilesEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuFilesEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuId"].IsEmpty()){
                 string StuId = queryParam["StuId"].ToString();
                 expression = expression.And(t => t.StuId.Equals(StuId));
             }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Equals(StuNo));
            }
            if (!queryParam["TakeTime"].IsEmpty())
            {
                DateTime TakeTime = queryParam["TakeTime"].ToDate();
                expression = expression.And(t => t.TakeTime==TakeTime);
            }
            if (!queryParam["Taker"].IsEmpty())
            {
                string Taker = queryParam["Taker"].ToString();
                expression = expression.And(t => t.Taker.Contains(Taker));
            }
            if (!queryParam["SaveAddress"].IsEmpty())
            {
                string SaveAddress = queryParam["SaveAddress"].ToString();
                expression = expression.And(t => t.SaveAddress.Contains(SaveAddress));
            }
            if (!queryParam["SaveState"].IsEmpty())
            {
                int SaveState = queryParam["SaveState"].ToInt();
                expression = expression.And(t => t.SaveState == SaveState);
            }
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        expression = expression.And(t => t.NoticeNo.Equals(keyord));
                        break;
                    case "StuNo":          //���֤��
                        expression = expression.And(t => t.StuNo.Equals(keyord));
                        break;
                    case "StuName":          //����
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    case "Taker":          //�ᵵ��
                        expression = expression.And(t => t.Taker.Contains(keyord));
                        break;
                    case "StuId":
                       expression = expression.And(t => t.StuId.Equals(keyord));
                        break;
                    case "SaveState":
                        int SaveState = keyord.ToInt();
                        expression = expression.And(t => t.SaveState == SaveState);
                        break;
                    default:
                        break;
                }
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_StuFilesEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuFilesEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_StuFilesEntity>();
            //�ο�����
            var queryParam = keyValue.ToJObject();
            if (!queryParam["ID"].IsEmpty())
            {
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Equals(ID));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Equals(StuNo));
            }
            if (!queryParam["TakeTime"].IsEmpty())
            {
                DateTime TakeTime = queryParam["TakeTime"].ToDate();
                expression = expression.And(t => t.TakeTime == TakeTime);
            }
            if (!queryParam["Taker"].IsEmpty())
            {
                string Taker = queryParam["Taker"].ToString();
                expression = expression.And(t => t.Taker.Contains(Taker));
            }
            if (!queryParam["SaveAddress"].IsEmpty())
            {
                string SaveAddress = queryParam["SaveAddress"].ToString();
                expression = expression.And(t => t.SaveAddress.Contains(SaveAddress));
            }
            if (!queryParam["SaveState"].IsEmpty())
            {
                int SaveState = queryParam["SaveState"].ToInt();
                expression = expression.And(t => t.SaveState == SaveState);
            }
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        expression = expression.And(t => t.NoticeNo.Equals(keyord));
                        break;
                    case "StuNo":          //���֤��
                        expression = expression.And(t => t.StuNo.Equals(keyord));
                        break;
                    case "StuName":          //����
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    default:
                        break;
                }
            }

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
        public void SaveForm(string conn, string keyValue, BK_StuFilesEntity entity)
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
