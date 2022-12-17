using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LB3.Models
{
    [DataContract]
    public class Page
    {
        public Page() { }

        [DataMember]
        public List<Student> Students { get; set; }
        [DataMember]
        public HateoasPageLinks _links { get; set; }
    }
}