using ApiHelper.Models.Base;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ApiHelper.Api.Base
{
    public class ApiBase
    {
        public static async Task<ResponseBase<SessionInfo>> GetSession()
        {
                var bodyParam = new Session
                {
                    Type = 7,
                    Connection = new Connection
                    {
                        ipAddress = HttpContext.Current.Request.UserHostAddress,
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
                var responseData = JsonConvert.DeserializeObject<ResponseBase<SessionInfo>>(responseString);
                return responseData;

        }
    }
}
