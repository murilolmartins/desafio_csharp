using System.Text;
using DesafioCsharp.Entitties.Exceptions;

namespace DesafioCsharp.Entitties
{
    public class Colaborador
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataAdmissao { get; set; }

        public double SalarioBase { get; set; }

        private readonly IList<Projeto> _projetosParticipantes = new List<Projeto>();

        private readonly IList<Atividade> _atividadesAtribuidas = new List<Atividade>();

        public Colaborador(int id, string nome, DateTime dataAdmissao, double salarioBase)
        {
            Id = id;
            Nome = nome;
            DataAdmissao = dataAdmissao;
            SalarioBase = salarioBase;
        }

        public void AdicionarProjeto(Projeto projeto)
        {
            if (projeto == null) throw new ArgumentNullException(nameof(projeto));

            ExisteProjeto(projeto);

            _projetosParticipantes.Add(projeto);
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            if (atividade == null) throw new ArgumentNullException(nameof(atividade));

            ExisteAtividade(atividade);

            _atividadesAtribuidas.Add(atividade);
        }

        public void RemoverProjeto(Projeto projeto)
        {
            _projetosParticipantes.Remove(projeto);
        }

        public void RemoverAtividade(Atividade atividade)
        {
            _atividadesAtribuidas.Remove(atividade);
        }


        public override string ToString()
        {

            StringBuilder sb = new();

            sb.AppendLine("Id: " + Id);

            sb.AppendLine("Nome: " + Nome);

            sb.AppendLine("Data de Admissão: " + DataAdmissao);

            sb.AppendLine("Salário Base: " + SalarioBase);

            sb.AppendLine("Projetos Participantes: ");

            foreach (var projeto in _projetosParticipantes)
            {
                sb.AppendLine(projeto.ToString());
            }

            sb.AppendLine("Atividades Atribuidas: ");

            foreach (var atividade in _atividadesAtribuidas)
            {
                sb.AppendLine(atividade.ToString());
            }

            return sb.ToString();

        }

        private void ExisteProjeto(Projeto projeto)
        {
            if (_projetosParticipantes.Any((projeto) => projeto.Nome == projeto.Nome))
                throw new ArgumentException($"O projeto já foi adicionado ao colaborador {Nome}");
        }

        private void ExisteAtividade(Atividade atividade)
        {
            if (_atividadesAtribuidas.Any((atividade) => atividade.Nome == atividade.Nome))
                throw new ConflictException($"A atividade já foi adicionada ao colaborador {Nome}");

        }
    }

}