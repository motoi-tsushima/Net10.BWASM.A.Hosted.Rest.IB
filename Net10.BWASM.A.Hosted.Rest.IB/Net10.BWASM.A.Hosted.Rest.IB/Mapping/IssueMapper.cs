using Net10.BWASM.A.Hosted.Rest.IB.Models;
using Shared.Rest.IB.Dtos;
using Shared.Rest.IB.Enums;

namespace Net10.BWASM.A.Hosted.Rest.IB.Mapping;

public static class IssueMapper
{
    public static IssueDto ToDto(Issue issue) => new()
    {
        Id = issue.Id,
        AuthorName = issue.AuthorName,
        CreatedAt = issue.CreatedAt,
        Category = issue.Category,
        Title = issue.Title,
        Description = issue.Description,
        Status = (IssueStatus)issue.Status,
        Resolution = issue.Resolution,
        ResolverName = issue.ResolverName,
        ResolvedAt = issue.ResolvedAt
    };

    public static Issue ToModel(IssueCreateDto dto) => new()
    {
        AuthorName = dto.AuthorName,
        CreatedAt = DateTime.Now,
        Category = string.IsNullOrWhiteSpace(dto.Category) ? null : dto.Category,
        Title = dto.Title,
        Description = dto.Description,
        Status = (int)IssueStatus.NotStarted
    };

    public static void ApplyUpdate(Issue issue, IssueUpdateDto dto)
    {
        issue.Category = string.IsNullOrWhiteSpace(dto.Category) ? null : dto.Category;
        issue.Title = dto.Title;
        issue.Description = dto.Description;
        issue.Status = (int)dto.Status;
        issue.Resolution = string.IsNullOrWhiteSpace(dto.Resolution) ? null : dto.Resolution;
        issue.ResolverName = string.IsNullOrWhiteSpace(dto.ResolverName) ? null : dto.ResolverName;

        if (dto.Status == IssueStatus.Resolved)
        {
            issue.ResolvedAt ??= DateTime.Now;
        }
        else
        {
            issue.ResolvedAt = null;
        }
    }
}
