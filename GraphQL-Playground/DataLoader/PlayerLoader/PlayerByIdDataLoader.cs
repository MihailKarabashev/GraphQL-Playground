using GraphQL_Playground.Data;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.DataLoader.Player
{
    public class PlayerByIdDataLoader : BatchDataLoader<int, Models.Player>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;


        public PlayerByIdDataLoader(
          IDbContextFactory<AppDbContext> dbContextFactory,
          IBatchScheduler batchScheduler,
          DataLoaderOptions options

          ) : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }


        protected override async Task<IReadOnlyDictionary<int, Models.Player>>
            LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using AppDbContext dbContext =
                 _dbContextFactory.CreateDbContext();

            return await dbContext.Players
                .Where(x => keys.Contains(x.Id))
                .Include(x=> x.Team)
                .ToDictionaryAsync(d => d.Id, cancellationToken);
        }
    }
}
