using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicRecordsREST.Models;

namespace MusicRecordsREST
{
    public class MusicRecordContext : DbContext
    {
        public MusicRecordContext(DbContextOptions<MusicRecordContext> options) : base(options)
        {}
        public DbSet<MusicRecordsData> MusicRecords { get; set; }

        public static readonly string ConnectionString = "Server=tcp:musicrecordsserver.database.windows.net,1433;Initial Catalog=MusicRecordsDB;Persist Security Info=False;User ID=KevinMalthe;Password=Sutminklit123;";

    }
}
