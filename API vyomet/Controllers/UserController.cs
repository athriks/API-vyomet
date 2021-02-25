using API_vyomet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;


namespace API_vyomet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly UserContext _context;

        public IActionResult OK { get; private set; }

        public UserController(UserContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User model)
        {
            try
            {
                //var newUser = new User()
                //{
                //    MobileNumber = model.MobileNumber
                //};
                //await _context.User.AddAsync(newUser);
                //await _context.SaveChangesAsync();

                //return Ok("DONE");
                int otpValue = new Random().Next(100000, 999999);
                var status = "";
               
                    string recipient = "7259822910";
                    string APIKey ="EhBm/ALkt/I-neVET3r85YmY1kAoqsWYWk6Jt0wJgZ";

                    string message = "Your OTP Number is " + otpValue + " ( Sent By : Technotips-Ashish )";
                    String encodedMessage = HttpUtility.UrlEncode(message);

                using (var webClient = new WebClient())
                {
                    byte[] response = webClient.UploadValues("http://api.lxalerts.earthnetworks.com/CellAlerts.aspx?nwlat=35.5133&nwlon=68.1649&selat=6.7524&selon=97.389&level=1,2,3&format=CAP&partnerid=AB203E79-001B-4221-BEC7-BC9490C34D7E", new NameValueCollection(){

                                         {"apikey" , APIKey},
                                         {"numbers" , recipient},
                                         {"message" , encodedMessage},
                                         {"sender" , "TXTLCL"}});

                    string result = System.Text.Encoding.UTF8.GetString(response);

                    var jsonObject = JObject.Parse(result);

                    status = jsonObject["status"].ToString();
                
                }
                return Ok(status);



            }
            catch (Exception e)
            {
                throw (e);
               
            }

        }

        
    }
}
