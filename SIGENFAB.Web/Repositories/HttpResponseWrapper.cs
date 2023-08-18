using System.Net;

namespace SIGENFAB.Web.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }
        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }
            var codigoEstatus = HttpResponseMessage.StatusCode;
            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Recurso não encontrado";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "Você precisa fazer login para fazer esta operação";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "Você não tem permissão para fazer esta operação";
            }
            return "Ocorreu um erro inesperado";
        }
    }
}
