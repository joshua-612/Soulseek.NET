﻿// <copyright file="EnqueueDownloadRequest.cs" company="JP Dillingham">
//     Copyright (c) JP Dillingham. All rights reserved.
//
//     This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
//     as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
//     of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License along with this program. If not, see https://www.gnu.org/licenses/.
// </copyright>

namespace Soulseek.Messaging.Messages
{
    using Soulseek.Exceptions;

    /// <summary>
    ///     A request to queue a file.
    /// </summary>
    internal sealed class EnqueueDownloadRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EnqueueDownloadRequest"/> class.
        /// </summary>
        /// <param name="filename">The name of the file being enqueued.</param>
        public EnqueueDownloadRequest(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        ///     Gets the name of the file being enqueued.
        /// </summary>
        public string Filename { get; }

        /// <summary>
        ///     Creates a new instance of <see cref="EnqueueDownloadRequest"/> from the specified <paramref name="bytes"/>.
        /// </summary>
        /// <param name="bytes">The byte array from which to parse.</param>
        /// <returns>The parsed instance.</returns>
        public static EnqueueDownloadRequest FromByteArray(byte[] bytes)
        {
            var reader = new MessageReader<MessageCode.Peer>(bytes);
            var code = reader.ReadCode();

            if (code != MessageCode.Peer.QueueDownload)
            {
                throw new MessageException($"Message Code mismatch creating Peer Queue Download (expected: {(int)MessageCode.Peer.QueueDownload}, received: {(int)code})");
            }

            var filename = reader.ReadString();
            return new EnqueueDownloadRequest(filename);
        }

        /// <summary>
        ///     Constructs a <see cref="byte"/> array from this message.
        /// </summary>
        /// <returns>The constructed byte array.</returns>
        public byte[] ToByteArray()
        {
            return new MessageBuilder()
                .WriteCode(MessageCode.Peer.QueueDownload)
                .WriteString(Filename)
                .Build();
        }
    }
}