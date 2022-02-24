using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using GreenDonut;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.GraphQL.Teams
{
    public class TeamByIdDataLoader : BatchDataLoader<int, Team>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public TeamByIdDataLoader(
            IDbContextFactory<AppDbContext> dbContextFactory,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
            
            ): base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<int, Team>> LoadBatchAsync(
            IReadOnlyList<int> keys,
            CancellationToken cancellationToken)
        {
            await using AppDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Teams
                .Where(x => keys.Contains(x.Id))
                .Include(x=> x.Players)
                .ToDictionaryAsync(d => d.Id, cancellationToken);
        }
    }
}
