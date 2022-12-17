using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution
{
    class Note
    {
        [JsonProperty("Subj")]
        public string Subj { get; set; }

        [JsonProperty("NoteValue")]
        public int NoteValue { get; set; }        
    }

    class NoteResponse
    {
        public Note[] Value { get; set; }
    }
}
