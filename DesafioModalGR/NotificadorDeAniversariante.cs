using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesafioModalGR
{
    class NotificadorDeAniversariante
    {
        public static void Executar()
        {
            Console.WriteLine("Digite o mes (em numero inteiro)");
            int.TryParse(Console.ReadLine(), out int mes);
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\PC\source\repos\DesafioModalGR\DesafioModalGR\MOCK_DATA.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("|");
                Console.WriteLine("Esses sao os aniversariantes do Mes!! ");
                while (!parser.EndOfData)
                {
                    // Processa a linha
                    string[] fields = parser.ReadFields();
                    for (int k = 0; k < fields.Length; k++)
                    {
                        DateTime.TryParse(fields[3], out DateTime dt);
                        if (dt.Month == mes)
                        {
                            Console.WriteLine(fields[k]);
                        }
                    }
                }
            }
            Console.WriteLine("Pressione enter para sair.");
            Console.ReadLine();

        }
    }
}
