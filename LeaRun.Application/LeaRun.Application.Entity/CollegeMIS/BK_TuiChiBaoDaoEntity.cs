using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-03 09:59
    /// �� ����BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string TuiChiId { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// �Ƴٱ���ԭ��
        /// </summary>
        /// <returns></returns>
        public string Reason { get; set; }
        /// <summary>
        /// �Ƴٱ���ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? TuiChiTime { get; set; }
        /// <summary>
        /// �ύ��¼ʱ��
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther { get; set; }
        /// <summary>
        /// �༶��ClassNo
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther1 { get; set; }
        /// <summary>
        /// �༶��ClassName
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther2 { get; set; }
        /// <summary>
        /// TuiChiOther3
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther3 { get; set; }
        /// <summary>
        /// TuiChiOther4
        /// </summary>
        /// <returns></returns>
        public string TuiChiOther4 { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.TuiChiId = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.TuiChiId = keyValue;
                                    
        }
        #endregion
    }
}