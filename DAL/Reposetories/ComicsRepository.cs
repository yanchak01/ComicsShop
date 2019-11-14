using ComicsShop.DAL.Interfaces.IRepo;
using DAL.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Reposetories
{
    public class ComicsRepository:BaseRepository<Comics>,IComicsRepository<Comics>
    {
        private readonly ComicsDbContext _context;
        public ComicsRepository(ComicsDbContext context):base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Comics>> Get()
        {
            var comics = await context.Comicses.Include(comicss => comicss.Authors).ToListAsync();
            return comics;
        }
    }
}
