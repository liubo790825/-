using LeaRun.Application.Busines.AuthorizeManage;
using LeaRun.Application.Cache;
using LeaRun.Application.Code;
using LeaRun.Application.Entity.AuthorizeManage;
using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Entity.SystemManage.ViewModel;
using LeaRun.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.SystemManage;


namespace LeaRun.Application.Web.Controllers
{
    public class ClientDataController : MvcControllerBase
    {
        private DataItemCache dataItemCache = new DataItemCache();
        private OrganizeCache organizeCache = new OrganizeCache();
        private DepartmentCache departmentCache = new DepartmentCache();
        private PostCache postCache = new PostCache();
        private RoleCache roleCache = new RoleCache();
        private UserGroupCache userGroupCache = new UserGroupCache();
        private UserCache userCache = new UserCache();
        private AuthorizeBLL authorizeBLL = new AuthorizeBLL();
        private ModuleButtonBLL btnbll = new ModuleButtonBLL();

        private ExcelImportBLL excelBll = new ExcelImportBLL();
        private ExcelExportBLL exportBll = new ExcelExportBLL();
        [AjaxOnly(false), HttpPost]
        public ActionResult GetClientDataJson()
        {
            var data = new
            {
                organize = this.GetOrganizeData(),//公司
                department = this.GetDepartmentData(),//部门
                post = this.GetPostData(),//岗位
                role = this.GetRoleData(),//角色
                userGroup = this.GetUserGroupData(),//用户组
                user = this.GetUserData(),//用户
                dataItem = this.GetDataItem(),//字典
                authorizeMenu = this.GetModuleData(),//导航菜单
                authorizeButton = this.GetModuleButtonData(),//功能按钮
                authorizeColumn = this.GetModuleColumnData(),//功能视图

                menu = this.GetMenuData_old(),//跟原版一样的数据
                menuData = this.GetMenuData(),//得到的菜单
                button = this.GetModuleButtonData(),//所有的按钮
                
                excelImportTemplate = this.GetExcelImportData(),
                excelExportTemplate = this.GetExcelExportData(),
                
                buttonData = this.GetButtonData()//得到所有的按钮
            };
            return this.ToJsonResult(data);
        }

        #region 刘波 于2017年6月7日添加
        /// <summary>
        /// 刘波 于2017年6月7日添加
        /// 由于数据字典按原方法返回的数据太大，造成了运行错误，所以使用这个方法
        /// 根据ID号直接返回数据字典的内容
        /// </summary>
        /// <param name="ItemDetailId">ID号</param>
        /// <returns></returns>
        public ActionResult GetDataItemModel(string ItemDetailId) {
            var itemmodel = this.dataItemCache.GetDataItem(ItemDetailId);
            return this.ToJsonResult(itemmodel);
        }

        /// <summary>
        /// 返回导入数据的一些按数据
        /// </summary>
        /// <returns></returns>
        public object GetExcelImportData()
        {
            IEnumerable<ExcelImportEntity> list = excelBll.GetList(string.Empty);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var current in list)
            {
                var templateInfo = excelBll.GetDetails(current.F_Id);
                Dictionary<string, object> dicentitys = new Dictionary<string, object>();
                Dictionary<string, object> dickey = new Dictionary<string, object>();
                Dictionary<string, object> dicdatachild = new Dictionary<string, object>();
                var btnentity = btnbll.GetEntity(current.F_ModuleBtnId);//得到按钮的数据

                var datachild = new {
                    filedsInfo = templateInfo,
                    templateInfo=current
                };
                dicdatachild.Add("0", datachild);

                IEnumerable<ExcelImportEntity> values = from t in list where t.F_ModuleId.Equals(current.F_ModuleId)  select t;               
                int i = 0;
                foreach (var item in values)
                {
                    dickey.Add(i.ToString(), item.F_Id);
                    i++;
                }
                //dictionary.Add(current.F_ModuleId, dictionary2);
                var entitysItem = new
                {
                    btn = btnentity,
                    data = dicdatachild
                };
                dicentitys.Add(btnentity.EnCode, entitysItem);
                var fieldItem = new
                {
                    entitys = dicentitys
                    //keys = dickey
                };
                //dictionary.Add(current.F_ModuleId, dicentitys);
                dictionary.Add(current.F_ModuleId, dickey); //最开始用的这个


            }
            return dictionary;
        }

        /// <summary>
        /// 返回导出数据的一些按数据
        /// </summary>
        /// <returns></returns>
        public object GetExcelExportData()
        {
            var list = exportBll.GetList(string.Empty);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var current in list)
            {
                dictionary.Add(current.F_ModuleId, current);
            }
            return dictionary;
        }


        private object GetMenuData_old()
        {
            IEnumerable<ModuleEntity> list = this.authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleEntity current in list)
            {
                dictionary.Add(current.ModuleId, current);
            }
            return dictionary;
        }

        private object GetMenuData()
        {

            var data = authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.ModuleId, fieldItem);
            }
            return dictionary;
        }

        private object GetButtonData()
        {
            var data = authorizeBLL.GetModuleButtonList(SystemInfo.CurrentUserId);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (ModuleButtonEntity item in data)
            {
                var fieldItem = new
                {
                    EnCode = item.EnCode,
                    FullName = item.FullName
                };
                dictionary.Add(item.ModuleButtonId, fieldItem);
            }
            return dictionary;
        }

        #endregion

        private object GetOrganizeData()
        {
            IEnumerable<OrganizeEntity> list = this.organizeCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (OrganizeEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    FullName = current.FullName
                };
                dictionary.Add(current.OrganizeId, value);
            }
            return dictionary;
        }

        private object GetDepartmentData()
        {
            IEnumerable<DepartmentEntity> list = this.departmentCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (DepartmentEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    FullName = current.FullName,
                    OrganizeId = current.OrganizeId
                };
                dictionary.Add(current.DepartmentId, value);
            }
            return dictionary;
        }

        private object GetUserGroupData()
        {
            IEnumerable<RoleEntity> list = this.userGroupCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    FullName = current.FullName
                };
                dictionary.Add(current.RoleId, value);
            }
            return dictionary;
        }

        private object GetPostData()
        {
            IEnumerable<RoleEntity> list = this.postCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    FullName = current.FullName
                };
                dictionary.Add(current.RoleId, value);
            }
            return dictionary;
        }

        private object GetRoleData()
        {
            IEnumerable<RoleEntity> list = this.roleCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (RoleEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    FullName = current.FullName
                };
                dictionary.Add(current.RoleId, value);
            }
            return dictionary;
        }

        private object GetUserData()
        {
            IEnumerable<UserEntity> list = this.userCache.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (UserEntity current in list)
            {
                var value = new
                {
                    EnCode = current.EnCode,
                    Account = current.Account,
                    RealName = current.RealName,
                    OrganizeId = current.OrganizeId,
                    DepartmentId = current.DepartmentId
                };
                dictionary.Add(current.UserId, value);
            }
            return dictionary;
        }

        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <returns></returns>
        private object GetDataItem()
        {
            var dataList = dataItemCache.GetDataItemList();
            var dataSort = dataList.Distinct(new Comparint<DataItemModel>("EnCode"));
            Dictionary<string, object> dictionarySort = new Dictionary<string, object>();
            foreach (DataItemModel itemSort in dataSort)
            {
                var dataItemList = dataList.Where(t =>  t.EnCode.Equals(itemSort.EnCode));//!string.IsNullOrEmpty(t.EnCode) &&
                Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
                foreach (DataItemModel itemList in dataItemList)
                {
                    if (!string.IsNullOrEmpty(itemList.EnCode) &&  !dictionaryItemList.ContainsKey(itemList.ItemValue) && !dictionaryItemList.ContainsValue(itemList.ItemName))
                    {
                        dictionaryItemList.Add(itemList.ItemValue, itemList.ItemName);
                    }
                }
                foreach (DataItemModel itemList in dataItemList)
                {
                    //if (!string.IsNullOrEmpty(itemList.EnCode) && !dictionaryItemList.ContainsKey(itemList.ItemDetailId) && !dictionaryItemList.ContainsValue(itemList.ItemName))
                        dictionaryItemList.Add(itemList.ItemDetailId, itemList.ItemName);
                }
               dictionarySort.Add(itemSort.EnCode, dictionaryItemList);               
            }
            return dictionarySort;
        }


        private object GetDataItem_old()
        {
            IEnumerable<DataItemModel> dataItemList = this.dataItemCache.GetDataItemList();
            IEnumerable<DataItemModel> enumerable = dataItemList.Distinct(new Comparint<DataItemModel>(new string[]
			{
				"EnCode"
			}));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (IEnumerator<DataItemModel> enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    DataItemModel itemSort = enumerator.Current;
                    IEnumerable<DataItemModel> enumerable2 = from t in dataItemList
                                                             where t.EnCode.Equals(itemSort.EnCode)
                                                             select t;
                    Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
                    foreach (DataItemModel current in enumerable2)
                    {
                        try
                        {
                            dictionary2.Add(current.ItemValue, current.ItemName);
                        }
                        catch (Exception ex)
                        {
                            string temps = ex.Message;
                        }
                        
                    }
                    foreach (DataItemModel current2 in enumerable2)
                    {
                        dictionary2.Add(current2.ItemDetailId, current2.ItemName);
                    }
                    dictionary.Add(itemSort.EnCode, dictionary2);
                }
            }
            return dictionary;
        }

        private object GetModuleData()
        {
            return this.authorizeBLL.GetModuleList(SystemInfo.CurrentUserId);
        }

        private object GetModuleButtonData()
        {
            IEnumerable<ModuleButtonEntity> moduleButtonList = this.authorizeBLL.GetModuleButtonList(SystemInfo.CurrentUserId);
            IEnumerable<ModuleButtonEntity> enumerable = moduleButtonList.Distinct(new Comparint<ModuleButtonEntity>(new string[]
			{
				"ModuleId"
			}));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (IEnumerator<ModuleButtonEntity> enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ModuleButtonEntity item = enumerator.Current;
                    IEnumerable<ModuleButtonEntity> value = from t in moduleButtonList
                                                            where t.ModuleId.Equals(item.ModuleId)
                                                            select t;
                    dictionary.Add(item.ModuleId, value);
                }
            }
            return dictionary;
        }

        private object GetModuleColumnData()
        {
            IEnumerable<ModuleColumnEntity> moduleColumnList = this.authorizeBLL.GetModuleColumnList(SystemInfo.CurrentUserId);
            IEnumerable<ModuleColumnEntity> enumerable = moduleColumnList.Distinct(new Comparint<ModuleColumnEntity>(new string[]
			{
				"ModuleId"
			}));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            using (IEnumerator<ModuleColumnEntity> enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ModuleColumnEntity item = enumerator.Current;
                    IEnumerable<ModuleColumnEntity> value = from t in moduleColumnList
                                                            where t.ModuleId.Equals(item.ModuleId)
                                                            select t;
                    dictionary.Add(item.ModuleId, value);
                }
            }
            return dictionary;
        }
    }
}
