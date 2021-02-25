using API_vyomet.Controllers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace API_vyomet.Services
{
    public class MyCronJob1 : CronJobService
    {
        private readonly ILogger<MyCronJob1> _logger;
        public MyCronJob1(IScheduleConfig<MyCronJob1> config, ILogger<MyCronJob1> logger)
         : base(config.CronExpression, config.TimeZoneInfo)
        {
            _logger = logger;
        }

        //public string aa(string a)
        //{
        //    return a;
        //}
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 starts.");
            return base.StartAsync(cancellationToken);
        }
        

        public override async Task DoWork(CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();
            _logger.LogInformation("CronJob 1 dowrk.");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response =  httpClient.GetAsync("http://api.lxalerts.earthnetworks.com/CellAlerts.aspx?nwlat=12.3000&nwlon=-78.0000&selat=-59.6000&selon=-33.2000&level=1,2,3&format=CAP&partnerid=AB203E79-001B-4221-BEC7-BC9490C34D7E").Result;
            _logger.LogInformation("quoteJson" + response);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                XDocument xdoc = XDocument.Parse(response.Content.ReadAsStringAsync().Result);
                    _logger.LogInformation("quoteJson" + xdoc);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xdoc.ToString());
                var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
              _logger.LogInformation("quoteJson" + json);

                JObject json1 = JObject.Parse(json);
                _logger.LogInformation("quoteJson" + json1);

                //for (var i = 0; i < json["alert"].length; i++)
                //  {
                //      _logger.LogInformation("quoteJson" + );

                //  }



            }
        }
    
                public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("CronJob 1 is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}
