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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-18 15:12
    /// 描 述：撤消申请记录
    /// </summary>
    public class BK_CancelAppService : RepositoryFactory, BK_CancelAppIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_CancelAppEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_CancelAppEntity>();
             //参考代码
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }*/
             //如果有字段2，字段3也这样写...
             //expression = expression.And(t => t.ID > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_CancelAppEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_CancelAppEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_CancelAppEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_CancelAppEntity>(keyValue);
        }


        /// <summary>
        /// 学生端查询操行违规撤销申请记录
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
            strsql.Append(@"  and a.CheckState='申请撤消'");
            strsql.Append(@"  and a.RoleName='学生'");
            strsql.Append(@"  and a.Checker=b.StuName");
            strsql.Append(@"  and b.IsCanceled='1'");
            strsql.Append(@"  and a.AppId != (Select AppId From BK_CancelApp where BK_CancelApp.RoleName='学生会')");
            return this.BaseRepository(conn).FindList<M_BK_CancelAppEntity>(strsql.ToString()).ToList();
        }


        /// <summary>
        /// 教师端查询操行违规撤销申请记录
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
            strsql.Append(@"  and a.CheckState='学生会同意撤消'");
            strsql.Append(@"  and a.RoleName='学生会'");
            strsql.Append(@"  and b.IsCanceled='1'");
            return this.BaseRepository(conn).FindList<M_BK_CancelAppEntity>(strsql.ToString()).ToList();
        }


        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BehaviorRecode");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and IsCanceled='1' and BK_BehaviorRecode.ID != (Select BK_CancelApp.AppId From BK_CancelApp where BK_CancelApp.RoleName='学生会')");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }

        //记录数量
        public List<M_BK_NumberEntity> TeaNumber(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_BehaviorRecode");
            strsql.Append(@"  left join BK_CancelApp on BK_CancelApp.AppId=BK_BehaviorRecode.ID");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and IsCanceled='1' and BK_CancelApp.RoleName='学生会' and BK_BehaviorRecode.ID != (Select BK_CancelApp.AppId From BK_CancelApp where BK_CancelApp.RoleName='教师')");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm2(string conn, string keyValue, BK_CancelAppEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                var mentity= db.FindEntity<BK_BehaviorRecodeEntity>(t => t.ID.Equals(entity.AppId));
                if (entity.CheckState == "学生会不同意撤消")
                {
                    mentity.IsCanceled = 0;
                }
                else if (entity.CheckState == "申请撤消")
                {
                    mentity.IsCanceled = 1;
                    mentity.AppCancel = mentity.AppCancel == null ? 1 : mentity.AppCancel.Value + 1;
                }
                if (entity.CheckState == "老师同意撤消")
                {
                    mentity.IsCanceled = 2;
                }
                else if (entity.CheckState == "老师不同意撤消")
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
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
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
