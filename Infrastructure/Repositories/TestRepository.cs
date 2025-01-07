using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TestRepository(SmpcDbContext context): ITestRepository
    {
        public async Task<List<SmpcOrganigram>> GetOrganigram()
        {
            var org = await context.SmpcOrganigrams.ToListAsync();
            return org;
        }
    }
}
