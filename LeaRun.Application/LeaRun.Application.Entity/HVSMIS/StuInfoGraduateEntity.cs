using System;
using LeaRun.Application.Code;

namespace LeaRun.Application.Entity.HVSMIS
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-10-12 11:41
    /// �� ������ҵ��������Ϣ
    /// </summary>
    public class StuInfoGraduateEntity : BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// ѧ��ID
        /// </summary>
        /// <returns></returns>
        public int? Id { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string StuNo { get; set; }
        /// <summary>
        /// ׼��֤��
        /// </summary>
        /// <returns></returns>
        public string zkzhao { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string StuName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string OldName { get; set; }
        /// <summary>
        /// �Ա�
        /// </summary>
        /// <returns></returns>
        public string Gender { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// ���֤��
        /// </summary>
        /// <returns></returns>
        public string sfzhao { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Nation { get; set; }
        /// <summary>
        /// У������
        /// </summary>
        /// <returns></returns>
        public string SchoolArea { get; set; }
        /// <summary>
        /// ϵ������
        /// </summary>
        /// <returns></returns>
        public string DeptName { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        public string MajorNo { get; set; }
        /// <summary>
        /// רҵ
        /// </summary>
        /// <returns></returns>
        public string MajorName { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassNo { get; set; }
        /// <summary>
        /// �༶����
        /// </summary>
        /// <returns></returns>
        public string ClassName { get; set; }
        /// <summary>
        /// רҵ����
        /// </summary>
        /// <returns></returns>
        public string gzjgong { get; set; }
        /// <summary>
        /// ѧ��
        /// </summary>
        /// <returns></returns>
        public string xzhi { get; set; }
        /// <summary>
        /// ��ѧʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? rxsjian { get; set; }
        /// <summary>
        /// �ڼ���
        /// </summary>
        /// <returns></returns>
        public string InSchoolYear { get; set; }
        /// <summary>
        /// ��ҵ��
        /// </summary>
        /// <returns></returns>
        public string OutSchoolYear { get; set; }
        /// <summary>
        /// �Ļ��̶�
        /// </summary>
        /// <returns></returns>
        public string CultureDegree { get; set; }
        /// <summary>
        /// ʡ��
        /// </summary>
        /// <returns></returns>
        public string Province { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string xsqu { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string ksqkuang { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string bklbie { get; set; }
        /// <summary>
        /// ��ѧ���
        /// </summary>
        /// <returns></returns>
        public string rxlb { get; set; }
        /// <summary>
        /// ԭ��ҵѧУ
        /// </summary>
        /// <returns></returns>
        public string ybyxx { get; set; }
        /// <summary>
        /// ������ò
        /// </summary>
        /// <returns></returns>
        public string PartyFace { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string jguan { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public float? mshi { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public float? cshi { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public float? tce { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public float? yshu { get; set; }
        /// <summary>
        /// Ѫ��
        /// </summary>
        /// <returns></returns>
        public string xxing { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public decimal? sgao { get; set; }
        /// <summary>
        /// ʵϰ����
        /// </summary>
        /// <returns></returns>
        public string PracRegion { get; set; }
        /// <summary>
        /// ʵϰ��λ
        /// </summary>
        /// <returns></returns>
        public string PracUnit { get; set; }
        /// <summary>
        /// ʵϰ��ʼʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? PracStartDate { get; set; }
        /// <summary>
        /// ʵϰ����
        /// </summary>
        /// <returns></returns>
        public string PracType { get; set; }
        /// <summary>
        /// ʵϰ״̬
        /// </summary>
        /// <returns></returns>
        public string PracStatus { get; set; }
        /// <summary>
        /// ʵϰ����
        /// </summary>
        /// <returns></returns>
        public int? PracTimes { get; set; }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        /// <returns></returns>
        public string byzping { get; set; }
        /// <summary>
        /// רҵ�γ�
        /// </summary>
        /// <returns></returns>
        public string zykcheng { get; set; }
        /// <summary>
        /// ��ҵʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? bysjian { get; set; }
        /// <summary>
        /// ��ҵȥ��
        /// </summary>
        /// <returns></returns>
        public string byqxiang { get; set; }
        /// <summary>
        /// ���ּ���֤����Ϣ
        /// </summary>
        /// <returns></returns>
        public string GzjdInfo { get; set; }
        /// <summary>
        /// �ٰ�������
        /// </summary>
        /// <returns></returns>
        public string zazyxiang { get; set; }
        /// <summary>
        /// �س�
        /// </summary>
        /// <returns></returns>
        public string yhtchang { get; set; }
        /// <summary>
        /// ְ��
        /// </summary>
        /// <returns></returns>
        public string zwu { get; set; }
        /// <summary>
        /// ����״��
        /// </summary>
        /// <returns></returns>
        public string jkzkuang { get; set; }
        /// <summary>
        /// �������ڵ�
        /// </summary>
        /// <returns></returns>
        public string hkszdi { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        /// <returns></returns>
        public string hklbie { get; set; }
        /// <summary>
        /// ��ͥͨѶ��ַ
        /// </summary>
        /// <returns></returns>
        public string txdzhi { get; set; }
        /// <summary>
        /// ��ͥ��������
        /// </summary>
        /// <returns></returns>
        public string yzbma { get; set; }
        /// <summary>
        /// ��ͥ�绰����
        /// </summary>
        /// <returns></returns>
        public string dhhma { get; set; }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        /// <returns></returns>
        public string lxren { get; set; }
        /// <summary>
        /// ��ͥ����
        /// </summary>
        /// <returns></returns>
        public string jtcsheng { get; set; }
        /// <summary>
        /// ��ǲʱ��
        /// </summary>
        /// <returns></returns>
        public DateTime? pqsjian { get; set; }
        /// <summary>
        /// ��ǲ֤��
        /// </summary>
        /// <returns></returns>
        public string pqzhao { get; set; }
        /// <summary>
        /// ��ҵ֤��
        /// </summary>
        /// <returns></returns>
        public string byzhao { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        public string fxming { get; set; }
        /// <summary>
        /// ����λ
        /// </summary>
        /// <returns></returns>
        public string fdwei { get; set; }
        /// <summary>
        /// ��ְ��
        /// </summary>
        /// <returns></returns>
        public string fzwu { get; set; }
        /// <summary>
        /// ���绰
        /// </summary>
        /// <returns></returns>
        public string fdhua { get; set; }
        /// <summary>
        /// ĸ����
        /// </summary>
        /// <returns></returns>
        public string mxming { get; set; }
        /// <summary>
        /// ĸ��λ
        /// </summary>
        /// <returns></returns>
        public string mdwei { get; set; }
        /// <summary>
        /// ĸְ��
        /// </summary>
        /// <returns></returns>
        public string mzwu { get; set; }
        /// <summary>
        /// ĸ�绰
        /// </summary>
        /// <returns></returns>
        public string mdhua { get; set; }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        /// <returns></returns>
        public string lxdhua { get; set; }
        /// <summary>
        /// �ֻ�
        /// </summary>
        /// <returns></returns>
        public string Mobile { get; set; }
        /// <summary>
        /// QQ��
        /// </summary>
        /// <returns></returns>
        public string qqnumber { get; set; }
        /// <summary>
        /// ���п���
        /// </summary>
        /// <returns></returns>
        public string BankNo { get; set; }
        /// <summary>
        /// ��ͥ������
        /// </summary>
        /// <returns></returns>
        public string zongsru { get; set; }
        /// <summary>
        /// �˾�����
        /// </summary>
        /// <returns></returns>
        public string junsru { get; set; }
        /// <summary>
        /// �Ƿ�ͱ�
        /// </summary>
        /// <returns></returns>
        public string dibao { get; set; }
        /// <summary>
        /// ������Դ
        /// </summary>
        /// <returns></returns>
        public string srlyuan { get; set; }
        /// <summary>
        /// ��ѧ���־
        /// </summary>
        /// <returns></returns>
        public string StipendMark { get; set; }
        /// <summary>
        /// һ��ͨ��
        /// </summary>
        /// <returns></returns>
        public string ykthao { get; set; }
        /// <summary>
        /// һ��ͨ�˺�
        /// </summary>
        /// <returns></returns>
        public string yktzhao { get; set; }
        /// <summary>
        /// ס����Ϣ
        /// </summary>
        /// <returns></returns>
        public string DormInfo { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        public string PrizeInfo { get; set; }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <returns></returns>
        public string PunishInfo { get; set; }
        /// <summary>
        /// ͼ�������Ϣ
        /// </summary>
        /// <returns></returns>
        public string BooksLend { get; set; }
        /// <summary>
        /// Ƿ����Ϣ
        /// </summary>
        /// <returns></returns>
        public string OweFeeInfo { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string jli { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string bzhu { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        /// <returns></returns>
        public string CheckMark { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        /// <returns></returns>
        public string Col1 { get; set; }
        /// <summary>
        /// ����2
        /// </summary>
        /// <returns></returns>
        public string Col2 { get; set; }
        /// <summary>
        /// ����3
        /// </summary>
        /// <returns></returns>
        public string Col3 { get; set; }
        /// <summary>
        /// shbzhi
        /// </summary>
        /// <returns></returns>
        public string shbzhi { get; set; }
        /// <summary>
        /// lxing
        /// </summary>
        /// <returns></returns>
        public string lxing { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Id = 1;// Guid.NewGuid().ToString();//����ʵ����Ҫȥ�޸�
                                            }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(int keyValue)
        {
            this.Id = keyValue;
                                            }
        #endregion
    }
}