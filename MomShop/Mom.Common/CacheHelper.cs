using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
namespace Mom.Common
{
    public class CacheHelper
    {
        public static ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(System.Configuration.ConfigurationManager.AppSettings["RedisConn"]);
        

        /// <summary>
        /// 写入string类型缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="db">数据库 默认0</param>
        /// <returns></returns>
        public static bool SetString(string key,string value, TimeSpan expiry,int db=0)
        {
            bool b = conn.GetDatabase(db).StringSet(key,value, expiry);
            return b;
        }

        /// <summary>
        /// 读取string类型缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="db">数据库 默认0</param>
        /// <returns></returns>
        public static string GetString(string key,int db=0)
        {
            string str =  conn.GetDatabase(db).StringGet(key);
            return str;
        }

        /// <summary>
        /// 检查是否存在此缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="db">数据库 默认0</param>
        /// <returns></returns>
        public static bool ExistsKey(string key ,int db=0)
        {
            bool b =  conn.GetDatabase(db).KeyExists(key);
            return b;
        }
    }
}
