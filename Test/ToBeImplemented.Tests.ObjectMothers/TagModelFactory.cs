namespace ToBeImplemented.Tests.ObjectMothers
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public class TagModelFactory
    {
        public static Tag Create(long id = 3, string text = "test-tag-text")
        {
            var result = new Tag { Text = text, Id = id, Concepts = new List<Concept>() };
            return result;
        }
    }
}