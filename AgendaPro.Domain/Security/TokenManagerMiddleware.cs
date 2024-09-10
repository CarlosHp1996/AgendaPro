//using System.Net;
//using System.Text.Json;
//using Core.Interfaces.Security;
//using Microsoft.AspNetCore.Http;
//using Serilog;
//using System;
//using System.Net;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace AgendaPro.Domain.Security
//{
//    public class TokenManagerMiddleware : IMiddleware
//    {
//        private readonly ITokenManager _tokenManager;

//        public TokenManagerMiddleware(ITokenManager tokenManager)
//        {
//            _tokenManager = tokenManager;
//        }

//        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//        {
//            try
//            {
//                _tokenManager.GetEndpoints(context);
//                if (await _tokenManager.IsCurrentActiveToken() || context.Request.Path == "/api/login")
//                {
//                    await next(context);

//                    return;
//                }
//                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;

//            }
//            catch (Exception ex)
//            {
//                await HandlerExceptionAsync(context, ex);
//            }
//        }
//        private static Task HandlerExceptionAsync(HttpContext context, Exception exception)
//        {
//            Log.Error(exception, "Erro no sistema.");

//            var code = HttpStatusCode.InternalServerError;

//            var msgErro = "Ocorreu um erro no sistema. Contate o administrador do sistema.";
//            var result = JsonSerializer.Serialize(msgErro);
//            context.Response.ContentType = "application/json";
//            context.Response.StatusCode = (int)code;

//            return context.Response.WriteAsync(result);
//        }

//    }
//}
