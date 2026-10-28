using System.Collections.Generic;

namespace CentralAtendimento
{
    public class Guiche
    {
        private int id;
        private Queue<Senha> atendimentos;

        public Guiche()
            : this(0)
        {
        }

        public Guiche(int id)
        {
            this.id = id;
            atendimentos = new Queue<Senha>();
        }

        public int Id
        {
            get { return id; }
        }

        public Queue<Senha> Atendimentos
        {
            get { return atendimentos; }
        }

        public bool chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas == null || filaSenhas.Count == 0)
                return false;

            Senha senha = filaSenhas.Dequeue();
            senha.RegistrarAtendimento();
            atendimentos.Enqueue(senha);
            return true;
        }

        public Senha Chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas == null || filaSenhas.Count == 0)
                return null;

            Senha senha = filaSenhas.Dequeue();
            senha.RegistrarAtendimento();
            atendimentos.Enqueue(senha);
            return senha;
        }
    }
}
