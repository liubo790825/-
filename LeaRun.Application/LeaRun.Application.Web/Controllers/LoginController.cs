using LeaRun.Application.Busines;
using LeaRun.Application.Busines.AuthorizeManage;
using LeaRun.Application.Busines.BaseManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Code;
using LeaRun.Application.Entity;
using LeaRun.Application.Entity.BaseManage;
using LeaRun.Application.Entity.SystemManage;
using LeaRun.Util;
using LeaRun.Util.Attributes;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Xml;

namespace LeaRun.Application.Web.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：J&M
    /// 日 期：2015.09.01 13:32
    /// 描 述：系统登录
    /// </summary>
    [HandlerLogin(LoginMode.Ignore)]
    public class LoginController : MvcControllerBase
    {
        #region 视图功能
        /// <summary>
        /// 默认页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录中转页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckIndex()
        {
            return View();
        }





        #endregion

        #region 提交数据
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult VerifyCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        /// <summary>
        /// 安全退出
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult OutLogin()
        {
            LogEntity logEntity = new LogEntity();
            logEntity.CategoryId = 1;
            logEntity.OperateTypeId = ((int)OperationType.Exit).ToString();
            logEntity.OperateType = EnumAttribute.GetDescription(OperationType.Exit);
            logEntity.OperateAccount = OperatorProvider.Provider.Current().Account;
            logEntity.OperateUserId = OperatorProvider.Provider.Current().UserId;
            logEntity.ExecuteResult = 1;
            logEntity.ExecuteResultJson = "退出系统";
            logEntity.Module = Config.GetValue("SoftName");
            logEntity.WriteLog();
            Session.Abandon();                                          //清除当前会话
            Session.Clear();                                            //清除当前浏览器所有Session
            WebHelper.RemoveCookie("learn_autologin");                  //清除自动登录
            return Content(new AjaxResult { type = ResultType.success, message = "退出系统" }.ToJson());
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="verifycode">验证码</param>
        /// <param name="autologin">下次自动登录</param>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CheckLogin(string username, string password, string verifycode, int autologin)
        
        {
            LogEntity logEntity = new LogEntity();
            logEntity.CategoryId = new int?(1);
            logEntity.OperateTypeId = ((int)OperationType.Login).ToString();
            logEntity.OperateType = EnumAttribute.GetDescription(OperationType.Login);
            logEntity.OperateAccount = username;
            logEntity.OperateUserId = username;
            logEntity.Module = Config.GetValue("SoftName");

            try
            {
                #region 验证码验证
                if (autologin == 0)
                {
                    verifycode = Md5Helper.MD5(verifycode.ToLower(), 16);
                    if (Session["session_verifycode"].IsEmpty() || verifycode != Session["session_verifycode"].ToString())
                    {
                        throw new Exception("验证码错误，请重新输入");
                    }
                }
                #endregion

                #region 第三方账户验证
                //AccountEntity accountEntity = accountBLL.CheckLogin(username, password);
                //if (accountEntity != null)
                //{
                //    Operator operators = new Operator();
                //    operators.UserId = accountEntity.AccountId;
                //    operators.Code = accountEntity.MobileCode;
                //    operators.Account = accountEntity.MobileCode;
                //    operators.UserName = accountEntity.FullName;
                //    operators.Password = accountEntity.Password;
                //    operators.IPAddress = Net.Ip;
                //    operators.IPAddressName = IPLocation.GetLocation(Net.Ip);
                //    operators.LogTime = DateTime.Now;
                //    operators.Token = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                //    operators.IsSystem = true;
                //    OperatorProvider.Provider.AddCurrent(operators);
                //    //登录限制
                //    LoginLimit(username, operators.IPAddress, operators.IPAddressName);
                //    return Success("登录成功。");
                //}
                #endregion

                #region 内部账户验证
                UserEntity userEntity = new UserBLL().CheckLogin(username, password);
                if (userEntity != null)
                {
                    AuthorizeBLL authorizeBLL = new AuthorizeBLL();
                    Operator operators = new Operator();
                    operators.UserId = userEntity.UserId;
                    operators.Code = userEntity.EnCode;
                    operators.Account = userEntity.Account;
                    operators.UserName = userEntity.RealName;
                    operators.Password = userEntity.Password;
                    operators.Secretkey = userEntity.Secretkey;
                    operators.CompanyId = userEntity.OrganizeId;
                    operators.DepartmentId = userEntity.DepartmentId;
                    operators.IPAddress = Net.Ip;
                    operators.IPAddressName = IPLocation.GetLocation(Net.Ip);
                    operators.ObjectId = new PermissionBLL().GetObjectStr(userEntity.UserId);
                    operators.LogTime = DateTime.Now;
                    operators.Token = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    //写入当前用户数据权限
                    AuthorizeDataModel dataAuthorize = new AuthorizeDataModel();
                    dataAuthorize.ReadAutorize = authorizeBLL.GetDataAuthor(operators);
                    dataAuthorize.ReadAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators);
                    dataAuthorize.WriteAutorize = authorizeBLL.GetDataAuthor(operators, true);
                    dataAuthorize.WriteAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators, true);
                    operators.DataAuthorize = dataAuthorize;
                    //判断是否系统管理员
                    if (userEntity.Account == "System" || userEntity.RoleId== "b7a61699-947c-4100-a18d-ddf5eeb6c3dd")//超级管理员
                    {
                        operators.IsSystem = true;
                    }
                    else
                    {
                        operators.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operators);
                    //登录限制

                    LoginLimit(username, operators.IPAddress, operators.IPAddressName);
                    //写入日志
                    logEntity.ExecuteResult = 1;
                    logEntity.ExecuteResultJson = "登录成功";
                    logEntity.WriteLog();
                }
                return Success("登录成功。", userEntity);
                #endregion
            }
            catch (Exception ex)
            {
                WebHelper.RemoveCookie("learn_autologin");                  //清除自动登录
                logEntity.ExecuteResult = -1;
                logEntity.ExecuteResultJson = ex.Message;
                logEntity.WriteLog();
                return Error(ex.Message);
            }
        }

        /// <summary>
        /// 登录验证2
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AjaxOnly]
        public ActionResult CheckLogin2()
        {
            Operator operators = OperatorProvider.Provider.Current();
            if (operators != null)
            {
                var temp = Success("登录成功。", operators);

                return Success("登录成功。", operators);
            }
            return Error("登录失败。");
        }
        
        
        #endregion

        #region 注册账户、登录限制
        private AccountBLL accountBLL = new AccountBLL();
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="mobileCode">手机号码</param>
        /// <returns>返回6位数验证码</returns>
        [HttpGet]
        public ActionResult GetSecurityCode(string mobileCode)
        {
            if (!ValidateUtil.IsValidMobile(mobileCode))
            {
                throw new Exception("手机格式不正确,请输入正确格式的手机号码。");
            }
            var data = accountBLL.GetSecurityCode(mobileCode);
            if (!string.IsNullOrEmpty(data))
            {
                SmsModel smsModel = new SmsModel();
                smsModel.account = Config.GetValue("SMSAccount");
                smsModel.pswd = Config.GetValue("SMSPswd");
                smsModel.url = Config.GetValue("SMSUrl");
                smsModel.mobile = mobileCode;
                smsModel.msg = "验证码 " + data + "，(请确保是本人操作且为本人手机，否则请忽略此短信)";
                SmsHelper.SendSmsByJM(smsModel);
            }
            return Success("获取成功。");
        }
        /// <summary>
        /// 注册账户
        /// </summary>
        /// <param name="mobileCode">手机号</param>
        /// <param name="securityCode">短信验证码</param>
        /// <param name="fullName">姓名</param>
        /// <param name="password">密码（md5）</param>
        /// <param name="verifycode">图片验证码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(string mobileCode, string securityCode, string fullName, string password, string verifycode)
        {
            AccountEntity accountEntity = new AccountEntity();
            accountEntity.MobileCode = mobileCode;
            accountEntity.SecurityCode = securityCode;
            accountEntity.FullName = fullName;
            accountEntity.Password = password;
            accountEntity.IPAddress = Net.Ip;
            accountEntity.IPAddressName = IPLocation.GetLocation(accountEntity.IPAddress);
            accountEntity.AmountCount = 30;
            accountBLL.Register(accountEntity);
            return Success("注册成功。");
        }
        /// <summary>
        /// 登录限制
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="iPAddress">IP</param>
        /// <param name="iPAddressName">IP所在城市</param>
        public void LoginLimit(string account, string iPAddress, string iPAddressName)
        {
            //if (account == "System")
            //{
            //    return;
            //}
            string platform = Net.Browser;
            accountBLL.LoginLimit(platform, account, iPAddress, iPAddressName);
        }
        #endregion





        /// <summary>
        /// 登录验证
        /// </summary>
        /// <returns></returns>
        public ActionResult CAS(string ticket)

        {
            LogEntity logEntity = new LogEntity();
            //try
            //{

                //C#接口例程
                string ServiceURL = "http://localhost:4066/Login/CheckIndex";
                string outStr = "";
                string strNetID = null, strTicket = "", validateUrl = "";
                string CASHost = "http://124.117.237.213:8081/cas/";
            


        strTicket = Request.QueryString["ticket"];
            /*
            if (strTicket == null || strTicket.Length == 0)
            {
                string redir = CASHost + "login?service=" + ServiceURL;
                Response.Redirect(redir);
            }

            //============== read ticket and request validation ==================
            validateUrl = CASHost + "serviceValidate?ticket=" + strTicket + "&service=" + ServiceURL;
            StreamReader Reader = new StreamReader(new WebClient().OpenRead(validateUrl));
            string resp = Reader.ReadToEnd(); //return(resp);
            NameTable nt = new NameTable();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
            XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
            XmlTextReader reader = new XmlTextReader(resp, XmlNodeType.Element, context);
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    string tag = reader.LocalName;
                    if (tag == "user") strNetID = reader.ReadString();
                }
            }
            reader.Close();
            */
            //根据成功获取的strNetID，进行后续处理...
            /*
             http://124.117.237.212:9000
            system
            qj2015

            账号：
            院学工：120169083
            123456

            系学工：
            120069003	盛文婷
            120139040	张玲
            123456


            学生
            http://124.117.237.212:9005/login.aspx
            720130006
            0006
            */
            strNetID = "120169083";
                if (strNetID != null)
                {
                    string username = strNetID;
                    string password = "123456";
                    
                    logEntity.CategoryId = new int?(1);
                    logEntity.OperateTypeId = ((int)OperationType.Login).ToString();
                    logEntity.OperateType = EnumAttribute.GetDescription(OperationType.Login);
                    logEntity.OperateAccount =username;
                    logEntity.OperateUserId = username;
                    logEntity.Module = Config.GetValue("SoftName");

                #region 内部账户验证
                UserEntity userEntity = new UserBLL().CheckLogin(username);//.CheckLogin(username, password);
                    if (userEntity != null)
                    {
                        AuthorizeBLL authorizeBLL = new AuthorizeBLL();
                        Operator operators = new Operator();
                        operators.UserId = userEntity.UserId;
                        operators.Code = userEntity.EnCode;
                        operators.Account = userEntity.Account;
                        operators.UserName = userEntity.RealName;
                        operators.Password = userEntity.Password;
                        operators.Secretkey = userEntity.Secretkey;
                        operators.CompanyId = userEntity.OrganizeId;
                        operators.DepartmentId = userEntity.DepartmentId;
                        operators.IPAddress = Net.Ip;
                        operators.IPAddressName = IPLocation.GetLocation(Net.Ip);
                        operators.ObjectId = new PermissionBLL().GetObjectStr(userEntity.UserId);
                        operators.LogTime = DateTime.Now;
                        operators.Token = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                        //写入当前用户数据权限
                        AuthorizeDataModel dataAuthorize = new AuthorizeDataModel();
                        dataAuthorize.ReadAutorize = authorizeBLL.GetDataAuthor(operators);
                        dataAuthorize.ReadAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators);
                        dataAuthorize.WriteAutorize = authorizeBLL.GetDataAuthor(operators, true);
                        dataAuthorize.WriteAutorizeUserId = authorizeBLL.GetDataAuthorUserId(operators, true);
                        operators.DataAuthorize = dataAuthorize;
                        //判断是否系统管理员
                        if (userEntity.Account == "System" || userEntity.RoleId == "b7a61699-947c-4100-a18d-ddf5eeb6c3dd")//超级管理员
                        {
                            operators.IsSystem = true;
                        }
                        else
                        {
                            operators.IsSystem = false;
                        }
                        OperatorProvider.Provider.AddCurrent(operators);
                        //登录限制

                        LoginLimit(username, operators.IPAddress, operators.IPAddressName);
                        //写入日志
                        logEntity.ExecuteResult = 1;
                        logEntity.ExecuteResultJson = "登录成功";
                        logEntity.WriteLog();
                    }
                    //return Success("登录成功。");
                    Response.Redirect(ServiceURL);

                }
                else
                {
                    string redir = CASHost + "login?service=" + ServiceURL;
                    Response.Redirect(redir);
                }
            return View("Default.cshtml");
                #endregion
            //}
            //catch (Exception ex)
            //{
            //    WebHelper.RemoveCookie("learn_autologin");                  //清除自动登录
            //    logEntity.ExecuteResult = -1;
            //    logEntity.ExecuteResultJson = ex.Message;
            //    logEntity.WriteLog();
            //    //return Error(ex.Message);
            //    //string redir = CASHost + "login?service=" + ServiceURL;
            //    Response.Redirect(ServiceURL);
            //}
        }




    }
}
