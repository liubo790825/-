using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-18 15:12
    /// �� �������������¼
    /// </summary>
    public class M_BK_CancelAppEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ����Ҫ������ID��
        /// </summary>
        /// <returns></returns>
        public string AppId { get; set; }
        /// <summary>
        /// ����˻�������
        /// </summary>
        /// <returns></returns>
        public string Checker { get; set; }
        /// <summary>
        /// ����ʱ������ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? CheckerTime { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string CheckState { get; set; }
        /// <summary>
        /// ��ע��˵��
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// ��˽�ɫID��
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ��������ID��
        /// </summary>
        /// <returns></returns>
        public string BehaviorTypeId { get; set; }
        /// <summary>
        /// Υ���Ĳ���
        /// </summary>
        /// <returns></returns>
        public string BreachBehavior { get; set; }
        /// <summary>
        /// Υ��ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? BreachTime { get; set; }
        /// <summary>
        /// �ύ��
        /// </summary>
        /// <returns></returns>
        public string Submiter { get; set; }
        /// <summary>
        /// �Ƿ�����0δ������1���������У�2����
        /// </summary>
        /// <returns></returns>
        public int? IsCanceled { get; set; }
        /// <summary>
        /// ���볷���Ĵ���
        /// </summary>
        /// <returns></returns>
        public int? AppCancel { get; set; }
        /// <summary>
        /// �Ƿ�������볷����������볷��������3�������ߣ������ٴ�����
        /// </summary>
        /// <returns></returns>
        public int? CanCancel { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Ժϵ��
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }



        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
                                    
        }
        #endregion
    }
}