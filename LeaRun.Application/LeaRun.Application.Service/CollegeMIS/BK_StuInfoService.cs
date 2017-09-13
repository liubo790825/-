using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-06 09:47
    /// �� �����������ݵ���      ����ȷ�Ϻ��ѧ�����ݵ��뵽�˱���      ͬʱ�ְࣨ�����ţ� ��ѧ��
    /// </summary>
    public class BK_StuInfoService : RepositoryFactory, BK_StuInfoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ѧ�����ֻ���¼(by allen)
        /// </summary>
        /// <param name="username">���֤��</param>
        /// <param name="pass">����</param>
        /// <returns></returns>
        public BK_StuInfoEntity StuLogin(string conn, string username, string pass)
        {
            //return this.BaseRepository(conn).FindEntity<BK_StuInfoEntity>(keyValue);
            var expression = LinqExtensions.True<BK_StuInfoEntity>();
            expression = expression.And(t => t.IdentityCardNo == username);
            expression = expression.And(t => t.StuPwd == pass);
            //expression = expression.Or(t => t.telephone == username);
            return this.BaseRepository(conn).FindEntity(expression);

        }

        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public DataTable GetTablePageList(string conn, Pagination pagination, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@" select s.* 
                            ,d.DeptName,m.MajorName,md.MajorDetailName  as MDName,c.ClassName
                            ,db.bedno,db.BedName,db.BedId
                            ,dorm.DormName, dorm.DormNo
                            ,df.DormFloorsNo,df.DormFloorsName
                            ,du.DormUnitNo,du.DormUnitName
                            ,bu.DormBuildingName
                            from BK_StuInfo s
                            left join BK_Dept d on s.DeptNo = d.DeptNo
                            left join BK_Major m on s.MajorNo=m.MajorNo
                            left join BK_MajorDetail md on s.MajorDetailNok = md.MajorDetailNo
                            left join BK_ClassInfo c on s.ClassNo = c.ClassNo
							left join BK_DormBed db on db.StuId= s.stuInfoId
                            left join BK_Dorm dorm on db.DormId = dorm.DormId
                            left join BK_DormFloors df on db.DormFloorsId = df.DormFloorsId
                            left join BK_DormUnit du on du.DormUnitId = db.DormUnitId
                            left join BK_DormBuilding bu on bu.DormBuildingId = db.DormBuildingId
                            where 1=1
                            "); //left join BK_StuClass sc on sc.stuInfoId = s.stuInfoId
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["NewStuReport"].IsEmpty())
            {
                int NewStuReport = queryParam["NewStuReport"].ToInt();
                strSql.Append(string.Format(" and NewStuReport='{0}'", NewStuReport));
            }
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                string stuInfoId = queryParam["stuInfoId"].ToString();
                strSql.Append(string.Format(" and s.stuInfoId='{0}'", stuInfoId));
            }
            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                strSql.Append(string.Format(" and s.StuNo='{0}'", StuNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                strSql.Append(string.Format(" and s.StuName like '%{0}%'", StuName));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                strSql.Append(string.Format(" and s.NoticeNo = '{0}'", NoticeNo));
            }
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        strSql.Append(string.Format(" and s.NoticeNo = '{0}'", keyord));
                        break;
                    case "StuNo":          //ѧ��
                        strSql.Append(string.Format(" and s.StuNo = '{0}'", keyord));
                        break;
                    case "StuName":          //����
                        strSql.Append(string.Format(" and s.StuName like '%{0}%'", keyord));
                        break;
                    case "IdentityCardNo":          //���֤��
                        strSql.Append(string.Format(" and s.IdentityCardNo = '{0}'", keyord));
                        break;
                    default:
                        break;
                }
            }

            //������ֶ�2���ֶ�3Ҳ����д...
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindTable(strSql.ToString());
            }
            return this.BaseRepository(conn).FindTable(strSql.ToString(),  pagination); 
        }
        /// <summary>
        /// ����������ͳ����������������
        /// </summary>
        /// <param name="conn">�����ַ���</param>
        /// <param name="pagination">ҳ����</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns></returns>
        public DataTable GetNewStuCountPageList(string conn, Pagination pagination, string queryJson)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DeptNo,MajorNo,count(MajorNo) as StuCount from BK_StuInfo where 1=1  ");
            var queryParam = queryJson.ToJObject();
            if (!queryParam["StartTime"].IsEmpty() && !queryParam["EndTime"].IsEmpty())
            {
                string StartTime = queryParam["StartTime"].ToString()+" 00:00:00";
                string EndTime = queryParam["EndTime"].ToString() + " 23:59:59";
                strSql.Append(string.Format(" and NewStuReportDatetime between '{0}' and '{1}'", StartTime, EndTime));
            }
            strSql.Append(" group by DeptNo, MajorNo");
            return this.BaseRepository(conn).FindTable(strSql.ToString(), pagination);
        }


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuInfoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuInfoEntity>();

            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["NewStuReport"].IsEmpty())
            {
                int NewStuReport = queryParam["NewStuReport"].ToInt();
                expression = expression.And(t => t.NewStuReport == NewStuReport);
            }

            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Contains(StuNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Contains(NoticeNo));
            }
            if (!queryParam["ClassNo"].IsEmpty())
            {
                string ClassNo = queryParam["ClassNo"].ToString();
                expression = expression.And(t => t.ClassNo.Equals(ClassNo));
            }
            if (!queryParam["MajorNo"].IsEmpty())
            {
                string MajorNo = queryParam["MajorNo"].ToString();
                expression = expression.And(t => t.MajorNo.Equals(MajorNo));
            }
            if (!queryParam["DeptNo"].IsEmpty())
            {
                string DeptNo = queryParam["DeptNo"].ToString();
                expression = expression.And(t => t.DeptNo.Equals(DeptNo));
            }


            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        expression = expression.And(t => t.NoticeNo.Contains(keyord));
                        break;
                    case "StuNo":          //���֤��
                        expression = expression.And(t => t.StuNo.Contains(keyord));
                        break;
                    case "StuName":          //����
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    case "IdentityCardNo":          //���֤��
                        expression = expression.And(t => t.IdentityCardNo.Contains(keyord));
                        break;
                    case "ClassNo":
                        expression = expression.And(t => t.ClassNo.Contains(keyord));
                        break;
                    default:
                        break;
                }
            }
            if (pagination==null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public List<BK_StuInfoEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuInfoEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["newstu"].IsEmpty())
            {//��ѯ��������,δ�鵵�Ͱ༶��Ϊ�յ�ѧ�����ְ���
               // expression = expression.And(t => t.GuiDangMark=="δ�鵵" && string.IsNullOrEmpty( t.ClassNo));// (t.PrintNotice == null || t.PrintNotice == 0) && string.IsNullOrEmpty(t.StuNo));
                expression = expression.And(t => t.StuOther.Equals("δ�ְ�"));//��ѯ����δ�ְ��ѧ��
            }

            if (!queryParam["nostuno"].IsEmpty())
            {//��ѯѧ��Ϊ�յ�����
                expression = expression.And(t => string.IsNullOrEmpty(t.StuNo));
            }
            if (!queryParam["MajorDetailNok"].IsEmpty())
            {//��ѯѧ����רҵ����
                string majordetno = queryParam["MajorDetailNok"].ToString();
                expression = expression.And(t => t.MajorDetailNok.Equals(majordetno));
            }
            //������ֶ�2���ֶ�3Ҳ����д...
            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        expression = expression.And(t => t.NoticeNo.Contains(keyord));
                        break;
                    case "StuNo":          //���֤��
                        expression = expression.And(t => t.StuNo.Contains(keyord));
                        break;
                    case "StuName":          //����
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    case "IdentityCardNo":          //���֤��
                        expression = expression.And(t => t.IdentityCardNo.Contains(keyord));
                        break;
                    default:
                        break;
                }
            }
            return this.BaseRepository(conn).FindList(expression).ToList();
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_StuInfoEntity>(keyValue);
        }

        /// <summary>
        /// ����������ȡʵ��
        /// </summary>
        /// <param name="queryJson">����ֵ</param>
        /// <returns></returns>
        public BK_StuInfoEntity GetEntityByWhere(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuInfoEntity>();

            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                string stuInfoId = queryParam["stuInfoId"].ToString();
                expression = expression.And(t => t.stuInfoId.Equals(stuInfoId));
            }

            if (!queryParam["NewStuReport"].IsEmpty())
            {
                int NewStuReport = queryParam["NewStuReport"].ToInt();
                expression = expression.And(t => t.NewStuReport == NewStuReport);
            }

            if (!queryParam["StuNo"].IsEmpty())
            {
                string StuNo = queryParam["StuNo"].ToString();
                expression = expression.And(t => t.StuNo.Contains(StuNo));
            }
            if (!queryParam["StuName"].IsEmpty())
            {
                string StuName = queryParam["StuName"].ToString();
                expression = expression.And(t => t.StuName.Contains(StuName));
            }
            if (!queryParam["NoticeNo"].IsEmpty())
            {
                string NoticeNo = queryParam["NoticeNo"].ToString();
                expression = expression.And(t => t.NoticeNo.Contains(NoticeNo));
            }
            if (!queryParam["ClassNo"].IsEmpty())
            {
                string ClassNo = queryParam["ClassNo"].ToString();
                expression = expression.And(t => t.ClassNo.Equals(ClassNo));
            }
            if (!queryParam["MajorNo"].IsEmpty())
            {
                string MajorNo = queryParam["MajorNo"].ToString();
                expression = expression.And(t => t.MajorNo.Equals(MajorNo));
            }
            if (!queryParam["DeptNo"].IsEmpty())
            {
                string DeptNo = queryParam["DeptNo"].ToString();
                expression = expression.And(t => t.DeptNo.Equals(DeptNo));
            }


            //��ѯ����
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyord = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "NoticeNo":            //֪ͨ���
                        expression = expression.And(t => t.NoticeNo.Equals(keyord));
                        break;
                    case "StuNo":          //���֤��
                        expression = expression.And(t => t.StuNo.Equals(keyord));
                        break;
                    case "StuName":          //����
                        expression = expression.And(t => t.StuName.Contains(keyord));
                        break;
                    case "IdentityCardNo":          //���֤��
                        expression = expression.And(t => t.IdentityCardNo.Equals(keyord));
                        break;
                    case "ClassNo":
                        expression = expression.And(t => t.ClassNo.Contains(keyord));
                        break;
                    default:
                        break;
                }
            }
            return this.BaseRepository(conn).FindEntity<BK_StuInfoEntity>(expression);
        }

        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_StuSocRelaEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_StuSocRelaEntity>("select * from BK_StuSocRela where stuInfoId='" + keyValue + "'");
        }





        /// <summary>
        /// ��ѯ�ҵ�����2017-7-20������
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson">�ҵ�ID��</param>
        /// <returns></returns>
        public List<M_BK_DormStuInfoEntity> GetMyDormers(string conn, string queryJson)
        {
            string stuInfoId = "";
            var queryParam = queryJson.ToJObject();
            if (!queryParam["stuInfoId"].IsEmpty())
            {
                stuInfoId = queryParam["stuInfoId"].ToString();
            }

            StringBuilder strsql = new StringBuilder();   
            strsql.Append(@"  select s.*,db.BedName from BK_StuInfo s");
            strsql.Append(@"  left join BK_DormBed db on db.StuId=s.stuInfoId");
            strsql.Append(@"  where db.DormId = (
                                    select DormId from BK_DormBed where 1=1");



            strsql.Append(string.Format(" and StuId='{0}')", stuInfoId));
            strsql.Append(string.Format(" and s.stuInfoId !='{0}'", stuInfoId));
            return this.BaseRepository(conn).FindList<M_BK_DormStuInfoEntity>(strsql.ToString()).ToList();
        }


        /// <summary>
        /// ��ѯͬ��ͬѧ
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_StuInfoEntity> GetMyClassmatesList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_StuInfoEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (queryParam["ClassNo"] != null && queryParam["ClassNo"].ToString() != "")
            {//��ѯͬ��ͬѧ
                string ClassNo = queryParam["ClassNo"].ToString();
                expression = expression.And(t => t.ClassNo.Contains(ClassNo));
            }
            //*/
            //������ֶ�2���ֶ�3Ҳ����д...
            expression = expression.And(t => !string.IsNullOrEmpty(t.stuInfoId));
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string conn, string keyValue)
        {
            IRepository db = new RepositoryFactory().BaseRepository(conn).BeginTrans();
            try
            {
                db.Delete<BK_StuInfoEntity>(keyValue);
                db.Delete<BK_StuSocRelaEntity>(t => t.stuInfoId.Equals(keyValue));
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string conn, string keyValue, BK_StuInfoEntity entity, List<BK_StuSocRelaEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //��ϸ,����ȫ��ɾ����Ҫ���Ƿ����ˣ�������ˣ��Ͳ�����ӣ�û�о����
                    if (entryList != null && entryList.Count > 0)
                    {
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.StuSocRelaId))
                            {
                                item.Modify(item.StuSocRelaId);
                                item.stuInfoId = entity.stuInfoId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.stuInfoId = entity.stuInfoId;
                                db.Insert(item);
                            }
                        }
                    }
                }
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);
                    //��ϸ
                    foreach (BK_StuSocRelaEntity item in entryList)
                    {
                        item.Create();
                        item.stuInfoId = entity.stuInfoId;
                        db.Insert(item);
                    }
                }
                db.Commit();
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}
