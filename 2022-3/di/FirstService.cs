
namespace _2022_3.di {
  public class FirstService : IFirstService
  {
    private readonly ISecondService _second;
    
    public FirstService(ISecondService second) {
      this._second = second;
    }

    public void FirstFunction(HttpContext context)
    {
      this._second.SecondFunction(context);
    }
  }
}
