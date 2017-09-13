using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:39
    /// �� �������ᵥԪ��Ϣ
    /// </summary>
    public class BK_DormUnitService : RepositoryFactory, BK_DormUnitIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_DormUnitEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DormUnitEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["dormUnitId"].IsEmpty())//ת��������
             {
                 string DormUnitId = queryParam["dormUnitId"].ToString();
                 expression = expression.And(t => t.DormUnitId.Equals(DormUnitId));
             }
             if (!queryParam["dormUnitNo"].IsEmpty())//ת��������
             {
                 string DormUnitNo = queryParam["dormUnitNo"].ToString();
                 expression = expression.And(t => t.DormUnitNo.Equals(DormUnitNo));
             }

             if (!queryParam["DormUnitManager"].IsEmpty()){
                 string DormUnitManager = queryParam["DormUnitManager"].ToString();
                 expression = expression.And(t => t.DormUnitManager.Contains(DormUnitManager));              
             }
            if (!queryParam["DormUnitName"].IsEmpty())
            {
                string DormUnitName = queryParam["DormUnitName"].ToString();
                expression = expression.And(t => t.DormUnitName.Contains(DormUnitName));               
            }
            if (!queryParam["DormUnitNo"].IsEmpty())
            {
                string DormUnitNo = queryParam["DormUnitNo"].ToString();
                expression = expression.And(t => t.DormUnitNo.Contains(DormUnitNo));
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_DormUnitEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormUnitEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_DormFloorsEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DormFloorsEntity>("select * from BK_DormFloors where DormUnitId='" + keyValue + "' order by DormFloorsName");
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
                db.Delete<BK_DormUnitEntity>(keyValue);
                db.Delete<BK_DormFloorsEntity>(t => t.DormUnitId.Equals(keyValue));
                db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ������
                db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ����λ


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
        public void SaveForm(string conn, string keyValue, BK_DormUnitEntity entity,List<BK_DormFloorsEntity> entryList)
        {
          IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
              if (!string.IsNullOrEmpty(keyValue))
              {
                  //����
                  entity.Modify(keyValue);
                  db.Update(entity);
                    //��ϸ
                    if (entryList != null && entryList.Count > 0)
                    {

                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.DormFloorsId))
                            {
                                item.Modify(item.DormFloorsId);
                                item.DormUnitId = entity.DormUnitId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DormUnitId = entity.DormUnitId;
                                db.Insert(item);
                            }
                        }
                    }
              }
              else
              {
                  //����
                  entity.Create();
                  db.Insert(entity);
                  //��ϸ
                  foreach (BK_DormFloorsEntity item in entryList)
                  {
                      item.Create();
                      item.DormUnitId = entity.DormUnitId;
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
