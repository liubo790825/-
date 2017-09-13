using LeaRun.Application.Entity.HVSMIS;
using LeaRun.Application.Busines.HVSMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace LeaRun.Application.Web.Areas.HVSMIS.Controllers
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-13 12:14
    /// �� �����̹������˻�
    /// </summary>
    public class EmpInfo2AccountController : MvcControllerBase
    {
        private EmpInfo2AccountBLL empinfo2accountbll = new EmpInfo2AccountBLL();

        #region ��ͼ����
        /// <summary>
        /// �б�ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// ��ҳ��
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }
        #endregion

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�Json</returns>
        [HttpGet]
        public ActionResult GetListJson(string queryJson)
        {
            var data = empinfo2accountbll.GetList(queryJson);
            LeaRun.Application.Busines.BaseManage.UserBLL ubll = new Busines.BaseManage.UserBLL();
            //LeaRun.Application.Busines.BaseManage.RoleBLL rbll = new Busines.BaseManage.RoleBLL();

            //var accdata = ubll.GetAllUsersTable();
            var accudata = ubll.GetAllList();
            //var rdata = rbll.GetAllList();
            List<LeaRun.Application.Entity.BaseManage.UserEntity> accdata = accudata as List<LeaRun.Application.Entity.BaseManage.UserEntity>;//�����˻�
            //List<LeaRun.Application.Entity.BaseManage.RoleEntity> urdata = rdata as List<LeaRun.Application.Entity.BaseManage.RoleEntity>;//���н�ɫ
            foreach (var item in data)
            {
                //item.CheckMark = "0";//�޵�¼�˺�
                var flag= accdata.Find(s => s.EnCode == item.EmpNo);
                if (flag != null)
                {
                    item.CheckMark = "1";//�Ѵ����˺�                    
                    var oPassword = Md5Helper.MD5(DESEncrypt.Encrypt(Md5Helper.MD5("123456", 32).ToLower(), flag.Secretkey).ToLower(), 32).ToLower();
                    if (flag.Password== oPassword)//123456
                        item.CheckMark += "2";//δ������
                    if (flag.EnabledMark == 0)
                        item.CheckMark += "9";//�ѽ���
                    if (flag.DeleteMark == 1)
                        item.CheckMark += "3";//��ɾ���˺�


                }
                else
                    item.CheckMark = "0";//�޵�¼�˺�
            }
            return ToJsonResult(data);
        }
        /// <summary>
        /// ��ȡʵ�� 
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns>���ض���Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = empinfo2accountbll.GetEntity(keyValue);
            return ToJsonResult(data);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ���������޵�¼�˻���Ա��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateLoginUser(string keyValue)
        {
            var data = empinfo2accountbll.GetList("");
            LeaRun.Application.Busines.BaseManage.UserBLL ubll = new Busines.BaseManage.UserBLL();
            LeaRun.Application.Busines.BaseManage.RoleBLL rbll = new Busines.BaseManage.RoleBLL();
            LeaRun.Application.Busines.BaseManage.DepartmentBLL dbll = new Busines.BaseManage.DepartmentBLL();
            LeaRun.Application.Busines.BaseManage.UserGroupBLL  ugbll = new Busines.BaseManage.UserGroupBLL();
            LeaRun.Application.Busines.BaseManage.PostBLL pbll = new Busines.BaseManage.PostBLL();
            LeaRun.Application.Busines.BaseManage.JobBLL jbll = new Busines.BaseManage.JobBLL();

            var accudata = ubll.GetAllList();
            var rdata = rbll.GetAllList();

            var ddata = dbll.GetList();
            var rugdata = ugbll.GetAllList();
            var rpdata = pbll.GetAllList();
            var rjdata = jbll.GetList();

            List<LeaRun.Application.Entity.BaseManage.UserEntity> accdata = accudata as List<LeaRun.Application.Entity.BaseManage.UserEntity>;//�����˻�
            List<LeaRun.Application.Entity.BaseManage.RoleEntity> urdata = rdata as List<LeaRun.Application.Entity.BaseManage.RoleEntity>;//���н�ɫ

            List<LeaRun.Application.Entity.BaseManage.DepartmentEntity> dlist = ddata as List<LeaRun.Application.Entity.BaseManage.DepartmentEntity>;//���в���
            List<LeaRun.Application.Entity.BaseManage.RoleEntity> rglist = rugdata as List<LeaRun.Application.Entity.BaseManage.RoleEntity>;//������
            List<LeaRun.Application.Entity.BaseManage.RoleEntity> rplist = rpdata as List<LeaRun.Application.Entity.BaseManage.RoleEntity>;//����ְλ
            List<LeaRun.Application.Entity.BaseManage.RoleEntity> rwlist = rjdata as List<LeaRun.Application.Entity.BaseManage.RoleEntity>;//���й���

            int counter = 0;
            foreach (var item in data)
            {
                //item.CheckMark = "0";//�޵�¼�˺�
                var flag = accdata.Find(s => s.EnCode == item.EmpNo);
                if (flag == null)
                {
                    //bool IsOk = roleBLL.ExistFullName(FullName, keyValue);
                    var loginusers=accdata.FindAll(s => s.RealName == item.EmpName);
                    var testuser = ((List<LeaRun.Application.Entity.HVSMIS.EmpInfo2AccountEntity>)data).FindAll(s => s.EmpName == item.EmpName);
                    //foreach (var iu in loginusers)
                    if(testuser.Count > 1)
                    {
                        //if(iu.EnCode==item.EmpNo)//��Ȼ�������������˺�
                        //{
                        //    continue;
                        //}
                        //else
                        {
                            //�������޸������˺�
                            //������¼�˺�
                            //����                            

                            LeaRun.Application.Entity.BaseManage.UserEntity ue = new Entity.BaseManage.UserEntity();
                            //if (testuser.Count >= 1)
                            //{
                            //    ue.Account = item.EmpName + Convert.ToDateTime(item.Birthday).ToString("yy");
                            //}
                            //if (testuser.Count >= 1)
                            //{
                            //    ue.Account = item.EmpName + Convert.ToDateTime(item.Birthday).ToString("Md");
                            //}
                            //if (testuser.Count >= 5)
                            {
                                ue.Account = item.EmpName + Convert.ToDateTime(item.Birthday).ToString("yyMd");
                            }
                            ue.EnCode = item.EmpNo;
                            ue.RealName = ue.Account;// item.EmpName;
                            ue.NickName = item.EmpName;
                            ue.Gender = item.Gender == "��" ? 1 : 0;
                            ue.Birthday = item.Birthday;
                            ue.CreateDate = System.DateTime.Now;

                            var d = dlist.Find(s => s.FullName == item.Department);
                            ue.DepartmentId = d==null?"":d.DepartmentId;
                            var r = rplist.Find(s => s.FullName == item.EmpPosition);
                            ue.PostId = r==null?"":r.RoleId;
                            ue.PostName = r == null ? "" : r.FullName;// item.EmpPosition;

                            //ue.Secretkey = "ef83b6525ed3f7f0";
                            ue.Password = "123456";//123456
                            ubll.SaveForm("", ue);
                            ++counter;
                        }
                    }
                    if(testuser.Count==1)
                    {
                        //�������޸������˺�
                        //������¼�˺�
                        //����
                        LeaRun.Application.Entity.BaseManage.UserEntity ue = new Entity.BaseManage.UserEntity();
                        ue.Account = item.EmpName;
                        ue.EnCode = item.EmpNo;
                        ue.RealName = ue.Account;// item.EmpName;
                        ue.NickName = item.EmpName;
                        ue.Gender = item.Gender == "��" ? 1 : 0;
                        ue.Birthday = item.Birthday;
                        ue.CreateDate = System.DateTime.Now;

                        var d = dlist.Find(s => s.FullName == item.Department);
                        ue.DepartmentId = d == null ? "" : d.DepartmentId;
                        var r = rplist.Find(s => s.FullName == item.EmpPosition);
                        ue.PostId = r == null ? "" : r.RoleId;
                        ue.PostName = r == null ? "" : r.FullName;// item.EmpPosition;

                        //ue.Secretkey = "ef83b6525ed3f7f0";
                        ue.Password = "123456";//123456
                        ubll.SaveForm("", ue);
                        ++counter;
                    }
                }
            }
            return Success(string.Format("�ɹ�����{0}��Ա���˺š�", counter));
        }
        
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, EmpInfo2AccountEntity entity)
        {
            empinfo2accountbll.SaveForm(keyValue, entity);
            return Success("�����ɹ���");
        }
        #endregion
    }
}
