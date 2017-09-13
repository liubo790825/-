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
    /// 日 期：2017-08-17 12:29
    /// 描 述：换床申请
    /// </summary>
    public class BK_AppChangeBedService : RepositoryFactory, BK_AppChangeBedIService
    {
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_AppChangeBedEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_AppChangeBedEntity>();
             //参考代码
             var queryParam = queryJson.ToJObject();
             if (!queryParam["StuId"].IsEmpty()){
                 string StuId = queryParam["StuId"].ToString();
                 expression = expression.And(t => t.AppStuId.Equals(StuId));
             }
            if (!queryParam["AppStuNo"].IsEmpty())
            {
                string AppStuNo = queryParam["AppStuNo"].ToString();
                expression = expression.And(t => t.AppStuNo.Equals(AppStuNo));
            }
            if (!queryParam["AppStuName"].IsEmpty())
            {
                string AppStuName = queryParam["AppStuName"].ToString();
                expression = expression.And(t => t.AppStuName.Contains(AppStuName));
            }
            if (!queryParam["AppStuPhone"].IsEmpty())
            {
                string AppStuPhone = queryParam["AppStuPhone"].ToString();
                expression = expression.And(t => t.AppStuPhone.Contains(AppStuPhone));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.TargetStuId.Contains(StuId));
            }
            if (!queryParam["TargetStuNo"].IsEmpty())
            {
                string TargetStuNo = queryParam["TargetStuNo"].ToString();
                expression = expression.And(t => t.TargetStuNo.Equals(TargetStuNo));
            }
            if (!queryParam["TargetPassed"].IsEmpty())
            {
                int TargetPassed = queryParam["TargetPassed"].ToInt();
                expression = expression.And(t => t.TargetPassed== TargetPassed);
            }

            return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_AppChangeBedEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable<BK_AppChangeBedEntity>().ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_AppChangeBedEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_AppChangeBedEntity>(keyValue);
        }


        /// <summary>
        /// 获取宿舍交换记录信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_AppChangeBedEntity> SelectAppChangeBed(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_AppChangeBedEntity>();
            //参考代码
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.AppStuNo.Equals(StuNo));
            }
            return this.BaseRepository(conn).IQueryable<BK_AppChangeBedEntity>().ToList();
        }

        /// <summary>
        /// 查询我的宿舍交换记录信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeGetMyInfo(string conn, string queryJson)
        {
            string AppStuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["AppStuNo"].IsEmpty())
            {
                AppStuNo = queryParam["AppStuNo"].ToString();
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select a.*,b.ClassName,c.BedName,d.DormName");
            strSql.Append(@" from BK_AppChangeBed a");
            strSql.Append(@" left join BK_ClassInfo b on a.TargetClassId=b.ClassNo");
            strSql.Append(@" left join BK_DormBed c on c.BedId =a.NewBedId");
            strSql.Append(@" left join BK_Dorm d on d.DormId=c.DormId");
            
            if (!queryParam["AppStuNo"].IsEmpty())
            {
                strSql.Append(string.Format(" where 1=1 and a.AppStuNo = '{0}'", AppStuNo));
            }

            return this.BaseRepository(conn).FindList<M_BK_AppChangeBedEntity>(strSql.ToString());

            //return this.BaseRepository(conn).FindList<BK_DormBedEntity>("select * from BK_DormBed where DormId='" + keyValue + "' order by BedName");
        }


        /// <summary>
        /// 对我的交换申请
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public IEnumerable<M_BK_AppChangeBedEntity> GetMyExchangeList(string conn, Pagination pagination, string queryJson)
        {
            string TargetStuNo = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["TargetStuNo"].IsEmpty())
            {
                TargetStuNo = queryParam["TargetStuNo"].ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"select a.*,b.ClassName,c.BedName,d.DormName");
            strsql.Append(@" from BK_AppChangeBed a");
            strsql.Append(@" left join BK_ClassInfo b on a.AppClassId=b.ClassNo");
            strsql.Append(@" left join BK_DormBed c on c.BedId =a.OldBedId");
            strsql.Append(@" left join BK_Dorm d on d.DormId=c.DormId  where 1=1 ");
            strsql.Append(@" and (a.TargetPassed = '0' or a.TargetPassed = '1')");
            strsql.Append(@" and a.Passed!='0'");

            if (!queryParam["TargetStuNo"].IsEmpty())
            {
                strsql.Append(string.Format(" and a.TargetStuNo = '{0}'", TargetStuNo));
            }
            return this.BaseRepository(conn).FindList<M_BK_AppChangeBedEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// 教师端获取交换申请
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public IEnumerable<M_BK_AppChangeBedEntity> TeaGetDormExchangeList(string conn, Pagination pagination)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"select a.*,b.ClassName,c.BedName,d.DormName");
            strsql.Append(@" from BK_AppChangeBed a");
            strsql.Append(@" left join BK_ClassInfo b on a.AppClassId=b.ClassNo");
            strsql.Append(@" left join BK_DormBed c on c.BedId =a.OldBedId");
            strsql.Append(@" left join BK_Dorm d on d.DormId=c.DormId  where 1=1 ");
            strsql.Append(@" and  a.TargetPassed = '1'");
            strsql.Append(@" and a.Passed='1'");
            return this.BaseRepository(conn).FindList<M_BK_AppChangeBedEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// 教师端获取宿舍交换申请记录数
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">我的ID号</param>
        /// <returns></returns>
        public IEnumerable<M_BK_NumberEntity> TeaNumber(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@" select COUNT(1) number");
            strsql.Append(@" from BK_AppChangeBed a");
            strsql.Append(@" left join BK_ClassInfo b on a.AppClassId=b.ClassNo");
            strsql.Append(@" left join BK_DormBed c on c.BedId =a.OldBedId");
            strsql.Append(@" left join BK_Dorm d on d.DormId=c.DormId  where 1=1 ");
            strsql.Append(@" and  a.TargetPassed = '1'");
            strsql.Append(@" and a.Passed='1'");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
        }


        /// <summary>
        /// 宿舍交换双方学生信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeStuInfo(string conn, string queryJson)
        {
            string StuId = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StuId"].IsEmpty())
            {
                StuId = queryParam["StuId"].ToString();
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select b.ClassName,c.BedName,d.DormName");
            strSql.Append(@" from BK_StuInfo a");
            strSql.Append(@" left join BK_ClassInfo b on a.ClassNo=b.ClassNo");
            strSql.Append(@" left join BK_DormBed c on c.StuId =a.stuInfoId");
            strSql.Append(@" left join BK_Dorm d on d.DormId=c.DormId");

            if (!queryParam["AppStuNo"].IsEmpty())
            {
                strSql.Append(string.Format(" where 1=1 and c.StuId = '{0}'", StuId));
            }

            return this.BaseRepository(conn).FindList<M_BK_AppChangeBedEntity>(strSql.ToString());

            //return this.BaseRepository(conn).FindList<BK_DormBedEntity>("select * from BK_DormBed where DormId='" + keyValue + "' order by BedName");
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
        public void SaveForm(string conn, string keyValue, BK_AppChangeBedEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                if (entity.TargetStuId == "" || entity.TargetStuId == null)
                {
                    entity.TargetPassed = 1;
                    entity.TargetStuId = "";
                    entity.TargetStuName = "";
                    entity.TargetStuNo = "";
                    entity.TargetRemark = "";
                    entity.TargetStuPhone = "";
                    entity.TargetClassId = "";
                }
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                if(entity.TargetStuId == ""||entity.TargetStuId == null){
                    entity.TargetPassed = 1;

                }
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
