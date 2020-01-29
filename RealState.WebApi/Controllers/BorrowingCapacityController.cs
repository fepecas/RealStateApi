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
        public BorrowingCapacityManager BorrowingCapacityManager { get; set; }

        public BorrowingCapacityController()
        {
            BorrowingCapacityManager = new BorrowingCapacityManager();
        }

        [HttpPost]
        public IHttpActionResult Consult([FromBody] BorrowingCapacity sheet, CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = _borrowingCapacity.Consult(sheet);
            return Ok(response);
        }
    }
}
