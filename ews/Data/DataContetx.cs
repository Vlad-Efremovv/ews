using ews.Entities;
using Microsoft.EntityFrameworkCore;

namespace ews.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserGroupRole> UserGroupRole { get; set; }
        public DbSet<RoomGroup> RoomGroup { get; set; }
        public DbSet<GroupRole> GroupRole { get; set; }
        public DbSet<RoomBooking> RoomBooking { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<AccessRefreshRelation> AccessRefreshRelation { get; set; }

    }
}
