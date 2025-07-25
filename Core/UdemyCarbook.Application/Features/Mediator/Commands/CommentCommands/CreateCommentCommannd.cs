﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommannd:IRequest
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public string Email { get; set; }
    }
}
