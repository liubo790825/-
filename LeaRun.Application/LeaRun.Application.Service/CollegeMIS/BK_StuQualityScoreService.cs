using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util.WebControl;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Util;
using System.Data;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-07 16:20
    /// �� ����ѧ���ۺ����ʼ�¼��
    /// </summary>
    public class BK_StuQualityScoreService : RepositoryFactory<BK_StuQualityScoreEntity>, BK_StuQualityScoreIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuQualityScoreEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_StuQualityScoreEntity>();
             //�ο�����
             var queryParam = queryJson.ToJObject();
             if (!queryParam["QualityId"].IsEmpty()){
                 string QualityId = queryParam["QualityId"].ToString();
                 expression = expression.And(t => t.QualityId.Equals(QualityId));
             }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            //expression = expression.And(t => t.ID > 0);
            return this.BaseRepository(conn).FindList(expression,pagination);
        }
         
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public DataTable GetPageListByDataSet(string conn, Pagination pagination, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select sqs.ID,sqs.QualityId,sqs.StuId,sqs.StuThoughts
                            ,oq.Title,oq.Speaker,oq.RunTime,oq.UnitName,oq.RunAddress,oq.[Description]
                            ,stu.StuNo,stu.StuName,stu.Gender,stu.DeptNo,stu.MajorNo,
                            stu.IdentityCardNo,stu.telephone,stu.ClassNo,stu.Grade
                            ,ci.ClassName,ci.ClassNameFull,ci.ClassTutorNo,ci.ClassDiredctorNo
                            ,m.MajorName,d.DeptName
                             from [dbo].[BK_StuQualityScore] sqs
                            left join [BK_OverallQuality] oq on sqs.QualityId = oq.ID
                            left join BK_StuInfo stu on stu.stuInfoId = sqs.StuId
                            left join BK_ClassInfo ci on ci.ClassNo = stu.ClassNo
                            left join BK_Major m on m.MajorNo = stu.MajorNo
                            left join BK_Dept d on d.DeptNo = stu.DeptNo
                            where 1=1
                        ");
            var queryParam = queryJson.ToJObject();
            if (!queryParam["QualityId"].IsEmpty())
            {
                string QualityId = queryParam["QualityId"].ToString();
                strSql.Append(" and sql.QualityId='" + QualityId + "'");
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                strSql.Append(" and sql.StuId='" + StuId + "'");
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                strSql.Append(" and stu.StuName like '%" + StuName + "%'");
            }
            return this.BaseRepository(conn).FindTable(strSql.ToString(), pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_StuQualityScoreEntity> GetList(string conn, string queryJson)
        {
            return this.BaseRepository(conn).IQueryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuQualityScoreEntity GetEntity(string conn, string keyValue)
        {
            var expression = LinqExtensions.True<BK_StuQualityScoreEntity>();
            //�ο�����
            var queryParam = keyValue.ToJObject();
            if (!queryParam["ID"].IsEmpty())
            {
                string ID = queryParam["ID"].ToString();
                expression = expression.And(t => t.ID.Equals(ID));
            }
            if (!queryParam["QualityId"].IsEmpty())
            {
                string QualityId = queryParam["QualityId"].ToString();
                expression = expression.And(t => t.QualityId.Equals(QualityId));
            }
            if (!queryParam["StuId"].IsEmpty())
            {
                string StuId = queryParam["StuId"].ToString();
                expression = expression.And(t => t.StuId.Equals(StuId));
            }

            return this.BaseRepository(conn).FindEntity(expression); //.FindEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            this.BaseRepository(conn).Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_StuQualityScoreEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                this.BaseRepository(conn).Update(entity);
            }
            else
            {
                entity.Create();
                this.BaseRepository(conn).Insert(entity);
            }
        }
        #endregion
    }
}
