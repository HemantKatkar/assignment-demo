// <copyright file="IRepository.cs" company="Tatvasoft">
// Copyright (c) Tatvasoft. All rights reserved.
// </copyright>

namespace ApplicationCore.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ApplicationCore.Common;

    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T">any class</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Executes the with store procedure.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns> returns result of stored procedure</returns>
        IQueryable<T> ExecWithStoreProcedure(string query, params object[] parameters);

        /// <summary>
        /// Executes the stored procedure list.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>returns result of stored procedures</returns>
        IQueryable<TEntity> ExecuteStoredProcedureList<TEntity>(string sql, params object[] parameters)
            where TEntity : class;
    }
}
