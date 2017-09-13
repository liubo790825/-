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
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public class BK_DormService : RepositoryFactory, BK_DormIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_DormEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_DormEntity>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select u.*");
            strSql.Append(@", f.DormFloorsManager,f.DormFloorsName,f.DormFloorsNo,f.DormFloorsType");
            strSql.Append(",du.DormUnitManager,du.DormUnitName,du.DormUnitNo,du.DormUnitType");
            strSql.Append(",b.BuildingArea,b.BuildType,b.BuildingManager,b.DormBuildingNo,b.DormBuildingName");
            strSql.Append(" from BK_Dorm u ");
            strSql.Append(" left join BK_DormFloors f on f.DormFloorsId = u.DormFloorsId ");
            strSql.Append(" left join BK_DormUnit du on du.DormUnitId = u.DormUnitId ");
            strSql.Append(" left join BK_DormBuilding b on b.DormBuildingId = u.DormBuildingId ");
            strSql.Append("where 1=1 ");

            //参考代码
            if (!string.IsNullOrEmpty( queryJson))
            {
                var queryParam = queryJson.ToJObject();

                if (!queryParam["dormId"].IsEmpty())//转换数据用
                {
                    string DormId = queryParam["dormId"].ToString();
                    expression = expression.And(t => t.DormId.Equals(DormId));
                }


                if (!queryParam["DormName"].IsEmpty())
                {
                    string DormName = queryParam["DormName"].ToString();
                    expression = expression.And(t => t.DormName.Contains(DormName));
                    strSql.Append(" and DormName like '%" + DormName + "%'");
                }
                if (!queryParam["DormNo"].IsEmpty())
                {
                    string DormNo = queryParam["DormNo"].ToString();
                    expression = expression.And(t => t.DormNo.Contains(DormNo));
                    strSql.Append(" and DormNo like '%" + DormNo + "%'");
                }
                if (!queryParam["DormFloorsId"].IsEmpty())
                {
                    string DormFloorsId = queryParam["DormFloorsId"].ToString();
                    expression = expression.And(t => t.DormFloorsId.Equals(DormFloorsId));
                }
                if (!queryParam["MajorId"].IsEmpty())
                {
                    string MajorId = queryParam["MajorId"].ToString();
                    expression = expression.And(t => t.MajorId.Equals(MajorId));
                }
                if (!queryParam["MajorDetailId"].IsEmpty())
                {
                    string MajorDetailId = queryParam["MajorDetailId"].ToString();
                    expression = expression.And(t => t.MajorDetailId.Equals(MajorDetailId));
                }
            }
            strSql.Append(" order by b.DormBuildingName,du.DormUnitName,f.DormFloorsNo,u.DormName");

            if (pagination==null)
            {
                //return this.BaseRepository(conn).FindList<BK_DormEntity>(strSql.ToString());
                return this.BaseRepository(conn).FindList(expression).OrderBy(s => s.DormName);
            }
            //return this.BaseRepository(conn).FindList<BK_DormEntity>(strSql.ToString(), pagination);
            return this.BaseRepository(conn).FindList(expression,pagination).OrderBy(s=>s.DormName);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DormEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormEntity>(keyValue);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BK_DormEntity> GetList(string conn, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select d.* from BK_Dorm d
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
                    strSql.Append(string.Format(" and d.DormFloorsId='{0}'", DormFloorsId));
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
            strSql.Append(" order by DormNo");
            return this.BaseRepository(conn).FindList<BK_DormEntity>(strSql.ToString());
        }


        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DormBedEntity> GetDetails(string conn, string keyValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  s.telephone as BedOther4 , u.BedId,u.DormId,u.DormFloorsId,DormUnitId,u.DormBuildingId,u.BedName,u.BedNo,u.BedPrice,u.IsDwell
, u.IsDistribute, u.IsUsed, u.MajorId, u.MajorDetailId, u.ClassInfoId, u.StuId, u.StuName");
            strSql.Append(" from BK_DormBed u");
            strSql.Append(" left join BK_StuInfo s on u.StuId=s.stuInfoId");
            strSql.Append(string.Format( " where DormId = '{0}'" ,keyValue));
            strSql.Append(" order by BedName");
            return this.BaseRepository(conn).FindList<BK_DormBedEntity>(strSql.ToString());

            //return this.BaseRepository(conn).FindList<BK_DormBedEntity>("select * from BK_DormBed where DormId='" + keyValue + "' order by BedName");
        }

        /// <summary>
        /// 根据专业性别金额查询宿舍2017-7-25唐世杰
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<BK_DormEntity> GetDormName(string conn, string queryJson)
        {
            string majorId = "";
            string dormFloorsType = "";
            string price = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["MajorId"].IsEmpty())
            {//查询宿舍
                majorId = queryParam["MajorId"].ToString();
            }
            if (!queryParam["DormFloorsType"].IsEmpty())
            {//查询宿舍
                dormFloorsType = queryParam["DormFloorsType"].ToString();
            }
            if (!queryParam["Price"].IsEmpty())
            {//查询宿舍
                price = queryParam["Price"].ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select a.DormId,a.DormName");
            strsql.Append(@"  from BK_Dorm a");
            strsql.Append(@"  left join BK_DormFloors b on a.DormFloorsId=b.DormFloorsId ");
            strsql.Append(@"  where 1=1");

            if (!queryParam["MajorId"].IsEmpty())
            {
                strsql.Append(string.Format(" and a.MajorId='{0}'", majorId));
            }
            if (!queryParam["DormFloorsType"].IsEmpty())
            {
                strsql.Append(string.Format(" and b.DormFloorsType='{0}'", dormFloorsType));
            }
            if (!queryParam["Price"].IsEmpty())
            {
                strsql.Append(string.Format(" and a.Price='{0}'", price));
            }
            return this.BaseRepository(conn).FindList<BK_DormEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// 学生端查询宿舍床位2017-7-25唐世杰
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetDormBed(string conn, string keyValue)
        {
            string DormId = keyValue;

            if (!DormId.IsEmpty())
            {//查询宿舍床位
                DormId = DormId.ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select b.*,c.StuInfoId,c.StuName,c.MajorDetailName ,c.NationalityNo,c.ProvinceNo,c.ClassNo 
from BK_DormBed b");
            //strsql.Append(@"  left JOIN BK_DormBed b on b.DormId=a.DormId");
            strsql.Append(@"  left JOIN BK_StuInfo c on b.StuId=c.stuInfoId");
            strsql.Append(@"  where 1=1");

            if (!DormId.IsEmpty())
            {
                strsql.Append(string.Format(" and b.DormId='{0}'", DormId));
            }
            return this.BaseRepository(conn).FindList<M_BK_DormEntity>(strsql.ToString()).ToList();
        }
        /// <summary>
        /// 学生端查询宿舍交换床位信息2017-8-22唐世杰
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetExchangeDormBed(string conn, string keyValue, string queryJson)
        {

            string StuId = "";
            string DormId = keyValue;
            var queryParam = queryJson.ToJObject();
            if (!DormId.IsEmpty())
            {//查询宿舍床位
                DormId = DormId.ToString();
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                StuId = queryParam["StuId"].ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select b.*,c.StuInfoId,c.StuNo,c.StuName,c.MajorDetailName ,c.telephone,c.NationalityNo,c.ProvinceNo,c.ClassNo 
from BK_DormBed b");
            //strsql.Append(@"  left JOIN BK_DormBed b on b.DormId=a.DormId");
            strsql.Append(@"  left JOIN BK_StuInfo c on b.StuId=c.stuInfoId");
            strsql.Append(@"  where 1=1");

            if (!DormId.IsEmpty())
            {
                strsql.Append(string.Format(" and b.DormId='{0}'", DormId));
            }

            if (!StuId.IsEmpty())
            {
                strsql.Append(string.Format(" and (b.StuId!='{0}' or b.StuId is Null)", StuId));
            }
            return this.BaseRepository(conn).FindList<M_BK_DormEntity>(strsql.ToString()).ToList();
        }

        //教师端查看宿舍信息
        public List<BK_DormEntity> GetDormId(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select DormId,DormName");  
            strsql.Append(@"  from BK_dorm");
            strsql.Append(@"  where DormId in(");
            strsql.Append(@"  select DISTINCT DormId");
            strsql.Append(@"  from BK_DormBed");
            strsql.Append(@"  where (StuId is not null) and (StuId <> ''))");
            return this.BaseRepository(conn).FindList<BK_DormEntity>(strsql.ToString()).ToList();
        }
        //教师端查看所有床位信息
        public List<M_BK_DormStuInfoEntity> TeaGetDormBed(string conn, string keyValue)
        {
            string DormId = keyValue;

            if (!DormId.IsEmpty())
            {//查询宿舍床位
                DormId = DormId.ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select b.BedName,c.StuName,c.HeadImg ,c.ProvinceNo,c.telephone 
from BK_DormBed b");
            strsql.Append(@"  left JOIN BK_StuInfo c on b.StuId=c.stuInfoId");
            strsql.Append(@"  where 1=1");

            if (!DormId.IsEmpty())
            {
                strsql.Append(string.Format(" and b.DormId='{0}'", DormId));
                strsql.Append(string.Format(" and (StuId is not null)" ));
                strsql.Append(string.Format(" and (StuId <> '')" ));
            }
            return this.BaseRepository(conn).FindList<M_BK_DormStuInfoEntity>(strsql.ToString()).ToList();
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
                db.Delete<BK_DormEntity>(keyValue);
                db.Delete<BK_DormBedEntity>(t => t.DormId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
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
        public void SaveForm(string conn, string keyValue, BK_DormEntity entity, List<BK_DormBedEntity> entryList)
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
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.BedId))//如果ID号空，就增加数据，如果不为空就修改数据
                            {
                                item.Modify(item.BedId);
                                item.DormId = entity.DormId;
                                db.Update(item);//修改数
                            }
                            else
                            {
                                item.Create();
                                item.DormId = entity.DormId;
                                db.Insert(item);
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
                    foreach (BK_DormBedEntity item in entryList)
                    {
                        item.Create();
                        item.DormId = entity.DormId;
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
