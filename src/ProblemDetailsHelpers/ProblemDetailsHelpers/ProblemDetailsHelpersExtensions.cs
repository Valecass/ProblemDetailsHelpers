using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemDetailsHelpers
{
    public static class ProblemDetailsHelpersExtensions
    {
        /// <summary>
        /// Adds the required services for <see cref="UseProblemDetails"/> to work correctly,
        /// using the default options.
        /// </summary>
        /// <param name="services">The service collection to add the services to.</param>
        /// <param name="environment">The IWebHostEnvironment of the web application.</param>
        public static IServiceCollection AddProblemDetailsExtended(this IServiceCollection services, IWebHostEnvironment environment)
        {
            return services.AddProblemDetails(setup =>
            {
                setup.IncludeExceptionDetails = (ctx, env) => environment.IsDevelopment() || environment.IsStaging();
                setup.Map<ProblemDetailsExtendedException>(exception => new ProblemDetailsExtended
                {
                    Title = exception.Title,
                    Detail = exception.Detail,
                    Status = exception.Status,
                    Type = exception.Type,
                    Instance = exception.Instance,                    
                    Errors = exception.Errors
                });
            });
        }

        /// <summary>
        /// Adds the <see cref="ProblemDetailsMiddleware"/> to the application pipeline.
        /// </summary>
        /// <param name="app">The application builder to add the middleware to.</param>
        /// <exception cref="InvalidOperationException">If <see cref="AddProblemDetails(IServiceCollection)"/> hasn't been called.</exception>
        public static IApplicationBuilder UseProblemDetails(this IApplicationBuilder app)
        {
            return app.UseProblemDetails();            
        }


    }
}
