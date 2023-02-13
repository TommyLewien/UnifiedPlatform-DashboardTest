using Discom.UP.Backend.UpDash.Base.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Discom.UP.Backend.UpDash.Base.Logging
{

    /// <summary>
    /// Code
    /// </summary>
    [DataContract]
    public class Code : Enumeration
    {
        [DataMember(Order = 1)]
        public override string Name { get; set; }

        [DataMember(Order = 2)]
        public override int Id { get; set; }

        /// <summary>
        /// General
        /// </summary>
        public static Code General = new Code(10, nameof(General));
        /// <summary>
        /// Connection
        /// </summary>
        public static Code Connection = new Code(11, nameof(Connection));
        /// <summary>
        /// Validation
        /// </summary>
        public static Code Validation = new Code(12, nameof(Validation));
        /// <summary>
        /// Permission
        /// </summary>
        public static Code Permission = new Code(13, nameof(Permission));
        /// <summary>
        /// Topology
        /// </summary>
        public static Code Topology = new Code(14, nameof(Topology));
        /// <summary>
        /// Databse
        /// </summary>
        public static Code Database = new Code(15, nameof(Database));
        /// <summary>
        /// Persistence
        /// </summary>
        public static Code Persistence = new Code(16, nameof(Persistence));
        /// <summary>
        /// Backend
        /// </summary>
        public static Code Backend = new Code(17, nameof(Backend));
        /// <summary>
        /// Frontend
        /// </summary>
        public static Code Frontend = new Code(18, nameof(Frontend));
        /// <summary>
        /// Data
        /// </summary>
        public static Code Data = new Code(19, nameof(Data));
        /// <summary>
        /// File
        /// </summary>
        public static Code File = new Code(20, nameof(File));

        /// <summary>
        /// MeasurementData
        /// </summary>
        public static Code MeasurementData = new Code(51, nameof(MeasurementData));
        /// <summary>
        /// Result
        /// </summary>
        public static Code Results = new Code(52, nameof(Results));
        /// <summary>
        /// Parameter
        /// </summary>
        public static Code Parameter = new Code(53, nameof(Parameter));
        /// <summary>
        /// ProductionData
        /// </summary>
        public static Code ProductionData = new Code(54, nameof(ProductionData));
        /// <summary>
        /// AIML
        /// </summary>
        public static Code AIML = new Code(55, nameof(AIML));
        /// <summary>
        /// Archives
        /// </summary>
        public static Code Archives = new Code(56, nameof(Archives));
        /// <summary>
        /// Waves
        /// </summary>
        public static Code Waves = new Code(57, nameof(Waves));

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private Code(int id, string name) : base(id, name)
        {
        }

        /// <summary>
        /// Default Constructor for Serialization
        /// </summary>
        public Code() : base(1, nameof(General)) { }
    }

    /// <summary>
    /// DetailCode
    /// </summary>
    [DataContract]
    public class DetailCode : Enumeration
    {
        [DataMember(Order = 1)]
        public override string Name { get; set; }

        [DataMember(Order = 2)]
        public override int Id { get; set; }

        #region Connection - 11000
        /// <summary>
        /// Unauthorized
        /// </summary>
        public static DetailCode Connection_Unauthorized = new DetailCode(11001, nameof(Connection_Unauthorized));
        /// <summary>
        /// Failed
        /// </summary>
        public static DetailCode Connection_Failed = new DetailCode(11002, nameof(Connection_Failed));
        #endregion

        #region Validation - 12000
        /// <summary>
        /// FactoryMandatory
        /// </summary>
        public static DetailCode Validation_FactoryMandatory = new DetailCode(12001, nameof(Validation_FactoryMandatory));
        /// <summary>
        /// LineMandatory
        /// </summary>
        public static DetailCode Validation_LineMandatory = new DetailCode(12002, nameof(Validation_LineMandatory));
        /// <summary>
        /// TimeOrTopNMandatory
        /// </summary>
        public static DetailCode Validation_TimeOrTopNMandatory = new DetailCode(12003, nameof(Validation_TimeOrTopNMandatory));
        /// <summary>
        /// LineMandatory
        /// </summary>
        public static DetailCode Validation_LinesMandatory = new DetailCode(12004, nameof(Validation_LinesMandatory));
        #endregion

        #region Permission - 13000
        /// <summary>
        /// Denied
        /// </summary>
        public static DetailCode Permission_Denied = new DetailCode(13001, nameof(Permission_Denied));
        /// <summary>
        /// RequestUndefined
        /// </summary>
        public static DetailCode Permission_RequestUndefined = new DetailCode(13002, nameof(Permission_RequestUndefined));
        /// <summary>
        /// UserUndefined
        /// </summary>
        public static DetailCode Permission_UserUndefined = new DetailCode(13003, nameof(Permission_UserUndefined));
        #endregion

        #region Topology - 14000
        /// <summary>
        /// Topology_Mismatch
        /// </summary>
        public static DetailCode Topology_Mismatch = new DetailCode(14001, nameof(Topology_Mismatch));
        #endregion

        #region Database - 15000
        /// <summary>
        /// DataBase_ConnectionError
        /// </summary>
        public static DetailCode DataBase_ConnectionError = new DetailCode(15001, nameof(DataBase_ConnectionError));
        /// <summary>
        /// Database_UpgradeFailure
        /// </summary>
        public static DetailCode Database_UpgradeFailure = new DetailCode(15002, nameof(Database_UpgradeFailure));
        /// <summary>
        /// Database_UpgradeDenied
        /// </summary>
        public static DetailCode Database_UpgradeDenied = new DetailCode(15003, nameof(Database_UpgradeDenied));
        #endregion

        #region Persistence - 16000
        #endregion

        #region Backend - 17000
        /// <summary>
        /// UnknownDatabaseType
        /// </summary>
        public static DetailCode Backend_UnknownDatabaseType = new DetailCode(17001, nameof(Backend_UnknownDatabaseType));
        /// <summary>
        /// InternalServerError
        /// </summary>
        public static DetailCode Backend_InternalServerError = new DetailCode(17002, nameof(Backend_InternalServerError));
        #endregion

        #region Frontend - 18000
        #endregion

        #region Data - 19000
        /// <summary>
        /// DataGatheringFailure
        /// </summary>
        public static DetailCode Data_DataGatheringFailure = new DetailCode(19001, nameof(Data_DataGatheringFailure));
        /// <summary>
        /// NoDataAvailable
        /// </summary>
        public static DetailCode Data_NoDataAvailable = new DetailCode(19002, nameof(Data_NoDataAvailable));
        #endregion

        #region File - 20000
        /// <summary>
        /// FileNotFound
        /// </summary>
        public static DetailCode File_FileNotFound = new DetailCode(20001, nameof(File_FileNotFound));
        #endregion

        #region MeasurementData - 51000
        #endregion

        #region Results - 52000
        #endregion

        #region Parameter - 53000
        #endregion

        #region ProductionData - 54000
        #endregion

        #region AIML - 55000
        #endregion

        #region Archives - 56000
        #endregion

        #region Waves - 57000
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        private DetailCode(int id, string name) : base(id, name)
        {
        }

        /// <summary>
        /// Default Constructor for Serialization
        /// </summary>
        public DetailCode() : base(1, nameof(Connection_Unauthorized)) { }

        /// <summary>
        /// String representation for validation
        /// </summary>
        /// <returns></returns>
        public string ToErrorCode()
        {
            return $"{Id};{Name}";
        }
    }
}