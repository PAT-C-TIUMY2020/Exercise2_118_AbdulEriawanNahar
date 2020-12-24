using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
namespace ServiceRest3b
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITI_UMY
    {
        [OperationContract]
        [WebGet(UriTemplate = "Mahasiswa", ResponseFormat = WebMessageFormat.Json)]
        List<Mahasiswa> GetAllMahasiswa();

        [OperationContract]
        [WebInvoke(UriTemplate = "Mahasiswa/nim=(nim)", ResponseFormat = WebMessageFormat.Json)]
        Mahasiswa GetMahasiswaByNIM(string nim);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Mahasiswa", RequestFormat = WebMessageFormat.Json)]
        string CreateMahasiswa(Mahasiswa mhs);
        [OperationContract]
        [WebInvoke(Method = "PUT", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Mahasiswa1", ResponseFormat = WebMessageFormat.Json)]
        string UpdateMahasiswa(string nim, string nama, string prodi, string angkatan);
        [OperationContract]
        [WebInvoke(Method = "DELETE", BodyStyle = WebMessageBodyStyle.WrappedRequest, UriTemplate = "Mahasiswa2", RequestFormat = WebMessageFormat.Json)]
        string DeleteMahasiswa(string nim);
        [OperationContract]
        [WebInvoke(UriTemplate = "Mahasiswa3", ResponseFormat = WebMessageFormat.Json)]
        string CountMahasiswa();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ServiceRest3b.ContractType".
    [DataContract]
    public class Mahasiswa
    {
        private string _nama, _nim, _prodi, _angkatan;
        [DataMember(Order = 1)]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember(Order = 2)]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }
        [DataMember(Order = 3)]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember(Order = 4)]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }
}
