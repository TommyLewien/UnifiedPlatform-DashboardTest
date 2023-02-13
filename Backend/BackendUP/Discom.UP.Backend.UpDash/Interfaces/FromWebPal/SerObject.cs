using System.Runtime.Serialization;

namespace Discom.UP.Backend.UpDash.Interfaces.FromWebPal
{
    [DataContract(Name = "StorageController.SerObject", Namespace = "http://schemas.datacontract.org/2004/07/Discom.Service.Serialization.Controllers")]
    public class SerObject
    {
        [DataMember()]
        public string? Application { get; set; }
        [DataMember()]
        public string? User { get; set; }
        [DataMember()]
        public string? StorageClass { get; set; }
        [DataMember()]
        public string? Instance { get; set; }
        [DataMember()]
        public string? XDoc { get; set; }
        [DataMember()]
        public bool IsSuccess { get; set; }

        public SerObject()
        {
        }
    }
}
