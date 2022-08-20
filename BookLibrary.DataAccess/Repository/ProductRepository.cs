﻿using BookLibrary.DataAccess.Data;
using BookLibrary.DataAccess.Repository.IRepository;
using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.DataAccess.Repository
{
    public class ProductRepository : Repositary<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var objFromDB = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if(objFromDB != null)
            {
                objFromDB.Title = obj.Title;
                objFromDB.ISBN = obj.ISBN;
                objFromDB.FinalPrice = obj.FinalPrice;
                objFromDB.Price50 = obj.Price50;
                objFromDB.ListPrice = obj.ListPrice;
                objFromDB.Price100 = obj.Price100;
                objFromDB.Description = obj.Description;
                objFromDB.CategroyId = obj.CategroyId;
                objFromDB.Author = obj.Author;
                objFromDB.CoverTypeId = obj.CoverTypeId;

                if (obj.ImageUrl != null)
                {
                    objFromDB.ImageUrl = obj.ImageUrl;
                }

            }
        }
    }
}
