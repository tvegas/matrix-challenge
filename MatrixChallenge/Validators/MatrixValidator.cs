using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChallenge.Validators
{
    public static class MatrixValidator
    {
        public static void ValidateSquareMatrix(string[][] matrix)
        {
            var maxColumns = matrix.Select(b => b.Length).Max();

            var missingColumns = matrix.Any(b => b.Length != maxColumns);

            var notOneCharacter = matrix.Any(b => b.Any(c => c.Trim().Length > 1 || c.Trim().Length == 0));

            if (maxColumns != matrix.Length || missingColumns)
                throw new ApplicationException("La matriz debe ser cuadrada.");
        }
    }
}
