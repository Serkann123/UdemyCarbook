﻿namespace UdemyCarbook.WebUI.Models
{
    public class JwtTokenModel
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
