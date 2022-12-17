using System.Web.Mvc;
using System.Web.Http;
using Lab8.Models;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Lab8.Controllers
{
    public class JRServiceController : Controller
    {

        [HttpPost]
        public JsonResult Multi([FromBody] ReqJsonRPC[] body)
        {
            var length = body.Length;
            var result = new object[length];

            for (var i = 0; i < length; i++)
                result[i] = Single(body[i]).Data;

            return Json(result);
        }

        [HttpPost]
        public JsonResult Single(ReqJsonRPC body)
        {
            if (HttpContext.Session["MethodsIgnore"] != null && (bool)HttpContext.Session["MethodsIgnore"])
                return Json(GetError(body.Id, new ErrorJsonRPC { Message = "Methods are not available", Code = -32601 }));

            var method = body.Method;
            var param = body.Params;
            if(param == null)
            {
                return Json(body, JsonRequestBehavior.AllowGet);
            }
            int? result = null;

            var key = param.Key;
            var value = int.Parse(string.IsNullOrEmpty(param.Value) ? "0" : param.Value);

            switch (method)
            {
                case "SetM": { result = SetM(key, value); break; }
                case "GetM": { result = GetM(key); break; }
                case "AddM": { result = AddM(key, value); break; }
                case "SubM": { result = SubM(key, value); break; }
                case "MulM": { result = MulM(key, value); break; }
                case "DivM": { result = DivM(key, value); break; }
                case "ErrorExit": { ErrorExit(); break; }

                default:
                {
                    return Json(GetError(body.Id, new ErrorJsonRPC {
                        Message = $"Function {body.Method} is not found",
                        Code = -32601
                    }));
                }
            }

            return Json(new ResJsonRPC
            {
                Id = body.Id,
                Method = body.Method,
                Result = result
            });
        }

        private static ResJsonRPCError GetError(string id, ErrorJsonRPC error)
        {
            return new ResJsonRPCError
            {
                Id = id,
                Error = error
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Session[k] = x;
            return GetM(k);
        }

        private int? GetM(string k)
        {
            var result = HttpContext.Session[k];
            if (result == null)
                return null;
            return int.Parse(result.ToString());
        }

        private int? AddM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value is null ? x : value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value is null ? x : value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value is null ? x : value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Session[k] = value is null ? x : value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Session.Clear();
            HttpContext.Session["MethodsIgnore"] = true;
        }
    }
}