using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ROBOWebApp.Controllers;

namespace ROBOTest
{
    /// <summary>
    /// Classe respons�vel pelos testes do ROBOController.
    /// </summary>
    public class ROBOControllerTests
    {
        private ROBOController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            Controller = new ROBOController(new ROBOWebApp.Models.ROBO());
        }

        [Test]
        public void GetRepouso()
        {
            string result = Controller.Get();
            Assert.AreEqual(result, "{\"BracoEsquerdo\":{\"ContracaoCotovelo\":0,\"RotacaoPulso\":2},\"BracoDireito\":{\"ContracaoCotovelo\":0,\"RotacaoPulso\":2},\"Cabeca\":{\"Rotacao\":2,\"Inclinacao\":1}}");
        }

        [Test]
        public void GetAposMovimentos()
        {
            // Movimento inv�lido: inexistente
            Controller.Post(new Payload { Acao = 0, ParametroDaAcao = -1 });
            // Movimento inv�lido: muito brusco
            Controller.Post(new Payload { Acao = 0, ParametroDaAcao = 2 });
            // Contra��o do cotovelo direito: leve
            Controller.Post(new Payload { Acao = 1, ParametroDaAcao = 1 });
            // Contra��o do cotovelo direito: moderada
            Controller.Post(new Payload { Acao = 1, ParametroDaAcao = 2 });
            // Contra��o do cotovelo direito: forte
            Controller.Post(new Payload { Acao = 1, ParametroDaAcao = 3 });
            // Movimento inv�lido: inexistente
            Controller.Post(new Payload { Acao = 1, ParametroDaAcao = 4 });
            // Movimento inv�lido: cotovelo esquerdo deveria estar fortemente flexionado
            Controller.Post(new Payload { Acao = 2, ParametroDaAcao = 3 });
            // Rota��o do pulso direito para -45�
            Controller.Post(new Payload { Acao = 3, ParametroDaAcao = 1 });
            // Rota��o do pulso direito para 90�
            Controller.Post(new Payload { Acao = 3, ParametroDaAcao = 0 });
            // Movimento inv�lido: muito brusco
            Controller.Post(new Payload { Acao = 3, ParametroDaAcao = 2 });
            // Inclina��o da cabe�a para baixo
            Controller.Post(new Payload { Acao = 5, ParametroDaAcao = 2 });
            // Movimento inv�lido: a cabe�a n�o deveria estar inclinada para baixo
            Controller.Post(new Payload { Acao = 4, ParametroDaAcao = 1 });
            // Inclina��o da cabe�a para baixo
            Controller.Post(new Payload { Acao = 5, ParametroDaAcao = 1 });
            // Rota��o da cabe�a para 45�
            Controller.Post(new Payload { Acao = 4, ParametroDaAcao = 3 });
            // Rota��o da cabe�a para 90�
            Controller.Post(new Payload { Acao = 4, ParametroDaAcao = 4 });
            // Movimento inv�lido: muito brusco
            Controller.Post(new Payload { Acao = 4, ParametroDaAcao = 0 });
            // Inclina��o da cabe�a para cima
            Controller.Post(new Payload { Acao = 5, ParametroDaAcao = 0 });

            string result = Controller.Get();
            Assert.AreEqual(result, "{\"BracoEsquerdo\":{\"ContracaoCotovelo\":0,\"RotacaoPulso\":2},\"BracoDireito\":{\"ContracaoCotovelo\":3,\"RotacaoPulso\":0},\"Cabeca\":{\"Rotacao\":4,\"Inclinacao\":0}}");
        }

        [Test]
        public void PostInvalido1()
        {
            var response = Controller.Post(new Payload { Acao = -1, ParametroDaAcao = 0 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }

        [Test]
        public void PostInvalido2()
        {
            var response = Controller.Post(new Payload { Acao = 6, ParametroDaAcao = 0 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }

        [Test]
        public void PostInvalido3()
        {
            var response = Controller.Post(new Payload { Acao = 0, ParametroDaAcao = 10 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }

        [Test]
        public void PostInvalido4()
        {
            var response = Controller.Post(new Payload { Acao = 0, ParametroDaAcao = 2 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }

        [Test]
        public void PostInvalido5()
        {
            var response = Controller.Post(new Payload { Acao = 2, ParametroDaAcao = 3 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }

        [Test]
        public void PostInvalido6()
        {
            Controller.Post(new Payload { Acao = 5, ParametroDaAcao = 2 });
            var response = Controller.Post(new Payload { Acao = 4, ParametroDaAcao = 1 });
            Assert.IsInstanceOf(typeof(BadRequestObjectResult), response);
        }
    }
}