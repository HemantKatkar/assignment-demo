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
    public class ItemsService : IItemsService
    {
        private readonly IRepository<Items> repository;

        public ItemsService(IRepository<Items> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>
        /// return item.
        /// </returns>
        public ApiResult<Items> CreateItems(Items items)
        {
            ApiResult<Items> result = new ApiResult<Items>();
            ICollection<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(Helper.SqlInputParam(SqlConstant.NAME, items.Name, SqlDbType.VarChar));
            parameters.Add(Helper.SqlInputParam(SqlConstant.OPTIONID, items.OptionId, SqlDbType.Int));
            Helper.AddResultOutputParams(ref parameters);

            var datalist = this.repository.ExecWithStoreProcedure(SqlConstant.ADDITEMS, parameters.ToArray()).ToList();
            Helper.SetResultParams(ref result, ref parameters);

            return result;
        }
    }
}
