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
    /// �� �ڣ�2017-08-07 15:06
    /// �� �����ۺ��������ݱ�
    /// </summary>
    public class BK_OverallQualityService : RepositoryFactory<BK_OverallQualityEntity>, BK_OverallQualityIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_OverallQualityEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_OverallQualityEntity>().And(t=>t.DeleteMark==0);
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["AcademicTypeId"].IsEmpty()){
                 string AcademicTypeId = queryParam["AcademicTypeId"].ToString();
                 expression = expression.And(t => t.AcademicTypeId.Equals(AcademicTypeId));
             }
            if (!queryParam["UnitName"].IsEmpty())
            {
                string UnitName = queryParam["UnitName"].ToString();
                expression = expression.And(t => t.UnitName.Contains(UnitName));
            }
            if (!queryParam["AcademicTypeName"].IsEmpty())
            {
                string AcademicTypeName = queryParam["AcademicTypeName"].ToString();
                expression = expression.And(t => t.AcademicTypeName.Contains(AcademicTypeName));
            }
            if (!queryParam["Title"].IsEmpty())
            {
                string Title = queryParam["Title"].ToString();
                expression = expression.And(t => t.Title.Contains(Title));
            }
            if (!queryParam["Speaker"].IsEmpty())
            {
                string Speaker = queryParam["Speaker"].ToString();
                expression = expression.And(t => t.Speaker.Contains(Speaker));
            }
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_OverallQualityEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_OverallQualityEntity GetEntity(string conn, string keyValue)
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
        public void SaveForm(string conn, string keyValue, BK_OverallQualityEntity entity)
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
