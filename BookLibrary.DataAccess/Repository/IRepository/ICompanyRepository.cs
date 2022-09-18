﻿using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository: IRepository<Company>
    {
        void Update(Company obj);
        void Save();
    }
}
