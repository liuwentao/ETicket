using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ETicket.Client.Dal;

namespace ETicket.Client.Bll
{
    public class TicketBiz
    {
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public DataSet GetUser(string owner)
        {
            SqlLiteDal dal = new SqlLiteDal();
            string sql = string.Format(@"SELECT
                a.id 编号,
                b.name 小区,
                a.owner 户主,
                a.user_type 类型,
                a.phone 电话,
                c.name 楼号,
                a.cell 单元,
                a.degree 上次度数
                FROM
                ownerinfo a,areainfo b,buildinfo c
                where 
                a.areaid =b.id
                and a.buildid =c.id
                and b.id=c.areaid
                and  a.owner like '%{0}%'", owner);
            return dal.GetData(sql);
        }
        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetUser(Dictionary<string, string> dict)
        {
            SqlLiteDal dal = new SqlLiteDal();
            string sql = string.Format(@"SELECT
                a.id 编号,
                b.name 小区,
                a.owner 户主,
                a.user_type 类型,
                a.phone 电话,
                c.name 楼号,
                a.cell 单元,
                a.degree 上次度数
                FROM
                ownerinfo a,areainfo b,buildinfo c
                where 
                a.areaid =b.id
                and a.buildid =c.id
                and b.id=c.areaid
                and  a.owner like @owner
                and a.buildid=@buildid
                and a.areaid=@areaid
               ");
            return dal.GetData(sql, dict);
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool AddUser(Dictionary<string, string> dict)
        {
            SqlLiteDal dal = new SqlLiteDal();

            string sql = "insert into ownerinfo (owner,address,phone,areaid,buildid,cell,degree,user_type) values (@owner,@address,@phone,@areaid,@buildid,@cell,0,@user_type)";

            return dal.ExcuteDict(sql, dict);
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool ModifyUser(Dictionary<string, string> dict)
        {
            SqlLiteDal dal = new SqlLiteDal();
            string sql2 = @"update ownerinfo set owner=@owner,address=@address,phone=@phone,areaid=@areaid,buildid=@buildid,cell=@cell,user_type=@user_type where id=@userid";

            return dal.ExcuteDict(sql2, dict);
        }

        /// <summary>
        /// 添加一个小区
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string AddArea(string name)
        {
            var dal = new SqlLiteDal();
            string sql = string.Format("select id from areainfo where name ='{0}'", name);
            var result = dal.GetDict(sql);
            if (result.ContainsKey("id"))
            {
                return result["id"];
            }
            sql = "insert into areainfo (name) values(@name)";
            var dict = new Dictionary<string, string>();
            dict.Add("name", name);
            dal.ExcuteDict(sql, dict);
            sql = string.Format("select id from areainfo where name ='{0}'", name);
            result = dal.GetDict(sql);
            if (result.ContainsKey("id"))
            {
                return result["id"];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获得小区信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAreas()
        {
            string sql = "select * from areainfo";
            var dal = new SqlLiteDal();
            var ds = dal.GetData(sql);
            var dict = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables["data"].Rows)
            {
                if (!dict.ContainsKey(row["id"].ToString()))
                {
                    dict.Add(row["id"].ToString(), row["name"].ToString());
                }
            }
            return dict;
        }

        /// <summary>
        /// 获得楼宇的信息
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetBuild(string areaId)
        {
            string sql = string.Format("select * from buildinfo where areaid={0}", areaId);
            var dal = new SqlLiteDal();
            var ds = dal.GetData(sql);
            var dict = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables["data"].Rows)
            {
                if (!dict.ContainsKey(row["id"].ToString()))
                {
                    dict.Add(row["id"].ToString(), row["name"].ToString());
                }
            }
            return dict;
        }

        /// <summary>
        /// 增加一个新的楼号
        /// </summary>
        /// <param name="name"></param>
        /// <param name="areaid"></param>
        /// <returns></returns>
        internal string AddBuild(string name, string areaid)
        {
            var dal = new SqlLiteDal();
            string sql = string.Format("select * from buildinfo where name='{0}' and areaid={1}", name, areaid);
            var result = dal.GetDict(sql);
            if (result.ContainsKey("id"))
            {
                return result["id"];
            }
            var dict = new Dictionary<string, string>();
            dict.Add("name", name);
            dict.Add("areaid", areaid);
            sql = "insert into buildinfo (name,areaid) values (@name,@areaid)";
            dal.ExcuteDict(sql, dict);
            sql = string.Format("select * from buildinfo where name='{0}' and areaid={1}", name, areaid);
            result = dal.GetDict(sql);
            if (result.ContainsKey("id"))
            {
                return result["id"];
            }
            return string.Empty;
        }

        /// <summary>
        /// 获得用户的字典信息
        /// </summary>
        /// <param name="areaid"></param>
        /// <param name="buildid"></param>
        /// <returns></returns>
        internal Dictionary<string, string> GetUser(string areaid, string buildid)
        {
            string sql = string.Format("select distinct owner from ownerinfo where areaid={0} and buildid ={1}", areaid, buildid);
            var dal = new SqlLiteDal();
            var ds = dal.GetData(sql);
            var dict = new Dictionary<string, string>();
            foreach (DataRow row in ds.Tables["data"].Rows)
            {
                dict.Add(row["owner"].ToString(), row["owner"].ToString());
            }
            return dict;
        }


        /// <summary>
        /// 获得系统的配置信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetSysConfig()
        {
            var dal = new SqlLiteDal();
            return dal.GetData("select * from system");
        }

        /// <summary>
        /// 修改系统的配置信息
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool ModifySysConfig(IDictionary<string, string> dict)
        {
            var dal = new SqlLiteDal();
            string sql = "update system set price=@price,limitprice=@limitprice,limitdegree=@limitdegree,publicfee=@publicfee where typeid=@typeid";

            return dal.ExcuteDict(sql, dict);
        }

        internal DataSet GetEmptyTicket(string p, string p_2)
        {
            try
            {
                var dict = new Dictionary<string, string>();
                dict.Add("buildId", p_2);
                dict.Add("areaId", p);

                var dal = new SqlLiteDal();
                return dal.GetData(GET_NEW_TICKET, dict);
            }
            catch (Exception)
            {

                throw;
            }
            return null;

        }
        const string GET_NEW_TICKET = @"SELECT ow.cell, 
       ow.owner,
       ow.id ownerid,
       ow.areaid,
       ow.buildid,
       ow.degree last, 
       b.lastprint,
       a.name area_name,
       b.name build_name,
       s.price, 
       s.limitprice limitFee,
       s.limitdegree,
       t.name usertype,
       0 current,
       0 diff,
       s.publicfee public,
       0.0 amount
FROM   ownerinfo ow, 
       areainfo a, 
       buildinfo b, 
       system s ,
       userType t
WHERE  ow.areaid = a.id 
       AND ow.buildid = b.id 
       AND ow.user_type = s.typeid 
       and ow.user_type =t.id
        and ow.areaid=@areaId
         and ow.buildid=@buildId";
        /// <summary>
        /// init ticket table
        /// </summary>
        /// <returns></returns>
        private DataTable initTicketTable()
        {
            var table = new DataTable();
            table.TableName = "ticket";
            table.Columns.Add(new DataColumn("cell", typeof(string)));
            table.Columns.Add(new DataColumn("owner", typeof(string)));
            table.Columns.Add(new DataColumn("current", typeof(decimal)));
            table.Columns.Add(new DataColumn("lastMonth", typeof(decimal)));
            table.Columns.Add(new DataColumn("price", typeof(decimal)));
            table.Columns.Add(new DataColumn("diff", typeof(decimal)));
            table.Columns.Add(new DataColumn("pub", typeof(decimal)));
            table.Columns.Add(new DataColumn("amount", typeof(decimal)));
            return table;
        }

        /// <summary>
        /// 保存电费信息
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="buildId"></param>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public bool SaveTicket(DataSet ds, string buildId, string areaId)
        {
            bool flag = true;
            try
            {
                ModifyLastBuild(buildId, areaId);
                foreach (DataRow row in ds.Tables["data"].Rows)
                {
                    updataOwnerInfo(row["ownerid"].ToString(), row["current"].ToString());
                    InsertTicket(row);

                }
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        /// <summary>
        /// 插入一条ticket记录
        /// </summary>
        /// <param name="row"></param>
        private bool InsertTicket(DataRow row)
        {
            string sql = @"insert into ticketinfo(
                date,
                areaid,
                ownerid,
                buildid,
                predegree,
                degree,
                price,
                limitdegree,
                limitprice,
                publicfee,
                amount) values (
                datetime('now','localtime'),
                @areaid,
                @ownerid,
                @buildid,
                @predegree,
                @degree,
                @price,
                @limitdegree,
                @limitprice ,
                @publicfee,
                @amount)";
            var dict = new Dictionary<string, string>();
            var dal = new SqlLiteDal();
            dict.Add("ownerid", row["ownerid"].ToString());
            dict.Add("areaid", row["areaid"].ToString());
            dict.Add("buildid", row["buildid"].ToString());
            dict.Add("predegree", row["last"].ToString());
            dict.Add("degree", row["current"].ToString());
            dict.Add("price", row["price"].ToString());
            dict.Add("limitdegree", row["limitdegree"].ToString());
            dict.Add("limitprice", row["limitFee"].ToString());
            dict.Add("publicfee", row["public"].ToString());
            dict.Add("amount", row["amount"].ToString());
            return dal.ExcuteDict(sql, dict);
        }

        /// <summary>
        /// 编辑上次的时间
        /// </summary>
        /// <param name="buildId"></param>
        /// <param name="areaId"></param>
        private void ModifyLastBuild(string buildId, string areaId)
        {
            string sql = "update buildinfo set lastprint = datetime('now','localtime') where id=@buildid and areaid =@areaid";
            var dict = new Dictionary<string, string>();
            dict.Add("buildid", buildId);
            dict.Add("areaid", areaId);
            var dal = new SqlLiteDal();
            dal.ExcuteDict(sql, dict);
        }

        /// <summary>
        /// 编辑业主信息
        /// </summary>
        /// <param name="o"></param>
        /// <param name="o1"></param>
        /// <returns></returns>
        private bool updataOwnerInfo(string oid, string degree)
        {
            var dal = new SqlLiteDal();
            var dict = new Dictionary<string, string>();
            dict.Add("oid", oid);
            dict.Add("degree", degree);
            dal.ExcuteDict("update ownerinfo set degree=@degree where id =@oid", dict);
            return false;
        }
    }
}
