using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Validators.Tools
{
    public sealed class ApiValidationProblem
    {
        public Dictionary<string, string[]>? Errors { get; set; }
        public string? Title { get; set; }
        public int? Status { get; set; }
    }
}
