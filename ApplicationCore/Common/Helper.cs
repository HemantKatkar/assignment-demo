// <copyright file="Helper.cs" company="Tatvasoft">
// Copyright (c) Tatvasoft. All rights reserved.
// </copyright>

namespace ApplicationCore.Common
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Security.Claims;
    using ApplicationCore.Entities;

    /// <summary>
    /// Class Helper
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// to check passed parameter is null or not. is null then return db null value
        /// </summary>
        /// <param name="value">Object values</param>
        /// <returns>Returns Null values</returns>
        public static object ToDBNull(object value)
        {
            if (value != null)
            {
                return value;
            }

            return DBNull.Value;
        }

        /// <summary>
        /// SQLs the input parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <returns>Returns Input Parameter</returns>
        public static SqlParameter SqlInputParam(string name, object value, SqlDbType sqlType)
        {
            SqlParameter input = new SqlParameter(name, ToDBNull(value));
            input.SqlDbType = sqlType;
            input.Direction = ParameterDirection.Input;

            return input;
        }

        /// <summary>
        /// SQLs the input parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="sqlType">Type of the SQL.</param>
        /// <param name="size">The size.</param>
        /// <returns>
        /// Returns Input Parameter
        /// </returns>
        public static SqlParameter SqlOutputParam(string name, SqlDbType sqlType, int? size = null)
        {
            SqlParameter output = new SqlParameter(name, sqlType);
            output.Direction = ParameterDirection.Output;

            if (size.HasValue)
            {
                output.Size = size.Value;
            }

            return output;
        }

        /// <summary>
        /// Gets the SQL parameter value.
        /// </summary>
        /// <typeparam name="T">class items</typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// return sql parameter value
        /// </returns>
        public static T GetSqlParamValue<T>(string parameterName, IEnumerable<SqlParameter> parameters)
        {
            return parameters.Where(x => IsEqual(x.ParameterName, parameterName)).Select(y => y.Value).OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Adds the result output parameter(s).
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        public static void AddResultOutputParams(ref ICollection<SqlParameter> parameters)
        {
            parameters.Add(SqlOutputParam(SqlConstant.CODE, SqlDbType.Int));
            parameters.Add(SqlOutputParam(SqlConstant.MESSAGE, SqlDbType.VarChar, SqlConstant.VARCHARMAXSIZE));
        }

        /// <summary>
        /// Sets the result parameter(s).
        /// </summary>
        /// <typeparam name="T">Entity class.</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="parameters">The parameters.</param>
        public static void SetResultParams<T>(ref ApiResult<T> result, ref ICollection<SqlParameter> parameters)
            where T : class
        {
            result.Code = GetSqlParamValue<int>(SqlConstant.CODE, parameters);
            result.Message = GetSqlParamValue<string>(SqlConstant.MESSAGE, parameters);
        }

        /// <summary>
        /// Determines whether the specified values are equal or both empty.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns>returns status</returns>
        public static bool IsEqual(string first, string second)
        {
            return (string.IsNullOrEmpty(first) && string.IsNullOrWhiteSpace(second)) || (!string.IsNullOrEmpty(first) && first.Equals(second, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
