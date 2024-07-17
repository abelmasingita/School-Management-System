using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataLayerContextFactory : IDesignTimeDbContextFactory<DataLayer>
    {
        public DataLayer CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<DataLayer>();
            var connectionString = "Data Source=Masingita\\SQLEXPRESS;Initial Catalog=School-Management-QA;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connectionString);

            return new DataLayer(optionsBuilder.Options);
        }
    }
}
