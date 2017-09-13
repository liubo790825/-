using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-08-03 09:59
    /// �� ����BK_TuiChiBaoDao
    /// </summary>
    public class BK_TuiChiBaoDaoService : RepositoryFactory, BK_TuiChiBaoDaoIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
             var expression = LinqExtensions.True<BK_TuiChiBaoDaoEntity>();
             //�ο�����
             /*var queryParam = queryJson.ToJObject();
             if (!queryParam["�ֶ�1"].IsEmpty()){
                 string FullHead = queryParam["�ֶ�1"].ToString();
                 expression = expression.And(t => t.�ֶ�1.Contains(�ֶ�1));
             }*/
             //������ֶ�2���ֶ�3Ҳ����д...
             return this.BaseRepository(conn).FindList(expression,pagination);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<BK_TuiChiBaoDaoEntity> GetList(string conn, string queryJson)
        {
            var expression = LinqExtensions.True<BK_TuiChiBaoDaoEntity>();
            //�ο�����
            //*
            var queryParam = queryJson.ToJObject();
            if (!queryParam["IdentityCardNo"].IsEmpty())//IdentityCardNo
            {
                string IdentityCardNo = queryParam["IdentityCardNo"].ToString();
                expression = expression.And(t => t.IdentityCardNo.Contains(IdentityCardNo));
            }//*/

            //������ֶ�2���ֶ�3Ҳ����д...

            return this.BaseRepository(conn).IQueryable(expression).ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_TuiChiBaoDaoEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_TuiChiBaoDaoEntity>(keyValue);
        }

               

        /// <summary>
        /// ��ѯ���Ƴٱ���ѧ���༶2017-7-25������
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<BK_TuiChiBaoDaoEntity> GetTuiChiClass(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select distinct TuiChiOther1,TuiChiOther2");
            strsql.Append(@"  FROM BK_TuiChiBaoDao ");
            return this.BaseRepository(conn).FindList<BK_TuiChiBaoDaoEntity>(strsql.ToString()).ToList();
        }

        /// <summary>
        /// ��ѯ�Ƴٱ���ѧ��2017-7-25������
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<M_BK_TuiChiBaoDaoEntity> GetTuiChiInfo(string conn, string keyValue)
        {
            string ClassNo = keyValue;

            if (!ClassNo.IsEmpty())
            {// ��ѯ�Ƴٱ���ѧ��
                ClassNo = ClassNo.ToString();
            }
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select b.*,db.HeadImg,db.StuName,db.NationalityNo,db.telephone,db.ProvinceNo,d.ClassName,d.ClassNo");
            strsql.Append(@"  from BK_TuiChiBaoDao b");
            strsql.Append(@"  left join BK_StuInfo db on db.IdentityCardNo=b.IdentityCardNo");
            strsql.Append(@"  left join BK_ClassInfo d on b.TuiChiOther1=d.ClassNo");
            strsql.Append(@"  where 1=1");

            if (!ClassNo.IsEmpty())
            {
                strsql.Append(string.Format(" and b.TuiChiOther1='{0}'", ClassNo));
            }
            return this.BaseRepository(conn).FindList<M_BK_TuiChiBaoDaoEntity>(strsql.ToString()).ToList();
        }

        //��¼����
        public List<M_BK_NumberEntity> Number(string conn)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(@"  select COUNT(1) number");
            strsql.Append(@"  from BK_TuiChiBaoDao");
            strsql.Append(@"  where 1=1");
            return this.BaseRepository(conn).FindList<M_BK_NumberEntity>(strsql.ToString()).ToList();
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
        public void SaveForm(string conn, string keyValue, BK_TuiChiBaoDaoEntity entity)
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
