﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.RepositoryPattern
{
    public interface IGenericRepository<T>  where T : class
    {
        List<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Remove(T entity);
        Comment GetById(int id);
        List<T> GetCommentsByBlogId(int id);
        int GetCountCommentBlog(int id);
    }
}
