﻿using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly IGenericRepository<Comment> _repository;

    public CommentsController(IGenericRepository<Comment> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
       var value = _repository.GetAll();
        return Ok(value);
    }

    [HttpGet("{id}")]
    public IActionResult GetComment(int id)
    {
        var value = _repository.GetById(id);
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CreateComment(Comment comment)
    {
        _repository.Create(comment);
        return Ok("Yorum başarıyla eklendi");
    }

    [HttpPut]
    public IActionResult UpdateComment(Comment comment)
    {
        _repository.Update(comment);
        return Ok("Yorum başarıyla güncellendi");
    }

    [HttpDelete]
    public IActionResult DeleteComment(int id)
    {
        var value = _repository.GetById(id);
        _repository.Delete(value);
        return Ok("Yorum başarıyla silindi");
    }



}
