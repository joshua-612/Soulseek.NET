﻿// <copyright file="MessageException.cs" company="JP Dillingham">
//     Copyright (c) JP Dillingham. All rights reserved.
//
//     This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as
//     published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
//     of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License along with this program. If not, see https://www.gnu.org/licenses/.
// </copyright>

namespace Soulseek.NET.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Represents errors that occur while handling network messages.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class MessageException : SoulseekClientException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageException"/> class.
        /// </summary>
        public MessageException()
            : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MessageException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner
        ///     exception is specified.
        /// </param>
        public MessageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected MessageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while compressing or decomressing network message payload data.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class MessageCompressionException : MessageException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageCompressionException"/> class.
        /// </summary>
        public MessageCompressionException()
            : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageCompressionException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MessageCompressionException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageCompressionException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner
        ///     exception is specified.
        /// </param>
        public MessageCompressionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageCompressionException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected MessageCompressionException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }

    /// <summary>
    ///     Represents errors that occur while reading the payload of a network message.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class MessageReadException : MessageException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageReadException"/> class.
        /// </summary>
        public MessageReadException()
            : base()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageReadException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MessageReadException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageReadException"/> class with a specified error message and a
        ///     reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner
        ///     exception is specified.
        /// </param>
        public MessageReadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageReadException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        protected MessageReadException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
