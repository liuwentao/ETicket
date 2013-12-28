using System;
using System.Collections.Generic;
using System.Text;
using ETicket.Client.Dal;
using System.Data;

namespace ETicket.Client.Bll
{
    public class HiBiz
    {
        /// <summary>
        /// 获得项目列表
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetProject()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData("select id,name from project order by id");
            foreach (DataRow row in ds.Tables["data"].Rows)
            {
                if (!dict.ContainsKey(row["id"].ToString()))
                {
                    dict.Add(row["id"].ToString(), row["name"].ToString());
                }
            }
            return dict;
        }

        internal Dictionary<string, string> GetCarInfo(string carNo)
        {
            Dictionary<string, string> dict = null;

            SqlLiteDal dal = new SqlLiteDal();
            string sql = string.Format("SELECT id,carno,note from carinfo where carno ='{0}'", carNo);
            dict = dal.GetDict(sql);
            return dict;
        }

        internal bool AddCar(string carNo, string carName)
        {
            SqlLiteDal dal = new SqlLiteDal();
            bool result = false;
            var carInfo = GetCarInfo(carNo);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("no", carNo);
            dict.Add("note", carName);
            string sql = string.Empty;
            if (carInfo.Count > 0)
            {
                sql = "update carinfo set note=@note where carno=@no";
            }
            else
            {
                sql = "insert into carinfo(carno,note,logtime) values(@no,@note,DATETIME('now'))";
            }
            result = dal.ExcuteDict(sql, dict);
            return result;

        }

        internal bool AddTicket(Dictionary<string, string> dict)
        {
            SqlLiteDal dal = new SqlLiteDal();
            var carInfo = GetCarInfo(dict["carno"]);
            if (carInfo.Count == 0)
            {
                AddCar(dict["carno"], "");
                carInfo = GetCarInfo(dict["carno"]);
            }
            dict["carno"] = carInfo["id"];
            string sql = "insert into ticket(carid,proid,create_date,amount,note,log_time) values(@carno,@proj,@tdate,@amount,@note,DATETIME('now'))";
            return dal.ExcuteDict(sql, dict);
        }

        public DataSet GetData(int type)
        {
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData(string.Format("select carinfo.carno,ticket.proid,project.name,ticket.amount,ticket.create_date, ticket.note from ticket,carinfo,project where ticket.carid =carinfo.id and ticket.proid =project.id and create_date ='{0}'", DateTime.Now.ToString("yyyy-MM-dd")));

            var dictProject = GetProject();
            DataTable table = new DataTable("work");
            table.Columns.Add(new DataColumn("id", typeof(int)));
            table.Columns["id"].AutoIncrement = true;
            table.Columns["id"].AutoIncrementSeed = 1;
            table.Columns["id"].AutoIncrementStep = 1;
            table.Columns.Add(new DataColumn("carno"));
            table.Columns.Add(new DataColumn("create_date"));
            foreach (var item in dictProject)
            {
                table.Columns.Add(new DataColumn("pro_" + item.Key));
            }
            table.Columns.Add(new DataColumn("note"));
            DataRow row = null;
            foreach (DataRow item in ds.Tables["data"].Rows)
            {
                row = table.NewRow();
                foreach (DataColumn col in ds.Tables["data"].Columns)
                {
                    if ("proid".Equals(col.ColumnName))
                    {
                        row["pro_" + item[col]] = item["amount"];
                    }
                    else
                    {
                        if (table.Columns.Contains(col.ColumnName))
                        {
                            row[col.ColumnName] = item[col];
                        }
                    }
                }
                table.Rows.Add(row);
            }
            foreach (var item in dictProject)
            {
                if (table.Columns.Contains("pro_" + item.Key))
                {
                    table.Columns["pro_" + item.Key].ColumnName = item.Value;
                }
            }
            table.Columns["id"].ColumnName = "序号";
            table.Columns["carno"].ColumnName = "车牌";
            table.Columns["create_date"].ColumnName = "日期";
            table.Columns["note"].ColumnName = "备注";
            ds.Tables.Add(table);
            return ds;
        }

        public DataSet GetTodayTickets()
        {
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData(string.Format("select ticket.id 编号,carinfo.carno 车牌,project.name 施工项目,ticket.amount 金额,ticket.create_date 日期, ticket.note 备注 from ticket,carinfo,project where ticket.carid =carinfo.id and ticket.proid =project.id and create_date ='{0}' order by ticket.id desc", DateTime.Now.ToString("yyyy-MM-dd")));
            return ds;
        }

        public DataSet GetTickets()
        {
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData("select ticket.id 编号,carinfo.carno 车牌,project.name 施工项目,ticket.amount 金额,ticket.create_date 日期, ticket.note 备注 from ticket,carinfo,project where ticket.carid =carinfo.id and ticket.proid =project.id  order by ticket.id asc");
            return ds;
        }

        public DataSet GetTodayProejctStatic()
        {
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData(string.Format("select project.id,project.name,count(ticket.id)  count ,sum(ticket.amount) amount from project LEFT JOIN ticket on project.id =ticket.proid and ticket.create_date='{0}' GROUP BY project.id,project.name order by project.id", DateTime.Now.ToString("yyyy-MM-dd")));
            return ds;
        }
        internal DataSet GetCarSet(string CarNo)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            SqlLiteDal dal = new SqlLiteDal();
            string sql = string.Format("SELECT id 编号,carno 车牌,note 备注 from carinfo where carno like '%{0}%'", CarNo);
            DataSet ds = dal.GetData(sql);

            return ds;
        }

        internal DataSet GetTicketOfCar(string carNo)
        {
            SqlLiteDal dal = new SqlLiteDal();
            DataSet ds = dal.GetData(string.Format("select ticket.id 编号, carinfo.carno 车牌,project.name 施工项目,ticket.amount 金额,ticket.create_date 日期, ticket.note 备注 from ticket,carinfo,project where ticket.carid =carinfo.id and ticket.proid =project.id and carinfo.carno='{0}'", carNo));
            return ds;
        }

        const string SQL_GET_CONDITION_TICKETS = @"select ticket.id          编号,
       carinfo.carno      车牌,
       project.name       施工项目,
       ticket.amount      金额,
       ticket.create_date 日期,
       ticket.note        备注
  from ticket, carinfo, project
 where ticket.carid = carinfo.id
   and ticket.proid = project.id
   and project.id like @proj
   and ticket.create_date between @dateBegin and @dateEnd
   and carinfo.carno like @carno
 order by ticket.id asc
";
        internal DataSet GetTickets(Dictionary<string, string> dict)
        {
            SqlLiteDal dal = new SqlLiteDal();
            return dal.GetData(SQL_GET_CONDITION_TICKETS, dict);

        }
    }
}
