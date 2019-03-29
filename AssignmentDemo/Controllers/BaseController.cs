using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApplicationCore.Common;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDemo.Controllers
{
    /// <summary>
    /// Class BaseController
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>The http result.</returns>
        protected IActionResult GetErrorResult(HttpStatusCode code, string message)
        {
            return this.GetErrorResult(code, new List<string> { message });
        }

        /// <summary>
        /// Gets the error list result.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="messages">The messages.</param>
        /// <returns>The error list result</returns>
        protected IActionResult GetErrorResult(HttpStatusCode code, IEnumerable<string> messages)
        {
            ErrorResult result = new ErrorResult();
            result.Messages.AddRange(messages);

            return this.StatusCode((int)code, result);
        }

        /// <summary>
        /// Gets the error result.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>The http result.</returns>
        protected IActionResult GetErrorResult(int code, string message)
        {
            return this.GetErrorResult(code, new List<string> { message });
        }

        /// <summary>
        /// Gets the error list result.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="messages">The messages.</param>
        /// <returns>The error list result</returns>
        protected IActionResult GetErrorResult(int code, IEnumerable<string> messages)
        {
            return this.GetErrorResult((HttpStatusCode)code, messages);
        }

        /// <summary>
        /// Gets the API result.
        /// </summary>
        /// <typeparam name="T">item class</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="errorBody">if set to <c>true</c> [error body].</param>
        /// <returns>
        /// return api result.
        /// </returns>
        protected IActionResult GetResult<T>(ApiResult<T> result, bool errorBody = false)
            where T : class
        {
            if (result == null)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }
            else if (!result.IsValid)
            {
                if (errorBody && !string.IsNullOrWhiteSpace(result.Message))
                {
                    return this.GetErrorResult(result.Code, result.Message);
                }

                return this.StatusCode(result.Code);
            }

            return this.StatusCode(result.Code, result.Item);
        }

        /// <summary>
        /// Gets the API result.
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="result">The result.</param>
        /// <param name="errorBody">if set to <c>true</c> [error body].</param>
        /// <returns>return api result for list.</returns>
        protected IActionResult GetResult<T>(ApiResult<IEnumerable<T>> result, bool errorBody = false)
            where T : class
        {
            if (result == null)
            {
                return this.StatusCode((int)HttpStatusCode.InternalServerError);
            }
            else if (!result.IsValid || !result.IsSuccessStatusCode)
            {
                if (errorBody && !string.IsNullOrWhiteSpace(result.Message))
                {
                    return this.GetErrorResult(result.Code, result.Message);
                }

                return this.StatusCode(result.Code);
            }

            return this.StatusCode(result.Code, result.Item);
        }

        /// <summary>
        /// Validates the post.
        /// </summary>
        /// <typeparam name="T">T Type</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>
        /// return model errors.
        /// </returns>
        protected ICollection<string> ValidatePost<T>(T model)
            where T : class
        {
            ICollection<string> errors = this.Validate<T>(model);

            return errors;
        }

        /// <summary>
        /// Validates the post.
        /// </summary>
        /// <typeparam name="T">Item class</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>validate model errors</returns>
        protected ICollection<string> ValidatePatch<T>(T model)
            where T : class
        {
            ICollection<string> errors = this.Validate<T>(model);

            return errors;
        }

        /// <summary>
        /// Validates the model.
        /// </summary>
        /// <typeparam name="T">T Type</typeparam>
        /// <param name="model">The model.</param>
        /// <returns>return errors.</returns>
        protected ICollection<string> Validate<T>(T model)
        where T : class
        {
            List<string> errors = new List<string>();

            if (model == null || !this.ModelState.IsValid)
            {
                errors.AddRange(this.GetModelStateErrors());
            }

            return errors;
        }

        /// <summary>
        /// Gets the model state errors.
        /// </summary>
        /// <returns>returns error messages.</returns>
        private IEnumerable<string> GetModelStateErrors()
        {
            return this.ModelState.Values.SelectMany(e => e.Errors.Select(m => m.ErrorMessage));
        }
    }
}