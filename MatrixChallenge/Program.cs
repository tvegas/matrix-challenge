using MatrixChallenge.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var result = string.Empty;
                var defaultPath = "./matrix-default.txt";

                Console.WriteLine($"Por favor, ingrese una opcion para comenzar (solo numeros):");
                Console.WriteLine($"1 - Especificar path del archivo.");
                Console.WriteLine($"2 - Utilizar archivo por defecto (matrix-default.txt).");

                var optionSelected = Console.ReadLine();
                
                switch (optionSelected.Trim())
                {
                    case "1":
                        Console.WriteLine($"Por favor, ingrese el path del archivo .txt");

                        var customPath = Console.ReadLine();
                        result = MatrixStringFinderHelper.SearchLongestRepeatedCharacterSecuency(customPath);

                    break;

                    case "2":
                        result = MatrixStringFinderHelper.SearchLongestRepeatedCharacterSecuency(defaultPath);
                    break;
                                      
                    default:
                        Console.WriteLine($"Opcion incorrecta.");
                    break;

                }

                if(!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine($"------------------------------");
                    Console.WriteLine($"El resultado es: {result}.");
                    Console.WriteLine($"------------------------------");
                }

                Console.WriteLine($"Presione una tecla para finalizar.");
                Console.ReadLine();
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Presione una tecla para finalizar.");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error inesperado {ex.Message}, por favor presione una tecla para finalizar.");
                Console.ReadLine();
            }
        }
    }
}
