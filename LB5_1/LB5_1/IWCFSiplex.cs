using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LB5_1
{
    [ServiceContract]
    public interface IWCFSiplex
    {

        [OperationContract]
        [WebGet(UriTemplate="Add?x={x}&y={y}")]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string str, double d);

        [OperationContract]
        A Sum(A objOne, A objTwo);

    }

    [DataContract]
    public class A
    {
        [DataMember]
        public string s { get; set; }

        [DataMember]
        public int k { get; set; }

        [DataMember]
        public float f { get; set; }
    }
}
