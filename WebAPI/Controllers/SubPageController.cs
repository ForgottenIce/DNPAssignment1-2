using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SubPageController : ControllerBase {
        private readonly ISubPageLogic subPageLogic;
        private readonly IPostLogic postLogic;

        public SubPageController(ISubPageLogic subPageLogic, IPostLogic postLogic) {
            this.subPageLogic = subPageLogic;
            this.postLogic = postLogic;
        }

        [HttpPost]
        public async Task<ActionResult<SubPage>> CreateAsync(SubPageCreationDto dto) {
            throw new NotImplementedException();
        }
    }
}
