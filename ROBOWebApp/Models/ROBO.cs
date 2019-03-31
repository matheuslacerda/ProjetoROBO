namespace ROBOWebApp.Models
{
    /// <summary>
    /// Classe que simula um R.O.B.O.
    /// </summary>
    public class ROBO
    {
        public Braco BracoEsquerdo { get; set; }
        public Braco BracoDireito { get; set; }
        public Cabeca Cabeca { get; set; }

        public ROBO()
        {
            BracoEsquerdo = new Braco();
            BracoDireito = new Braco();
            Cabeca = new Cabeca();
        }
    }
}
