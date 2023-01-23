using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace MatrixChallenge.Validators
{
    public static class FileValidator
    {
        /// <summary>
        /// Throws if the file doesnt exists or has an invalid extension
        /// </summary>
        /// <param name="path">The path of the file to validate</param>
        public static void ValidateFile(string path)
        {

            var isTxt = path.ToLower().Contains(".txt") && path.Split('.').Last().ToLower() == "txt";

            if (!isTxt)
                throw new ApplicationException("El archivo debe ser de extensison .txt");

            var exists = File.Exists(path);

            if (!exists)
                throw new ApplicationException("El path del archivo es inexistente.");


        }
    }
}
