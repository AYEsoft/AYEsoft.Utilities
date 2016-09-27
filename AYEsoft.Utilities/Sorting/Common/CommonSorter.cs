// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System;
using System.Collections.Generic;

namespace AYEsoft.Utilities.Sorting.Common
{
    /// <summary>
    ///     Provides the base class from which the classes that represent common sorter are derived.
    /// </summary>
    public abstract class CommonSorter : ICommonSorter
    {
        #region Methods

        /// <summary>
        ///     Sorts the specified range of elements in ascending order according to the given <paramref name="comparer" />.
        ///     Basic method that sorting is based on.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        protected abstract void Sort<T>(IList<T> list, int index, int count, IComparer<T> comparer);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the default comparer.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        public void SortAscending<T>(IList<T> list)
        {
            SortAscending(list, 0, list?.Count ?? 0, Comparer<T>.Default);
        }

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparison" /> method.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparison">Delegate to comparison method.</param>
        public void SortAscending<T>(IList<T> list, Comparison<T> comparison)
        {
            SortAscending(list, 0, list?.Count ?? 0, Comparer<T>.Create(comparison));
        }

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        public void SortAscending<T>(IList<T> list, IComparer<T> comparer)
        {
            SortAscending(list, 0, list?.Count ?? 0, comparer);
        }

        /// <summary>
        ///     Sorts the specified range of elements in ascending order according to the given <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        public void SortAscending<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), "List cannot be null.");
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer), "Comparer cannot be null.");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be positive.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be positive.");
            }

            if (count + index > list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Selection is out of range.");
            }

            Sort(list, index, count, comparer);
        }

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the default comparer.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        public void SortDescending<T>(IList<T> list)
        {
            SortDescending(list, 0, list?.Count ?? 0, Comparer<T>.Default);
        }

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparison" /> method.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparison">Delegate to comparison method.</param>
        public void SortDescending<T>(IList<T> list, Comparison<T> comparison)
        {
            SortDescending(list, 0, list?.Count ?? 0, Comparer<T>.Create(comparison));
        }

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in descending order according to the given
        ///     <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        public void SortDescending<T>(IList<T> list, IComparer<T> comparer)
        {
            SortDescending(list, 0, list?.Count ?? 0, comparer);
        }

        /// <summary>
        ///     Sorts the specified range of elements in descending order according to the given <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        public void SortDescending<T>(IList<T> list, int index, int count, IComparer<T> comparer)
        {
            // Sort ascending with inverted comparer.
            SortAscending(list, index, count,
                comparer == null ? null : Comparer<T>.Create((x, y) => -comparer.Compare(x, y)));
        }

        #endregion
    }
}