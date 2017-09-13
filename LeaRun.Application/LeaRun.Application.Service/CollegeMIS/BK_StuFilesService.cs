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
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-08-17 17:53
    /// 描 述：学生档案管理
    /// </summary>
    public class BK_StuFilesService : RepositoryFactory<BK_StuFilesEntity>, BK_StuFilesIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_StuFilesEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuFilesEntity>();
             //参考代码
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
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //通知书号
                        expression = expression.And(t => t.NoticeNo.Equals(keyord));
                        break;
                    case "StuNo":          //身份证号
                        expression = expression.And(t => t.StuNo.Equals(keyord));
                        break;
                    case "StuName":          //姓名
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    case "Taker":          //提档人
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
            //如果有字段2，字段3也这样写...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_StuFilesEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_StuFilesEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_StuFilesEntity>();
            //参考代码
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
            //查询条件
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //通知书号
                        expression = expression.And(t => t.NoticeNo.Equals(keyord));
                        break;
                    case "StuNo":          //身份证号
                        expression = expression.And(t => t.StuNo.Equals(keyord));
                        break;
                    case "StuName":          //姓名
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    default:
                        break;
                }
            }

            return this.BaseRepository(conn).FindEntity(expression);
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
