using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace _2022_5.Controllers {

  [Route("second")]
  public class SecondController {

    public IUrlHelper Url { get; set;}
    private readonly IUrlHelperFactory _url;
    public HttpContext HttpContext {get; set;}

    [ControllerContext] public ControllerContext ControllerContext {get; set;}
    [ActionContext] public ActionContext ActionContext {get; set;}
    [ViewDataDictionary] public ViewDataDictionary ViewBag { get; set;} 

    public SecondController(IHttpContextAccessor accessor, IUrlHelperFactory url) {
      _url = url;
      this.HttpContext = accessor.HttpContext;
    }


  [Route("")]
    public string Index() {
      return "abcdef";

    }


  }
}