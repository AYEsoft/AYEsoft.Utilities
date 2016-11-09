// Copyright (c) AYEsoft. All rights reserved.
// Licensed under the MIT License, you may not use this file except in compliance with the License.
// Please visit http://www.ayesoft.eu/ for more infromation about AYEsoft.

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AYEsoft.Utilities.Combinatorics
{
    /// <summary>
    ///     Iterates through all distinct permutations of a given sequence of comparable items.
    /// </summary>
    /// <typeparam name="T">Type of elements in sequence on which permutation is performed.</typeparam>
    public class PermutationEnumerator<T> : IEnumerator<IList<T>>
    {
        #region Fields

        private readonly IList<T> _sequence;
        private readonly IComparer<T> _comparer;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        public IList<T> Current { get; private set; }

        /// <summary>
        ///     Gets the element in the collection at the current position of the enumerator.
        /// </summary>
        object IEnumerator.Current => Current;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of PermutationEnumerator class.
        /// </summary>
        /// <param name="sequence">Sequence of items to use for permutations.</param>
        public PermutationEnumerator(IList<T> sequence)
        {
            _comparer = Comparer<T>.Default;
            _sequence = sequence.OrderBy(x => x, _comparer).ToList();
        }

        /// <summary>
        ///     Initializes a new instance of PermutationEnumerator class.
        /// </summary>
        /// <param name="sequence">Sequence of items to use for permutations.</param>
        /// <param name="comparer">Comparer to use for item comparison.</param>
        public PermutationEnumerator(IList<T> sequence, IComparer<T> comparer)
        {
            _comparer = comparer;
            _sequence = sequence.OrderBy(x => x, _comparer).ToList();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Clears resources associated with the current instance of PermutationEnumerator class.
        /// </summary>
        public void Dispose()
        {
            _sequence.Clear();
            Current.Clear();
        }

        /// <summary>
        ///     Moves to the next permutation of the sequence.
        /// </summary>
        /// <returns>
        ///     Returns false if Current sequence is a last permutation and no additional permutations are available. Returns
        ///     true if next permutation was generated successfuly.
        /// </returns>
        public bool MoveNext()
        {
            if (Current == null)
            {
                Current = new List<T>(_sequence);
                return true;
            }
            if (Current.Count < 2)
            {
                return false;
            }

            var marker = Current.Count - 1;
            while ((marker > 0) && (_comparer.Compare(Current[marker - 1], Current[marker]) >= 0))
            {
                marker--;
            }

            if (marker == 0)
            {
                return false;
            }

            var swapSourceIndex = marker - 1;

            var swapTargetIndex = Current.Count - 1;
            // Find first element greater than the element to swap
            while (swapTargetIndex > swapSourceIndex)
            {
                if (_comparer.Compare(Current[swapTargetIndex], Current[swapSourceIndex]) > 0)
                {
                    break;
                }
                swapTargetIndex--;
            }

            // Swap target and source
            var swapData = Current[swapTargetIndex];
            Current[swapTargetIndex] = Current[swapSourceIndex];
            Current[swapSourceIndex] = swapData;

            var i = swapSourceIndex + 1;
            var j = Current.Count - 1;

            // Change order of sequence after marker
            while (i < j)
            {
                swapData = Current[i];
                Current[i] = Current[j];
                Current[j] = swapData;

                i++;
                j--;
            }

            return true;
        }

        /// <summary>
        ///     Resets sequence to the first permutation.
        /// </summary>
        public void Reset()
        {
            Current = new List<T>(_sequence);
        }

        #endregion
    }
}