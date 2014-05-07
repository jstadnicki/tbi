namespace ToBeImplemented.Infrastructure.Repository
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public interface ITagRepository
    {
        List<Tag> GetTags(List<string> textTags);
    }
}