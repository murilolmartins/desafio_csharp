using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Id = id
            Nome = nome;
            DataAdmissao = dataAdmissao;
            SalarioBase = salarioBase;
        }

        public void AdicionarProjeto(Projeto projeto)
        {
            _projetosParticipantes.Add(projeto);
        }

        public void AdicionarAtividade(Atividade atividade)
        {
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

        public double CalcularSalario()
        {
            double salario = SalarioBase;
            foreach (var atividade in _atividadesAtribuidas)
            {
                salario += atividade.CalcularCusto();
            }
            return salario;
        }


        public override string ToString()
        {

            StringBuilder sb = new();

            sb.AppendLine("Id: " + Id);

            sb.AppendLine("Nome: " + Nome);

            sb.AppendLine("Data de Admissão: " + DataAdmissao);

            sb.AppendLine("Salário Base: " + SalarioBase);

            sb.AppendLine("Salário Total: " + CalcularSalario());

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


    }
}