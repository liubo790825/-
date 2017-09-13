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
    /// �� �ڣ�2017-07-28 09:28
    /// �� ����ѧ����ס��λ��¼
    /// </summary>
    public class BK_StuBedDwellService : RepositoryFactory<BK_StuBedDwellEntity>, BK_StuBedDwellIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuBedDwellEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuBedDwellEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuId"].IsEmpty()){
                 string StuId = queryParam["StuId"].ToString();
                 expression = expression.And(t => t.StuId.Equals(StuId));
             }
            if (!queryParam["BedId"].IsEmpty())
            {
                string BedId = queryParam["BedId"].ToString();
                expression = expression.And(t => t.BedId.Equals(BedId));
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
        public IEnumerable<BK_StuBedDwellEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuBedDwellEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity(keyValue);
        }

        /// <summary>
        /// ����������ȡʵ��
        /// </summary>
        /// <param name="queryJson">��ѯ������</param>
        /// <returns></returns>
        public BK_StuBedDwellEntity GetEntityByWhere(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuBedDwellEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            if (!queryParam["BedId"].IsEmpty())
            {
                string BedId = queryParam["BedId"].ToString();
                expression = expression.And(t => t.BedId.Equals(BedId));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            //expression = expression.And(t => t.ID > 0);
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
        public void SaveForm(string conn, string keyValue, BK_StuBedDwellEntity entity)
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
