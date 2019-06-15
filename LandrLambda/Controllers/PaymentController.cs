using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace LandrLambda.Controllers
{
    [Route("api/Payment")]
    //[EnableCors(origins: "https://upa5wme7j2.execute-api.us-east-1.amazonaws.com/prod", headers: "*", methods: "*")]
    public class PaymentController : Controller
    {
        string ResponseOk = "{\"status\": \"1\", \"message\": \"success\", \"data\":[message]}";
        string ResponseErr = "{\"status\": \"0\", \"message\": \"error occurred\"}";


        string clientSecretprivate = System.Configuration.ConfigurationManager.AppSettings["ClientSecret"].ToString();

       
        string ResponseType = "application/json; charset=utf-8";

        
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]int userid, [FromBody]string email, [FromBody]string token)
        {
            string retvel = string.Empty;
            DbConnect masterobj = new DbConnect();
           // string header = Convert.ToString(HttpContext.Current.Request.Headers["Token"]);
           // if (header == ValidateToken())
           // {
                masterobj.AddUserPayments(userid, email, token);


                retvel = ResponseOk.Replace("[message]", "\"Payment Saved.\"");


            //}
           // else
           // {
               // retvel = ResponseErr.Replace("error occurred", "Invalid Token!");
           // }
           return retvel;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
