namespace AstroCurio.WEB.Repositories
{
    public interface IRepository
    {

        Task<HttpResponseWrapper<T>> Get<T>(string url);

        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);

        Task<HttpResponseWrapper<T>>Delete<T>(string url);



    }
}