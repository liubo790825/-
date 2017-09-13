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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-11 14:25
    /// 描 述：学生换班记录
    /// </summary>
    public class BK_StuChangeClassRecService : RepositoryFactory, BK_StuChangeClassRecIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuChangeClassRecEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuChangeClassRecEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["Old_ClassId"].IsEmpty()){
                 string Old_ClassId = queryParam["Old_ClassId"].ToString();
                 expression = expression.And(t => t.Old_ClassId.Equals(Old_ClassId));
             }
            if (!queryParam["Old_ClassNo"].IsEmpty())
            {
                string Old_ClassNo = queryParam["Old_ClassNo"].ToString();
                expression = expression.And(t => t.Old_ClassNo.Equals(Old_ClassNo));
            }
            if (!queryParam["New_ClassId"].IsEmpty())
            {
                string New_ClassId = queryParam["New_ClassId"].ToString();
                expression = expression.And(t => t.New_ClassId.Equals(New_ClassId));
            }
            if (!queryParam["New_ClassNo"].IsEmpty())
            {
                string New_ClassNo = queryParam["New_ClassNo"].ToString();
                expression = expression.And(t => t.New_ClassNo.Equals(New_ClassNo));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            //如果有字段2，字段3也这样写...
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuChangeClassRecEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_StuChangeClassRecEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuChangeClassRecEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_StuChangeClassRecEntity>(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_StuChangeClassRecEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();

            try
            {
                BK_StuInfoEntity stuEntity = db.FindEntity<BK_StuInfoEntity>(s => s.stuInfoId.Equals(entity.StuId));
                BK_DormBedEntity bedEntity = db.FindEntity<BK_DormBedEntity>(t => t.StuId.Equals(entity.StuId));
                //修改学生的班级信息
                stuEntity.ClassNo = entity.New_ClassNo;//修改学生的班级号
                stuEntity.MajorNo = entity.New_MajorNo;//修改学生的专业
                stuEntity.DeptNo = entity.New_DeptNo;//修改学生的院系

                db.Update<BK_StuInfoEntity>(stuEntity);//修改学生的班级号

                if (bedEntity!=null)
                {
                    bedEntity.MajorId = entity.New_MajorNo;//同时把学生的床位号里的专业也修改了
                    db.Update<BK_DormBedEntity>(bedEntity);
                }
                if (!string.IsNullOrEmpty(keyValue))
                {
                    entity.Modify(keyValue);
                    db.Update(entity);
                }
                else
                {
                    entity.Create();
                    db.Insert(entity);
                }
                db.Commit();
            }
            catch (System.Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}
