using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin2017-7-21 唐世杰
    /// 日 期：2017-07-21 11:00
    /// 描 述：BK_JunxunFuzhuang
    /// </summary>
    public class BK_JunxunFuzhuangService : RepositoryFactory, BK_JunxunFuzhuangIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_JunxunFuzhuangEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_JunxunFuzhuangEntity>();
             //参考代码
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }*/
             //如果有字段2，字段3也这样写...
             //expression = expression.And(t => t.FuzhuangId > 0);
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_JunxunFuzhuangEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_JunxunFuzhuangEntity>();
            //参考代码
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["BaodaoOther1"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["BaodaoOther1"].ToString();
                expression = expression.And(t => t.BaodaoOther1.Contains(IdentityCardNo));
            }//*/

            //如果有字段2，字段3也这样写...

            return this.BaseRepository(conn).IQueryable(expression).ToList();
        }

        /// <summary>
        /// 获取军训服装信息列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<M_BK_JunxunFuzhuangEntity> GetJunXunFuList(string conn, Pagination pagination)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select a.*,b.StuName,b.Gender");
            strSql.Append(@" from BK_JunxunFuzhuang a");
            strSql.Append(@" left join BK_StuInfo b on a.BaodaoOther1=b.IdentityCardNo");
            
            //expression = expression.And(t => !string.IsNullOrEmpty(t.FuzhuangId));
            return this.BaseRepository(conn).FindList<M_BK_JunxunFuzhuangEntity>(strSql.ToString(), pagination).ToList();
        }



        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_JunxunFuzhuangEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_JunxunFuzhuangEntity>(keyValue);
        }


        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_JunxunFuzhuang");
            strsql.Append(@"  where 1=1");
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
        public void SaveForm(string conn, string keyValue, BK_JunxunFuzhuangEntity entity)
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
