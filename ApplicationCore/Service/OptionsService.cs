using ApplicationCore.Common;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ApplicationCore.Service
{
    /// <summary>
    /// Class OptionsService
    /// </summary>
    /// <seealso cref="ApplicationCore.Interfaces.IOptionsService" />
    public class OptionsService : IOptionsService
    {
        private readonly IRepository<Options> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public OptionsService(IRepository<Options> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <returns>
        /// return options.
        /// </returns>
        public ApiResult<IEnumerable<OptionsResults>> GetOptions(string name)
        {
            ApiResult<IEnumerable<OptionsResults>> result = new ApiResult<IEnumerable<OptionsResults>>();
            ICollection<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(Helper.SqlInputParam(SqlConstant.NAME, name, SqlDbType.VarChar));
            Helper.AddResultOutputParams(ref parameters);
            var datalist = this.repository.ExecWithStoreProcedure(SqlConstant.GETOPTIONS, parameters.ToArray()).ToList();
            var optionsData = datalist.ToList();
            Helper.SetResultParams(ref result, ref parameters);
            result.Item = optionsData.GroupBy(x => x.Category).Select(y => new OptionsResults() { Category = y.Key, Options = y.ToList() });

            return result;
        }
    }
}
