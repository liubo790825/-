using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-19 10:07
    /// 描 述：行政班
    /// </summary>
    public class BK_ClassInfoBLL
    {
        private BK_ClassInfoIService service = new BK_ClassInfoService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region 构造方法指定要连的数据库
        public BK_ClassInfoBLL()
        {
            SystemManage.DataBaseLinkBLL databaseLinkBLL = new Busines.SystemManage.DataBaseLinkBLL();
            conEntity = databaseLinkBLL.GetEntity("9914ca66-d5ae-4a26-9353-76bddea33179");
        }
        #endregion
        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<BK_ClassInfoEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public List<BK_ClassInfoEntity> GetList( string queryJson)
        {
             return service.GetList(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetDetails_old (string keyValue)
        {
            return service.GetDetails_old(conEntity.DbConnection, keyValue);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_ClassInfoEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">班级ID号</param>
        /// <returns></returns>
        public IEnumerable<BK_StuInfoEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        ///  以List的方式获取子表详细信息
        /// </summary>
        /// <param name="keyValue">班级号</param>
        /// <returns></returns>
        public List<BK_StuInfoEntity> GetListDetails( string keyValue)
        {
            return service.GetListDetails(conEntity.DbConnection, keyValue);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 添加学生到班级
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="classid">班级ID号</param>
        /// <param name="entryList">学生ID号</param>
        /// <returns></returns>
        public int InsertStuCls(string classid, List<BK_StuInfoEntity> entryList)
        {
            return service.InsertStuCls(conEntity.DbConnection, classid, entryList);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(conEntity.DbConnection,keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, BK_ClassInfoEntity entity,List<BK_StuClassEntity> entryList)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity, entryList);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
