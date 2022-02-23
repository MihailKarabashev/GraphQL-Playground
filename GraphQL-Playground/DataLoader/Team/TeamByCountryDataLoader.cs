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
    public class TeamByCountryDataLoader : GroupedDataLoader<string, Team>
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

        public TeamByCountryDataLoader (
             IDbContextFactory<AppDbContext> dbContextFactory,
             IBatchScheduler batchScheduler,
             DataLoaderOptions options
            ) : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }
        protected override async Task<ILookup<string, Team>> LoadGroupedBatchAsync(
            IReadOnlyList<string> countries,
            CancellationToken cancellationToken
            )
        {
            await using AppDbContext dbContext = _dbContextFactory.CreateDbContext();

            var list = await dbContext.Teams.Where(x => countries.Contains(x.Country))
                .ToListAsync();

            return list.ToLookup(x => x.Country);
        }
    }
}
