// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections.Generic;

namespace AYEsoft.Utilities.Sorting.Common
{
    /// <summary>
    ///     Provides the implementation of Selection Sort algorithm.
    /// </summary>
    public class SelectionSorter : CommonSorter
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
            var leftMarker = index;
            var rightMarker = index + count - 1;

            while (leftMarker <= rightMarker)
            {
                var minElementIndex = leftMarker;
                var maxElementIndex = rightMarker;
                for (var i = leftMarker; i <= rightMarker; i++)
                {
                    if (comparer.Compare(list[i], list[minElementIndex]) < 0)
                    {
                        minElementIndex = i;
                    }
                    if (comparer.Compare(list[i], list[maxElementIndex]) > 0)
                    {
                        maxElementIndex = i;
                    }
                }

                var temp = list[leftMarker];
                list[leftMarker] = list[minElementIndex];
                list[minElementIndex] = temp;

                if (rightMarker != minElementIndex)
                {
                    temp = list[rightMarker];
                    list[rightMarker] = list[maxElementIndex];
                    list[maxElementIndex] = temp;
                }

                leftMarker++;
                rightMarker--;
            }
        }
    }
}