using System;

namespace CentralAtendimento
{
    public class Senha
    {
        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime dataAtend;
        private DateTime horaAtend;

        public int Id { get { return id; } }
        public DateTime DataGeracao { get { return dataGerac; } }
        public DateTime HoraGeracao { get { return horaGerac; } }
        public DateTime DataAtendimento { get { return dataAtend; } }
        public DateTime HoraAtendimento { get { return horaAtend; } }
        public bool FoiAtendida { get; private set; }

        public Senha(int id)
        {
            this.id = id;
            dataGerac = DateTime.Now;
            horaGerac = DateTime.Now;
            FoiAtendida = false;
        }

        public void RegistrarAtendimento()
        {
            dataAtend = DateTime.Now;
            horaAtend = DateTime.Now;
            FoiAtendida = true;
        }

        public string dadosParciais()
        {
            return string.Format("{0} - {1:dd/MM/yyyy} - {2:HH:mm:ss}",
                id, dataGerac, horaGerac);
        }

        public string dadosCompletos()
        {
            return string.Format("{0} - Gerada: {1:dd/MM/yyyy} {2:HH:mm:ss} - Atendida: {3:dd/MM/yyyy} {4:HH:mm:ss}",
                id,
                dataGerac,
                horaGerac,
                dataAtend,
                horaAtend);
        }

        public override string ToString()
        {
            return FoiAtendida ? dadosCompletos() : dadosParciais();
        }
    }
}
