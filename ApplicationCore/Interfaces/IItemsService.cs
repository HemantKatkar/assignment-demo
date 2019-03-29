using ApplicationCore.Common;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Class IItemsService
    /// </summary>
    public interface IItemsService
    {
        /// <summary>
        /// Creates the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>return item.</returns>
        ApiResult<Items> CreateItems(Items items);
    }
}
