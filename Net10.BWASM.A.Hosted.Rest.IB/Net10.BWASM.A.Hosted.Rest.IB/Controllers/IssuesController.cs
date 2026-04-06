using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net10.BWASM.A.Hosted.Rest.IB.Data;
using Net10.BWASM.A.Hosted.Rest.IB.Mapping;
using Shared.Rest.IB.Dtos;

namespace Net10.BWASM.A.Hosted.Rest.IB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IssuesController(IssuesDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IssueDto>>> GetAll()
    {
        var issues = await db.Issues
            .OrderByDescending(i => i.CreatedAt)
            .ToListAsync();
        return Ok(issues.Select(IssueMapper.ToDto));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<IssueDto>> GetById(int id)
    {
        var issue = await db.Issues.FindAsync(id);
        if (issue is null) return NotFound();
        return Ok(IssueMapper.ToDto(issue));
    }

    [HttpPost]
    public async Task<ActionResult<IssueDto>> Create(IssueCreateDto dto)
    {
        var issue = IssueMapper.ToModel(dto);
        db.Issues.Add(issue);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = issue.Id }, IssueMapper.ToDto(issue));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<IssueDto>> Update(int id, IssueUpdateDto dto)
    {
        var issue = await db.Issues.FindAsync(id);
        if (issue is null) return NotFound();
        IssueMapper.ApplyUpdate(issue, dto);
        await db.SaveChangesAsync();
        return Ok(IssueMapper.ToDto(issue));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var issue = await db.Issues.FindAsync(id);
        if (issue is null) return NotFound();
        db.Issues.Remove(issue);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
