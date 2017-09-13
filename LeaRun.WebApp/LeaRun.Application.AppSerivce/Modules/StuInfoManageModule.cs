using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Application.Busines.CustomerManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Entity.CustomerManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace LeaRun.Application.AppSerivce
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技
    /// 创建人：陈彬彬
    /// 日 期：2016.05.12 13:57
    /// 描 述:客户管理接口
    /// </summary>
    public class StuInfoManageModule : BaseModule
    {
        private BK_StuInfoBLL stuinfobll = new BK_StuInfoBLL();
        //...

        public StuInfoManageModule()
            : base("/learun/api")
        {
            Post["/StuInfoManage/freshStuList"] = FreshStuList;//对应learun-config.js中的配置路径
        }
        /// <summary>
        /// 获取新生列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator FreshStuList(dynamic _)
        {
            try
            {
                List<NewStu> NewStuList = new List<NewStu>();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                
                //参考代码
                string[] classnolist=new string[1];
            var queryParam = recdata.data.queryData.ToJObject();
            if (queryParam["ClassNo"]!=null && queryParam["ClassNo"].ToString()!="")
            {
                classnolist = queryParam["ClassNo"].ToString().Split(',');
            }

                
             

                foreach (var classNo in classnolist)
                    {
                        var data = stuinfobll.GetPageList(null, "{\"ClassNo\":\"" + classNo + "\"}");
                        NewStu d = new NewStu();
                        d.classno = classNo;
                        d.childEntity = data;
                        NewStuList.Add(d);
                    }
                    var temp = this.SendData(NewStuList, recdata.userid, recdata.token, ResponseType.Success);
                    return temp;
            }

            catch(System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常"+e.Message);
            }

        }
        
    }
}

public class NewStu
{
    public string classno { get; set; }
    public IEnumerable<BK_StuInfoEntity> childEntity { get; set; }
}