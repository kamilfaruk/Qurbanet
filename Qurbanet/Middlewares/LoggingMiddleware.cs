using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Qurbanet.Helpers.Exceptions;
using Qurbanet.Models.ViewModels;
using System.Net;

namespace Qurbanet.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (_logger.BeginScope(new
            {
                RequestId = context.TraceIdentifier,
                Path = context.Request.Path,
                Method = context.Request.Method
            }))
            {
                try
                {
                    await _next(context);
                }
                catch (ValidationException ex)
                {
                    _logger.LogWarning(ex, "Validation exception occurred: {Message}", ex.Message);
                    context.Response.StatusCode = 400;
                    await HandleHtmlError(context, ex.Message, ex.ErrorCode);
                }
                catch (BusinessException ex)
                {
                    _logger.LogError(ex, "Business exception occurred: {Message}", ex.Message);
                    context.Response.StatusCode = 403;
                    await HandleHtmlError(context, ex.Message, ex.ErrorCode);
                }
                catch (DatabaseException ex)
                {
                    _logger.LogError(ex, "Database exception occurred: {Message}", ex.Message);
                    context.Response.StatusCode = 403;
                    await HandleHtmlError(context, ex.Message, ex.ErrorCode);
                }
                catch (AuthorizationException ex)
                {
                    _logger.LogError(ex, "Authorization exception occurred: {Message}", ex.Message);
                    context.Response.StatusCode = 403;
                    await HandleHtmlError(context, ex.Message, ex.ErrorCode);
                }
                catch (CustomException ex)
                {
                    _logger.LogError(ex, "A custom exception occurred.");
                    context.Response.StatusCode = 400;
                    await HandleHtmlError(context, ex.Message, ex.ErrorCode);
                }
                catch (Exception ex)
                {
                    //Daha önce tanımlanmamış bir hata fırlatıldı...
                    _logger.LogError(ex, string.Format("An unexpected error occurred. {0}", ex.Message));
                    await HandleHtmlError(context, string.Format("An unexpected error occurred. {0}", ex.Message), (int)HttpStatusCode.InternalServerError);
                }
            }
        }

        private async Task HandleHtmlError(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "text/html";
            context.Response.StatusCode = statusCode;

            var errorViewModel = new ErrorViewModel
            {
                Message = message,
                StatusCode = statusCode
            };

            // Razor View'i render et ve sonucu yaz
            var view = "/Views/Shared/Error.cshtml"; // Hata sayfasının yolu
            var renderedView = await RenderViewToStringAsync(context, view, errorViewModel);

            await context.Response.WriteAsync(renderedView);
        }

        private async Task<string> RenderViewToStringAsync(HttpContext context, string viewPath, object model)
        {
            var serviceProvider = context.RequestServices;
            var razorViewEngine = serviceProvider.GetRequiredService<IRazorViewEngine>();
            var tempDataProvider = serviceProvider.GetRequiredService<ITempDataProvider>();
            var actionContext = new ActionContext(context, new RouteData(), new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            using var writer = new StringWriter();
            var viewResult = razorViewEngine.GetView(null, viewPath, false);

            if (!viewResult.Success)
            {
                throw Helpers.Constants.CustomExceptions.NotFound;
            }

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = model },
                new TempDataDictionary(context, tempDataProvider),
                writer,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return writer.ToString();
        }
    }
}