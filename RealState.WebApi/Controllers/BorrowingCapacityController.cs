using RealState.Domain;
using RealState.Model.BorrowingCapacity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace RealState.WebApi.Controllers
{
    public class BorrowingCapacityController : ApiController
    {
        public BorrowingCapacityManager _borrowingCapacityManager { get; set; }

        public BorrowingCapacityController()
        {
            _borrowingCapacityManager = new BorrowingCapacityManager();
        }

        [HttpPost]
        public IHttpActionResult Analyze([FromBody] BorrowingCapacity sheet, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = _borrowingCapacity.Analyze(sheet);
            return Ok(response);
        }
    }
}
