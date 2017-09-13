using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 15:59
    /// 描 述：床位信息
    /// </summary>
    public class BK_DormBedService : RepositoryFactory, BK_DormBedIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DormBedEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DormBedEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();

             if (!queryParam["bedId"].IsEmpty())//转换数据用
             {
                 string BedId = queryParam["bedId"].ToString();
                 expression = expression.And(t => t.BedId.Equals(BedId));
             }

             if (!queryParam["BedNo"].IsEmpty()){
                 string BedNo = queryParam["BedNo"].ToString();
                 expression = expression.And(t => t.BedNo.Contains(BedNo));
             }
            if (!queryParam["DormId"].IsEmpty())
            {
                string DormId = queryParam["DormId"].ToString();
                expression = expression.And(t => t.DormId.Equals(DormId));
            }

            //如果有字段2，字段3也这样写...
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<BK_DormBedEntity> GetList(string conn, string queryJson)
        {
            var bedlist = this.BaseRepository(conn).IQueryable<BK_DormBedEntity>();
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["DormFloorsId"].IsEmpty())
                {
                    string DormFloorsId = queryParam["DormFloorsId"].ToString();
                    bedlist = bedlist.Where(s => s.DormFloorsId.Equals(DormFloorsId));
                }
                if (!queryParam["DormId"].IsEmpty())
                {
                    string DormId = queryParam["DormId"].ToString();
                    bedlist = bedlist.Where(s => s.DormId.Equals(DormId));
                }
                if (!queryParam["MajorId"].IsEmpty())
                {
                    string MajorId = queryParam["MajorId"].ToString();
                    bedlist = bedlist.Where(s => s.MajorId.Equals(MajorId));
                }
                if (!queryParam["MajorDetailId"].IsEmpty())
                {
                    string MajorDetailId = queryParam["MajorDetailId"].ToString();
                    bedlist = bedlist.Where(s => s.MajorDetailId.Equals(MajorDetailId));
                }
                if (!queryParam["StuId"].IsEmpty())
                {
                    string StuId = queryParam["StuId"].ToString();
                    bedlist = bedlist.Where(s => s.StuId.Equals(StuId));
                }

            }
            return bedlist.ToList();
        }


        /// <summary>
        /// 获取床位列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BK_DormBedEntity> GetListByStr(string conn, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select d.* from BK_DormBed d
                            left join BK_DormFloors df on df.DormFloorsId = d.DormFloorsId
                            where 1=1 ");//left join BK_Major m on m.MajorId = d.MajorId

            //参考代码
            if (!string.IsNullOrEmpty(queryJson))
            {
                var queryParam = queryJson.ToJObject();
                if (!queryParam["DormName"].IsEmpty())
                {
                    string DormName = queryParam["DormName"].ToString();
                    strSql.Append(" and DormName like '%" + DormName + "%'");
                }
                if (!queryParam["DormNo"].IsEmpty())
                {
                    string DormNo = queryParam["DormNo"].ToString();
                    strSql.Append(" and DormNo like '%" + DormNo + "%'");
                }
                if (!queryParam["DormFloorsId"].IsEmpty())
                {
                    string DormFloorsId = queryParam["DormFloorsId"].ToString();
                    strSql.Append(string.Format(" and m.DormFloorsId='{0}'", DormFloorsId));
                }
                if (!queryParam["MajorId"].IsEmpty())
                {
                    string MajorId = queryParam["MajorId"].ToString();
                    strSql.Append(string.Format(" and m.MajorId='{0}'", MajorId));
                }
                if (!queryParam["MajorDetailId"].IsEmpty())
                {
                    string MajorDetailId = queryParam["MajorDetailId"].ToString();
                    strSql.Append(string.Format(" and m.MajorDetailId='{0}'", MajorDetailId));
                }
                if (!queryParam["MajorNo"].IsEmpty())//专业号
                {
                    string MajorNo = queryParam["MajorNo"].ToString();
                    strSql.Append(string.Format(" and d.MajorId='{0}'", MajorNo));
                }
                if (!queryParam["DormFloorsType"].IsEmpty())//楼层类型
                {
                    string DormFloorsType = queryParam["DormFloorsType"].ToString();//DormFloorsType
                    strSql.Append(string.Format(" and df.DormFloorsType like '%{0}%'", DormFloorsType));
                }
            }

            return this.BaseRepository(conn).FindList<BK_DormBedEntity>(strSql.ToString());
        }



        //记录数量
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_DormBed");
            strsql.Append(@"  where 1=1");
            strsql.Append(@"  and (StuId is not null) and (StuId <> '')");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }



        //查询原床位号
        public List<BK_DormBedEntity> SelectOldBedId(string conn, string queryJson)
        {
             string StuId = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuId"].IsEmpty())
            {
                StuId = queryParam["StuId"].ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select BedId");
            strsql.Append(@"  from BK_DormBed");
            strsql.Append(@"  where 1=1");
            strsql.Append(string.Format(" and StuId='{0}'", StuId));
            return this.BaseRepository(conn).FindList<BK_DormBedEntity>(strsql.ToString()).ToList();
        }



        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DormBedEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormBedEntity>(keyValue);
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
        public void SaveForm(string conn, string keyValue, BK_DormBedEntity entity)
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
