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
    public class BK_CancelAppEntity : BaseEntity
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