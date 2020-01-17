using RealState.Domain;
using RealState.Model.Enum;
using RealState.Model.Property;
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
            _propertyManager = new PropertyManager();
        }
        #endregion Constructor

        #region Private Members
        private readonly ProjectManager _projectManager;
        private readonly PropertyManager _propertyManager;
        #endregion Private Members

        #region Endpoints
        [HttpGet]
        public virtual IHttpActionResult Lookup(CancellationToken cancellationToken = default(CancellationToken))
        {
            var projects = _projectManager.GetAll();
            return Ok(projects);
        }

        [HttpGet]
        public virtual IHttpActionResult Get([FromUri] int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var property = _propertyManager.GetById(id);
            return Ok(property);
        }
        #endregion Endpoints
    }
}
