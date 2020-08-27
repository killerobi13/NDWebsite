using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewDawnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewDawnWeb.Services
{
    public class NewsService
    {
        private SqlDbContext sqlDbContext { get; set; }
        private IConfiguration config { get; set; }
        public NewsService(SqlDbContext sqlDbContext, IConfiguration config)
        {
            this.config = config;
            this.sqlDbContext = sqlDbContext;
        }

        public IEnumerable<News> GetNewsPage(int startIndex)
        {
            return this.sqlDbContext.News.Skip(startIndex).Take(3).Include(t=>t.Publisher).ToList();
        }

        public News GetNews(int id)
        {
            return this.sqlDbContext.News.FirstOrDefault(t => t.Id == id);
        }

        public int GetNewsPagesCount()
        {
            return this.sqlDbContext.News.Count();
        }

    }
}
