using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CountMe.Helpers
{
    public sealed class PlainTextInputFormatter : TextInputFormatter
    {
        public PlainTextInputFormatter()
        {
            SupportedMediaTypes.Add("text/plain");
            SupportedEncodings.Add(System.Text.Encoding.UTF8);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            int content = 0;
            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                content = Convert.ToInt32((await reader.ReadToEndAsync()).Trim());
            }
            return InputFormatterResult.Success(content);
        }
    }
}