using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApiADO.Models.HallsTypes.Blank;
using CinemaApiADO.Models.HallsTypes.Domain;
using CinemaApiADO.Models.HallsTypes.View;
using CinemaApiADO.Models.Roles.Blank;
using CinemaApiADO.Models.Roles.Domain;
using CinemaApiADO.Models.Roles.View;
using CinemaApiAdo.Services.HallTypes;
using CinemaApiAdo.Services.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IRoleService _service;
        public RolesController(ILogger<RolesController> logger, IRoleService sessionService)
        {
            _logger = logger;
            _service = sessionService;
        }

        [HttpGet("all")]
        public IEnumerable<RoleView> GetAll()
        {
            IEnumerable<RoleDomain> sessiondomain = _service.GetAllRole();
            return RoleView.Convert(sessiondomain);
        }
          
        [HttpPost("create")]
        public void Create([FromBody] RoleBlank roleBlank)
        {
            _service.CreateRole(roleBlank);
        }

        [HttpPost("remove")]
        public void Delete(int roleId)
        {
            _service.DeleteRole(roleId);
        }

        [HttpPost("update")]
        public void Update(int roleId, RoleBlank roleBlank)
        {
            _service.UpdateRole(roleId,roleBlank);
        }
    }
}
