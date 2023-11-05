
namespace DesafioModalGR
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProgramaDeEmprestimo.Executar();
            Console.WriteLine("Qual desafio desejas ver? ");
            Console.WriteLine("1) Cofre eletronico");
            Console.WriteLine("2) Aniversariantes");
            Console.WriteLine("3) Programa de Emprestimo");

            int.TryParse(Console.ReadLine(), out int escolha);

            switch (escolha)
            {
                case 1:
                    CofreEletronico.Executar();
                    break;
                case 2:
                    NotificadorDeAniversariante.Executar();
                    break;
                case 3:
                    ProgramaDeEmprestimo.Executar();
                    break;
                default:
                    Console.WriteLine("Opcao invalida!");
                    return;
            }

        }
    }
}