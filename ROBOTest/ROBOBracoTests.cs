using NUnit.Framework;
using ROBOWebApp.Models;
using System;

namespace ROBOTest
{
    /// <summary>
    /// Classe responsável pelos testes do modelo do braço do R.O.B.O.
    /// </summary>
    public class ROBOBracoTests
    {
        private Braco Braco1 { get; set; }

        [SetUp]
        public void Setup()
        {
            Braco1 = new Braco();
        }

        [Test]
        public void CotoveloEmRepouso()
        {
            Assert.AreEqual(Braco1.ContracaoCotovelo, Braco.Contracoes.EmRepouso);
        }

        [Test]
        public void CotoveloLevementeContraido()
        {
            Braco1.ContrairCotovelo(1);
            Assert.AreEqual(Braco1.ContracaoCotovelo, Braco.Contracoes.LevementeContraido);
        }

        [Test]
        public void CotoveloContraido()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Assert.AreEqual(Braco1.ContracaoCotovelo, Braco.Contracoes.Contraido);
        }

        [Test]
        public void CotoveloFortementeContraido()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Assert.AreEqual(Braco1.ContracaoCotovelo, Braco.Contracoes.FortementeContraido);
        }

        [Test]
        public void PulsoMenos90()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(1);
            Braco1.RodarPulso(0);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Menos90);
        }

        [Test]
        public void PulsoMenos45()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(1);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Menos45);
        }

        [Test]
        public void PulsoEmRepouso()
        {
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.EmRepouso);
        }

        [Test]
        public void PulsoMais45()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(3);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Mais45);
        }

        [Test]
        public void PulsoMais90()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(3);
            Braco1.RodarPulso(4);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Mais90);
        }

        [Test]
        public void PulsoMais135()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(3);
            Braco1.RodarPulso(4);
            Braco1.RodarPulso(5);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Mais135);
        }

        [Test]
        public void PulsoMais180()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Braco1.RodarPulso(3);
            Braco1.RodarPulso(4);
            Braco1.RodarPulso(5);
            Braco1.RodarPulso(6);
            Assert.AreEqual(Braco1.RotacaoPulso, Braco.Rotacoes.Mais180);
        }

        [Test]
        public void CotoveloAcaoInexistente1()
        {
            Assert.Throws<Exception>(() => Braco1.ContrairCotovelo(-1));
        }

        [Test]
        public void CotoveloAcaoInexistente2()
        {
            Assert.Throws<Exception>(() => Braco1.ContrairCotovelo(4));
        }

        [Test]
        public void PulsoAcaoInexistente3()
        {
            Assert.Throws<Exception>(() => Braco1.RodarPulso(-1));
        }

        [Test]
        public void PulsoAcaoInexistente4()
        {
            Assert.Throws<Exception>(() => Braco1.RodarPulso(7));
        }

        [Test]
        public void PulsoCotovelo1()
        {
            Assert.Throws<Exception>(() => Braco1.RodarPulso(3));
        }

        [Test]
        public void PulsoCotovelo2()
        {
            Braco1.ContrairCotovelo(1);
            Assert.Throws<Exception>(() => Braco1.RodarPulso(3));
        }

        [Test]
        public void PulsoCotovelo3()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Assert.Throws<Exception>(() => Braco1.RodarPulso(3));
        }

        [Test]
        public void MovimentoBrusco1()
        {
            Assert.Throws<Exception>(() => Braco1.ContrairCotovelo(2));
        }

        [Test]
        public void MovimentoBrusco2()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Assert.Throws<Exception>(() => Braco1.ContrairCotovelo(0));
        }

        [Test]
        public void MovimentoBrusco3()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Assert.Throws<Exception>(() => Braco1.RodarPulso(4));
        }

        [Test]
        public void MovimentoBrusco4()
        {
            Braco1.ContrairCotovelo(1);
            Braco1.ContrairCotovelo(2);
            Braco1.ContrairCotovelo(3);
            Assert.Throws<Exception>(() => Braco1.RodarPulso(0));
        }
    }
}
