namespace _2022_4.di {

  public class SecondService : ISecondService
  {
    public void SecondFunction(HttpContext context)
    {
      context.Response.WriteAsync("Zgadnij co tu będzie");
    }
  }
}