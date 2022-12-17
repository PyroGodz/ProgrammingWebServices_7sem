using solution.JsonSindication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace solution
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IFeed1" в коде и файле конфигурации.
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    [ServiceKnownType(typeof(JsonFeedFormatter))]
    [ServiceKnownType(typeof(List<Note>))]
    public interface IFeed1
    {

        [OperationContract]
        [WebGet(UriTemplate = "/createFeed", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter CreateFeed();

        [OperationContract]
        [WebGet(UriTemplate = "/students/{studentId}/notes", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetStudentNotes(string studentId);

        [OperationContract]
        [WebGet(UriTemplate = "/students/{studentId}/notes/json", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetStudentNotesJson(string studentId);

        // TODO: Добавьте здесь операции служб
    }
}
