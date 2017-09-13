using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.CollegeMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-11 14:25
    /// �� ����ѧ�������¼
    /// </summary>
    public class BK_StuChangeClassRecEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string ID { get; set; }
        /// <summary>
        /// ѧ��ID��
        /// </summary>
        /// <returns></returns>
        public string StuId { get; set; }
        /// <summary>
        /// ԭ�༶ID��
        /// </summary>
        /// <returns></returns>
        public string Old_ClassId { get; set; }
        /// <summary>
        /// ԭ�༶��
        /// </summary>
        /// <returns></returns>
        public string Old_ClassNo { get; set; }
        /// <summary>
        /// �°༶ID��
        /// </summary>
        /// <returns></returns>
        public string New_ClassId { get; set; }
        /// <summary>
        /// �°༶��
        /// </summary>
        /// <returns></returns>
        public string New_ClassNo { get; set; }
        /// <summary>
        /// ����ԭ��
        /// </summary>
        /// <returns></returns>
        public string ChangeRemark { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? ChangeDate { get; set; }
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
        /// ԭԺϵID��
        /// </summary>
        /// <returns></returns>
        public string Old_DeptId { get; set; }

        /// <summary>
        /// ԭԺϵ��
        /// </summary>
        /// <returns></returns>
        public string Old_DeptNo { get; set; }
        /// <summary>
        /// ת��ԺϵID��
        /// </summary>
        /// <returns></returns>
        public string New_DeptId { get; set; }
        /// <summary>
        /// ת��Ժϵ��
        /// </summary>
        /// <returns></returns>
        public string New_DeptNo { get; set; }
        /// <summary>
        /// ԭרҵID��
        /// </summary>
        /// <returns></returns>
        public string Old_MajorId { get; set; }
        /// <summary>
        /// ԭרҵ��
        /// </summary>
        /// <returns></returns>
        public string Old_MajorNo { get; set; }
        /// <summary>
        /// ��רҵID��
        /// </summary>
        /// <returns></returns>
        public string New_MajorId { get; set; }
        /// <summary>
        /// ��רҵ��
        /// </summary>
        /// <returns></returns>
        public string New_MajorNo { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.ID = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.ChangeDate = DateTime.Now;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.ID = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}