using System.Collections.Generic;

namespace CentralAtendimento
{
    public class Senhas
    {
        private int proximoAtendimento;
        private Queue<Senha> filaSenhas;

        public Senhas()
        {
            filaSenhas = new Queue<Senha>();
            proximoAtendimento = 1;
        }

        public int Quantidade
        {
            get { return filaSenhas.Count; }
        }

        public Queue<Senha> FilaSenhas
        {
            get { return filaSenhas; }
        }

        public void gerar()
        {
            filaSenhas.Enqueue(new Senha(proximoAtendimento));
            proximoAtendimento++;
        }

        public Senha GerarSenha()
        {
            Senha senha = new Senha(proximoAtendimento);
            filaSenhas.Enqueue(senha);
            proximoAtendimento++;
            return senha;
        }

        public IEnumerable<Senha> Listar()
        {
            return filaSenhas;
        }
    }
}
