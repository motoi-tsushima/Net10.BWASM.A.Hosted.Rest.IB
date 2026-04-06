using System.ComponentModel.DataAnnotations;

namespace Shared.Rest.IB.Dtos;

public class IssueCreateDto
{
    [Required(ErrorMessage = "記入者氏名は必須です。")]
    [MaxLength(50, ErrorMessage = "記入者氏名は50文字以内で入力してください。")]
    public string AuthorName { get; set; } = string.Empty;

    [MaxLength(30, ErrorMessage = "カテゴリ名は30文字以内で入力してください。")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "課題タイトルは必須です。")]
    [MaxLength(100, ErrorMessage = "課題タイトルは100文字以内で入力してください。")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "課題の文面は必須です。")]
    [MaxLength(2000, ErrorMessage = "課題の文面は2000文字以内で入力してください。")]
    public string Description { get; set; } = string.Empty;
}
