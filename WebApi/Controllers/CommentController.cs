using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentController
{
    private CommentServices _commentServices;

    public CommentController()
    {
        _commentServices = new CommentServices();
    }
    
    [HttpGet("GetComment")]
    public List<Comment> GetComment()
    {
        return _commentServices.GetComment();
    }
    
    [HttpGet("GetCommentById")]
    public List<Comment> GetCommentById(int id)
    {
        return _commentServices.GetCommentById(id);
    }
    [HttpGet("GetCommentByCategoryId")]
    public List<Comment> GetCommentByCategoryId(int id)
    {
        return _commentServices.GetBlogByCategoryId(id);
    }
    
    [HttpPost("AddComment")]
    public void AddComment(Comment comment)
    {
        _commentServices.AddComment(comment);
    }
    
    
}