namespace _2022_5.Contraints {

  public class MyEvenNumberConstraint : IRouteConstraint
  {
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
      if( (values.ContainsKey(routeKey) == false) || values[routeKey] == null) {
        return false;
      }

      var value = values[routeKey].ToString();
      int intValue;
      if(int.TryParse(value, out intValue) == false) {
        return false;
      }

      return (intValue %2) == 0;
    }
  }
}