using DesafioCsharp.Entitties.Enums;

namespace DesafioCsharp.Entitties

{
    public class Atividade
    {
        public string Nome { get; set; }

        public DateTime Descricao { get; set; }

        public StatusDaAtividade Status { get; set; }

        public Colaborador Colaborador { get; set; }

        public Atividade(string nome, DateTime descricao, StatusDaAtividade status, Colaborador colaborador)
        {
            Nome = nome;
            Descricao = descricao;
            Status = status;
            Colaborador = colaborador;
        }

        public double CalcularCusto()
        {
            double custo = 0;
            if (Status == StatusDaAtividade.Iniciado)
            {
                custo = 0;
            }
            else if (Status == StatusDaAtividade.EmAndamento)
            {
                custo = 0.2 * Colaborador.SalarioBase;
            }
            else if (Status == StatusDaAtividade.Concluido)
            {
                custo = 0.5 * Colaborador.SalarioBase;
            }
            return custo;
        }

        public override string ToString()
        {
            return "Nome: " + Nome + "Descrição: " + Descricao + "Status: " + Status);
        }
    }
}