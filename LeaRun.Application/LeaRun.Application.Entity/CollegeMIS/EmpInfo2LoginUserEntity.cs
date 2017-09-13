using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-17 10:36
    /// �� ������ְԱ���˺�����
    /// </summary>
    public class EmpInfo2LoginUserEntity : BaseEntity
    {
        //TitleOfTechPost,DeptName,EmpFullTile,EmpSort
        #region ʵ���Ա
        /// <summary>
        /// ְ����
        /// </summary>
        /// <returns></returns>
        public string EmpNo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string EmpName { get; set; }
        /// <summary>
        /// �Ա����
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// ר��ְ
   
        /// </summary>
        /// 
        /// <returns></returns>
        public string EmpFullTime { get; set; }
        /// <summary>
        /// ��ְ�����
        /// </summary>
        /// <returns></returns>
        public string EmpSort { get; set; }
        /// <summary>
        /// ϵ�������ţ�����
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        
        /// <summary>
        /// Ƹ��ְ�ƴ���
        /// </summary>
        /// <returns></returns>
        public string TitleOfTechPost { get; set; }
        
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
       
      /// <summary>
      /// ְ����
      /// </summary>
        public string Zhiwugongzhong { get; set; }

        public string CheckMark { get; set; }

        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.EmpNo = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.EmpNo = keyValue;
        }
        #endregion
    }
}