// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections.Generic;
using AYEsoft.Utilities.Sorting.Common;
using NUnit.Framework;

namespace AYEsoft.Utilities.Tests.Sorting.Common
{
    [TestFixture(typeof(BubbleSorter))]
    [TestFixture(typeof(QuickSorter))]
    [TestFixture(typeof(InsertionSorter))]
    [TestFixture(typeof(SelectionSorter))]
    public class DefaultSorterTests<T> where T : ICommonSorter, new()
    {
        private static IEnumerable<TestCaseData> AscendingComparableIntTestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 2, 3, 4}, new[] {1, 2, 3, 4});
                yield return new TestCaseData(new[] {4, 2, 3, 1}, new[] {1, 2, 3, 4});
                yield return new TestCaseData(new[] {4, 3, 2, 1}, new[] {1, 2, 3, 4});
                yield return new TestCaseData(new int[] {}, new int[] {});
            }
        }

        private static IEnumerable<TestCaseData> AscendingSortRangeIntTestCases
        {
            get
            {
                yield return
                    new TestCaseData(new[] {1, 2, 3, 4, 1, 2}, new[] {1, 2, 1, 2, 3, 4}, 2, 4,
                        Comparer<int>.Default);
                yield return
                    new TestCaseData(new[] {4, 2, 3, 1}, new[] {1, 2, 3, 4}, 0, 4, Comparer<int>.Default);
                yield return
                    new TestCaseData(new[] {4, 3, 2, 1}, new[] {4, 2, 3, 1}, 1, 2, Comparer<int>.Default);
            }
        }

        private static IEnumerable<TestCaseData> DescendingComparableIntTestCases
        {
            get
            {
                yield return new TestCaseData(new[] {1, 2, 3, 4}, new[] {4, 3, 2, 1});
                yield return new TestCaseData(new[] {4, 2, 3, 1}, new[] {4, 3, 2, 1});
                yield return new TestCaseData(new[] {4, 3, 2, 1}, new[] {4, 3, 2, 1});
                yield return new TestCaseData(new int[] {}, new int[] {});
            }
        }

        private static IEnumerable<TestCaseData> DescendingSortRangeIntTestCases
        {
            get
            {
                yield return
                    new TestCaseData(new[] {1, 2, 3, 4, 1, 2}, new[] {1, 2, 4, 3, 2, 1}, 2, 4,
                        Comparer<int>.Default);
                yield return
                    new TestCaseData(new[] {4, 2, 3, 1}, new[] {4, 3, 2, 1}, 0, 4, Comparer<int>.Default);
                yield return
                    new TestCaseData(new[] {4, 3, 2, 1}, new[] {4, 3, 2, 1}, 1, 2, Comparer<int>.Default);
            }
        }


        [TestCaseSource(nameof(AscendingComparableIntTestCases))]
        public void SortIntsAscendingWithDefaultComparer(int[] input, int[] expected)
        {
            var sorter = new T();
            sorter.SortAscending(input);

            CollectionAssert.AreEqual(input, expected);
        }

        [TestCaseSource(nameof(AscendingSortRangeIntTestCases))]
        public void SortIntsAscendingWithDefaultComparerAndRange(int[] input, int[] expected, int startIndex, int count,
            IComparer<int> comparer)
        {
            var sorter = new T();
            sorter.SortAscending(input, startIndex, count, comparer);

            CollectionAssert.AreEqual(input, expected);
        }

        [TestCaseSource(nameof(DescendingComparableIntTestCases))]
        public void SortIntsDescendingWithDefaultComparer(int[] input, int[] expected)
        {
            var sorter = new T();
            sorter.SortDescending(input);

            CollectionAssert.AreEqual(input, expected);
        }

        [TestCaseSource(nameof(DescendingSortRangeIntTestCases))]
        public void SortIntsDescendingWithDefaultComparerAndRange(int[] input, int[] expected, int startIndex, int count,
            IComparer<int> comparer)
        {
            var sorter = new T();
            sorter.SortDescending(input, startIndex, count, comparer);

            CollectionAssert.AreEqual(input, expected);
        }
    }
}