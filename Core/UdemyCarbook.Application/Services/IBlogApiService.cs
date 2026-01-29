using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IBlogApiService
    {
        Task<List<ResultBlogsAllWithAuthorDto>> GetBlogsAllWithAuthorsAsync();
        Task<bool> RemoveAsync(int id);
    }
}
