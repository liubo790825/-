using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.FormManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-25 14:27
    /// �� ������ģ�����ݱ�
    /// </summary>
    public class Form_ModuleContentEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }
        /// <summary>
        /// ��ģ��ID
        /// </summary>
        /// <returns></returns>
        public string FrmId { get; set; }
        /// <summary>
        /// ���汾��
        /// </summary>
        /// <returns></returns>
        public string FrmVersion { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string FrmContent { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;
                                    
        }
        #endregion
    }
}