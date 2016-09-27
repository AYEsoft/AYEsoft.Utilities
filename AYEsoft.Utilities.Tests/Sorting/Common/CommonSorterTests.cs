// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System;
using System.Collections.Generic;
using AYEsoft.Utilities.Sorting.Common;
using NUnit.Framework;

namespace AYEsoft.Utilities.Tests.Sorting.Common
{
    [TestFixture]
    public class CommonSorterTests
    {
        // Manual mock due to Moq having difficulties with protected generic methods.
        public class SorterTestsHelper : CommonSorter
        {
            public object List { get; private set; }
            public int Index { get; private set; }
            public int Count { get; private set; }
            public object Comparer { get; private set; }

            protected override void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer)
            {
                List = list;
                Index = index;
                Count = count;
                Comparer = comparer;
            }
        }

        public class SortAscendingTests
        {
            [Test]
            public void SortWithListExecutesSortWithAscendingOrderComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                sorter.SortAscending(list);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1),
                    Is.EqualTo(Comparer<int>.Default.Compare(5, 1)), "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 1),
                    Is.EqualTo(Comparer<int>.Default.Compare(1, 1)), "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5),
                    Is.EqualTo(Comparer<int>.Default.Compare(1, 5)), "Invalid comparer");
            }

            [Test]
            public void SortWithComparisonExecutesSortWithExpectedComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                var comparisonMethod = new Comparison<int>((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });
                sorter.SortAscending(list, comparisonMethod);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(comparisonMethod(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(comparisonMethod(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(comparisonMethod(2, 2)),
                    "Invalid comparer");
            }

            [Test]
            public void SortWithComparerExecutesSortWithExpectedComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                var comparer = Comparer<int>.Create((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });

                sorter.SortAscending(list, comparer);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(comparer.Compare(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(comparer.Compare(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(comparer.Compare(2, 2)),
                    "Invalid comparer");
            }

            [Test]
            public void SortWithComparerAndRangeExecutesSortWithExpectedIndexCountAndComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>
                {
                    1,
                    2,
                    4,
                    6,
                    10
                };
                var comparer = Comparer<int>.Create((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });

                var index = 1;
                var count = 3;
                sorter.SortAscending(list, index, count, comparer);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(index), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(count), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(comparer.Compare(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(comparer.Compare(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(comparer.Compare(2, 2)),
                    "Invalid comparer");
            }
        }

        public class SortDescendingTests
        {
            [Test]
            public void SortWithListExecutesSortWithAscendingOrderComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                sorter.SortDescending(list);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1),
                    Is.EqualTo(-Comparer<int>.Default.Compare(5, 1)), "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 1),
                    Is.EqualTo(-Comparer<int>.Default.Compare(1, 1)), "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5),
                    Is.EqualTo(-Comparer<int>.Default.Compare(1, 5)), "Invalid comparer");
            }

            [Test]
            public void SortWithComparisonExecutesSortWithExpectedComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                var comparisonMethod = new Comparison<int>((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });
                sorter.SortDescending(list, comparisonMethod);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(-comparisonMethod(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(-comparisonMethod(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(-comparisonMethod(2, 2)),
                    "Invalid comparer");
            }

            [Test]
            public void SortWithComparerExecutesSortWithExpectedComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>();
                var comparer = Comparer<int>.Create((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });

                sorter.SortDescending(list, comparer);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(0), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(0), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(-comparer.Compare(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(-comparer.Compare(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(-comparer.Compare(2, 2)),
                    "Invalid comparer");
            }

            [Test]
            public void SortWithComparerAndRangeExecutesSortWithExpectedIndexCountAndComparer()
            {
                var sorter = new SorterTestsHelper();
                var list = new List<int>
                {
                    1,
                    2,
                    4,
                    6,
                    10
                };
                var comparer = Comparer<int>.Create((x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                });

                var index = 1;
                var count = 3;
                sorter.SortDescending(list, index, count, comparer);

                Assert.That(sorter.List, Is.EqualTo(list), "Lists do not match.");
                Assert.That(sorter.Index, Is.EqualTo(index), "Index value is invalid.");
                Assert.That(sorter.Count, Is.EqualTo(count), "Count value is invalid.");
                Assert.That(sorter.Comparer, Is.Not.Null, "Comparer is null.");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(5, 1), Is.EqualTo(-comparer.Compare(5, 1)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(1, 5), Is.EqualTo(-comparer.Compare(1, 5)),
                    "Invalid comparer");
                Assert.That(((IComparer<int>) sorter.Comparer).Compare(2, 2), Is.EqualTo(-comparer.Compare(2, 2)),
                    "Invalid comparer");
            }
        }
    }
}