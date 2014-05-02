namespace ToBeImplemented.Tests.ObjectMothers
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;

    public class TagModelFactory
    {
        public static Tag Create()
        {
            var result = new Tag { Text = "test-tag-text", Id = 331 , Concepts = new List<Concept>()};
            return result;
        }
    }
}