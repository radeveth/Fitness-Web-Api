namespace FitnessWebApi.ViewModels.Web
{
    public class HttpMethod
    {
        public HttpMethod(string method, string route)
        {
            this.Method = method;
            this.Route = route;
        }

        public string Method { get; set; }

        public string Route { get; set; }
    }
}
