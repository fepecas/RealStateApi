using RealState.Domain;
using RealState.Model.PaymentPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace RealState.WebApi.Controllers
{
    public class PaymentPlanController : ApiController
    {
        public PaymentPlanManager _paymentPlanManager { get; set; }

        public PaymentPlanController()
        {
            _paymentPlanManager = new PaymentPlanManager();
        }

        [HttpPost]
        public IHttpActionResult Analyze([FromBody] PaymentPlanRequest plan, CancellationToken cancellationToken = default(CancellationToken))
        {
           var response = _paymentPlanManager.Analyze(plan);
            return Ok(response);
        }
    }
}
