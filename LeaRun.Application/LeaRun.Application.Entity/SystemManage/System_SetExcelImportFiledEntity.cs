using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.SystemManage
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-12 10:57
    /// �� �������ݵ�����ϸ����
    /// </summary>
    public class System_SetExcelImportFiledEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ID��
        /// </summary>
        /// <returns></returns>
        public string F_Id { get; set; }
        /// <summary>
        /// ����ģ��Id
        /// </summary>
        /// <returns></returns>
        public string F_ImportTemplateId { get; set; }
        /// <summary>
        /// �ֵ�����
        /// </summary>
        /// <returns></returns>
        public string F_FliedName { get; set; }
        /// <summary>
        /// �ֶ�����
        /// </summary>
        /// <returns></returns>
        public string F_FiledType { get; set; }
        /// <summary>
        /// Excel����
        /// </summary>
        /// <returns></returns>
        public string F_ColName { get; set; }
        /// <summary>
        /// Ψһ����֤:0Ҫ,1��Ҫ
        /// </summary>
        /// <returns></returns>
        public bool? F_OnlyOne { get; set; }
        /// <summary>
        /// ��������0:�޹���,1:GUID,2:�����ֵ�3:���ݱ�;4:�̶���ֵ;5:������ID;6:����������;7:����ʱ��;
        /// </summary>
        /// <returns></returns>
        public int? F_RelationType { get; set; }
        /// <summary>
        /// �����ֵ���
        /// </summary>
        /// <returns></returns>
        public string F_DataItemEncode { get; set; }
        /// <summary>
        /// �̶�����
        /// </summary>
        /// <returns></returns>
        public string F_Value { get; set; }
        /// <summary>
        /// ������id
        /// </summary>
        /// <returns></returns>
        public string F_DbId { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string F_DbTable { get; set; }
        /// <summary>
        /// �����ֶ�
        /// </summary>
        /// <returns></returns>
        public string F_DbSaveFlied { get; set; }
        /// <summary>
        /// �����ֶ�
        /// </summary>
        /// <returns></returns>
        public string F_DbRelationFlied { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public int? F_SortCode { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.F_Id = Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                    
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.F_Id = keyValue;
                                    
        }
        #endregion
    }
}