using Microsoft.EntityFrameworkCore;
using cursach_3.DATA;
using Microsoft.SqlServer.Server;
using System.Diagnostics.Metrics;


namespace cursach_3.Repository.Migrations
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            new ArticleMap(modelBuilder.Entity<Article_DATA>()); 
            new AuthorMap(modelBuilder.Entity<Author_DATA>());  
            new CommentaryMap(modelBuilder.Entity<Commentary_DATA>()); 
            new File_Archive_DATA_map(modelBuilder.Entity<File_Archive_DATA>()); 
            new PhotoMap(modelBuilder.Entity<Photo_folder_DATA>()); 
            new ThreadMap(modelBuilder.Entity<Thread_DATA>()); 
            new Topic_DATA_map(modelBuilder.Entity<Topic_DATA>()); 
            new UserMap(modelBuilder.Entity<User_DATA>()); 
        }

    }
}
