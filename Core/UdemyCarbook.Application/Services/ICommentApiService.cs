using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICommentApiService
    {
        Task<bool> CreateAsync(CreateCommentDto dto);
    }
}
