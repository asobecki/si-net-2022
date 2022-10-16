namespace _2022_4.di {

  public class FirstService : IFirstService
  {

    private readonly ISecondService _second;

    public FirstService(ISecondService secondService) {
      _second = secondService;
    }

    public void FirstFunction(HttpContext context)
    {
      _second.SecondFunction(context);
    }
  }
}