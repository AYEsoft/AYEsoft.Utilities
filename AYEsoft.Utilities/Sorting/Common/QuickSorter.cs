// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections.Generic;

namespace AYEsoft.Utilities.Sorting.Common
{
    /// <summary>
    ///     Provides the implementation of Quick Sort algorithm.
    /// </summary>
    public class QuickSorter : CommonSorter
    {
        /// <summary>
        ///     Sorts the specified range of elements in ascending order according to the given <paramref name="comparer" />.
        ///     Basic method that sorting is based on.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        protected override void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            if (list.Count == 0) return;
            var leftMarker = index;
            var rightMarker = index + count - 1;

            RecursiveQuickSort(list, leftMarker, rightMarker, comparer);
        }

        /// <summary>
        ///     Sorts the list recursively.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="leftMarker">Starting index of a subcollection of elements.</param>
        /// <param name="rightMarker">Ending index of a subcollection of elements.</param>
        /// <param name="comparer">Specified comparer.</param>
        private void RecursiveQuickSort<T>(IList<T> list, int leftMarker, int rightMarker, IComparer<T> comparer)
        {
            var i = leftMarker;
            var j = rightMarker;

            var center = list[(leftMarker + rightMarker)/2];

            while (i < j)
            {
                while (comparer.Compare(list[i], center) < 0)
                {
                    i++;
                }
                while (comparer.Compare(list[j], center) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;

                    i++;
                    j--;
                }

                if (leftMarker < j)
                {
                    RecursiveQuickSort(list, leftMarker, j, comparer);
                }
                if (rightMarker > i)
                {
                    RecursiveQuickSort(list, i, rightMarker, comparer);
                }
            }
        }
    }
}