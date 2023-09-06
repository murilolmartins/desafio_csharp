using DesafioCsharp.Entitties.Enums;

namespace DesafioCsharp.Entitties

{
    public class Atividade
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public StatusDaAtividade Status { get; set; }

        public Colaborador? Colaborador { get; set; }

        public Atividade(string nome, string descricao, StatusDaAtividade status)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + "Descrição: " + Descricao + "Status: " + Status;
        }
    }
}