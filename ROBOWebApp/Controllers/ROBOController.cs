using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace ROBOWebApp.Controllers
{
    public class Payload
    {
        public int Acao { get; set; }
        public int ParametroDaAcao { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ROBOController : ControllerBase
    {
        private ROBOWebApp.Models.ROBO Bot;

        public ROBOController(ROBOWebApp.Models.ROBO bot)
        {
            Bot = bot;
        }

        // GET: api/ROBO
        /// <summary>
        /// Obtém um JSON com o status atual dos membros do R.O.B.O.
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(Bot);
        }

        // POST: api/ROBO
        /// <summary>
        /// Envia uma ação para o R.O.B.O.
        /// </summary>
        /// <remarks>Ações:
        /// <para/>0: Contração do cotovelo do braço esquerdo
        /// <para/>1: Contração do cotovelo do braço direito
        /// <para/>2: Rotação do pulso do braço esquerdo
        /// <para/>3: Rotação do pulso do braço direito
        /// <para/>4: Rotação da cabeça
        /// <para/>5: Inclinação da cabeça
        /// <para/>-
        /// <para/>Parâmetros:
        /// <para/>Contração de cotovelo: 0 - Em repouso; 1 - Levemente contraído; 2 - Contraído; 3 - Fortemente contraído
        /// <para/>Rotação do pulso: 0 - Rotação para -90º; 1 - Rotação para -45º; 2 - Em repouso; 3 - Rotação para 45º; 4 - Rotação para 90º; 5 - Rotação para 135º; 6 - Rotação para 180º
        /// <para/>Rotação da cabeça: 0 - Rotação -90º; 1 - Rotação -45º; 2 - Em repouso; 3 - Rotação 45º; 4 - Rotação 90º
        /// <para/>Inclinação da cabeça: 0 - Para cima; 1 - Em repouso; 2 - Para baixo</remarks>
        /// <param name="payload">Carrega a ação (Acao) e parâmetro da ação (ParametroDaAcao)</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Payload payload)
        {
            try
            {
                switch (payload.Acao)
                {
                    case 0:
                        Bot.BracoEsquerdo.ContrairCotovelo(payload.ParametroDaAcao);
                        break;
                    case 1:
                        Bot.BracoDireito.ContrairCotovelo(payload.ParametroDaAcao);
                        break;
                    case 2:
                        Bot.BracoEsquerdo.RodarPulso(payload.ParametroDaAcao);
                        break;
                    case 3:
                        Bot.BracoDireito.RodarPulso(payload.ParametroDaAcao);
                        break;
                    case 4:
                        Bot.Cabeca.RodarCabeca(payload.ParametroDaAcao);
                        break;
                    case 5:
                        Bot.Cabeca.InclinarCabeca(payload.ParametroDaAcao);
                        break;
                    default:
                        return BadRequest(new { message = "Ação inválida!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

            return StatusCode(200);
        }
    }
}
