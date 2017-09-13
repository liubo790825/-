using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-19 09:54
    /// �� ����У��
    /// </summary>
    public class BK_SchoolAreaService : RepositoryFactory, BK_SchoolAreaIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_SchoolAreaEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_SchoolAreaEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["AreaName"].IsEmpty()){
                 string AreaName = queryParam["AreaName"].ToString();
                 expression = expression.And(t => t.AreaName.Contains(AreaName));
             }
             //������ֶ�2���ֶ�3Ҳ����д...
             //expression = expression.And(t => t.AreaId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_SchoolAreaEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_SchoolAreaEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["areaId"].IsEmpty())//ת��������
            {
                string AreaId = queryParam["areaId"].ToString();
                expression = expression.And(t => t.AreaId.Equals(AreaId));
            }
            if (!queryParam["AreaName"].IsEmpty())
            {
                string AreaName = queryParam["AreaName"].ToString();
                expression = expression.And(t => t.AreaName.Contains(AreaName));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            //expression = expression.And(t => t.AreaId > 0);
            return this.BaseRepository(conn).FindList(expression);
        }



        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_SchoolAreaEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_SchoolAreaEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_DeptEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DeptEntity>("select * from BK_Dept where AreaId='" + keyValue + "'");
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<BK_SchoolAreaEntity>(keyValue);
                db.Delete<BK_DeptEntity>(t => t.AreaId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_SchoolAreaEntity entity, List<BK_DeptEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.DeptId))
                            {
                                item.Modify(item.DeptId);
                                item.AreaId = entity.AreaId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.AreaId = entity.AreaId;
                                db.Insert(item);
                            }
                        }
                    }
                    //��ϸ
                    //db.Delete<BK_DeptEntity>(t => t.AreaId.Equals(keyValue));
                }
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);
                    //��ϸ
                    foreach (BK_DeptEntity item in entryList)
                    {
                        item.Create();
                        item.AreaId = entity.AreaId;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}
