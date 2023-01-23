using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChallenge.Validators
{
    public static class MatrixValidator
    {
        /// <summary>
        /// Validates that the matrix is square
        /// </summary>
        /// <param name="matrix">Matrix to be validated</param>
        public static void ValidateSquareMatrix(string[][] matrix)
        {
            var maxColumns = matrix.Select(b => b.Length).Max();

            var missingColumnsOrNotOneCharacter = matrix.Any(b => b.Length != maxColumns || (b.Any(c => c.Trim().Length > 1 || c.Trim().Length == 0)));

            if (maxColumns != matrix.Length || missingColumnsOrNotOneCharacter)
                throw new ApplicationException("La matriz debe ser cuadrada.");
        }
    }
}
