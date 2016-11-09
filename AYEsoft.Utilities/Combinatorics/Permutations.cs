// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections;
using System.Collections.Generic;

namespace AYEsoft.Utilities.Combinatorics
{
    /// <summary>
    ///     Enumerates through all distinct permutations of a given sequence of comparable items.
    /// </summary>
    /// <typeparam name="T">Type of elements in sequence on which permutation is performed.</typeparam>
    public class Permutations<T> : IEnumerable<IList<T>>
    {
        private readonly PermutationEnumerator<T> _enumerator;

        /// <summary>
        ///     Initializes a new instance of Permutations class.
        /// </summary>
        /// <param name="sequence">Sequence of items to use for permutations.</param>
        public Permutations(IList<T> sequence)
        {
            _enumerator = new PermutationEnumerator<T>(sequence);
        }

        /// <summary>
        ///     Initializes a new instance of Permutations class.
        /// </summary>
        /// <param name="sequence">Sequence of items to use for permutations.</param>
        /// <param name="comparer">Comparer to use for item comparison.</param>
        public Permutations(IList<T> sequence, IComparer<T> comparer)
        {
            _enumerator = new PermutationEnumerator<T>(sequence, comparer);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<IList<T>> GetEnumerator()
        {
            return _enumerator;
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}