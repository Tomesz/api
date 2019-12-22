using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace pizza.Models
{
    public partial class pizza_dbContext : DbContext
    {
        public pizza_dbContext()
        {
        }

        public pizza_dbContext(DbContextOptions<pizza_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Additions> Additions { get; set; }
        public virtual DbSet<AddressHist> AddressHist { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Deliverers> Deliverers { get; set; }
        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<Drinks> Drinks { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<OrderHist> OrderHist { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentHist> PaymentHist { get; set; }
        public virtual DbSet<PaymentStatuses> PaymentStatuses { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<PersonHist> PersonHist { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Pizzas> Pizzas { get; set; }

        // Unable to generate entity type for table 'dbo.orderred_additions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.orderred_drinks'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.recieps'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.client_adresses'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=pizza_db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Additions>(entity =>
            {
                entity.HasKey(e => e.AdditionId)
                    .HasName("additions_pk");

                entity.ToTable("additions");

                entity.Property(e => e.AdditionId)
                    .HasColumnName("addition_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<AddressHist>(entity =>
            {
                entity.HasKey(e => new { e.EndorseNo, e.AddressId })
                    .HasName("address_hist_pk");

                entity.ToTable("address_hist");

                entity.Property(e => e.EndorseNo).HasColumnName("endorse_no");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlatNo).HasColumnName("flat_no");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasColumnName("post_code")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNo).HasColumnName("street_no");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("addresses_pk");

                entity.ToTable("addresses");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.FlatNo).HasColumnName("flat_no");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasColumnName("post_code")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.StreetNo).HasColumnName("street_no");
            });

            modelBuilder.Entity<Deliverers>(entity =>
            {
                entity.HasKey(e => e.DelivererId)
                    .HasName("deliverers_pk");

                entity.ToTable("deliverers");

                entity.Property(e => e.DelivererId)
                    .HasColumnName("deliverer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.HiredFrom)
                    .HasColumnName("hired_from")
                    .HasColumnType("date");

                entity.Property(e => e.HiredTo)
                    .HasColumnName("hired_to")
                    .HasColumnType("date");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasColumnType("numeric(2, 2)");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Deliverers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deliverers_persons_fk");
            });

            modelBuilder.Entity<Deliveries>(entity =>
            {
                entity.HasKey(e => e.DeliveryId)
                    .HasName("deliveries_pk");

                entity.ToTable("deliveries");

                entity.Property(e => e.DeliveryId)
                    .HasColumnName("delivery_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.DelivererId).HasColumnName("deliverer_id");

                entity.Property(e => e.DeliveyDate)
                    .HasColumnName("delivey_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deliveries_addresses_fk");

                entity.HasOne(d => d.Deliverer)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.DelivererId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("deliveries_deliverers_fk");
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.HasKey(e => e.DiscountId)
                    .HasName("discounts_pk");

                entity.ToTable("discounts");

                entity.Property(e => e.DiscountId)
                    .HasColumnName("discount_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DiscoutPerc).HasColumnName("discout_perc");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Drinks>(entity =>
            {
                entity.HasKey(e => e.DrinkId)
                    .HasName("drinks_pk");

                entity.ToTable("drinks");

                entity.Property(e => e.DrinkId)
                    .HasColumnName("drink_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("ingredients_pk");

                entity.ToTable("ingredients");

                entity.Property(e => e.IngredientId)
                    .HasColumnName("ingredient_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Available).HasColumnName("available");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(3, 2)");
            });

            modelBuilder.Entity<OrderHist>(entity =>
            {
                entity.HasKey(e => new { e.EndorseNo, e.OrderId })
                    .HasName("order_hist_pk");

                entity.ToTable("order_hist");

                entity.Property(e => e.EndorseNo).HasColumnName("endorse_no");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");

                entity.Property(e => e.DiscountId).HasColumnName("discount_id");

                entity.Property(e => e.PaymentsPaymentId).HasColumnName("payments_payment_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");
            });

            modelBuilder.Entity<OrderStatuses>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("order_statuses_pk");

                entity.ToTable("order_statuses");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusDesc)
                    .IsRequired()
                    .HasColumnName("status_desc")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("orders_pk");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");

                entity.Property(e => e.DiscountId).HasColumnName("discount_id");

                entity.Property(e => e.PaymentsPaymentId).HasColumnName("payments_payment_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.PizzaId).HasColumnName("pizza_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(4, 2)");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("status_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_deliveries_fk");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("orders_discounts_fk");

                entity.HasOne(d => d.PaymentsPayment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentsPaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_payments_fk");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_persons_fk");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_pizzas_fk");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_statuses_fk");
            });

            modelBuilder.Entity<PaymentHist>(entity =>
            {
                entity.HasKey(e => new { e.EndorseNo, e.PaymentId })
                    .HasName("payment_hist_pk");

                entity.ToTable("payment_hist");

                entity.Property(e => e.EndorseNo).HasColumnName("endorse_no");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.PaystatusId).HasColumnName("paystatus_id");

                entity.Property(e => e.PaytypeId).HasColumnName("paytype_id");
            });

            modelBuilder.Entity<PaymentStatuses>(entity =>
            {
                entity.HasKey(e => e.PaystatusId)
                    .HasName("payment_statuses_pk");

                entity.ToTable("payment_statuses");

                entity.Property(e => e.PaystatusId)
                    .HasColumnName("paystatus_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusDesc)
                    .IsRequired()
                    .HasColumnName("status_desc")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.HasKey(e => e.PaytypeId)
                    .HasName("payment_types_pk");

                entity.ToTable("payment_types");

                entity.Property(e => e.PaytypeId)
                    .HasColumnName("paytype_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeDesc)
                    .IsRequired()
                    .HasColumnName("type_desc")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("payments_pk");

                entity.ToTable("payments");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PaystatusId).HasColumnName("paystatus_id");

                entity.Property(e => e.PaytypeId).HasColumnName("paytype_id");

                entity.Property(e => e.StatusDate)
                    .HasColumnName("status_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Paystatus)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaystatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_statuses_fk");

                entity.HasOne(d => d.Paytype)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaytypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payment_types_fk");
            });

            modelBuilder.Entity<PersonHist>(entity =>
            {
                entity.HasKey(e => new { e.EndorseNo, e.PersonId })
                    .HasName("person_hist_pk");

                entity.ToTable("person_hist");

                entity.Property(e => e.EndorseNo).HasColumnName("endorse_no");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Forenames)
                    .IsRequired()
                    .HasColumnName("forenames")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.PersonId)
                    .HasName("persons_pk");

                entity.ToTable("persons");

                entity.Property(e => e.PersonId)
                    .HasColumnName("person_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateModified)
                    .HasColumnName("date_modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Forenames)
                    .IsRequired()
                    .HasColumnName("forenames")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pizzas>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("pizzas_pk");

                entity.ToTable("pizzas");

                entity.Property(e => e.PizzaId)
                    .HasColumnName("pizza_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaDesc)
                    .IsRequired()
                    .HasColumnName("pizza_desc")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(5, 2)");
            });
        }
    }
}
