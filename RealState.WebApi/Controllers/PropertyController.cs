using RealState.Domain;
using RealState.IDomain;
using RealState.Model.Common;
using RealState.Model.Sale;
using System.Threading;
using System.Web.Http;

namespace RealState.WebApi.Controllers
{
    public class PropertyController : ApiController
    {
        #region Constructor
        public PropertyController()
        {
            _projectManager = new ProjectManager();
        }
        #endregion Constructor

        #region Private Members
        private readonly ProjectManager _projectManager;
        #endregion Private Members

        #region Endpoints
        [HttpGet]
        public virtual IHttpActionResult Lookup(CancellationToken cancellationToken = default(CancellationToken))
        {
            //var person = new Person("Ananda", "López");
            var customer = new Customer("Mauro", "Repizo");
            var salesMan = new SalesPerson("Felipe", "Rayo");

            var x = customer.IntroduceHimself();
            var y = salesMan.IntroduceHimself();


            var projects = _projectManager.GetAll();
            return Ok(projects);
        }
        #endregion Endpoints
    }
}
