using Newtonsoft.Json;
using obilet.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using obilet.Model.Session;
using obilet.Utilities.Client;

namespace obilet.Controllers
{
    public class SessionController : Controller
    {
        public async Task<object> GetSession(JourneyModel model)
        {
            var bodyParam = new Session
            {
                Type = 7,
                Connection = new Connection
                {
                    ipAddress = HttpContext.Request.UserHostAddress,
                },
                Application = new Application
                {
                    EquipmentId = "distribusion",
                    Version = "1.0.0.0"
                }
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(bodyParam, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
            var response = await Client.Instance.PostAsync("/api/client/getsession", stringContent);
            var result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode != HttpStatusCode.OK) throw new HttpUnhandledException();
            var responseString = result;
            var responseData = JsonConvert.DeserializeObject<object>(responseString);
            return responseData;
        }
    }
}
