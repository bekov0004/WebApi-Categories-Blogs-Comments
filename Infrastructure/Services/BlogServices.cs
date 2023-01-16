using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class BlogServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=Blog_db;User Id=postgres;Password=2004;";

    public List<Blog> GetBlog()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = "select * from Blogs ";
            var result = connection.Query<Blog>(sql);
            return result.ToList();
        }
    }
    
    public List<Blog> GetBlogsById(int id)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select * from Blogs where id = {id}";
            var result = connection.Query<Blog>(sql);
            return result.ToList();
        }
    }
    
    public void AddBlogs(Blog blog)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =
                $"insert into Blogs(Id,Title,Image,CreateDate,UserId,CategoryId,Content) " +
                $"values " +
                $"({blog.Id},'{blog.Title}','{blog.Image}','{blog.CreateDate}',{blog.UserId},{blog.CategoryId},'{blog.Content}')";
            var add = connection.Execute(sql);
            if (add>0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");

        }
    }
    
    public void UpdateBlog(Blog blog)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =  
                $" update Blogs "+
                $" set  Title = '{blog.Title}',Image = '{blog.Image}',CreateDate = '{blog.CreateDate}',UserId = {blog.UserId},CategoryId = {blog.CategoryId},Content = '{blog.Content}'"+
                $" where id = {blog.Id}";
            var update = connection.Execute(sql);
            if (update>0) System.Console.WriteLine("Updated");
            else System.Console.WriteLine("Not Updaated");

        }
    }
    
    public void DeleteBlog(int id)
    {
        using(var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"delete from Blogs where id = {id} ";
            var delete = connection.Execute(sql);
            if (delete>0) System.Console.WriteLine("Deleted");
            else System.Console.WriteLine("Not Removed");
        }
    }
    
    public List<Blog> GetBlogByCategoryId(int id)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = 
                $" select "+
                $" b.Id, "+
                $" b.Title, "+
                $" b.Image, "+
                $" b.CreateDate, "+
                $" b.UserId, "+
                $" b.CategoryId, "+
                $" b.Content, "+
                $" c.Title "+
                $" from Blogs b "+
                $" join Categories c on c.id = b.CategoryId " +
                $" where b.CategoryId = {id}";
            var quotes = connection.Query<Blog>(sql);
            return quotes.ToList();
        }
    }
    
    /*
1.Get
2.GetById
3.GetByCategoryId
4.Add
5.Update
6.Delete
     */
}