using SpringYCBlogs.Infrastructure.CommonUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringYCBlogs.Infrastructure
{
    public class SQLProfiler : DbCommandInterceptor
    {
        private readonly int _executionTime = Int32.Parse(ConfigurationManager.AppSettings.Get("executionTime")); //执行时间，如果超过该值，则记录sql
        //private static readonly string key = "Profilter1";

        private readonly Stopwatch _stopwatch = new Stopwatch();

        public SQLProfiler()
        {
        }
        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Executing(interceptionContext);
            base.NonQueryExecuting(command, interceptionContext);
        }
        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Executing(interceptionContext);
            base.ReaderExecuting(command, interceptionContext);
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.ReaderExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Executing(interceptionContext);
            base.ScalarExecuting(command, interceptionContext);
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Executed(command, interceptionContext);
            base.ScalarExecuted(command, interceptionContext);
        }

        private void Executing<T>(DbCommandInterceptionContext<T> interceptionContext)
        {
            //interceptionContext.SetUserState(key, _stopwatch);
            _stopwatch.Restart();
        }

        private void Executed<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            //var timer = (Stopwatch)interceptionContext.FindUserState(key);
            _stopwatch.Stop();
            StringBuilder sb = new StringBuilder("参数：");
            foreach (SqlParameter item in command.Parameters)
            {
                sb.AppendFormat("{0}:{1},\t{2},\t", item.ParameterName, item.Value, item.DbType.GetType());
            }
            if (interceptionContext.Exception != null)
            {
                LogHelper.Error(string.Format("错误SQL语句:{0}\n{1}\n{2}", interceptionContext.Exception.Message, command.CommandText, sb.ToString()),
                    interceptionContext.Exception);
            }
            else if (_stopwatch.ElapsedMilliseconds >= _executionTime)
            {
                LogHelper.Info(string.Format("耗时SQL语句({0}ms)\nSQL语句：{1}\n{2}", _stopwatch.ElapsedMilliseconds,
                        command.CommandText, sb.ToString()));
            }
            else
            {
                LogHelper.Info(string.Format("执行的SQL:\n{0}\n{1}", command.CommandText, sb.ToString()));
            }

        }
    }
}
