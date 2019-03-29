using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Common;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDemo.Controllers
{
    /// <summary>
    /// Class OptionsController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class OptionsController : BaseController
    {
        private readonly IOptionsService optionsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsController"/> class.
        /// </summary>
        /// <param name="optionsService">The options service.</param>
        public OptionsController(IOptionsService optionsService)
        {
            this.optionsService = optionsService;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>return options.</returns>
        [HttpGet]
        public IActionResult GetOptions([FromQuery]string name)
        {
            ApiResult<IEnumerable<OptionsResults>> result = this.optionsService.GetOptions(name);
            return this.GetResult(result, true);
        }
    }
}