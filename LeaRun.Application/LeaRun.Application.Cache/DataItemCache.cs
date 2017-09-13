using LeaRun.Application.Busines;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Cache.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Cache
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：J&M
    /// 日 期：2015.12.29 9:56
    /// 描 述：数据字典缓存
    /// </summary>
    public class DataItemCache
    {
        private DataItemDetailBLL busines = new DataItemDetailBLL();

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList()
        {
            var cacheList = CacheFactory.Cache().GetCache<IEnumerable<DataItemModel>>(busines.cacheKey);
            if (cacheList == null)
            {
                var data = busines.GetDataItemList();
                CacheFactory.Cache().WriteCache(data, busines.cacheKey);
                return data;
            }
            else
            {
                return cacheList;
            }
        }
        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetDataItemList(string EnCode)
        {
            return this.GetDataItemList().Where(t => t.EnCode == EnCode && t.EnabledMark==1);
        }

        /// <summary>
        /// 数据字典列表
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public IEnumerable<DataItemModel> GetSubDataItemList(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode && t.EnabledMark==1);
            string ItemDetailId = data.First(t => t.ItemValue == ItemValue).ItemDetailId;
            return data.Where(t => t.ParentId == ItemDetailId);
        }
        /// <summary>
        /// 项目值转换名称
        /// </summary>
        /// <param name="EnCode">分类代码</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public string ToItemName(string EnCode, string ItemValue)
        {
            var data = this.GetDataItemList().Where(t => t.EnCode == EnCode && t.EnabledMark==1);
            return data.First(t => t.ItemValue == ItemValue).ItemName;
        }

        #region  刘波 于2017年6月7日添加

        /// <summary>
        /// 根据 ID号返回名称
        /// </summary>
        /// <param name="ItemDetailId"></param>
        /// <returns></returns>
        public string ToItemName(string ItemDetailId)
        {
            var data = this.GetDataItemList().Where(t => t.ItemDetailId == ItemDetailId );
            return data.FirstOrDefault().ItemName;
        }

        /// <summary>
        /// 根据ID号返回一个字典数据
        /// </summary>
        /// <param name="ItemDetailId">字典ID号</param>
        /// <returns></returns>
        public DataItemModel GetDataItem(string ItemDetailId)
        {
            return this.GetDataItemList().Where(t => t.ItemDetailId == ItemDetailId).FirstOrDefault();
        }

        #endregion
    }
}
