using System.Collections.Generic;
using ArquivoBaseBootcamp.Models;

namespace ArquivoBaseBootcamp.Services
{
    public interface IInteresseService
    {
        public Interessada ConsultarPorEmail(string email);
        public List<Interessada> ConsultarTodos();
        public Interessada Incluir(Interessada interessada);
        public Interessada AtualizarEmail(string email, Interessada interessada);
        public bool ExcluirPorEmail(string email);
    }
}
