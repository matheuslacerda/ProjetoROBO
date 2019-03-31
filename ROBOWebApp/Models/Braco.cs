using System;
using System.Linq;

namespace ROBOWebApp.Models
{
    /// <summary>
    /// Classe que simula o braço de um R.O.B.O.
    /// </summary>
    public class Braco
    {
        public enum Contracoes
        {
            EmRepouso,
            LevementeContraido,
            Contraido,
            FortementeContraido
        }

        public enum Rotacoes
        {
            Menos90,
            Menos45,
            EmRepouso,
            Mais45,
            Mais90,
            Mais135,
            Mais180
        }

        public Contracoes ContracaoCotovelo { get; private set; }
        public Rotacoes RotacaoPulso { get; private set; }

        public Braco()
        {
            ContracaoCotovelo = Contracoes.EmRepouso;
            RotacaoPulso = Rotacoes.EmRepouso;
        }

        public void ContrairCotovelo(int forca)
        {
            int max = Enum.GetValues(typeof(Contracoes)).Cast<int>().Max();

            if (forca < 0 || forca > max)
                throw new Exception($"Parâmetro da ação inválido! Valores válidos: 0-{max}");

            if (Math.Abs(forca - (int)ContracaoCotovelo) > 1)
                throw new Exception($"Mudança de estado inválida! Movimento brusco, pulando estados. Estado atual: {(int)ContracaoCotovelo} ({ContracaoCotovelo}). Estado desejado: {forca} ({(Contracoes)forca}).");

            ContracaoCotovelo = (Contracoes)forca;
        }

        public void RodarPulso(int rotacao)
        {
            int max = Enum.GetValues(typeof(Rotacoes)).Cast<int>().Max();

            if (rotacao < 0 || rotacao > max)
                throw new Exception($"Parâmetro da ação inválido! Valores válidos: 0-{max}");

            if (!ContracaoCotovelo.Equals(Contracoes.FortementeContraido))
                throw new Exception("Movimento inválido! Não é possível girar o pulso se o cotovelo não estiver fortemente contraído.");

            if (Math.Abs(rotacao - (int)RotacaoPulso) > 1)
                throw new Exception($"Mudança de estado inválida! Movimento brusco, pulando estados. Estado atual: {(int)RotacaoPulso} ({RotacaoPulso}). Estado desejado: {rotacao} ({(Rotacoes)rotacao}).");

            RotacaoPulso = (Rotacoes)rotacao;
        }
    }
}
