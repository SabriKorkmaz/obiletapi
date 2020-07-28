
//using ApiHelper.Api.Base;
//using ApiHelper.Models.Base;
//using Newtonsoft.Json;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http.Cors;
//using System.Web.Mvc;

//namespace obiletApi.Controllers
//{
//    public class HomeController : Controller
//    {
//        string key = "ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx";
//        string sessionId = string.Empty;
//        string deviceId = string.Empty;
//        [EnableCors(origins: "http://localhost:54761", headers: "*", methods: "*")]
//        public async Task<ActionResult> GetLocations()
//        {
//            if (string.IsNullOrEmpty(Session["apiSessionId"] as string))
//            {
//                string sessionId = string.Empty;
//                string deviceId = string.Empty;
//                ResponseBase<SessionInfo> sessionInfo = await ApiBase.GetSession(key);
//                Session["apiSessionId"] = sessionInfo.Data.sessionId;
//                Session["apiDeviceId"] = sessionInfo.Data.deviceId;
//            }

//            using (var client = new HttpClient())
//            {
//                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//                client.DefaultRequestHeaders.Add("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");


//                var bodyParam = new RequestBase<string>()
//                {
//                    Data = null,
//                    DeviceSession = new DeviceSession()
//                    {
//                        DeviceId = Session["apiDeviceId"].ToString(),
//                        SessionId = Session["apiSessionId"].ToString()
//                    }
//                };
//                var stringContent = new StringContent(JsonConvert.SerializeObject(bodyParam, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
//                string jsonContent = stringContent.ReadAsStringAsync().Result;
//                var response = await client.PostAsync("https://v2-api.obilet.com/api/location/getbuslocations", stringContent);
//                if (response.StatusCode == HttpStatusCode.OK)
//                {
//                    var responseString = response.Content.ReadAsStringAsync().Result;
//                    ResponseBase<object> responseData = JsonConvert.DeserializeObject<ResponseBase<object>>(responseString);
//                    return Json(JsonConvert.SerializeObject(responseData.Data), JsonRequestBehavior.AllowGet);
//                }
//                else
//                {
//                    var responseString = response.Content.ReadAsStringAsync().Result;
//                    throw new HttpUnhandledException();
//                }
//            }
//        }
//    }
//}
