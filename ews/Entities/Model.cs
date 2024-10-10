using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ews.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("main_org")]
        public string MainOrg { get; set; }

        [EmailAddress]
        [Column("mail")]
        public string Mail { get; set; }

        [Column("role")]
        public int Role { get; set; } = 0; // роль (user (дефолтное) (0) | admin (1))

        public ICollection<Session> Sessions { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }
        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }

    public class UserGroupRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("room_group_id")]
        public int GroupId { get; set; }

        [Column("user_group_role_id")]
        public int UserRole { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(GroupId))]
        public RoomGroup RoomGroup { get; set; }

        [ForeignKey(nameof(UserRole))]
        public GroupRole GroupRole { get; set; }
    }

    public class RoomGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }

    public class GroupRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ICollection<UserGroupRole> UserGroupRoles { get; set; }
    }

    public class RoomBooking
    {
        [Key]
        [Column("booking_id")]
        public string BookingId { get; set; }

        [Column("t_from")]
        public DateTime TFrom { get; set; } // со скольки

        [Column("t_to")]
        public DateTime TTo { get; set; } // до скольки

        [Column("user_name")]
        public string? UserName { get; set; } // кем занято

        [Column("pair")]
        public string Pair { get; set; } // пара (нет(default)/да)

        [Column("outlook_id")]
        public string OutlookId { get; set; }

        [Column("user_id")]
        public int? UserId { get; set; }

        [Column("room_id")]
        public int RoomId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room? Room { get; set; }
    }

    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("room_id")]
        public int RoomId { get; set; }

        [Column("room_name")]
        public string RoomName { get; set; }

        [EmailAddress]
        [Column("room_mail")]
        [MaxLength(255)]
        public string RoomMail { get; set; } = string.Empty; // уникальный адрес почты комнаты

        [Column("type")]
        public bool Type { get; set; } = true;

        [Column("room_group_id")]
        public int GroupId { get; set; }

        [Column("protection")]
        public bool Protection { get; set; } = false;

        public ICollection<Favorite> Favorites { get; set; }
        public ICollection<RoomBooking> RoomBookings { get; set; }

        [ForeignKey(nameof(GroupId))]
        public RoomGroup RoomGroup { get; set; }
    }

    public class Favorite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("room_id")]
        public int RoomId { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }
    }

    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("session_id")]
        public int SessionId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("last_active")]
        public DateTime LastActive { get; set; } = DateTime.Now;

        [Column("is_active")]
        public bool IsActive { get; set; } = true;

        [Column("token_id")]
        public int? TokenId { get; set; }

        [ForeignKey(nameof(TokenId))]
        public AccessRefreshRelation? Token { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }

    public class AccessRefreshRelation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("token_id")]
        public int TokenId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("access_token")]
        public string? AccessToken { get; set; }

        [Column("refresh_token")]
        public string? RefreshToken { get; set; }

        public Session? Session { get; set; }
    }
}
