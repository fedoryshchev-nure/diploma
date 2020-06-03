using System;
using System.Text;
using AutoMapper;
using Diploma.API.Services.Implemetantions;
using Diploma.API.Services.Interfaces;
using Diploma.Common.Mappings;
using Diploma.Common.Settings;
using Diploma.Data.DAL;
using Diploma.Data.DAL.Seeders;
using Diploma.Data.DAL.UnitOfWork;
using Diploma.Data.DAL.UnitOfWork.Repositories.Implemetantions;
using Diploma.Data.DAL.UnitOfWork.Repositories.Interfaces;
using Diploma.Data.Entities.Main.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Diploma
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
			services.AddCors(options =>
			{
				options.AddPolicy("EnableCORS", builder =>
				{
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
				});
			});
			services.AddControllers();

			#region Settings

			var authOptionsSection = Configuration.GetSection(nameof(AuthOptions));
			var key = Encoding.ASCII.GetBytes(authOptionsSection[nameof(AuthOptions.Secret)]);
			var securityKey = new SymmetricSecurityKey(key);
			services.Configure<AuthOptions>(options =>
			{
				options.Secret = authOptionsSection[nameof(AuthOptions.Secret)];
				options.ExpiresInMinutes = int.Parse(authOptionsSection[nameof(AuthOptions.ExpiresInMinutes)]);
				options.Issuer = authOptionsSection[nameof(AuthOptions.Issuer)];
				options.Audience = authOptionsSection[nameof(AuthOptions.Audience)];
				options.SigningCredentials = new SigningCredentials(
					securityKey,
					SecurityAlgorithms.HmacSha256);
			});

			#endregion

			#region Db
			services.AddDbContext<ApplicationDbContext>(options =>
				options
					.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }))
					.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentityCore<User>(opts =>
			{
				opts.Password.RequireDigit = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequiredLength = 6;

				opts.User.RequireUniqueEmail = true;
			})
				.AddRoles<IdentityRole<Guid>>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<ILessonRepository, LessonRepository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			#endregion

			#region Auth

			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = authOptionsSection[nameof(AuthOptions.Issuer)],

				ValidateAudience = true,
				ValidAudience = authOptionsSection[nameof(AuthOptions.Audience)],

				ValidateIssuerSigningKey = true,
				IssuerSigningKey = securityKey,

				ValidateLifetime = true
			};
			services
				.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.ClaimsIssuer = authOptionsSection[nameof(AuthOptions.Issuer)];
					options.TokenValidationParameters = tokenValidationParameters;
					options.SaveToken = true;
				});

			services.AddScoped<IAuthService, AuthService>();

			#endregion

			#region Mapper

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			#endregion

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager)
		{
			app.UseCors("EnableCORS");

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			UserSeeder.SeedAsync(userManager).Wait();
		}
	}
}
