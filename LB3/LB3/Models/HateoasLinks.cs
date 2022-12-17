using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LB3.Models
{
	[DataContract]
	public class HateoasLinks
    {
		[DataMember]
		public string allStudents;
		[DataMember]
		public string self;

		public HateoasLinks(string allStudents, string self)
		{
			this.allStudents = allStudents;
			this.self = self;
		}
	}


    [DataContract]
    public class HateoasPageLinks
    {
        [DataMember]
        public List<string> allPages;
        [DataMember]
        public string self;

        public HateoasPageLinks(List<string> allPages, string self)
        {
            this.allPages = allPages;
            this.self = self;
        }
    }
}