using System.Globalization;
using DesafioCsharp.Entitties;
using DesafioCsharp.Entitties.Enums;
using DesafioCsharp.Entitties.Exceptions;

namespace DesafioCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Quantos colaboradores deseja cadastrar?");

                int n = int.Parse(Console.ReadLine()!);

                HashSet<Colaborador> colaboradores = new();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Digite o id do colaborador: ");
                    int id = int.Parse(Console.ReadLine()!);

                    if (colaboradores.Any(x => x.Id == id))
                    {
                        Console.WriteLine("Id já cadastrado");
                        i--;
                        continue;
                    };

                    Console.WriteLine("Digite o nome do colaborador: ");
                    string nome = Console.ReadLine()!;

                    Console.WriteLine("Digite a data de admissão do colaborador (dd/mm/aaaa): ");
                    DateTime dataAdmissao = DateTime.Parse(Console.ReadLine()!);

                    Console.WriteLine("Digite o salário base do colaborador: ");
                    double salarioBase = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                    Colaborador colaborador = new(id, nome, dataAdmissao, salarioBase);

                    colaboradores.Add(colaborador);
                }

                Console.WriteLine("Quantos projetos deseja cadastrar?");

                int m = int.Parse(Console.ReadLine()!);

                HashSet<Projeto> projetos = new();

                for (int i = 0; i < m; i++)
                {

                    Console.WriteLine("Digite o nome do projeto: ");
                    string nome = Console.ReadLine()!;

                    if (projetos.Any(x => x.Nome == nome))
                    {
                        Console.WriteLine("Nome já cadastrado");
                        i--;
                        continue;
                    };

                    Console.WriteLine("Digite a decrição do projeto: ");
                    string descricao = Console.ReadLine()!;

                    Projeto projeto = new(nome, descricao);

                    projetos.Add(projeto);
                }

                Console.WriteLine("Quantas atividades deseja cadastrar?");

                int p = int.Parse(Console.ReadLine()!);

                HashSet<Atividade> atividades = new();

                for (int i = 0; i < p; i++)
                {

                    Console.WriteLine("Digite o nome da atividade: ");
                    string nome = Console.ReadLine()!;

                    if (atividades.Any(x => x.Nome == nome))
                    {
                        Console.WriteLine("Nome já cadastrado");
                        i--;
                        continue;
                    };

                    Console.WriteLine("Digite a decrição da atividade: ");
                    string descricao = Console.ReadLine()!;

                    Console.WriteLine("Digite o status da atividade (Parada/Iniciada/Concluida): ");
                    StatusDaAtividade status = Enum.Parse<StatusDaAtividade>(Console.ReadLine()!);

                    Atividade atividade = new(nome, descricao, status);

                    atividades.Add(atividade);
                }

                bool continuar = true;

                while (continuar)
                {

                    Console.WriteLine("Digite o id do colaborador que deseja atribuir um projeto: ");

                    int id = int.Parse(Console.ReadLine()!);


                    Colaborador? colaboradorSelecionado = colaboradores.SingleOrDefault(x => x.Id == id);

                    if (colaboradorSelecionado == null)
                    {
                        Console.WriteLine("Colaborador não encontrado");
                        continue;
                    }

                    Console.WriteLine("Digite o nome do projeto que deseja atribuir ao colaborador: ");

                    string nomeProjeto = Console.ReadLine()!;

                    Projeto? projetoSelecionado = projetos.SingleOrDefault(x => x.Nome == nomeProjeto);

                    if (projetoSelecionado == null)
                    {
                        Console.WriteLine("Projeto não encontrado");
                        continue;
                    }


                    Console.WriteLine("Digite o nome da atividade que deseja atribuir ao colaborador: ");

                    string nomeAtividade = Console.ReadLine()!;

                    Atividade? atividadeSelecionada = atividades.SingleOrDefault(x => x.Nome == nomeAtividade);

                    if (atividadeSelecionada == null)
                    {
                        Console.WriteLine("Atividade não encontrada");
                        continue;
                    }

                    colaboradorSelecionado.AdicionarProjeto(projetoSelecionado);

                    colaboradorSelecionado.AdicionarAtividade(atividadeSelecionada);

                    projetoSelecionado.AdicionarAtividade(atividadeSelecionada);

                    Console.WriteLine(colaboradorSelecionado.ToString());

                    Console.WriteLine("Deseja atribuir outros colaboradores a outro projeto e atividade? (s/n)");

                    string resposta = Console.ReadLine()!;

                    if (resposta == "n") continuar = false;
                }

            }
            catch (ConflictException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
