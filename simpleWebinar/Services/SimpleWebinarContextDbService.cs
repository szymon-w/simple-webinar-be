using simpleWebinar.Exceptions;
using simpleWebinar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Services
{
    public class SimpleWebinarContextDbService : IDbService
    {
        private readonly SimpleWebinarDbContext _context;
        public SimpleWebinarContextDbService(SimpleWebinarDbContext context)
        {
            _context = context;
        }
        public void sampleMethod()
        {
        }


    }
}
