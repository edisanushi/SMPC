using Application.Interfaces.Services;
using Domain.Dtos;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TestService(ITestRepository testRepo) : ITestService
    {
        public async Task<List<TestDto>> GetOrganigram()
        {
            var res = await testRepo.GetOrganigram();

            var testDto = res.Select(x => new TestDto { Name = x.Name, dateCreated = x.CreatedOn }).ToList();

            return testDto;
        }
    }
}
