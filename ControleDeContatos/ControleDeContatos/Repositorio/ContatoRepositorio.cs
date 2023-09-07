using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        // injeção de dependencia
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext; 
        }
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            //carrega tudo que tem nesse banco de dados e listando
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            // gravar no banco de dados
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
             
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel ContatoDb = ListarPorId(contato.Id);

            if (ContatoDb == null) throw new Exception("Houve um erro de atualização do contato");

            ContatoDb.Nome = contato.Nome;
            ContatoDb.Email = contato.Email;
            ContatoDb.Celular = contato.Celular;

            _bancoContext.Contatos.Update(ContatoDb);
            _bancoContext.SaveChanges();

            return ContatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel ContatoDb = ListarPorId(id);

            if (ContatoDb == null) throw new Exception("Houve um erro na deleção do contato");

            _bancoContext.Contatos.Remove(ContatoDb);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
