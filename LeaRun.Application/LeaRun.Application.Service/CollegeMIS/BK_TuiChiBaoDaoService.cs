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
    /// 创 建：admin
    /// 日 期：2017-08-03 09:59
    /// 描 述：BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoService : RepositoryFactory, BK_TuiChiBaoDaoIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_TuiChiBaoDaoEntity>();
             //参考代码
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["字段1"].IsEmpty()){
                 string FullHead = queryParam["字段1"].ToString();
                 expression = expression.And(t => t.字段1.Contains(字段1));
             }*/
             //如果有字段2，字段3也这样写...
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_TuiChiBaoDaoEntity>();
            //参考代码
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["IdentityCardNo"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["IdentityCardNo"].ToString();
                expression = expression.And(t => t.IdentityCardNo.Contains(IdentityCardNo));
            }//*/

            //如果有字段2，字段3也这样写...

            return this.BaseRepository(conn).IQueryable(expression).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_TuiChiBaoDaoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_TuiChiBaoDaoEntity>(keyValue);
        }

               

        /// <summary>
        /// 查询有推迟报到学生班级2017-7-25唐世杰
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select distinct TuiChiOther1,TuiChiOther2");
            strsql.Append(@"  FROM BK_TuiChiBaoDao ");
            return this.BaseRepository(conn).FindList<BK_TuiChiBaoDaoEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// 查询推迟报到学生2017-7-25唐世杰
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_TuiChiBaoDaoEntity> GetTuiChiInfo(string conn, string keyValue)
        {
            string ClassNo = keyValue;

            if (!ClassNo.IsEmpty())
            {// 查询推迟报到学生
                ClassNo = ClassNo.ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select b.*,db.HeadImg,db.StuName,db.NationalityNo,db.telephone,db.ProvinceNo,d.ClassName,d.ClassNo");
            strsql.Append(@"  from BK_TuiChiBaoDao b");
            strsql.Append(@"  left join BK_StuInfo db on db.IdentityCardNo=b.IdentityCardNo");
            strsql.Append(@"  left join BK_ClassInfo d on b.TuiChiOther1=d.ClassNo");
            strsql.Append(@"  where 1=1");

            if (!ClassNo.IsEmpty())
            {
                strsql.Append(string.Format(" and b.TuiChiOther1='{0}'", ClassNo));
            }
            return this.BaseRepository(conn).FindList<M_BK_TuiChiBaoDaoEntity>(strsql.ToString()).ToList();
        }

        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_TuiChiBaoDao");
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
        public void SaveForm(string conn, string keyValue, BK_TuiChiBaoDaoEntity entity)
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
