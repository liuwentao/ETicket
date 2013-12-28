using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using ETicket.Client.Domain;
using System.Data;

namespace ETicket.Client.Dal
{
    /// <summary>
    /// 所有跟sqlite的操作都在这里
    /// </summary>
    public class SqlLiteDal
    {
        /// <summary>
        /// sqlite的连接字符串
        /// </summary>
        private const string CONNECT_STRING = "data source=ETicket.db";

        /// <summary>
        /// 通过sql获得一个数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetData(string sql)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                //SQLiteDataAdapter的方式数据库连接是自动打开的
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                adapter.Fill(ds, "data");
            }
            return ds;
        }

        /// <summary>
        /// 通过sql获得一个数据字典
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetDict(string sql)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                //SQLiteCommand的方式数据库连接必须提前打开
                conn.Open();
                using (var command = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (!dict.ContainsKey(reader.GetName(i)))
                            {
                                dict.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                    }
                }
            }
            return dict;
        }
        /// <summary>
        /// 对数据库之星更新操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public bool ExcuteDict(string sql, IDictionary<string, string> dict)
        {
            bool isOkay = false;
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                conn.Open();
                using (var command = new SQLiteCommand(sql, conn))
                {
                    if (dict != null)
                    {
                        foreach (var item in dict)
                        {
                            command.Parameters.AddWithValue(item.Key, item.Value);
                        }
                    }
                    isOkay = command.ExecuteNonQuery() > 0;
                }
            }
            return isOkay;
        }

     
        /// <summary>
        /// 对数据库之星更新操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExcuteDict(string sql)
        {
            return ExcuteDict(sql, null);
        }

        /// <summary>
        /// 带参数的查询数据集的方法
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public DataSet GetData(string sql, Dictionary<string, string> dict)
        {
            DataSet ds = new DataSet();
            using (SQLiteConnection conn = new SQLiteConnection(CONNECT_STRING))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                foreach (var item in dict)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(item.Key, item.Value);
                }
                adapter.Fill(ds, "data");
            }
            return ds;
        }
    }
}
