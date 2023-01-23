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
        public static string[][] GetMatrixFromFile(string path)
        {
            var array2d = File.ReadLines(path)
                            .Select(line => line.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                            .ToArray();
            return array2d;

        }
        
    }
}
