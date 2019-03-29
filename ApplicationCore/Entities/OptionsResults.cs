using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class OptionsResults
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>
        /// The options.
        /// </value>
        public IEnumerable<Options> Options { get; set; }
    }
}
