using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using System.Collections;
using System.Linq;

namespace _1lab
{
    public class http_handler : IHttpHandler, IRequiresSessionState
    {
        public static int result { get; set; }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Session["stack"] == null) context.Session["stack"] = new Stack<int>();  
                Stack<int> stack = (Stack<int>)context.Session["stack"];
                switch (context.Request.HttpMethod)
                {
                    case "GET":
                        {
                            context.Response.ContentType = "application/json";
                            int topValue = 0;
                            if (stack.Count() != 0)
                                topValue = stack.Peek();
                            context.Response.Write($"{{RESULT:{result + topValue}, STACK: {JsonSerializer.Serialize(stack)}}}");
                        }
                        break;
                    case "POST":
                        {
                            result = int.Parse(context.Request.Params["result"]);
                        }
                        break;
                    case "PUT":
                        {
                            int value = int.Parse(context.Request.Params["push"]);
                            stack.Push(value);
                        }
                        break;
                    case "DELETE":
                        {
                            if (stack.Count != 0)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                    default:
                        {
                            context.Response.StatusCode = 405;
                            context.Response.End();
                        }
                        break;
                }
            }

            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                context.Response.Write(e.Message);
            }
        }
    }
}
