using System;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Config;
using PostSharp.Aspects;

namespace Valid.Fulfillment.PostSharp
{
    /// <summary>
    /// Postsharp Exception Logging Aspect Class
    /// </summary>
    [Serializable]
    public class LogException : OnExceptionAspect
    {
        private string[] m_parameterNames;


        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            m_parameterNames = method.GetParameters().Select(p => p.Name).ToArray();
        }

        /// <summary>
        /// Method to log the method and stack trace when an exception occurs
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            var logger = LogManager.GetLogger(typeof (LogException));
            XmlConfigurator.Configure();

            args.FlowBehavior = FlowBehavior.RethrowException;

            var sb = new StringBuilder();

            if (args.Method.DeclaringType != null)
            {
                sb.AppendFormat("Exception thrown by {0} - {1} - {2}", args.Method.Name,
                    args.Method.DeclaringType.FullName, args.Exception.Message);
            }
            sb.AppendLine();
            sb.AppendFormat("StackTrace: {0}", args.Exception.StackTrace);
            sb.AppendLine();


            for (var i = 0; i < args.Arguments.Count; i++)
            {
                if (sb.Length > 0)
                {
                    sb.Append(", ");
                }

                sb.AppendFormat(
                    "{0} = {1}", m_parameterNames[i], args.Arguments[i] ?? "null");
            }

            if (logger != null)
            {
                logger.Info(sb.ToString());
            }
        }
    }
}