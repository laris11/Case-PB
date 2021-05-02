using System;
using System.Collections.Generic;
using ArquivoBaseBootcamp.Models;
using Newtonsoft.Json;

namespace ArquivoBaseBootcamp.Services
{
    public class InteresseService : IInteresseService
    {

        public Interessada ConsultarPorEmail(string email)
        {
            var contaInteressadas = " "; //  comando C# para contar os itens de uma lista
            for (var contador = 1; contaInteressadas; contador++) 
            {
                if (DadosInteressadas.Email[contador] == email) // comparar o email da linha índice contador com o email fornecido 
                {
                    return (DadosInteressadas[contador]); //Se for igual, retorna os dados da linha índice contador
                }
            }
            return (null); // se o email fornecido para procura não for encontrado, retorna vazio (para identificar no controller)
        }

        public Interessada AtualizarEmail(string email, Interessada interessada)
        {
            if (ConsultarPorEmail(interessada.Email) == interessada) // verifica se a interessada que precisa atualizar o email está cadastrada
            {
                interessada.Email = email; // se sim, atualiza email
                return(interessada); //retorna interessada com email atualizado
            }
            else
            {
                return(null); //se não, retorna vazio (para identificar no controller)
            }
        }

        public List<Interessada> ConsultarTodos()
        {
            return(DadosInteressadas); // retornar lista DadosInteressadas.json
        }

        public bool ExcluirPorEmail(string email)
        {
            if (ConsultarPorEmail(email).Email == email) //procura por interessada com email fornecido na lista. Se for encontrada, o email da interessada é o email fornecido
            {
                // excluir objeto interessada (Dados da interessa) na lista DadosInteressadas.json 
                return (true);
            }
            else
            {
                return (false);
            }
            
        }

        // Obrigatorio nome E email
        // Validar email
        // Nao permitir email duplicado
        
        public Interessada Incluir(Interessada interessada) 
        {
            // verificar se os dados passados fazem sentido

            if (interessada.Nome != null && interessada.Email != null) // && interessada.Nome tem " " (string espaço, nome e sobrenome) && interessada.Email tem "@" (string @, validar email) && interessada.Email não tem " " (string espaço, validar email)
            {
                var verificaRepeticaoEmail = ConsultarPorEmail(interessada.Email);
                if (verificaRepeticaoEmail == interessada)
                {
                    // incluir objeto interessada (Dados da interessa) na lista DadosInteressadas.json 
                    return (null);
                }
                else
                {
                    return (interessada);
                }
            }
            else
            {
                return (null);
            }


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // tentativas de fazer a lista de dados em um documento .json
        // não consegui terminar de fechar o código verificando se ele faz o que eu preciso, então deixei incompleto aqui, até onde consegui desenvolver

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // ler objeto interessada e salvar em string
            string DadosInteressadas = JsonConvert.SerializeObject(interessada); // 

            // converter para lista de interessadas (usado no ConsultarDados) 
            List<Interessada> listaInteressada = new List<Interessada>(); //convertido
            
            // converter DadosInteressadas.json em lista  - adiciona a interessada
            listaInteressada = JsonConvert.DeserializeObject<List<Interessada>>(DadosInteressadas); 
            listaInteressada.Add(interessada);

            // voltar lista para .json 

            // salvar .json convertido no arquivo DadosInteressadas.json

        }
    }
}


