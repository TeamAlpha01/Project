using Microsoft.AspNetCore.Identity.EntityFrameworkCore;  
using Microsoft.EntityFrameworkCore; 


namespace JWTAuthentication.Authentication  
{  
    public class IMSAuthenticationDbContext : IdentityDbContext<IMSAuthentication>
    {  
        public IMSAuthenticationDbContext(DbContextOptions<IMSAuthenticationDbContext> options) : base(options)  
        {  
  
        }  
        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }  
    }  
}