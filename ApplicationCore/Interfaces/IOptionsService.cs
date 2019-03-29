using ApplicationCore.Common;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Class IOptionsService
    /// </summary>
    public interface IOptionsService
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <returns>return options.</returns>
        ApiResult<IEnumerable<OptionsResults>> GetOptions(string name);
    }
}
