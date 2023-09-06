using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCsharp.Entitties
{
    public class Projeto
    {

        public string Nome { get; set; }

        public DateTime Descricao { get; set; }

        private readonly IList<Atividade> _atividades = new List<Atividade>();

        public Projeto(string nome, DateTime descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public void AdicionarAtividade(Atividade atividade)
        {
            _atividades.Add(atividade);
        }

        public void RemoverAtividade(Atividade atividade)
        {
            _atividades.Remove(atividade);
        }

        public override string ToString()
        {
            return "Nome: " + Nome + "Descrição: " + Descricao;
        }

    }
}