using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.IService.CollegeMIS;
using LeaRun.Data.Repository;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.WebControl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.Application.Service.CollegeMIS
{
    /// <summary>
    /// �� �� 6.1
    /// Copyright (c) 2013-2016 ����Ȫ���Ƽ����޹�˾
    /// �� ����admin
    /// �� �ڣ�2017-06-28 16:41
    /// �� ��������¥��Ϣ
    /// </summary>
    public class BK_DormBuildingService : RepositoryFactory, BK_DormBuildingIService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<BK_DormBuildingEntity> GetPageList(string conn, Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<BK_DormBuildingEntity>();
            //�ο�����
            var queryParam = queryJson.ToJObject();
            if (!queryParam["dormBuildingId"].IsEmpty())//ת��������
            {
                string DormBuildingId = queryParam["dormBuildingId"].ToString();
                expression = expression.And(t => t.DormBuildingId.Equals(DormBuildingId));
            }
            if (!queryParam["dormBuildingNo"].IsEmpty())
            {
                string dormBuildingNo = queryParam["dormBuildingNo"].ToString();
                expression = expression.And(t => t.DormBuildingNo.Equals(dormBuildingNo));
            }

            if (!queryParam["BuildType"].IsEmpty())
            {
                string BuildType = queryParam["BuildType"].ToString();
                expression = expression.And(t => t.BuildType.Equals(BuildType));
            }
            if (!queryParam["DormBuildingNo"].IsEmpty())
            {
                string DormBuildingNo = queryParam["DormBuildingNo"].ToString();
                expression = expression.And(t => t.DormBuildingNo.Equals(DormBuildingNo));
            }
            if (!queryParam["DormBuildingName"].IsEmpty())
            {
                string DormBuildingName = queryParam["DormBuildingName"].ToString();
                expression = expression.And(t => t.DormBuildingName.Contains(DormBuildingName));
            }
            if (pagination == null)
            {
                return this.BaseRepository(conn).FindList(expression);
            }
            return this.BaseRepository(conn).FindList(expression, pagination);
        }


        /// <summary>
        /// ��ѯ���е�¥
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BK_DormBuildingEntity> GetList(string conn)
        {
            var expression = LinqExtensions.True<BK_DormBuildingEntity>();
            return this.BaseRepository(conn).FindList(expression);
        }


        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public BK_DormBuildingEntity GetEntity(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindEntity<BK_DormBuildingEntity>(keyValue);
        }
        /// <summary>
        /// ��ȡ�ӱ���ϸ��Ϣ
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public IEnumerable<BK_DormUnitEntity> GetDetails(string conn, string keyValue)
        {
            return this.BaseRepository(conn).FindList<BK_DormUnitEntity>("select * from BK_DormUnit where DormBuildingId='" + keyValue + "' order by DormUnitName");
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
                db.Delete<BK_DormBuildingEntity>(keyValue);
                db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));
                db.Delete<BK_DormFloorsEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ��¥��
                db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ������
                db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ����λ

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
        public void SaveForm(string conn, string keyValue, BK_DormBuildingEntity entity, List<BK_DormUnitEntity> entryList)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    if (entryList != null && entryList.Count > 0)
                    {
                        //��ϸ
                        foreach (var item in entryList)
                        {
                            if (!string.IsNullOrEmpty(item.DormUnitId))
                            {
                                item.Modify(item.DormUnitId);
                                item.DormBuildingId = entity.DormBuildingId;
                                db.Update(item);
                            }
                            else
                            {
                                item.Create();
                                item.DormBuildingId = entity.DormBuildingId;
                                db.Insert(item);
                            }
                        }
                    }
                    //db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));                  
                }
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);
                    //��ϸ
                    foreach (BK_DormUnitEntity item in entryList)
                    {
                        item.Create();
                        item.DormBuildingId = entity.DormBuildingId;
                        db.Insert(item);
                    }
                }
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
        public void SaveForm(string conn, string keyValue, BK_DormBuildingEntity entity)
        {
            IRepository db = this.BaseRepository(conn).BeginTrans();
            try
            {
                #region �޸�����
                if (!string.IsNullOrEmpty(keyValue))
                {
                    //����
                    entity.Modify(keyValue);
                    db.Update(entity);
                    //��ϸ    
                    //��ɾ���������´���   
                   
                    db.Delete<BK_DormUnitEntity>(t => t.DormBuildingId.Equals(keyValue));//���ɾ����Ԫ��Ϣ
                    db.Delete<BK_DormFloorsEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ��¥��
                    db.Delete<BK_DormEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ������
                    db.Delete<BK_DormBedEntity>(t => t.DormBuildingId.Equals(keyValue));//��ɾ����λ

                    List<BK_DormUnitEntity> unitList = new List<BK_DormUnitEntity>();
                    List<BK_DormFloorsEntity> floorList = new List<BK_DormFloorsEntity>();
                    List<BK_DormEntity> dormList = new List<BK_DormEntity>();
                    List<BK_DormBedEntity> bedList = new List<BK_DormBedEntity>();

                    #region ��ӵ�Ԫ����
                    if (entity.UnitCount > 0)//��Ԫ����
                    {
                        for (int i = 0; i < entity.UnitCount; i++)
                        {
                            BK_DormUnitEntity dunit = new BK_DormUnitEntity();
                            dunit.DormBuildingId = entity.DormBuildingId;
                            // dunit.DormUnitId = Guid.NewGuid().ToString(); //���ɵ�Ԫ��ID��
                            dunit.DormUnitName = (i + 1) + "��Ԫ";
                            dunit.DormUnitNo = (i + 1) + "��Ԫ";
                            if (entity.BuildType.Equals("������")) //����¥������������Ů��������£��Ϳ���Ԫ�Ƿ�����
                            {
                                if (!string.IsNullOrEmpty(entity.UnitType))
                                {
                                    if (entity.UnitType.Equals("����"))
                                    {
                                        //�����Ԫ�����ˣ��Ϳ���Ԫ���ֵĹ�����ʲô
                                        dunit.DormUnitType = this.GetBoyOrGirl(entity.UnitTypeRule, i + 1);
                                    }
                                    else
                                    {
                                        dunit.DormUnitType = "������";
                                    }
                                }
                            }
                            else
                            {
                                dunit.DormUnitType = entity.BuildType;
                                //����Ѿ����֣���¥����������ⶰ¥Ϊ�����������е�Ԫ��Ϊ���������ΪŮ�������е�Ԫ��ΪŮ��
                            }
                            dunit.Create();
                            unitList.Add(dunit);
                            //db.Insert<BK_DormUnitEntity>(dunit);//��ӵ�Ԫ����

                        }
                        if (unitList.Count>0)
                        {
                            db.Insert<BK_DormUnitEntity>(unitList);//��ӵ�Ԫ����
                        }
                    }

                    if (unitList.Count > 0)
                    {
                        foreach (var dunit in unitList)
                        {
                            #region if (entity.FloorsCountForUnit > 0)//��Ԫ¥������
                            if (entity.FloorsCountForUnit > 0)//��Ԫ¥������
                            {
                                for (int j = 0; j < entity.FloorsCountForUnit; j++)
                                {
                                    BK_DormFloorsEntity floor = new BK_DormFloorsEntity();
                                    floor.DormBuildingId = entity.DormBuildingId;
                                    floor.DormUnitId = dunit.DormUnitId;

                                    //floor.DormFloorsId = Guid.NewGuid().ToString();//����¥���ID��
                                    floor.DormFloorsName = (j + 1) + "¥";//¥������,����1¥��2¥
                                    floor.DormFloorsNo = (j + 1) + "¥";
                                    if (dunit.DormUnitType.Equals("������"))
                                    {
                                        if (!string.IsNullOrEmpty(entity.FloorsType))
                                        {
                                            if (entity.FloorsType.Equals("����"))
                                            {
                                                //�����Ԫ�����ˣ��Ϳ���Ԫ���ֵĹ�����ʲô
                                                floor.DormFloorsType = this.GetBoyOrGirl(entity.FloorsTypeRule, j + 1);
                                            }
                                            else
                                            {
                                                floor.DormFloorsType = "������";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        floor.DormFloorsType = dunit.DormUnitType;
                                    }
                                    floor.Create();
                                    floorList.Add(floor);
                                    //db.Insert<BK_DormFloorsEntity>(floor);//���¥������


                                }
                                
                            }
                            #endregion
                        }

                        if (floorList.Count > 0)
                        {
                            db.Insert<BK_DormFloorsEntity>(floorList);//���¥������
                        }

                    }

                    if (floorList.Count>0)
                    {
                        int j = 0;
                        foreach (var floor in floorList)
                        {

                            #region ��ӷ�����

                            if (entity.DormCountForFloor > 0)
                            {

                                for (int n = 0; n < entity.DormCountForFloor; n++)
                                {
                                    BK_DormEntity dorm = new BK_DormEntity();//����Ƿ�������

                                    dorm.DormBuildingId = entity.DormBuildingId;
                                    dorm.DormUnitId = floor.DormUnitId;
                                    dorm.DormFloorsId = floor.DormFloorsId;

                                    dorm.DormName = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//����101��102,10�����ǣ�110.112.113.120.124
                                    dorm.DormNo = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//����101��102,10�����ǣ�110.112.113.120.124
                                    int beds = GetDormBeds(entity.BedRule, dorm.DormNo);
                                    dorm.Beds = beds;
                                    dorm.StarLevel = 0;//�Ǽ���׼
                                    dorm.Price = GetPrice(entity.DormBuildingOther9, beds);
                                    dorm.UsedBeds = 0;
                                    dorm.NotUseBeds = beds;
                                    dorm.DistributeBeds = 0;
                                    dorm.NotDistributeBeds = beds;

                                    dorm.Create();
                                    //db.Insert<BK_DormEntity>(dorm);//�������
                                    dormList.Add(dorm);


                                }
                               
                            }
                            j++;
                            #endregion
                        }
                        if (dormList.Count > 0)
                        {
                            db.Insert<BK_DormEntity>(dormList);//�������
                        }

                    }

                    foreach (var dorm in dormList)
                    {
                        int beds = dorm.Beds.Value;
                        #region ��Ӵ�λ

                        for (int b = 0; b < beds; b++)
                        { //���������Ĵ�λ
                            BK_DormBedEntity bedentity = new BK_DormBedEntity();

                            bedentity.DormBuildingId = entity.DormBuildingId;
                            bedentity.DormUnitId = dorm.DormUnitId;
                            bedentity.DormFloorsId = dorm.DormFloorsId;
                            bedentity.DormId = dorm.DormId;

                            bedentity.BedName = (b + 1) + "�Ŵ�";
                            bedentity.BedNo = (b + 1) + "�Ŵ�";
                            bedentity.BedPrice = dorm.Price;
                            bedentity.IsDwell = "��";
                            bedentity.IsDistribute = 0;
                            bedentity.IsUsed = 0;

                            bedentity.Create();
                            bedList.Add(bedentity);
                            //db.Insert<BK_DormBedEntity>(bedentity);
                        }
                        
                        #endregion
                    }
                    if (bedList.Count > 0)
                    {
                        db.Insert<BK_DormBedEntity>(bedList);
                    }
                    #endregion

                }
                #endregion
                #region �������
                else
                {
                    //����
                    entity.Create();
                    db.Insert(entity);


                    List<BK_DormUnitEntity> unitList = new List<BK_DormUnitEntity>();
                    List<BK_DormFloorsEntity> floorList = new List<BK_DormFloorsEntity>();
                    List<BK_DormEntity> dormList = new List<BK_DormEntity>();
                    List<BK_DormBedEntity> bedList = new List<BK_DormBedEntity>();

                    #region ��ӵ�Ԫ����
                    if (entity.UnitCount > 0)//��Ԫ����
                    {
                        for (int i = 0; i < entity.UnitCount; i++)
                        {
                            BK_DormUnitEntity dunit = new BK_DormUnitEntity();
                            dunit.DormBuildingId = entity.DormBuildingId;
                            // dunit.DormUnitId = Guid.NewGuid().ToString(); //���ɵ�Ԫ��ID��
                            dunit.DormUnitName = (i + 1) + "��Ԫ";
                            dunit.DormUnitNo = (i + 1) + "��Ԫ";
                            if (entity.BuildType.Equals("������")) //����¥������������Ů��������£��Ϳ���Ԫ�Ƿ�����
                            {
                                if (!string.IsNullOrEmpty(entity.UnitType))
                                {
                                    if (entity.UnitType.Equals("����"))
                                    {
                                        //�����Ԫ�����ˣ��Ϳ���Ԫ���ֵĹ�����ʲô
                                        dunit.DormUnitType = this.GetBoyOrGirl(entity.UnitTypeRule, i + 1);
                                    }
                                    else
                                    {
                                        dunit.DormUnitType = "������";
                                    }
                                }
                            }
                            else
                            {
                                dunit.DormUnitType = entity.BuildType;
                                //����Ѿ����֣���¥����������ⶰ¥Ϊ�����������е�Ԫ��Ϊ���������ΪŮ�������е�Ԫ��ΪŮ��
                            }
                            dunit.Create();
                            unitList.Add(dunit);
                            //db.Insert<BK_DormUnitEntity>(dunit);//��ӵ�Ԫ����

                        }
                        if (unitList.Count > 0)
                        {
                            db.Insert<BK_DormUnitEntity>(unitList);//��ӵ�Ԫ����
                        }
                    }

                    if (unitList.Count > 0)
                    {
                        foreach (var dunit in unitList)
                        {
                            #region if (entity.FloorsCountForUnit > 0)//��Ԫ¥������
                            if (entity.FloorsCountForUnit > 0)//��Ԫ¥������
                            {
                                for (int j = 0; j < entity.FloorsCountForUnit; j++)
                                {
                                    BK_DormFloorsEntity floor = new BK_DormFloorsEntity();
                                    floor.DormBuildingId = entity.DormBuildingId;
                                    floor.DormUnitId = dunit.DormUnitId;

                                    //floor.DormFloorsId = Guid.NewGuid().ToString();//����¥���ID��
                                    floor.DormFloorsName = (j + 1) + "¥";//¥������,����1¥��2¥
                                    floor.DormFloorsNo = (j + 1) + "¥";
                                    if (dunit.DormUnitType.Equals("������"))
                                    {
                                        if (!string.IsNullOrEmpty(entity.FloorsType))
                                        {
                                            if (entity.FloorsType.Equals("����"))
                                            {
                                                //�����Ԫ�����ˣ��Ϳ���Ԫ���ֵĹ�����ʲô
                                                floor.DormFloorsType = this.GetBoyOrGirl(entity.FloorsTypeRule, j + 1);
                                            }
                                            else
                                            {
                                                floor.DormFloorsType = "������";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        floor.DormFloorsType = dunit.DormUnitType;
                                    }
                                    floor.Create();
                                    floorList.Add(floor);
                                    //db.Insert<BK_DormFloorsEntity>(floor);//���¥������


                                }

                            }
                            #endregion
                        }

                        if (floorList.Count > 0)
                        {
                            db.Insert<BK_DormFloorsEntity>(floorList);//���¥������
                        }

                    }

                    if (floorList.Count > 0)
                    {
                        int j = 0;
                        foreach (var floor in floorList)
                        {

                            #region ��ӷ�����

                            if (entity.DormCountForFloor > 0)
                            {

                                for (int n = 0; n < entity.DormCountForFloor; n++)
                                {
                                    BK_DormEntity dorm = new BK_DormEntity();//����Ƿ�������

                                    dorm.DormBuildingId = entity.DormBuildingId;
                                    dorm.DormUnitId = floor.DormUnitId;
                                    dorm.DormFloorsId = floor.DormFloorsId;

                                    dorm.DormName = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//����101��102,10�����ǣ�110.112.113.120.124
                                    dorm.DormNo = (j + 1) + ((n + 1) < 10 ? "0" + (n + 1) : (n + 1) + "");//����101��102,10�����ǣ�110.112.113.120.124
                                    int beds = GetDormBeds(entity.BedRule, dorm.DormNo);
                                    dorm.Beds = beds;
                                    dorm.StarLevel = 0;//�Ǽ���׼
                                    dorm.Price = GetPrice(entity.DormBuildingOther9, beds);
                                    dorm.UsedBeds = 0;
                                    dorm.NotUseBeds = beds;
                                    dorm.DistributeBeds = 0;
                                    dorm.NotDistributeBeds = beds;

                                    dorm.Create();
                                    //db.Insert<BK_DormEntity>(dorm);//�������
                                    dormList.Add(dorm);


                                }

                            }
                            j++;
                            #endregion
                        }
                        if (dormList.Count > 0)
                        {
                            db.Insert<BK_DormEntity>(dormList);//�������
                        }

                    }

                    foreach (var dorm in dormList)
                    {
                        int beds = dorm.Beds.Value;
                        #region ��Ӵ�λ

                        for (int b = 0; b < beds; b++)
                        { //���������Ĵ�λ
                            BK_DormBedEntity bedentity = new BK_DormBedEntity();

                            bedentity.DormBuildingId = entity.DormBuildingId;
                            bedentity.DormUnitId = dorm.DormUnitId;
                            bedentity.DormFloorsId = dorm.DormFloorsId;
                            bedentity.DormId = dorm.DormId;

                            bedentity.BedName = (b + 1) + "�Ŵ�";
                            bedentity.BedNo = (b + 1) + "�Ŵ�";
                            bedentity.BedPrice = dorm.Price;
                            bedentity.IsDwell = "��";
                            bedentity.IsDistribute = 0;
                            bedentity.IsUsed = 0;

                            bedentity.Create();
                            bedList.Add(bedentity);
                            //db.Insert<BK_DormBedEntity>(bedentity);
                        }

                        #endregion
                    }
                    if (bedList.Count > 0)
                    {
                        db.Insert<BK_DormBedEntity>(bedList);
                    }
                    #endregion
                }
                #endregion
                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }

        /// <summary>
        /// ����������Ů����Ĭ��Ϊ������
        /// </summary>
        /// <param name="rules">����</param>
        /// <param name="bs">�ڼ�</param>
        /// <returns></returns>
        private string GetBoyOrGirl(string rules, int bs)
        {
            string type = "";

            //�����Ԫ�����ˣ��Ϳ���Ԫ���ֵĹ�����ʲô
            if (!string.IsNullOrEmpty(rules.Trim()))
            {
                string[] urules = rules.Trim().Split('|');
                foreach (var urule in urules)
                {
                    if (string.IsNullOrEmpty(urule.Trim()))
                    {
                        continue;
                    }

                    string[] utype = urule.Trim().Split(':');
                    if (utype[0].Contains("-"))//��������ˡ�-����ʾΪ1����Χ
                    {
                        string[] numbers = utype[0].Trim().Split('-');//���� 1-3
                        int min = Convert.ToInt32(numbers[0].Trim());//��Сֵ
                        int max = Convert.ToInt32(numbers[1].Trim());//���ֵ
                        if (min>max)//��������
                        {
                            int t = min;
                            min = max;
                            max = t;
                        }
                        for (int i = min; i <= max; i++)
                        {
                            if (i==bs)
                            {
                                type = utype[1].Trim();
                            }
                        }
                    }
                    else
                    {//��ʾֻ��Ե�����Ԫ
                        if (utype[0].Equals(bs))
                        {
                            type = utype[1].Trim();
                        }
                    }
                }
            }

            return type;

        }
        
        /// <summary>
        /// ���ط����ڵĴ�λ����
        /// </summary>
        /// <param name="rule">����</param>
        /// <param name="dormno">�����</param>
        /// <returns></returns>
        private int GetDormBeds(string rule,string dormno)
        {
            //101-105/8|106-110/6|201-205/6|206-220/8
            int beds = 0;
            if (!string.IsNullOrEmpty(rule.Trim()))
            {
                string[] ruless = rule.Trim().Split('|');//�õ�101-105/8��106-110/6��201-205/6��206-220/8
                foreach (var rules in ruless)
                {
                    if (string.IsNullOrEmpty(rules.Trim()))
                    {
                        continue;
                    }
                    string[] dormbeds = rules.Trim().Split('/');//�õ�101-105��8
                    if (dormbeds[0].Trim().Contains("-"))
                    {
                        string[] dorms = dormbeds[0].Trim().Split('-');
                        int min = Convert.ToInt32(dorms[0].Trim());//��Сֵ
                        int max = Convert.ToInt32(dorms[1].Trim());//���ֵ
                        if (min > max)//��������
                        {
                            int t = min;
                            min = max;
                            max = t;
                        }
                        for (int i = min; i <= max; i++)
                        {
                            if (dormno.Equals(i.ToString()))
                            {
                                beds = Convert.ToInt32(dormbeds[1].Trim());//�õ�����Ĵ�λ����
                            }
                        }
                    }
                    else
                    {
                        if (dormbeds[0].Trim().Equals(dormno))
                        {
                            beds = Convert.ToInt32(dormbeds[1].Trim());//�õ�����Ĵ�λ����
                        }
                    }

                }
            }
            return beds;
        }

        /// <summary>
        /// ���ݷ��䴲λ���ص���
        /// </summary>
        /// <param name="priceRule">����</param>
        /// <param name="bedcount">��λ��</param>
        /// <returns>��λ����</returns>
        private decimal GetPrice(string priceRule, int bedcount)
        {
            decimal price = 0;
            if (!string.IsNullOrEmpty(priceRule.Trim()))
            {
                //8/500|6/800|4/1200
                string[] rules = priceRule.Trim().Split('|');
                foreach (var bedprice in rules)
                {
                    string[] bp = bedprice.Trim().Split('/');
                    if (bp[0].Trim().Equals(bedcount.ToString()))
                    {
                        price = decimal.Parse(bp[1].Trim());
                        break;
                    }
                }

            }
            return price;
        } 

#endregion
    }
}
