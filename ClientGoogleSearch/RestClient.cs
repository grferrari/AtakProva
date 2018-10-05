using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGoogleSearch
{
    public class RestClient
    {
        private string url = "http://localhost:52695/api/search/";
        private string contentType = "application/json; charset=utf-8";
        private System.Net.WebRequest request;

        /*
         * Inicializa a conexão e a requisição dos dados da API.
         * 
         * Entrada: metodo da API concatenada com os parâmetros necessarios {string method}.
         *          metodo HTML para requisição {htmlMethod}.
         */
        private void initializeRequest(string method, string htmlMethod)
        {

            this.request = System.Net.WebRequest.Create(url + "/" + method);
            this.request.Method = htmlMethod;
            this.request.ContentType = this.contentType;
        }

        /*
         * Retorna a lista de titulos e links recebida da API.
         * 
         * Entrada: Texto da pesquisa {string content}.
         * Saída: Lista de titulos e links {list}.
         */
        public List<SiteData> getListOflinks(string content)
        {
           List<SiteData> list = new List<SiteData>();

            string jsonData = "";

            this.initializeRequest("searchInGoogle/" + content, "GET");

            var response = (System.Net.HttpWebResponse)request.GetResponse();

            using (var streamReader = new System.IO.StreamReader(response.GetResponseStream()))
            {

                jsonData = streamReader.ReadToEnd();

                list = Deserialize<List<SiteData>>(jsonData);
            }

            return list;
        }

        /*
         * Método que converte (deserializa) os dados em json para objetos do tipo SiteData.
         * 
         * Entrada: Arquivo json trazido pelo request {string stringJson}.
         * Saída: retorna todos os objetos separados e atribuidos a objetos SiteData {objeto}.
         */
        public T Deserialize<T>(string stringJson)
        {
            T object1 = Activator.CreateInstance<T>();

            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(stringJson));

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(object1.GetType());

            object1 = (T)serializer.ReadObject(memoryStream);

            memoryStream.Close();

            return object1;
        }
    }
}
