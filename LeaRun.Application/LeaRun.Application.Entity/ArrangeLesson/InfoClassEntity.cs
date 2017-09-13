using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.ArrangeLesson
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� �����ƺͽ�
    /// �� �ڣ�2016-10-24 15:36
    /// �� ����InfoClass
    /// </summary>
    public class InfoClassEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID
        /// </summary>
        /// <returns></returns>
        public int? ClassId { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// У��
        /// </summary>
        /// <returns></returns>
        public string SchoolArea { get; set; }
        /// <summary>
        /// ϵ��
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// ѧ������
        /// </summary>
        /// <returns></returns>
        public int? StuNum { get; set; }
        /// <summary>
        /// ״̬
        /// </summary>
        /// <returns></returns>
        public string Status { get; set; }
        /// <summary>
        /// �ϰ��
        /// </summary>
        /// <returns></returns>
        public string MergeClassNo { get; set; }
        /// <summary>
        /// �ϰ���
        /// </summary>
        /// <returns></returns>
        public string MergeClassname { get; set; }
        /// <summary>
        /// �Ƿ�ϰ�
        /// </summary>
        /// <returns></returns>
        public byte? IsMerged { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ClassId = 0;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            //this.ClassId = keyValue;
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.ClassId = keyValue;

        }
        #endregion
    }
}