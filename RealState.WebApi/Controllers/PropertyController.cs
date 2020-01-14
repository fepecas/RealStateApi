using RealState.Domain;
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
            var projects = _projectManager.GetAll();
            return Ok(projects);
        }
        #endregion Endpoints
    }
}
