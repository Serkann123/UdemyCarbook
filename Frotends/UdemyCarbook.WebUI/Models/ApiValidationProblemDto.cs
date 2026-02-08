using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Validators.Tools
{
    public sealed class ApiValidationProblemDto
    {
        public Dictionary<string, string[]>? Errors { get; set; }
        public string? Title { get; set; }
        public int? Status { get; set; }
    }
}
