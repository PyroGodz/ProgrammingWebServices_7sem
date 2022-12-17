using Newtonsoft.Json;
using solution.JsonSindication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace solution
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Feed1" в коде и файле конфигурации.
    public class Feed1 : IFeed1
    {
        public SyndicationFeedFormatter CreateFeed()
        {
            // Создать новый веб-канал.
            SyndicationFeed feed = new SyndicationFeed("Feed Title", "A WCF Syndication Feed", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            // Создать новый элемент рассылки.
            SyndicationItem item = new SyndicationItem("An item", "Item content", null);
            items.Add(item);
            feed.Items = items;

            // Возвращать канал ATOM или RSS, основываясь на строке запроса
            // RSS-&gt; http://localhost:8733/Design_Time_Addresses/solution/Feed1/
            // Atom-&gt; http://localhost:8733/Design_Time_Addresses/solution/Feed1/?format=atom
            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter = null;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }

            return formatter;
        }

        public SyndicationFeedFormatter GetStudentNotes(string studentId)
        {
            SyndicationFeed feed = new SyndicationFeed("Subjects & Notes", "Get list of notes by all subjects for this student", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            string wdsNotesUrl = "https://localhost:44357/WcfDataService1.svc/Note?$filter=(StudentId%20eq%20" + studentId + ")&$format=json";
            //string studentFilter = String.Format("StudentId%20eq%20{0}", studentId);
            //string requestUrl = String.Format("{0}?$format={1}&$filter={2}", wdsNotesUrl, "json", studentFilter);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(wdsNotesUrl);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            string responseString = reader.ReadToEnd();

            var notesResp = JsonConvert.DeserializeObject<NoteResponse>(responseString);
            var notes = notesResp.Value;

            foreach (var note in notes)
            {
                items.Add(new SyndicationItem(note.Subj, note.NoteValue.ToString(), null));
            }
            feed.Items = items;

            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }
            return formatter;
        }

        public SyndicationFeedFormatter GetStudentNotesJson(string studentId)
        {
            SyndicationFeed feed = new SyndicationFeed("Subjects & Notes", "Get list of notes by all subjects for this student", null);
            List<SyndicationItem> items = new List<SyndicationItem>();

            string wdsNotesUrl = "http://localhost:51172/DataServices/WDS.svc/Notes/";
            string studentFilter = String.Format("StudentId%20eq%20{0}", studentId);
            string requestUrl = String.Format("{0}?$format={1}&$filter={2}", wdsNotesUrl, "json", studentFilter);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            string responseString = reader.ReadToEnd();

            var notesResp = JsonConvert.DeserializeObject<NoteResponse>(responseString);
            var notes = notesResp.Value;

            foreach (var note in notes)
            {
                items.Add(new SyndicationItem(note.Subj, note.NoteValue.ToString(), null));
            }
            feed.Items = items;

            string query = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters["format"];
            SyndicationFeedFormatter formatter;
            if (query == "atom")
            {
                formatter = new Atom10FeedFormatter(feed);
            }
            else if (query == "json")
            {
                formatter = new JsonFeedFormatter(feed);
            }
            else
            {
                formatter = new Rss20FeedFormatter(feed);
            }
            return formatter;
        }
    }
}
