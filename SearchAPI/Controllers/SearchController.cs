using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchAPI.Models;

namespace SearchAPI.Controllers
{
    //Determina a rota de acesso para o controller.
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private SearchGoogle sg;

        //Determina o tipo do método http.
        [AcceptVerbs("GET")]
        //Determina o nome para acesso ao método com os parâmetros necessários.
        [Route("searchInGoogle/{text}")]
        /*
         * Retorna a lista de links e titulos encontrados em Json.
         * 
         * Entrada: texto da pesquisa {string text}.
         * Saída: Lista {sg.Final}.
         */
        public List<SiteData> searchInGoogle(string text)
        {
            this.sg = new SearchGoogle(text);
            return sg.Final;
        }
    }
}
