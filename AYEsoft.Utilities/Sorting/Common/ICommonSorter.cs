// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System;
using System.Collections.Generic;

namespace AYEsoft.Utilities.Sorting.Common
{
    /// <summary>
    ///     Defines the methods that all common sorters have to implement.
    /// </summary>
    public interface ICommonSorter
    {
        #region Methods

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the default comparer.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        void SortAscending<T>(IList<T> list);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparison" /> method.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparison">Delegate to comparison method.</param>
        void SortAscending<T>(IList<T> list, Comparison<T> comparison);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        void SortAscending<T>(IList<T> list, IComparer<T> comparer);

        /// <summary>
        ///     Sorts the specified range of elements in ascending order according to the given <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        void SortAscending<T>(IList<T> list, int index, int count, IComparer<T> comparer);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the default comparer.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        void SortDescending<T>(IList<T> list);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in ascending order according to the given
        ///     <paramref name="comparison" /> method.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparison">Delegate to comparison method.</param>
        void SortDescending<T>(IList<T> list, Comparison<T> comparison);

        /// <summary>
        ///     Sorts the elements of a <paramref name="list" /> in descending order according to the given
        ///     <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        void SortDescending<T>(IList<T> list, IComparer<T> comparer);

        /// <summary>
        ///     Sorts the specified range of elements in descending order according to the given <paramref name="comparer" />.
        /// </summary>
        /// <typeparam name="T">Type of elements in a <paramref name="list" />.</typeparam>
        /// <param name="list">List of elemnets to sort.</param>
        /// <param name="index">Starting index of sorting range.</param>
        /// <param name="count">Amount of elements to sort.</param>
        /// <param name="comparer">Specified comparer.</param>
        void SortDescending<T>(IList<T> list, int index, int count, IComparer<T> comparer);

        #endregion
    }
}