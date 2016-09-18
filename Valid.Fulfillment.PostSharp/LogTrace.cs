using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using log4net;
using log4net.Config;
using PostSharp.Aspects;

namespace Valid.Fulfillment.PostSharp
{
    /// <summary>
    /// Postsharp Trace Logging Aspect Class
    /// </summary>
    [Serializable]
    public sealed class LogTrace : OnMethodBoundaryAspect
    {
        private bool m_enableTracing;

        [NonSerialized] private ILog m_logger;

        private string[] m_parameterNames;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            m_parameterNames = method.GetParameters().Select(p => p.Name).ToArray();
            base.CompileTimeInitialize(method, aspectInfo);
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            m_enableTracing = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableTracing"]);
            m_logger = LogManager.GetLogger(typeof (LogTrace));
            XmlConfigurator.Configure();
            base.RuntimeInitialize(method);
        }

        /// <summary>
        /// Method to log the entry and arguments of any method when tracing is enabled 
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (m_enableTracing)
            {
                var sb = new StringBuilder();

                if (args.Method.DeclaringType != null)
                {
                    sb.AppendFormat("Entering method {0} - {1}", args.Method.Name, args.Method.DeclaringType.FullName);
                }
                sb.AppendLine();
                if (args.Arguments.Any())
                {
                    sb.AppendLine("With Arguments:");

                    for (var i = 0; i < args.Arguments.Count; i++)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(", ");
                        }

                        sb.AppendFormat(
                            "{0} = {1}", m_parameterNames[i], args.Arguments[i] ?? "null");
                    }
                }
                m_logger.Info(sb);
                Console.WriteLine(sb);
            }
            base.OnEntry(args);
        }

        /// <summary>
        /// Method to log the exit and return value of any method when tracing is enabled 
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            if (m_enableTracing)
            {
                var sb = new StringBuilder();

                if (args.Method.DeclaringType != null)
                {
                    sb.AppendFormat("Exiting method: {0} - {1}", args.Method.Name, args.Method.DeclaringType.FullName);
                }

                if (args.ReturnValue != null)
                {
                    sb.AppendLine(string.Format("\tReturn Value {0}", args.ReturnValue));
                }

                m_logger.Info(sb);
                Console.WriteLine(sb.ToString());
            }
            base.OnExit(args);
        }
    }
}