﻿using MatrixChallenge.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChallenge.Helpers
{
    public static class MatrixStringFinderHelper
    {
        public static string SearchLongestRepeatedCharacterSecuency(string path)
        {
            var result = string.Empty;
            var matrix = MatrixReaderHelper.GetMatrixFromFile(path);

            MatrixValidator.ValidateSquareMatrix(matrix);

            var verticalAndHorizontalResult = SearchLongestSecuencyInVerticallAndHorizontal(matrix);
            var diagonalsResult = SearchLongestSecuencyInDiagonals(matrix);

            result = EvaluateResult(diagonalsResult,verticalAndHorizontalResult);

            return result;

        }
        /// <summary>
        /// Search the longest repeated secuency vertically and horizontally
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>The longest repeted character string</returns>
        public static string SearchLongestSecuencyInVerticallAndHorizontal(string[][] matrix)
        {
            var result = string.Empty;
            for (var i = 0; i < matrix.Length; i++)
            {
                var vertically = string.Empty;
                var horizontally = string.Empty;
                for (var j = 0; j < matrix.Length; j++)
                {
                    horizontally = horizontally + matrix[i][j].Trim();
                    vertically = vertically + matrix[j][i].Trim();
                }
                result = EvaluateResult(horizontally, result);
                result = EvaluateResult(vertically, result);
            }

            return result;
        }
        /// <summary>
        /// Search the longest repeated secuency on all the diagonals in a given matrix
        /// </summary>
        /// <param name="matrix">The matrix</param>
        /// <returns>The longest repeted character string</returns>
        public static string SearchLongestSecuencyInDiagonals(string[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix.Length;

            var result = string.Empty;

            // number of secondary diagonals
            int diagonalsQty = rows + columns - 1;
            int row, column, reverseColum;

            // go through each diagonal
            for (int i = 0; i < diagonalsQty; i++)
            {
                // row to start
                if (i < columns)
                {
                    row = 0;
                    column = i;
                    reverseColum = columns - i - 1;
                }
                else
                {
                    row = i - columns + 1;
                    column = columns - 1;
                    reverseColum = 0;
                }

                // concatenated strings
                var diagonalString = string.Empty;
                var reverseDiagonalString = string.Empty;

                do
                {

                    diagonalString = diagonalString + matrix[row][column].Trim();
                    reverseDiagonalString = reverseDiagonalString + matrix[row][reverseColum].Trim();

                    row++;
                    column--;
                    reverseColum++;

                }
                while (row < rows && column >= 0);

                result = EvaluateResult(diagonalString, result);
                result = EvaluateResult(reverseDiagonalString, result);

            }

            return result;
        }
        /// <summary>
        /// Compares two strings in order to determine which one has the longes repeated character secuency
        /// </summary>
        /// <param name="text">Text to be compared</param>
        /// <param name="currentResult">Current result</param>
        /// <returns>The new result</returns>
        public static string EvaluateResult(string text, string currentResult)
        {
            var currentLength = currentResult.Length;

            if (text.Length > currentResult.Length)
            {
                var longestSecuency = GetLongestRepeatCharSecuency(text);
                if (longestSecuency.Length > currentLength)
                    return longestSecuency;
            }

            return currentResult;
        }
        /// <summary>
        /// Obtains the most repeated character secuency in a given string
        /// </summary>
        /// <param name="text"></param>
        /// <returns>The longest characted repeated secuency</returns>
        private static string GetLongestRepeatCharSecuency(string text)
        {
            var result = new string(text.Select((c, index) => text.Substring(index).TakeWhile(e => e == c))
                                               .OrderByDescending(e => e.Count())
                                               .First().ToArray());
            return result;
        }
    }
}