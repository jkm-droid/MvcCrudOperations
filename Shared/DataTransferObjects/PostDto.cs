using System;

namespace Shared.DataTransferObjects
{
    public record PostDto
    (
        Guid TopicId,
        string Title,
        string Author,
        string Slug
    );
}