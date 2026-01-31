using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
       Task<List<TagCloud>> GetTagCloudByBlogIdAsync(int id);
    }
}
