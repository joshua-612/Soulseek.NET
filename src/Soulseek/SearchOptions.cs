﻿// <copyright file="SearchOptions.cs" company="JP Dillingham">
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

namespace Soulseek
{
    using System;
    using Soulseek.Messaging.Messages;

    /// <summary>
    ///     Options for the search operation.
    /// </summary>
    public sealed class SearchOptions
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SearchOptions"/> class.
        /// </summary>
        /// <param name="username">The username of the user to search.</param>
        /// <param name="searchTimeout">The search timeout value, in seconds, used to determine when the search is complete.</param>
        /// <param name="responseLimit">The maximum number of search results to accept before the search is considered completed.</param>
        /// <param name="filterResponses">A value indicating whether responses are to be filtered.</param>
        /// <param name="minimumResponseFileCount">The minimum number of files a response must contain in order to be processed.</param>
        /// <param name="minimumPeerFreeUploadSlots">
        ///     The minimum number of free upload slots a peer must have in order for a response to be processed.
        /// </param>
        /// <param name="maximumPeerQueueLength">The maximum queue depth a peer may have in order for a response to be processed.</param>
        /// <param name="minimumPeerUploadSpeed">
        ///     The minimum upload speed a peer must have in order for a response to be processed.
        /// </param>
        /// <param name="responseFilter">
        ///     The function used to evaluate whether a response should be included in the search results.
        /// </param>
        /// <param name="fileLimit">The maximum number of file results to accept before the search is considered complete.</param>
        /// <param name="fileFilter">The function used to evaluate whether a file should be included in a search response.</param>
        /// <param name="stateChanged">The Action to invoke when the search changes state.</param>
        /// <param name="responseReceived">The Action to invoke when a new search response is received.</param>
        public SearchOptions(
            string username = null,
            int searchTimeout = 15,
            int responseLimit = 100,
            bool filterResponses = true,
            int minimumResponseFileCount = 1,
            int minimumPeerFreeUploadSlots = 0,
            int maximumPeerQueueLength = 1000000,
            int minimumPeerUploadSpeed = 0,
            Func<SearchResponse, bool> responseFilter = null,
            int fileLimit = 10000,
            Func<File, bool> fileFilter = null,
            Action<SearchStateChangedEventArgs> stateChanged = null,
            Action<SearchResponseReceivedEventArgs> responseReceived = null)
        {
            Username = username;
            SearchTimeout = searchTimeout;
            ResponseLimit = responseLimit;
            FileLimit = fileLimit;
            FilterResponses = filterResponses;
            MinimumResponseFileCount = minimumResponseFileCount;
            MinimumPeerFreeUploadSlots = minimumPeerFreeUploadSlots;
            MaximumPeerQueueLength = maximumPeerQueueLength;
            MinimumPeerUploadSpeed = minimumPeerUploadSpeed;
            StateChanged = stateChanged;
            ResponseReceived = responseReceived;
            ResponseFilter = responseFilter;
            FileFilter = fileFilter;
        }

        /// <summary>
        ///     Gets the function used to evaluate whether a file should be included in a search response (Default = all files included).
        /// </summary>
        public Func<File, bool> FileFilter { get; }

        /// <summary>
        ///     Gets the maximum number of file results to accept before the search is considered complete. (Default = 10,000).
        /// </summary>
        public int FileLimit { get; }

        /// <summary>
        ///     Gets a value indicating whether responses are to be filtered. (Default = true).
        /// </summary>
        public bool FilterResponses { get; }

        /// <summary>
        ///     Gets the maximum queue depth a peer may have in order for a response to be processed. (Default = 1000000).
        /// </summary>
        public int MaximumPeerQueueLength { get; }

        /// <summary>
        ///     Gets the minimum number of free upload slots a peer must have in order for a response to be processed. (Default = 0).
        /// </summary>
        public int MinimumPeerFreeUploadSlots { get; }

        /// <summary>
        ///     Gets the minimum upload speed a peer must have in order for a response to be processed. (Default = 0).
        /// </summary>
        public int MinimumPeerUploadSpeed { get; }

        /// <summary>
        ///     Gets the minimum number of files a response must contain in order to be processed. (Default = 1).
        /// </summary>
        public int MinimumResponseFileCount { get; }

        /// <summary>
        ///     Gets the function used to evaluate whether a response should be included in the search results (Default = all
        ///     responses included).
        /// </summary>
        public Func<SearchResponse, bool> ResponseFilter { get; }

        /// <summary>
        ///     Gets the maximum number of search results to accept before the search is considered complete. (Default = 100).
        /// </summary>
        public int ResponseLimit { get; }

        /// <summary>
        ///     Gets the Action to invoke when a new search response is received.
        /// </summary>
        public Action<SearchResponseReceivedEventArgs> ResponseReceived { get; }

        /// <summary>
        ///     Gets the search timeout value, in seconds, used to determine when the search is complete. (Default = 15).
        /// </summary>
        /// <remarks>The timeout duration is from the time of the last response.</remarks>
        public int SearchTimeout { get; }

        /// <summary>
        ///     Gets the Action to invoke when the search changes state.
        /// </summary>
        public Action<SearchStateChangedEventArgs> StateChanged { get; }

        /// <summary>
        ///     Gets the username of the user to search. (Default = null; do not search a specific user).
        /// </summary>
        public string Username { get; }
    }
}