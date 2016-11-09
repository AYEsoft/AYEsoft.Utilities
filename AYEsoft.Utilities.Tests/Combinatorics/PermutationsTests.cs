// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections.Generic;
using System.Linq;
using AYEsoft.Utilities.Combinatorics;
using NUnit.Framework;

namespace AYEsoft.Utilities.Tests.Combinatorics
{
    [TestFixture]
    public class PermutationsTests
    {
        [Test]
        public void ForeachEnumerationTest()
        {
            var sequence = "cab";
            var expected = new List<string> {"abc", "acb", "bac", "bca", "cab", "cba"};
            var result = new List<string>();

            var permutations = new Permutations<char>(sequence.ToCharArray());

            foreach (var permutation in permutations)
            {
                result.Add(new string(permutation.ToArray()));
            }

            CollectionAssert.AreEqual(expected, result);
        }
    }
}