﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
       public List<Review> GetReviewByCarId(int carId);
    }
}
