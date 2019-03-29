// <copyright file="ErrorResult.cs" company="Tatvasoft">
// Copyright (c) Tatvasoft. All rights reserved.
// </copyright>

namespace ApplicationCore.Common
{
    using System.Collections.Generic;

    /// <summary>
    ///  Class ErrorResult
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        public ErrorResult()
        {
            this.Messages = new List<string>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public List<string> Messages { get; set; }
    }
}
