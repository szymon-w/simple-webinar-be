using simpleWebinar.Exceptions;
using simpleWebinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Services
{
    public class SampleContextDbService : IDbService
    {
        private readonly SampleDbContext _context;
        public SampleContextDbService(SampleDbContext context)
        {
            _context = context;
        }
        public void sampleMethod()
        {
        }


    }
}
