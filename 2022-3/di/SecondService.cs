
namespace _2022_3.di {

    public class SecondService : ISecondService
    {
        public void SecondFunction(HttpContext context)
        {
          context.Response.WriteAsync("Funkcja wywołana z drugiej usługi");
        }
    }
}
