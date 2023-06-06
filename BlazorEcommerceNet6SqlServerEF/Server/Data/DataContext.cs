namespace BlazorEcommerceNet6SqlServerEF.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 2,
                    Name = "Movies",
                    Url = "movies"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "vide-games"
                }
                );
            
            

            modelBuilder.Entity<Product>().HasData(
        new Product
        {
            Id = 1,
            Title = "One",
            Description = "One One One One",
            ImageUrl = "https://i.natgeofe.com/n/548467d8-c5f1-4551-9f58-6817a8d2c45e/NationalGeographic_2572187_square.jpg",
            Price = 1.99m,
            CategoryId = 1
        },
        new Product
        {
            Id = 2,
            Title = "Two",
            Description = "Two Two Two Two",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/15/Cat_August_2010-4.jpg",
            Price = 2.99m,
            CategoryId = 1
        },
        new Product
        {
            Id = 3,
            Title = "Three",
            Description = "Three Three Three Three",
            ImageUrl = "https://cdn.britannica.com/39/7139-050-A88818BB/Himalayan-chocolate-point.jpg",
            Price = 3.99m,
            CategoryId = 1
        },
        new Product
        {
            Id = 4,
            Title = "Four",
            Description = "Four Four Four Four",
            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cat_November_2010-1a.jpg/1200px-Cat_November_2010-1a.jpg",
            Price = 2.99m,
            CategoryId = 2
        },
        new Product
        {
            Id = 5,
            Title = "Five",
            Description = "Five Five Five Five",
            ImageUrl = "https://icatcare.org/app/uploads/2018/07/Thinking-of-getting-a-cat.png",
            Price = 2.99m,
            CategoryId = 3
        }

                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
