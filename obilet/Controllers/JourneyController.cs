using ApiHelper.Api;
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
using obilet.Attribute;

namespace obilet.Controllers
{
    [SessionAuthorize]
    public class JourneyController : Controller
    {
        [HttpPost]
        public async Task<string> GetJourneys(JourneyModel model)
        {
            var authToken = Request.Headers["auth-token"];
            var session = authToken.Split(',');

          
            var bodyParam = new RequestBase<Journeys>()
            {
                Data = new Journeys()
                {
                    Date = Convert.ToDateTime(model.Date),
                    DestinationId = model.DestinationId,
                    OriginId = model.OriginId
                },
                DeviceSession = new DeviceSession
                {
                    DeviceId = session[1],
                    SessionId = session[0]
                }

            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(bodyParam, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
            var response = await Client.Instance.PostAsync("/api/journey/getbusjourneys", stringContent);
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpUnhandledException();
            var responseString = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonConvert.DeserializeObject<ResponseBase<object>>(responseString);
            return JsonConvert.SerializeObject(new { responseData.Data});
        }
    }
}
