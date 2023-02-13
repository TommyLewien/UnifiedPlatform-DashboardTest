using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// using Discom.UP.Backend.UpDash.Base.Entities.Common;
using Discom.UP.Backend.UpDash.Base.Interfaces.Application;
using Discom.UP.Backend.UpDash.Interfaces.Infrastructure;

using Discom.UP.DataContracts.Maintenance.ApiVersionQuery;
using Discom.UP.DataContracts.Maintenance.MessageContainer;
using Discom.UP.DataContracts.Maintenance.TopologyModel;
using Discom.UP.DataContracts.Maintenance.TopologyModelQuery;
using Discom.UP.DataContracts.Measurement.Measurement;
using Discom.UP.DataContracts.Measurement.MeasurementQuery;
using Google.Protobuf;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Text.Json;
using Discom.UP.Backend.UpDash.Base.Interfaces.MediatorSimulation;
using Microsoft.AspNetCore.Http.Json;

using NJS =  Newtonsoft.Json;


namespace Discom.UP.Backend.UpDash.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectInfoController : ControllerBase
    {
        HttpClient _httpClient;


        /// <summary>
        /// Constructor for DI
        /// </summary>
        public ProjectInfoController()
        {

            // Http Client
            _httpClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });

        }


        // will map to /api/ProjectInfo/Serialization
        [HttpGet("Serialization")]
        public SerializationInfoModel Serialization()
        {


            string serializationServer = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";


            /// Link to our own api/storage controller
            SerializationInfoModel sm = new SerializationInfoModel()
            {
                SerializationServer = serializationServer,
                SerializationUrl = "api/storage",
            };



            return sm;

        }




        ////// will map to /api/ProjectInfo/Serialization
        //[HttpGet("VersionUpWebApix")]
        //public VersionDTO VersionUpWebApix()
        //{


        //    VersionDTO data = new VersionDTO() { Major = 2, Minor = 1, Patch = 0 };


        //    return data;

        //}



        //// will map to /api/ProjectInfo/Serialization
        [HttpGet("VersionUpWebApi")]
        public async Task<IActionResult> VersionUpWebApi(CancellationToken cancellationToken)
        {

          //  using (var versionQueryRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44304/api/" + nameof(ApiVersionQuery)))

            using (var versionQueryRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost/Discom.UP.Application.WebApi/api/" + nameof(ApiVersionQuery)))
            {
                try
                {
                    versionQueryRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
                    ApiVersionQuery request = new ApiVersionQuery();

                    versionQueryRequestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                    var response = await _httpClient.SendAsync(versionQueryRequestMessage, cancellationToken);
                    if (response.IsSuccessStatusCode)
                    {
                        VersionDTO v = VersionDTO.Parser.ParseFrom(await response.Content.ReadAsStreamAsync());
                        return Ok(v);
                    }
                    else
                    {
                        string errorResult = await response.Content.ReadAsStringAsync();
                        var message = JsonSerializer.Deserialize<MessageContainer>(errorResult);
                        return BadRequest(message);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
        }

        // will map to /api/ProjectInfo/Serialization
        [HttpGet("VersionUpDashApi")]
        public IActionResult VersionUpDashApi()
        {

            VersionDTO versionDTO = new VersionDTO() { Major = 1, Minor = 1, Patch = 0 };


            return Ok(versionDTO);

        }



        // will map to /api/ProjectInfo/FactoryModel
        [HttpGet("FactoryModel")]
        public async Task<IActionResult> FactoryModel(CancellationToken cancellationToken)
        {

            using (var versionQueryRequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44304/api/" + nameof(TopologyModelQuery)))
            {
                try
                {
                    //versionQueryRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
                    versionQueryRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    TopologyModelQuery request = new TopologyModelQuery();

                    versionQueryRequestMessage.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

                    var response = await _httpClient.SendAsync(versionQueryRequestMessage, cancellationToken);
                    if (response.IsSuccessStatusCode)
                    {
                        // TopologyModel tp = TopologyModel.Parser.ParseFrom(await response.Content.ReadAsStreamAsync());
                        TopologyModel tp = TopologyModel.Parser.ParseJson(await response.Content.ReadAsStringAsync());
                        // string ms = await response.Content.ReadAsStringAsync();
                        //var tp = JsonSerializer.Deserialize<TopologyModel>(ms);
                        // var tp = NJS.JsonConvert.DeserializeObject<TopologyModel>(ms);
                        

                        return Ok(tp);
                    }
                    else
                    {
                        string errorResult = await response.Content.ReadAsStringAsync();
                        var message = JsonSerializer.Deserialize<MessageContainer>(errorResult);
                        return BadRequest(message);
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

            }
        }






        // in case of no authentication or the wildcard user "rotas" a random user name will be generated as well
        // will map to /api/ProjectInfo/UserInfo
        //  [Route("[action]")]
        [HttpGet("UserInfo")]
        public IActionResult UserInfo()
        {
            try
            {

                UserInfoModel uim = new UserInfoModel();
                uim.SetRandomUser(); // always generate a random user name in case the client wants to use it
                string? requestUser = this.HttpContext.User?.Identity?.Name;
                if (requestUser == null)
                {
                    uim.User = "unknown";
                    uim.IsAuthenticated = false;
                }
                else
                {
                    uim.User = requestUser;
                    uim.IsAuthenticated = true;
                }
                return Ok(uim);

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new ErrorReport("UserInfo: " + e.Message));
            }

        }

    }
}
