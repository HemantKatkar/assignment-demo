using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.Common;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : BaseController
    {
        private readonly IItemsService itemsService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsController"/> class.
        /// </summary>
        /// <param name="itemsService">The items service.</param>
        public ItemsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }

        /// <summary>
        /// Creates the item.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>return item</returns>
        [HttpPost]
        public IActionResult CreateItem([FromBody]Items items)
        {
            ICollection<string> errors = this.Validate<Items>(items);
            if (!errors.Any())
            {
                ApiResult<Items> result = this.itemsService.CreateItems(items);
                return this.GetResult(result, true);
            }

            return this.GetErrorResult(HttpStatusCode.BadRequest, errors);
        }
    }
}
