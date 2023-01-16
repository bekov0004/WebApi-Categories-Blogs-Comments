using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class CommentServices
{
    private string _conectionString = "Server=127.0.0.1;Port=5432;Database=Blog_db;User Id=postgres;Password=2004;";

    public List<Comment> GetComment()
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = "select * from Comments ";
            var result = connection.Query<Comment>(sql);
            return result.ToList();
        }
    }

    public List<Comment> GetCommentById(int id)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql = $"select * from Comments where id = {id}";
            var result = connection.Query<Comment>(sql);
            return result.ToList();
        }
    }

    public void AddComment(Comment comment)
    {
        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =
                $"insert into Comments(Id,CretedBy,CretedAt,Message,Email,ReplyId,BlogId) " +
                $"values " +
                $"({comment.Id},'{comment.CretedBy}','{comment.CretedAt}','{comment.Message}','{comment.Email}',{comment.ReplyId},'{comment.BlogId}')";
            var add = connection.Execute(sql);
            if (add > 0) System.Console.WriteLine("Added");
            else System.Console.WriteLine("Not Added");

        }
    }

    public List<Comment> GetBlogByCategoryId(int id)
    {

        using (var connection = new NpgsqlConnection(_conectionString))
        {
            string sql =
                $" select * from  Comments c " +
                $" join blogs b on b.id = c.BlogId " +
                $" where c.BlogId = {id}";
            var quotes = connection.Query<Comment>(sql);
            return quotes.ToList();
        }
    }
}