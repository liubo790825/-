using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 16:20
    /// �� ������ʱ��Ϊ��ϲ�ѯ
    /// </summary>
    public class BK_StuQSEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// �ۺ�����ID��
        /// </summary>
        /// <returns></returns>
        public string QualityId { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// DeleteMark
        /// </summary>
        /// <returns></returns>
        public int? DeleteMark { get; set; }
        /// <summary>
        /// EnabledMark
        /// </summary>
        /// <returns></returns>
        public int? EnabledMark { get; set; }
        /// <summary>
        /// ����֮��������
        /// </summary>
        /// <returns></returns>
        public string StuThoughts { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// CreateUserId
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// CreateUserName
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// ModifyDate
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// ModifyUserId
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// ModifyUserName
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        /// <summary>
        /// �����
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string Speaker { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? RunTime { get; set; }
        /// <summary>
        /// �ٰ쵥λ
        /// </summary>
        /// <returns></returns>
        public string UnitName { get; set; }
        /// <summary>
        /// �ٰ�ص�
        /// </summary>
        /// <returns></returns>
        public string RunAddress { get; set; }
        /// <summary>
        /// ��Ҫ���ݡ���Ҫ�۵������
        /// </summary>
        /// <returns></returns>
        public string Description { get; set; }
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
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// ϵ����
        /// </summary>
        /// <returns></returns>
        public string DeptNo { get; set; }
        /// <summary>
        /// רҵ��
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string IdentityCardNo { get; set; }
        /// <summary>
        /// �绰
        /// </summary>
        /// <returns></returns>
        public string telephone { get; set; }
        /// <summary>
        /// �༶��
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// �꼶
        /// </summary>
        /// <returns></returns>
        public string Grade { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// �༶ȫ��
        /// </summary>
        /// <returns></returns>
        public string ClassNameFull { get; set; }
        /// <summary>
        /// ClassTutorNo
        /// </summary>
        /// <returns></returns>
        public string ClassTutorNo { get; set; }
        /// <summary>
        /// ClassDiredctorNo
        /// </summary>
        /// <returns></returns>
        public string ClassDiredctorNo { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// ����ϵ��
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
           
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
           

        }
        #endregion
    }
}