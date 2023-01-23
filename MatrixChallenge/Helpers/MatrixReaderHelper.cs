using MatrixChallenge.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChallenge.Helpers
{
    public static class MatrixReaderHelper
    {
        /// <summary>
        /// Read a file and map it into a matrix
        /// </summary>
        /// <param name="path">Path of the file that contains the matrix</param>
        /// <returns>A matrix with string</returns>
        public static string[][] GetMatrixFromFile(string path)
        {
            FileValidator.ValidateFile(path);

            var matrix = File.ReadLines(path)
                            .Select(line => line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                            .ToArray();
            return matrix;

        }
        
    }
}
