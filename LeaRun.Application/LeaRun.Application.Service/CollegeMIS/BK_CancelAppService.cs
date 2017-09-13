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
    /// �� �ڣ�2017-08-18 15:12
    /// �� �������������¼
    /// </summary>
    public class BK_CancelAppService : RepositoryFactory, BK_CancelAppIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_CancelAppEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_CancelAppEntity>();
             //�ο�����
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }*/
             //������ֶ�2���ֶ�3Ҳ����д...
             //expression = expression.And(t => t.ID > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_CancelAppEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_CancelAppEntity>().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_CancelAppEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_CancelAppEntity>(keyValue);
        }


        /// <summary>
        /// ѧ���˲�ѯ����Υ�泷�������¼
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_CancelAppEntity> StuGetCancelAppList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select a.AppId,a.Checker,a.CheckState,a.CheckerTime,a.Remark,b.StuNo,b.StuName,b.BreachBehavior,b.BreachTime,b.Submiter,b.IsCanceled,b.AppCancel,b.CanCancel,b.CreateDate,d.DeptName,e.MajorName,f.ClassName");
            strsql.Append(@"  from BK_CancelApp a");
            strsql.Append(@"  left join BK_BehaviorRecode b on a.AppId=b.ID");
            strsql.Append(@"  left join BK_StuInfo c on b.StuNo=c.StuNo");
            strsql.Append(@"  left join BK_Dept d on d.DeptNo=c.DeptNo");
            strsql.Append(@"  left join BK_Major e on e.MajorNo=c.MajorNo");
            strsql.Append(@"  left join BK_ClassInfo f on f.ClassNo=c.ClassNo where 1=1");
            strsql.Append(@"  and a.CheckState='���볷��'");
            strsql.Append(@"  and a.RoleName='ѧ��'");
            strsql.Append(@"  and a.Checker=b.StuName");
            strsql.Append(@"  and b.IsCanceled='1'");
            strsql.Append(@"  and a.AppId != (Select AppId From BK_CancelApp where BK_CancelApp.RoleName='ѧ����')");
            return this.BaseRepository(conn).FindList<M_BK_CancelAppEntity>(strsql.ToString()).ToList();
        }


        /// <summary>
        /// ��ʦ�˲�ѯ����Υ�泷�������¼
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_CancelAppEntity> TeaGetCancelAppList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select a.AppId,a.Checker,a.CheckState,a.CheckerTime,a.Remark,b.StuNo,b.StuName,b.BreachBehavior,b.BreachTime,b.Submiter,b.IsCanceled,b.AppCancel,b.CanCancel,b.CreateDate,d.DeptName,e.MajorName,f.ClassName");
            strsql.Append(@"  from BK_CancelApp a");
            strsql.Append(@"  left join BK_BehaviorRecode b on a.AppId=b.ID");
            strsql.Append(@"  left join BK_StuInfo c on b.StuNo=c.StuNo");
            strsql.Append(@"  left join BK_Dept d on d.DeptNo=c.DeptNo");
            strsql.Append(@"  left join BK_Major e on e.MajorNo=c.MajorNo");
            strsql.Append(@"  left join BK_ClassInfo f on f.ClassNo=c.ClassNo where 1=1");
            strsql.Append(@"  and a.CheckState='ѧ����ͬ�⳷��'");
            strsql.Append(@"  and a.RoleName='ѧ����'");
            strsql.Append(@"  and b.IsCanceled='1'");
            return this.BaseRepository(conn).FindList<M_BK_CancelAppEntity>(strsql.ToString()).ToList();
        }


        //��¼����
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BehaviorRecode");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and IsCanceled='1' and BK_BehaviorRecode.ID != (Select BK_CancelApp.AppId From BK_CancelApp where BK_CancelApp.RoleName='ѧ����')");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }

        //��¼����
        public List<M_BK_NumberEntity> TeaNumber(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BehaviorRecode");
            strsql.Append(@"  left join BK_CancelApp on BK_CancelApp.AppId=BK_BehaviorRecode.ID");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and IsCanceled='1' and BK_CancelApp.RoleName='ѧ����' and BK_BehaviorRecode.ID != (Select BK_CancelApp.AppId From BK_CancelApp where BK_CancelApp.RoleName='��ʦ')");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
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
        public void SaveForm2(string conn, string keyValue, BK_CancelAppEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                var mentity= db.FindEntity<BK_BehaviorRecodeEntity>(t => t.ID.Equals(entity.AppId));
                if (entity.CheckState == "ѧ���᲻ͬ�⳷��")
                {
                    mentity.IsCanceled = 0;
                }
                else if (entity.CheckState == "���볷��")
                {
                    mentity.IsCanceled = 1;
                    mentity.AppCancel = mentity.AppCancel == null ? 1 : mentity.AppCancel.Value + 1;
                }
                if (entity.CheckState == "��ʦͬ�⳷��")
                {
                    mentity.IsCanceled = 2;
                }
                else if (entity.CheckState == "��ʦ��ͬ�⳷��")
                {
                    mentity.IsCanceled = 0;
                }else
                {
                    mentity.IsCanceled = 1;
                }
               
                db.Update<BK_BehaviorRecodeEntity>(mentity);

                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update<BK_CancelAppEntity>(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert<BK_CancelAppEntity>(entity);
                }

                db.Commit();
            }
            catch (System.Exception)
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
        public void SaveForm(string conn, string keyValue, BK_CancelAppEntity entity)
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
