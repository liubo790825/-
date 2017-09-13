using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2016-12-26 10:37
    /// �� �������Ž�ɫ
    /// </summary>
    public class Community_RolesEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���Ž�ɫID��
        /// </summary>
        /// <returns></returns>
        public string CR_Id { get; set; }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        /// <returns></returns>
        public string CR_Name { get; set; }
        /// <summary>
        /// ��ɫ��ע
        /// </summary>
        /// <returns></returns>
        public string CR_Remark { get; set; }
        /// <summary>
        /// �Ƿ�ʹ��
        /// </summary>
        /// <returns></returns>
        public bool? CR_Isuse { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public bool? CR_Status { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.CR_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.CR_Id = keyValue;
                                    
        }
        #endregion
    }
}