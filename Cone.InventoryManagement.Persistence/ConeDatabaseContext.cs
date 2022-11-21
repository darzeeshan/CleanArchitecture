using Cone.InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Persistence
{
    public class ConeDatabaseContext : DbContext
    {
        public ConeDatabaseContext(DbContextOptions<ConeDatabaseContext> options) : base(options)
        {
        }

        public DbSet<tblMapClientConnection> tblMapClientConnection { get; set; }
        public DbSet<tblMapClientFile> tblMapClientFile { get; set; }
        public DbSet<tblMapClientSetup> tblMapClientSetup { get; set; }
    }
}
