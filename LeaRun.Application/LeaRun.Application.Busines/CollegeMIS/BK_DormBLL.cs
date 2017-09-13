using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Application.Service.CollegeMIS;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System;
using System.Data;

namespace LeaRun.Application.Busines.CollegeMIS
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-28 16:33
    /// 描 述：宿舍信息
    /// </summary>
    public class BK_DormBLL
    {
        private BK_DormIService service = new BK_DormService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region 构造方法指定要连的数据库
        public BK_DormBLL()
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
        public IEnumerable<BK_DormEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_DormEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public IEnumerable<BK_DormEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 获取子表详细信息
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public IEnumerable<BK_DormBedEntity> GetDetails(string keyValue)
        {
            return service.GetDetails(conEntity.DbConnection,keyValue);
        }

        /// <summary>
        /// 查询宿舍信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<BK_DormEntity> GetDormName(string queryJson)
        {
            return service.GetDormName(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 查询宿舍床位信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetDormBed(string queryJson)
        {
            return service.GetDormBed(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 查询宿舍床位信息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_DormEntity> GetExchangeDormBed(string keyValue, string queryJson)
        {
            return service.GetExchangeDormBed(conEntity.DbConnection, keyValue, queryJson);
        }

        //教师端查询宿舍
        public List<BK_DormEntity> GetDormId()
        {
            return service.GetDormId(conEntity.DbConnection);
        }
        //教师端查询床位
        public List<M_BK_DormStuInfoEntity> TeaGetDormBed(string queryJson)
        {
            return service.TeaGetDormBed(conEntity.DbConnection, queryJson);
        }



        #endregion

        #region 提交数据
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
        public void SaveForm(string keyValue, BK_DormEntity entity,List<BK_DormBedEntity> entryList)
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
