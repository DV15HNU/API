using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace apicomp2001.Models
{
    public class DataAccess : DbContext
    {
        private readonly string _Connection;
        public DbSet<Programmes> Programmes { get; set; }
        public DataAccess(DbContextOptions<DataAccess> options) : base(options)
        {
            _Connection = Database.GetConnectionString();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Programmes>()
                .ToView(nameof(Programmes))
                .HasKey(t => t.Progcode);
        }
        public void Create(Programmes P)
        {
            using (SqlConnection sql = new SqlConnection(_Connection))
            {
                //parameters bla bla bla
            }
        }

        public void Update(Programmes P, int programmeid)
        {
            using (SqlConnection sql = new SqlConnection(_Connection))
            {
                using (SqlCommand cmd = new SqlCommand("CW2.Update_Programme", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Programme_Code", programmeid));
                    cmd.Parameters.Add(new SqlParameter("@Title", P.Progname));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int programmeid)
        {
            using (SqlConnection sql = new SqlConnection(_Connection))
            {
                using (SqlCommand cmd = new SqlCommand("CW2.Delete_Programme", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Programme_Code", programmeid));
                    sql.Open();
                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
