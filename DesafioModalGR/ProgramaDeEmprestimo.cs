// Ignore Spelling: Desafio

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioModalGR
{
    class ProgramaDeEmprestimo
    {
        public static void Executar()
        {
            string nomeDoColaborador;
            DateTime dataDeAdmissao;
            int salarioAtual;
            int valorEmprestimo;

            Console.WriteLine("digite seu nome: ");
            Console.ReadLine();
            Console.WriteLine("digite sua data de admissao: ");
            DateTime.TryParse(Console.ReadLine(), out dataDeAdmissao);
            Console.WriteLine("digite o seu salario em reais: ");
            int.TryParse(Console.ReadLine(), out salarioAtual);
            Console.WriteLine("digite o valor do emprestimo a ser simulado: ");
            int.TryParse(Console.ReadLine(), out valorEmprestimo);
            if (dataDeAdmissao.Year > DateTime.Now.Year - 5)
            {
                Console.WriteLine("Agradecemos o seu interesse, mas voce nao atende os requisitos minimos do programa.");
                return;
            }

            // valor deve ser multiplo de 2 e ate 2 vezes o salario atual
            if (valorEmprestimo % 2 != 0 || valorEmprestimo > 2 * salarioAtual)
            {
                Console.WriteLine("Insira um valor valido!");
                return;
            }

            Console.WriteLine("Selecione a opcao de retirada: ");
            Console.WriteLine("1) Notas de maior valor: ");
            Console.WriteLine("2) Notas de menor valor: ");
            Console.WriteLine("3) Notas meio a meio: ");
            int.TryParse(Console.ReadLine(), out int opc);
            int nCem = valorEmprestimo / 100;
            int nCinquenta = (valorEmprestimo % 100) / 50;
            int nVinte = ((valorEmprestimo % 100) % 50) / 20;
            int nDez = (((valorEmprestimo % 100) % 50) % 20) / 10;
            int nCinco = ((((valorEmprestimo % 100) % 50) % 20) % 10) / 5;
            int nDois = (((((valorEmprestimo % 100) % 50) % 20) % 10) % 5) / 2;
            switch (opc)
            {
                case 1:
                    Console.WriteLine($"{valorEmprestimo} em notas de maior valor: ");
                    Console.WriteLine($"{nCem} x 100;\n{nCinquenta} x 50;\n{nVinte} x 20;\n{nDez} x 10;\n{nCinco} x 5\n{nDois} x 2.");
                    break;
                case 2:
                    nVinte = valorEmprestimo / 20;
                    nDez = (valorEmprestimo % 20) / 10;
                    nCinco = ((valorEmprestimo % 20) % 10) / 5;
                    nDois = (((valorEmprestimo % 20) % 10) % 5) / 2;
                    Console.WriteLine($"{valorEmprestimo} em notas de menor valor: ");
                    Console.WriteLine($"{nVinte} x 20;\n{nDez} x 10;\n{nCinco} x 5\n{nDois} x 2");
                    break;
                case 3:
                    // Algoritmo pra calcular meio a meio
                    int metade = valorEmprestimo / 2;
                    int nMaiorCem = metade / 100;
                    int nMaiorCinquenta = (metade % 100) / 50;
                    int nMaiorVinte = ((metade % 100) % 50) / 20;
                    int nMaiorDez = (((metade % 100) % 50) % 20) / 10;
                    int nMaiorCinco = ((((metade % 100) % 50) % 20) % 10) / 5;
                    int nMaiorDois = (((((metade % 100) % 50) % 20) % 10) % 5) / 2;

                    int nMenorVinte = metade / 20;
                    int nMenorDez = (metade % 20) / 10;
                    int nMenorCinco = ((metade % 20) % 10) / 5;
                    int nMenorDois = (((metade % 20) % 10) % 5) / 2;

                    Console.WriteLine($"{valorEmprestimo} em notas Meio a Meio: ");
                    Console.WriteLine($"{metade} em notas de maior valor: \n{nMaiorCem} x 100 reais;" +
                        $"\n{nMaiorCinquenta} x 50 reais;\n{nMaiorVinte} x 20 reais;\n{nMaiorDez} x 10 reais;" +
                        $"\n{nMaiorCinco} x 5 reais;\n{nMaiorDois} x 2 reais");
                    Console.WriteLine($"{metade} em notas de menor valor: \n{nMenorVinte} x 20 reais;" +
                        $"\n{nMenorDez} x 10 reais;\n{nMenorCinco} x 5 reais;\n{nMenorDois} x 2 reais.");
                    break;
            }
        }
    }
}
