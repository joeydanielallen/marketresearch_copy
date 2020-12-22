using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace afmr.api.ModelBinders
{
    /// <summary>
    /// Enforcing UTC in for Asp.Net actions using DateTime parameters
    /// </summary>
    public class DateTimeUtcModelBinderProvider : IModelBinderProvider
    {
#pragma warning disable CA1802 // Use literals where appropriate
        internal static readonly DateTimeStyles SupportedStyles =
            DateTimeStyles.AdjustToUniversal |
            DateTimeStyles.AllowWhiteSpaces;
#pragma warning restore CA1802 // Use literals where appropriate

        /// <inheritdoc />
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (context.Metadata.ModelType != typeof(DateTime) &&
                context.Metadata.ModelType != typeof(DateTime?))
                return null;

            var modelType = context.Metadata.UnderlyingOrModelType;
            var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            if (modelType == typeof(DateTime) || modelType == typeof(DateTime?))
            {
                return new UtcAwareDateTimeModelBinder(SupportedStyles, loggerFactory);
            }

            return null;
        }
    }
}
