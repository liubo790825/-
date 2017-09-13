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
    /// 日 期：2017-08-17 12:29
    /// 描 述：换床申请
    /// </summary>
    public class BK_AppChangeBedBLL
    {
        private BK_AppChangeBedIService service = new BK_AppChangeBedService();

        private Entity.SystemManage.DataBaseLinkEntity conEntity;
        #region 构造方法指定要连的数据库
        public BK_AppChangeBedBLL()
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
        public IEnumerable<BK_AppChangeBedEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(conEntity.DbConnection,pagination, queryJson);
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_AppChangeBedEntity> GetList(string queryJson)
        {
            return service.GetList(conEntity.DbConnection,queryJson);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public BK_AppChangeBedEntity GetEntity(string keyValue)
        {
            return service.GetEntity(conEntity.DbConnection,keyValue);
        }

        /// <summary>
        /// 查询宿舍交换记录信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<BK_AppChangeBedEntity> SelectAppChangeBed(string queryJson)
        {
            return service.SelectAppChangeBed(conEntity.DbConnection, queryJson);
        }
        /// <summary>
        /// 查询我的宿舍交换记录信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeGetMyInfo(string queryJson)
        {
            return service.DormExchangeGetMyInfo(conEntity.DbConnection, queryJson);
        }

        /// <summary>
        /// 对我的交换申请
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> GetMyExchangeList(Pagination pagination, string queryJson)
        {
            return service.GetMyExchangeList(conEntity.DbConnection, pagination, queryJson);
        }

        /// <summary>
        /// 教师端获取交换申请
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> TeaGetDormExchangeList(Pagination pagination)
        {
            return service.TeaGetDormExchangeList(conEntity.DbConnection, pagination);
        }

        /// <summary>
        /// 教师端获取宿舍交换申请记录数
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<M_BK_NumberEntity> TeaNumber()
        {
            return service.TeaNumber(conEntity.DbConnection);
        }

        /// <summary>
        /// 宿舍交换双方学生信息
        /// </summary>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回列表</returns>
        public IEnumerable<M_BK_AppChangeBedEntity> DormExchangeStuInfo(string queryJson)
        {
            return service.DormExchangeStuInfo(conEntity.DbConnection, queryJson);
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
        public void SaveForm(string keyValue, BK_AppChangeBedEntity entity)
        {
            try
            {
                service.SaveForm(conEntity.DbConnection,keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
