namespace Application.Extensions
{
    public static class RequestExtension
    {
        public static bool IsAjax(this HttpRequest request)
        {
            if (request.Headers == null) return false;

            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
