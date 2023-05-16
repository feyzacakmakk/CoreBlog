﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {
        int GetTotalBlog();
        int GetTotalCategories();
        int GetBlogByWriterId();
    }
}
