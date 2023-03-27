using Microsoft.AspNetCore.Mvc.Formatters;

namespace InnoTractor.Assignment.Api.InputFormatters
{
    public class PlainTextFormatter : InputFormatter
    {
        private const string ConsumerIdentifier = "text/plain";

        public PlainTextFormatter()
        {
            SupportedMediaTypes.Add(ConsumerIdentifier);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            try
            {
                using(var reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    string value = await reader.ReadToEndAsync();
                    object model = Convert.ChangeType(value,context.ModelType);
                    return InputFormatterResult.Success(model);
                }
            }
            catch (Exception exc)
            {
                context.ModelState.TryAddModelError("The provided value is not valid", $"{exc.Message} ModelType = {context.ModelType}");
                return InputFormatterResult.Failure();
            }
        }

        protected override bool CanReadType(Type type)
        {
            return type == typeof(int);
        }

        public override bool CanRead(InputFormatterContext context)
        {
            return context.HttpContext.Request.ContentType == ConsumerIdentifier;
        }
    }
}
