﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal avgRentPriceForDaily { get; set; }
        public decimal avgRentPriceForWeekly { get; set; }
        public decimal getAvgRentPriceForMonthly { get; set; }
        public decimal carCountByTranmissionIsAuto { get; set; }
        public decimal carCountByKmSmallerThen1000 { get; set; }
    }
}


