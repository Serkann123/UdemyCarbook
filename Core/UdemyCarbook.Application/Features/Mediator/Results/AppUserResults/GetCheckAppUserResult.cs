using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Results.AppUserResults
{
    public class GetCheckAppUserResult
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsExist { get; set; }
    }
}
