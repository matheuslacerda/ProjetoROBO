using System;
using System.Linq;

namespace ROBOWebApp.Models
{
    /// <summary>
    /// Classe que simula a cabeça de um R.O.B.O.
    /// </summary>
    public class Cabeca
    {
        public enum Rotacoes
        {
            Menos90,
            Menos45,
            EmRepouso,
            Mais45,
            Mais90
        }

        public enum Inclinacoes
        {
            ParaCima,
            EmRepouso,
            ParaBaixo
        }

        public Rotacoes Rotacao { get; private set; }
        public Inclinacoes Inclinacao { get; private set; }

        public Cabeca()
        {
            Rotacao = Rotacoes.EmRepouso;
            Inclinacao = Inclinacoes.EmRepouso;
        }

        public void RodarCabeca(int rotacao)
        {
            int max = Enum.GetValues(typeof(Rotacoes)).Cast<int>().Max();

            if (rotacao < 0 || rotacao > max)
                throw new Exception($"Parâmetro da ação inválido! Valores válidos: 0-{max}");

            if (Inclinacao.Equals(Inclinacoes.ParaBaixo))
                throw new Exception("Movimento inválido! Não é possível girar a cabeça se ela estiver inclinada para baixo.");

            if (Math.Abs(rotacao - (int)Rotacao) > 1)
                throw new Exception($"Mudança de estado inválida! Movimento brusco, pulando estados. Estado atual: {(int)Rotacao} ({Rotacao}). Estado desejado: {rotacao} ({(Rotacoes)rotacao}).");

            Rotacao = (Rotacoes)rotacao;
        }

        public void InclinarCabeca(int inclinacao)
        {
            int max = Enum.GetValues(typeof(Inclinacoes)).Cast<int>().Max();

            if (inclinacao < 0 || inclinacao > max)
                throw new Exception($"Parâmetro da ação inválido! Valores válidos: 0-{max}");

            if (Math.Abs(inclinacao - (int)Inclinacao) > 1)
                throw new Exception($"Mudança de estado inválida! Movimento brusco, pulando estados. Estado atual: {(int)Inclinacao} ({Inclinacao}). Estado desejado: {inclinacao} ({(Inclinacoes)inclinacao}).");

            Inclinacao = (Inclinacoes)inclinacao;
        }
    }
}