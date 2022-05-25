using System;

namespace Shared.DataTransferObjects
{
    public record CategoryDto
    (
        Guid CategoryId,
        string Title,
        string Author
    );
}