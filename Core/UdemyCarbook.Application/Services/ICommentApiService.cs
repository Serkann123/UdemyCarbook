using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.BlogDtos;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICommentApiService
    {

        Task<List<ResultCommentDto>> GetAllAsync();
        Task<List<ResultCommentDto>> GetByBlogIdAsync(int id);
        Task<bool> CreateAsync(CreateCommentDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
