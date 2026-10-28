using System.Collections.Generic;

namespace CentralAtendimento
{
    public class Guiches
    {
        private List<Guiche> listaGuiches;

        public Guiches()
        {
            listaGuiches = new List<Guiche>();
        }

        public List<Guiche> ListaGuiches
        {
            get { return listaGuiches; }
        }

        public void adicionar(Guiche guiche)
        {
            if (guiche != null)
                listaGuiches.Add(guiche);
        }

        public Guiche Obter(int id)
        {
            foreach (Guiche guiche in listaGuiches)
            {
                if (guiche.Id == id)
                    return guiche;
            }
            return null;
        }
    }
}
