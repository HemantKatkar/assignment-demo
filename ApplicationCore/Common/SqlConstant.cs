// <copyright file="SqlConstant.cs" company="Tatvasoft">
// Copyright (c) Tatvasoft. All rights reserved.
// </copyright>

namespace ApplicationCore.Common
{
    /// <summary>
    /// Class SqlConstant
    /// </summary>
    public static class SqlConstant
    {
        /// <summary>
        /// The name
        /// </summary>
        public const string NAME = "@Name";

        /// <summary>
        /// The optionid
        /// </summary>
        public const string OPTIONID = "@OptionId";

        /// <summary>
        /// The code
        /// </summary>
        public const string CODE = "@Code";

        /// <summary>
        /// The message
        /// </summary>
        public const string MESSAGE = "@Message";

        /// <summary>
        /// The varchar maximum size
        /// </summary>
        public const int VARCHARMAXSIZE = 8000;

        /// <summary>
        /// The additems
        /// </summary>
        public const string ADDITEMS = "dbo.AddItems @Name, @OptionId, @Code OUTPUT, @Message OUTPUT";

        /// <summary>
        /// The getoptions
        /// </summary>
        public const string GETOPTIONS = "dbo.GetOptions @Name, @Code OUTPUT, @Message OUTPUT";
    }
}
