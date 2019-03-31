using NUnit.Framework;
using ROBOWebApp.Models;
using System;

namespace ROBOTest
{
    /// <summary>
    /// Classe responsável pelos testes do modelo da cabeça do R.O.B.O.
    /// </summary>
    class ROBOCabecaTests
    {
        private Cabeca Cabeca1 { get; set; }

        [SetUp]
        public void Setup()
        {
            Cabeca1 = new Cabeca();
        }

        [Test]
        public void CabecaMenos90()
        {
            Cabeca1.RodarCabeca(1);
            Cabeca1.RodarCabeca(0);
            Assert.AreEqual(Cabeca1.Rotacao, Cabeca.Rotacoes.Menos90);
        }

        [Test]
        public void CabecaMenos45()
        {
            Cabeca1.RodarCabeca(1);
            Assert.AreEqual(Cabeca1.Rotacao, Cabeca.Rotacoes.Menos45);
        }

        [Test]
        public void CabecaRotacaoRepouso()
        {
            Assert.AreEqual(Cabeca1.Rotacao, Cabeca.Rotacoes.EmRepouso);
        }

        [Test]
        public void CabecaMais45()
        {
            Cabeca1.RodarCabeca(3);
            Assert.AreEqual(Cabeca1.Rotacao, Cabeca.Rotacoes.Mais45);
        }

        [Test]
        public void CabecaMais90()
        {
            Cabeca1.RodarCabeca(3);
            Cabeca1.RodarCabeca(4);
            Assert.AreEqual(Cabeca1.Rotacao, Cabeca.Rotacoes.Mais90);
        }

        [Test]
        public void CabecaParaCima()
        {
            Cabeca1.InclinarCabeca(0);
            Assert.AreEqual(Cabeca1.Inclinacao, Cabeca.Inclinacoes.ParaCima);
        }

        [Test]
        public void CabecaInclinacaoRepouso()
        {
            Assert.AreEqual(Cabeca1.Inclinacao, Cabeca.Inclinacoes.EmRepouso);
        }

        [Test]
        public void CabecaParaBaixo()
        {
            Cabeca1.InclinarCabeca(2);
            Assert.AreEqual(Cabeca1.Inclinacao, Cabeca.Inclinacoes.ParaBaixo);
        }

        [Test]
        public void CabecaAcaoInexistente1()
        {
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(-1));
        }

        [Test]
        public void CabecaAcaoInexistente2()
        {
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(5));
        }

        [Test]
        public void CabecaAcaoInexistente3()
        {
            Assert.Throws<Exception>(() => Cabeca1.InclinarCabeca(-1));
        }

        [Test]
        public void CabecaAcaoInexistente4()
        {
            Assert.Throws<Exception>(() => Cabeca1.InclinarCabeca(3));
        }

        [Test]
        public void CabecaRotacaoInclinacao1()
        {
            Cabeca1.InclinarCabeca(2);
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(1));
        }

        [Test]
        public void CabecaRotacaoInclinacao2()
        {
            Cabeca1.InclinarCabeca(2);
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(3));
        }

        [Test]
        public void MovimentoBrusco1()
        {
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(4));
        }

        [Test]
        public void MovimentoBrusco2()
        {
            Assert.Throws<Exception>(() => Cabeca1.RodarCabeca(0));
        }

        [Test]
        public void MovimentoBrusco3()
        {
            Cabeca1.InclinarCabeca(0);
            Assert.Throws<Exception>(() => Cabeca1.InclinarCabeca(2));
        }

        [Test]
        public void MovimentoBrusco4()
        {
            Cabeca1.InclinarCabeca(2);
            Assert.Throws<Exception>(() => Cabeca1.InclinarCabeca(0));
        }
    }
}
