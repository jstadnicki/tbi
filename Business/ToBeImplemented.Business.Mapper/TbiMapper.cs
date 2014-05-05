namespace ToBeImplemented.Business.Mapper
{
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.ViewModel;
    using System.Linq;

    public class TbiMapper
    {
        public static void Initialize()
        {
            Concept2ConceptViewModel();
            User2AuthorViewModel();
            Tag2TagViewModel();
            Comment2CommentViewModel();
            AddConceptViewModel2Concept();
            Concept2EditConceptViewModel();
            Tag2String();
            ListOfTags2StringSemicolonSeparated();
        }

        private static void ListOfTags2StringSemicolonSeparated()
        {
            AutoMapper.Mapper.CreateMap<List<Tag>, string>()
                .ConstructUsing(l => string.Join(";", l.Select(t => t.Text)));
        }

        private static void Tag2String()
        {
            AutoMapper.Mapper.CreateMap<Tag, string>()
                .ConstructUsing(s => s.Text);
        }

        private static void Concept2EditConceptViewModel()
        {
            AutoMapper.Mapper.CreateMap<Concept, EditConceptViewModel>();
        }

        private static void AddConceptViewModel2Concept()
        {
            AutoMapper.Mapper.CreateMap<AddConceptViewModel, Concept>()
                .ForMember(d => d.Comments, o => o.UseValue(new List<Comment>()));
        }

        private static void Comment2CommentViewModel()
        {
            AutoMapper.Mapper.CreateMap<Comment, CommentViewModel>();
        }

        private static void Tag2TagViewModel()
        {
            AutoMapper.Mapper.CreateMap<Tag, TagViewModel>();
        }

        private static void User2AuthorViewModel()
        {
            AutoMapper.Mapper.CreateMap<User, AuthorViewModel>();
        }

        private static void Concept2ConceptViewModel()
        {
            AutoMapper.Mapper.CreateMap<Concept, ConceptViewModel>();
        }
    }
}