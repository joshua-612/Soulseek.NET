﻿// <copyright file="SearchResponseSlim.cs" company="JP Dillingham">
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

namespace Soulseek.NET.Messaging.Responses
{
    using Soulseek.NET.Exceptions;

    /// <summary>
    ///     A response to a file search which does not include a parsed list of files. This internal class allows the library to
    ///     defer processing of file entries until the other information in the response has been matched with criteria to
    ///     determine whether the response is to be thrown out.
    /// </summary>
    /// <remarks>Files may be retrieved using the message reader provided by <see cref="MessageReader"/>.</remarks>
    internal sealed class SearchResponseSlim
    {
        internal SearchResponseSlim(string username, int token, int fileCount, int freeUploadSlots, int uploadSpeed, long queueLength, MessageReader messageReader)
        {
            Username = username;
            Token = token;
            FileCount = fileCount;
            FreeUploadSlots = freeUploadSlots;
            UploadSpeed = uploadSpeed;
            QueueLength = queueLength;
            MessageReader = messageReader;
        }

        public int FileCount { get; }
        public int FreeUploadSlots { get; }
        public MessageReader MessageReader { get; }
        public long QueueLength { get; }
        public int Token { get; }
        public int UploadSpeed { get; }
        public string Username { get; }

        internal static SearchResponseSlim Parse(Message message)
        {
            var reader = new MessageReader(message);

            if (reader.Code != MessageCode.PeerSearchResponse)
            {
                throw new MessageException($"Message Code mismatch creating Peer Search Response (expected: {(int)MessageCode.PeerSearchResponse}, received: {(int)reader.Code}");
            }

            reader.Decompress();

            var username = reader.ReadString();
            var token = reader.ReadInteger();
            var fileCount = reader.ReadInteger();

            var position = reader.Position;
            reader.Seek(reader.Payload.Length - 17); // there are 8 unused bytes at the end of each message

            var freeUploadSlots = reader.ReadByte();
            var uploadSpeed = reader.ReadInteger();
            var queueLength = reader.ReadLong();

            reader.Seek(position);
            var messageReader = reader;

            return new SearchResponseSlim(username, token, fileCount, freeUploadSlots, uploadSpeed, queueLength, messageReader);
        }
    }
}