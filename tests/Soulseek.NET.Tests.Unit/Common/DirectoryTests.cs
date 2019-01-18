﻿// <copyright file="DirectoryTests.cs" company="JP Dillingham">
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

namespace Soulseek.NET.Tests.Unit.Common
{
    using AutoFixture.Xunit2;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class DirectoryTests
    {
        [Trait("Category", "Instantiation")]
        [Theory(DisplayName = "Instantiates with the given data"), AutoData]
        public void Instantiates_With_The_Given_Data(string directoryname, int fileCount)
        {
            var d = new Directory(directoryname, fileCount);

            Assert.Equal(directoryname, d.Directoryname);
            Assert.Equal(fileCount, d.FileCount);
        }

        [Trait("Category", "Instantiation")]
        [Theory(DisplayName = "Instantiates with empty File list given no list"), AutoData]
        public void Instantiates_With_Empty_File_List_Given_No_List(string directoryname, int fileCount)
        {
            var d = new Directory(directoryname, fileCount);

            Assert.NotNull(d.Files);
            Assert.Empty(d.Files);
        }

        [Trait("Category", "Instantiation")]
        [Theory(DisplayName = "Instantiates with given File list given list"), AutoData]
        public void Instantiates_With_Given_File_List_Given_List(string directoryname, int fileCount)
        {
            var files = new List<File>() { new File(1, "a", 2, "b", 0) };

            var d = new Directory(directoryname, fileCount, files);

            Assert.NotNull(d.Files);
            Assert.Single(d.Files);
            Assert.Equal(files[0], d.Files.ToList()[0]);
        }
    }
}
