using System.ComponentModel.DataAnnotations;
using Shared.Rest.IB.Enums;

namespace Shared.Rest.IB.Dtos;

public class IssueUpdateDto
{
    [MaxLength(30, ErrorMessage = "カテゴリ名は30文字以内で入力してください。")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "課題タイトルは必須です。")]
    [MaxLength(100, ErrorMessage = "課題タイトルは100文字以内で入力してください。")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "課題の文面は必須です。")]
    [MaxLength(2000, ErrorMessage = "課題の文面は2000文字以内で入力してください。")]
    public string Description { get; set; } = string.Empty;

    public IssueStatus Status { get; set; }

    [MaxLength(2000, ErrorMessage = "解決の文面は2000文字以内で入力してください。")]
    public string? Resolution { get; set; }

    [MaxLength(50, ErrorMessage = "解決担当者名は50文字以内で入力してください。")]
    public string? ResolverName { get; set; }
}
