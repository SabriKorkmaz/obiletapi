using ApiHelper.Api;
using ApiHelper.Api.Base;
using ApiHelper.Models;
using ApiHelper.Models.Base;
using Newtonsoft.Json;
using obilet.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace obilet.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public async Task<string> GetLocations(DeviceSession session)
        {
            if (string.IsNullOrEmpty(session.SessionId))
            {
                var sessionInfo = await ApiBase.GetSession();
                session.SessionId = sessionInfo.Data.sessionId;
                session.DeviceId = sessionInfo.Data.deviceId;
            }

            var bodyParam = new RequestBase<string>
            {
                Data = null,
                DeviceSession = new DeviceSession
                {
                    DeviceId = session.DeviceId,
                    SessionId = session.SessionId
                },
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(bodyParam, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
            var response = await Client.Instance.PostAsync("/api/location/getbuslocations", stringContent);

            if (response.StatusCode != HttpStatusCode.OK) throw new HttpUnhandledException();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<ResponseBase<object>>(responseString);
            return JsonConvert.SerializeObject(new { responseData.Data, session.SessionId, session.DeviceId });

        }
        [HttpPost]
        public async Task<string> GetJourneys(JourneyModel model)
        {

            if (string.IsNullOrEmpty(model.SessionId))
            {
                var sessionInfo = await ApiBase.GetSession();
                model.SessionId = sessionInfo.Data.sessionId;
                model.DeviceId = sessionInfo.Data.deviceId;
            }

            var bodyParam = new RequestBase<Journeys>()
            {
                Data = new Journeys()
                {
                    Date = Convert.ToDateTime(model.Date),
                    DestinationId = model.DestinationId,
                    OriginId = model.OriginId
                },
                DeviceSession = new DeviceSession()
                {
                    DeviceId = model.DeviceId,
                    SessionId = model.SessionId
                },

            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(bodyParam, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
            var response = await Client.Instance.PostAsync("/api/journey/getbusjourneys", stringContent);
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpUnhandledException();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<ResponseBase<object>>(responseString);
            return JsonConvert.SerializeObject(new { responseData.Data, model.SessionId, model.DeviceId });

        }
    }
}
