using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public class FueverDbContext(DbContextOptions<FueverDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Promotion> Promotions { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<OldBooking> OldBookings { get; set; }
    public DbSet<ChatMessage> ChatMessages { get; set; }
    public DbSet<OldChatMessage> OldChatMessages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationToUser> NotificationToUsers { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<StepsTracking> StepsTrackings { get; set; }
    public DbSet<TrackingAttachment> TrackingAttachments { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<FeedbackReply> FeedbackReplies { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<StorePayment> StorePayments { get; set; }
    public DbSet<PayoutManagement> PayoutManagements { get; set; }
    public DbSet<RegularDay> RegularDays { get; set; }
    public DbSet<OffDay> OffDays { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Khóa chính phức hợp
        builder.Entity<OrderItem>()
            .HasKey(oi => new { oi.OrderID, oi.ProductID });

        builder.Entity<NotificationToUser>()
            .HasKey(ntu => new { ntu.UserID, ntu.NotificationID });

        builder.Entity<CartItem>()
            .HasKey(ci => new { ci.CartID, ci.ProductID });

        // Định nghĩa mối quan hệ cho CartItems với hành vi ON DELETE NO ACTION
        builder.Entity<CartItem>()
            .HasOne(ci => ci.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(ci => ci.ProductID)
            .OnDelete(DeleteBehavior.Restrict); // Thay đổi từ CASCADE sang NO ACTION

        builder.Entity<CartItem>()
            .HasOne(ci => ci.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(ci => ci.CartID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<OrderItem>()
.HasOne(oi => oi.Product)
.WithMany(p => p.OrderItems)
.HasForeignKey(oi => oi.ProductID)
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Booking>()
.HasOne(b => b.Service)  // Một Booking có một Service
.WithMany(s => s.Bookings)  // Một Service có nhiều Bookings
.HasForeignKey(b => b.ServiceID)  // Khóa ngoại là ServiceID trong Booking
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Booking>()
.HasOne(b => b.Store)  // Một Booking thuộc về một Store
.WithMany(s => s.Bookings)  // Một Store có thể có nhiều Booking
.HasForeignKey(b => b.StoreID)  // Khóa ngoại là StoreID trong Booking
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<OldBooking>()
.HasOne(ob => ob.Service)  // Một OldBooking thuộc về một Service
.WithMany()  // Service không có OldBookings (do không có mối quan hệ 2 chiều)
.HasForeignKey(ob => ob.ServiceID)  // Khóa ngoại trong OldBooking
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<OldBooking>()
.HasOne(ob => ob.Store)  // Một OldBooking thuộc về một Service
.WithMany()  // Service không có OldBookings (do không có mối quan hệ 2 chiều)
.HasForeignKey(ob => ob.StoreID)  // Khóa ngoại trong OldBooking
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ChatMessage>()
.HasOne(cm => cm.FromUser)  // Một ChatMessage thuộc về một User
.WithMany()  // Một User có thể có nhiều ChatMessages
.HasForeignKey(cm => cm.FromUserID)  // Khóa ngoại UserID trong ChatMessage
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ChatMessage>()
.HasOne(cm => cm.ToUser)  // Một ChatMessage thuộc về một User
.WithMany()  // Một User có thể có nhiều ChatMessages
.HasForeignKey(cm => cm.ToUserID)  // Khóa ngoại UserID trong ChatMessage
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<OldChatMessage>()
.HasOne(cm => cm.FromUser)  // Một ChatMessage thuộc về một User
.WithMany()  // Một User có thể có nhiều ChatMessages
.HasForeignKey(cm => cm.FromUserID)  // Khóa ngoại UserID trong ChatMessage
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<OldChatMessage>()
.HasOne(cm => cm.ToUser)  // Một ChatMessage thuộc về một User
.WithMany()  // Một User có thể có nhiều ChatMessages
.HasForeignKey(cm => cm.ToUserID)  // Khóa ngoại UserID trong ChatMessage
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Transaction>()
.HasOne(oi => oi.Store)
.WithMany(p => p.Transactions)
.HasForeignKey(oi => oi.StoreID)
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<StepsTracking>()
.HasOne(oi => oi.Booking)
.WithMany(p => p.StepsTrackings)
.HasForeignKey(oi => oi.BookingID)
.OnDelete(DeleteBehavior.Restrict);

        builder.Entity<StepsTracking>()
.HasOne(oi => oi.Step)
.WithMany(p => p.StepsTrackings)
.HasForeignKey(oi => oi.StepID)
.OnDelete(DeleteBehavior.Restrict);

        // Ràng buộc CHECK và cấu hình decimal cho Promotion
        builder.Entity<Promotion>()
            .ToTable("Promotions", t => t.HasCheckConstraint("CK_Promotion_EndDate", "EndDate > StartDate"))
            .Property(p => p.PromotionValue).HasPrecision(10, 2);
        builder.Entity<Promotion>().Property(p => p.MinPriceToApply).HasPrecision(18, 2);

        // Ràng buộc CHECK và cấu hình decimal cho Order (tách rõ ràng)
        builder.Entity<Order>()
            .ToTable("Orders", t =>
            {
                t.HasCheckConstraint("CK_Order_TotalAmount", "TotalAmount >= 0");
                t.HasCheckConstraint("CK_Order_ShippingFee", "ShippingFee >= 0");
            })
            .Property(o => o.TotalAmount).HasPrecision(18, 2);
        builder.Entity<Order>()
            .Property(o => o.ShippingFee).HasPrecision(18, 2);

        // Ràng buộc CHECK và cấu hình decimal cho OrderItem
        builder.Entity<OrderItem>()
            .ToTable("OrderItems", t =>
            {
                t.HasCheckConstraint("CK_OrderItem_Quantity", "Quantity > 0");
                t.HasCheckConstraint("CK_OrderItem_UnitPrice", "UnitPrice >= 0");
            })
            .Property(oi => oi.UnitPrice).HasPrecision(18, 2);

        // Ràng buộc CHECK và cấu hình decimal cho Feedback
        builder.Entity<Feedback>()
            .ToTable("Feedbacks", t => t.HasCheckConstraint("CK_Feedback_Rating", "Rating BETWEEN 1 AND 5"))
            .Property(f => f.Rating).HasPrecision(10, 2);

        // Cấu hình decimal cho Booking
        builder.Entity<Booking>()
            .Property(b => b.TotalPrice).HasPrecision(18, 2);
        builder.Entity<Booking>()
            .Property(b => b.FinalPrice).HasPrecision(18, 2);

        // Cấu hình decimal cho Transaction
        builder.Entity<Transaction>()
            .Property(t => t.Amount).HasPrecision(18, 2);

        // Cấu hình decimal cho PayoutManagement
        builder.Entity<PayoutManagement>()
            .Property(pm => pm.Amount).HasPrecision(18, 2);
        builder.Entity<PayoutManagement>()
            .Property(pm => pm.FeeDeducted).HasPrecision(18, 2);

        // Cấu hình decimal cho Service
        builder.Entity<Service>()
            .Property(s => s.Price).HasPrecision(18, 2);

        // Cấu hình decimal cho Pet
        builder.Entity<Pet>()
            .Property(p => p.Weight).HasPrecision(18, 2);

        // Ràng buộc CHECK cho ApplicationUser.Status
        builder.Entity<ApplicationUser>()
            .ToTable("AspNetUsers", t => t.HasCheckConstraint("CK_User_Status", "[Status] IN ('active', 'suspended', 'banned')"))
            .Property(u => u.Status)
            .HasDefaultValue("active")
            .IsRequired();

        //// Seed Data
        //var hasher = new PasswordHasher<ApplicationUser>();

        // Định nghĩa 5 Role
        //var petOwnerRoleId = new Guid("59883a7c-3da6-4f71-8c8f-151172b9b022");
        //var storeOwnerRoleId = new Guid("192d8418-4906-4144-9d58-c5793b1b49c1");
        //var adminRoleId = new Guid("3f4d2468-1183-4e62-a672-84d587aa685a");
        //var staffRoleId = new Guid("ba979ae0-4f4b-4c0d-b47c-06aa2cb5c6dd");
        //var employeeRoleId = new Guid("883be1c0-8b64-4d8b-a4a5-eb0c1e235cea");

        //builder.Entity<IdentityRole<Guid>>().HasData(
        //    new IdentityRole<Guid> { Id = petOwnerRoleId, Name = "PetOwner", NormalizedName = "PETOWNER" },
        //    new IdentityRole<Guid> { Id = storeOwnerRoleId, Name = "StoreOwner", NormalizedName = "STOREOWNER" },
        //    new IdentityRole<Guid> { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
        //    new IdentityRole<Guid> { Id = staffRoleId, Name = "Staff", NormalizedName = "STAFF" },
        //    new IdentityRole<Guid> { Id = employeeRoleId, Name = "Employee", NormalizedName = "EMPLOYEE" }
        //);

        // Seed 1 User Admin
        //var admin = new ApplicationUser
        //{
        //    Id = new Guid("ffd97517-d4bb-44e9-9adb-11004e7f5f4a"),
        //    UserName = "admin",
        //    NormalizedUserName = "ADMIN1",
        //    Email = "admin@gmail.com",
        //    NormalizedEmail = "ADMIN1@GMAIL.COM",
        //    Gmail = "admin@gmail.com",
        //    ProfileImage = "admin.jpg",
        //    Phone = "0968890351",
        //    DateOfBirth = new DateTime(1980, 3, 15),
        //    Address = "789 Admin Rd",
        //    RegistrationDate = new DateTime(2025, 3, 16, 13, 9, 58, 415),
        //    Status = "active"
        //};

        //admin.PasswordHash = hasher.HashPassword(admin, "Admin@123");
        //builder.Entity<ApplicationUser>().HasData(admin);

        // Gán Role Admin cho User Admin
        //builder.Entity<IdentityUserRole<Guid>>().HasData(
        //new IdentityUserRole<Guid> { UserId = admin.Id, RoleId = adminRoleId }
        //);
    }
}