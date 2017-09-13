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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public class BK_ClassInfoService : RepositoryFactory, BK_ClassInfoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_ClassInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_ClassInfoEntity>();
            //参考代码
            if (!string.IsNullOrEmpty( queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["classNo"].IsEmpty())//转换数据用
                {
                    string ClassNo = queryParam["classNo"].ToString();
                    expression = expression.And(t => t.ClassNo.Equals(ClassNo));
                }

                if (!queryParam["ClassName"].IsEmpty())
                {
                    string ClassName = queryParam["ClassName"].ToString();
                    expression = expression.And(t => t.ClassName.Contains(ClassName));
                }
                if (!queryParam["Grade"].IsEmpty())
                {
                    string Grade = queryParam["Grade"].ToString();
                    expression = expression.And(t => t.Grade.Equals(Grade));
                }
                if (!queryParam["MajorNo"].IsEmpty())
                {
                    string MajorNo = queryParam["MajorNo"].ToString();
                    expression = expression.And(t => t.MajorNo.Equals(MajorNo));
                }
                if (!queryParam["MajorDetailNo"].IsEmpty())
                {
                    string MajorDetailNo = queryParam["MajorDetailNo"].ToString();
                    expression = expression.And(t => t.MajorDetailNo.Equals(MajorDetailNo));
                }
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression,pagination);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<BK_ClassInfoEntity> GetList(string conn,  string queryJson)
        {
            var expression = LinqExtensions.True<BK_ClassInfoEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["ClassName"].IsEmpty())
            {
                string ClassName = queryParam["ClassName"].ToString();
                expression = expression.And(t => t.ClassName.Contains(ClassName));
            }
            if (!queryParam["Grade"].IsEmpty())
            {
                string Grade = queryParam["Grade"].ToString();
                expression = expression.And(t => t.Grade.Equals(Grade));
            }
            if (!queryParam["MajorNo"].IsEmpty())
            {
                string MajorNo = queryParam["MajorNo"].ToString();
                expression = expression.And(t => t.MajorNo.Equals(MajorNo));
            }

            return this.BaseRepository(conn).FindList(expression).OrderBy(s=>s.DeptNo).OrderBy(s=>s.MajorNo).ToList();
        }
        

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_ClassInfoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_ClassInfoEntity>(keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetDetails_old(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_StuInfoEntity>("select * from BK_StuInfo where ClassNo='" + keyValue + "'").ToList();
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">班级ID号</param>
        /// <returns></returns>
        public IEnumerable<BK_StuInfoEntity> GetDetails(string conn, string keyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from BK_StuInfo where  ClassNo='" + keyValue + "'");//left join BK_StuClass on BK_StuInfo.stuInfoId=BK_StuClass.stuInfoId
            return this.BaseRepository(conn).FindList<BK_StuInfoEntity>(strSql.ToString());
        }
        /// <summary>
        ///  以List的方式获取子表详细信息
        /// </summary>
        /// <param name="keyValue">班级号</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetListDetails(string conn, string keyValue)
        {
            StringBuilder strSql = new StringBuilder();
            var expression = LinqExtensions.True<BK_StuInfoEntity>();
            expression = expression.And(t => t.ClassNo.Equals(keyValue));
            strSql.Append(@"select * from BK_StuInfo where  ClassNo='" + keyValue + "'");//left join BK_StuClass on BK_StuInfo.stuInfoId=BK_StuClass.stuInfoId
            return this.BaseRepository(conn).FindList<BK_StuInfoEntity>(expression).ToList();
            //return this.BaseRepository(conn).FindList<BK_StuInfoEntity>(strSql.ToString()).ToList();
        }


        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<BK_ClassInfoEntity>(keyValue);
                db.Delete<BK_StuClassEntity>(t => t.ClassId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 添加学生到班级
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="classid">班级ID号</param>
        /// <param name="stuinfoid">学生ID号</param>
        /// <returns></returns>
        public int InsertStuCls(string conn,string classid, List<BK_StuInfoEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            int result = 0;
            try
            {
                foreach (var item in entryList)
                {
                    item.Modify(item.stuInfoId);
                    item.ClassNo =  classid;
                    item.StuOther = "已分班";
                    result+=db.Update(item);
                }
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
            return result;
        }

        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_ClassInfoEntity entity,List<BK_StuClassEntity> entryList)
        {
          IRepository db = this.BaseRepository(conn).BeginTrans();
          try
          {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //主表
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //明细
                    //db.Delete<BK_StuClassEntity>(t => t.ClassId.Equals(keyValue));
                    if (entryList != null && entryList.Count > 0)
                    {
                        var stuclsList = db.FindList<BK_StuClassEntity>(t => t.ClassId.Equals(keyValue));
                        foreach (BK_StuClassEntity item in entryList)
                        {
                            if (stuclsList.Count() == 0)
                            {
                                item.Create();
                                db.Insert(item);
                            }
                            else
                            {
                                var stuclsentity = stuclsList.Where(s => s.stuInfoId.Equals(item.stuInfoId)).FirstOrDefault();
                                if (stuclsentity == null)
                                {
                                    item.Modify(item.StuClassId);
                                    item.ClassId = entity.ClassId;
                                    db.Update(item);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //主表
                    entity.Create();
                    db.Insert(entity);
                    //明细
                    foreach (BK_StuClassEntity item in entryList)
                    {
                        item.Create();
                        item.ClassId = entity.ClassId;
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
