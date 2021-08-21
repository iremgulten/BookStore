using System.Text;
using BookStore.API.Middleware;
using BookStore.Business.Mapper;
using BookStore.Business.Services.Abstract;
using BookStore.Business.Services.Concrete;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.DataAccess.Repositories.Concrete;
using BookStore.Entities.UserIdentityEntities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BookStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<BookService>());
            
            services.AddAutoMapper(typeof(MappingProfile));
            
            services.AddDbContext<BookStoreContext>(option => option.UseSqlServer("Server=(localdb)\\Mssqllocaldb;Database=BookStore;Trusted_Connection=True;"));

            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<BookStoreContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IBooksService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IUserFavBookService, UserFavBookService>();


            services.AddScoped<IBooksRepository, EFBooksRepository>();
            services.AddScoped<IGenreRepository, EFGenreRepository>();
            services.AddScoped<IAuthorRepository, EFAuthorRepository>();
            services.AddScoped<IPublisherRepository, EFPublisherRepository>();
            services.AddScoped<IUserFavBookRepository, EFUserFavBookRepository>();


            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
               });

            var issuer = Configuration.GetSection("Bearer")["Issuer"];
            var audience = Configuration.GetSection("Bearer")["Audience"];
            var key = Configuration.GetSection("Bearer")["SecurityKey"];

            services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateActor = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = issuer,
                            ValidAudience = audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                        };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<RequestResponseMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opt => opt.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

          //  app.UseExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
