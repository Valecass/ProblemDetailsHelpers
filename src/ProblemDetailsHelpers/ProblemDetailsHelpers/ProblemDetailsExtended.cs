using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemDetailsHelpers
{
    public class ProblemDetailsExtended : ProblemDetails
    {
        /// <summary>
        /// Gets the validation errors associated with this instance of <see cref="ProblemDetailsException"/>.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>(StringComparer.Ordinal);
    }
}
