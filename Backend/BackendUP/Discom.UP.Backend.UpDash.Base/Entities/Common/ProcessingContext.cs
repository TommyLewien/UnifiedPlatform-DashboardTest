using System;
using System.Collections.Generic;
using System.Text;

namespace Discom.UP.Backend.UpDash.Base.Entities.Common
{
    /// <summary>
    /// Enum to specify a target withing the topology model, where a query or command will be executed
    /// </summary>
    public enum Target
    {
        /// <summary>
        /// Backend Service
        /// </summary>
        BackendService,
        /// <summary>
        /// All Backend Services
        /// </summary>
        AllBackendServices,
        /// <summary>
        /// Parameter Database
        /// </summary>
        ParamDb,
        /// <summary>
        /// Result Database
        /// </summary>
        ResultDb,
        /// <summary>
        /// Measurement Data
        /// </summary>
        MeasurementData,
        /// <summary>
        /// Production Data
        /// </summary>
        ProductionData,
        /// <summary>
        /// AIML
        /// </summary>
        AIML,
        /// <summary>
        /// Archive
        /// </summary>
        Archive,
        /// <summary>
        /// Wave
        /// </summary>
        Wave,
        /// <summary>
        /// Collector
        /// </summary>
        Collector,
        /// <summary>
        /// Persistence
        /// </summary>
        Persistence,
        /// <summary>
        /// TestStands
        /// </summary>
        TestStands
    }

    /// <summary>
    /// Processing Context
    /// Specifies a BackendService within the TopologyModel where a query or command
    /// will be executed due respect of factory, line and testbench
    /// </summary>
    public class ProcessingContext
    {
        /// <summary>
        /// Factory
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// Line
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Test Bench
        /// </summary>
        public string TestBench { get; set; }

        /// <summary>
        /// Target
        /// </summary>
        public Target Target { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ProcessingContext()
        { }

        /// <summary>
        /// The Processing Context.
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="line"></param>
        /// <param name="testBench"></param>
        /// <param name="target"></param>
        public ProcessingContext(string factory, string line, string testBench, Target target)
        {
            Factory = factory;
            Line = line;
            TestBench = testBench;
            Target = target;
        }

        /// <summary>
        /// Returns the context as a formatted string.
        /// </summary>
        /// <returns></returns>
        public string GetContext()
        {
            string context = "";
            if (!string.IsNullOrEmpty(Factory)) context += Factory;
            if (!string.IsNullOrEmpty(Line)) context += "/" + Line;
            if (!string.IsNullOrEmpty(TestBench)) context += "/" + TestBench;
            context += "/" + Target.ToString();

            return context;
        }

        public override bool Equals(object obj)
        {
            if(obj is ProcessingContext processingContext)
            {
                return processingContext.GetContext().Equals(GetContext(), StringComparison.InvariantCultureIgnoreCase);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return GetContext().GetHashCode();
        }
    }
}
