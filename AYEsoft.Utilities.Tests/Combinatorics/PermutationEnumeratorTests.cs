// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Linq;
using AYEsoft.Utilities.Combinatorics;
using NUnit.Framework;

namespace AYEsoft.Utilities.Tests.Combinatorics
{
    [TestFixture]
    public class PermutationEnumeratorTests
    {
        public class ConstructorTests
        {
            [Test]
            public void FirstPermutationOrder()
            {
                var sequence = new[] {1, 3, 2, 2};
                var enumerator = new PermutationEnumerator<int>(sequence);
                Assert.That(enumerator.Current, Is.Null);
            }
        }

        public class MoveNextTests
        {
            [Test]
            public void RegularPerumtation()
            {
                var sequence = "bas";
                var enumerator = new PermutationEnumerator<char>(sequence.ToCharArray());
                var result = enumerator.MoveNext();
                Assert.That(result, Is.True);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("abs"));

                result = enumerator.MoveNext();
                Assert.That(result, Is.True);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("asb"));
            }

            [Test]
            public void PermutationsForSingleItem()
            {
                var sequence = "a";
                var enumerator = new PermutationEnumerator<char>(sequence.ToCharArray());
                var result = enumerator.MoveNext();
                Assert.That(result, Is.True);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("a"));

                result = enumerator.MoveNext();
                Assert.That(result, Is.False);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("a"));
            }

            [Test]
            public void PermutationsForCollectionOfEqualItems()
            {
                var sequence = "aaaa";
                var enumerator = new PermutationEnumerator<char>(sequence.ToCharArray());
                var result = enumerator.MoveNext();
                Assert.That(result, Is.True);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("aaaa"));

                result = enumerator.MoveNext();
                Assert.That(result, Is.False);
                Assert.That(new string(enumerator.Current.ToArray()), Is.EqualTo("aaaa"));
            }
        }

        public class ResetTests
        {
            [Test]
            public void ResetSequenceToDefault()
            {
                var sequence = new[] {1, 3, 2, 2};
                var expected = new[] {1, 2, 2, 3};
                var enumerator = new PermutationEnumerator<int>(sequence);
                var result = enumerator.MoveNext();
                Assert.That(result, Is.True);
                result = enumerator.MoveNext();
                Assert.That(result, Is.True);

                enumerator.Reset();

                CollectionAssert.AreEqual(expected, enumerator.Current);
            }
        }
    }
}