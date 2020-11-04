using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpringYCBlogs.Infrastructure.Concrete;

namespace SpringYCBlogs.Infrastructure.Repository
{

    public interface IArticleRepository : IRepository<Domain.Models.Article, Guid>
    {

    }
    public class ArticleRepository : RepositoryBase<Domain.Models.Article, Guid>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {

        }
    }

}
