// <copyright file="EfRepository.cs" company="Tatvasoft">
// Copyright (c) Tatvasoft. All rights reserved.
// </copyright>

namespace Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ApplicationCore.Common;
    using ApplicationCore.Interfaces;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// class EfRepository
    /// </summary>
    public sealed class EfRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DBContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EfRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Executes the with store procedure.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>returns result of stored procedure</returns>
        public IQueryable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return this.dbContext.Set<T>().FromSql(query, parameters);
        }

        /// <summary>
        /// Executes the stored procedure list.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>returns result of stored procedures</returns>
        public IQueryable<TEntity> ExecuteStoredProcedureList<TEntity>(string sql, params object[] parameters)
            where TEntity : class
            => this.dbContext.Set<TEntity>().FromSql(sql, parameters);
    }
}
