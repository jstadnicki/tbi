namespace ToBeImplemented.Business.Mapper
{
    using System;
    using System.Collections.Generic;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;
    using ToBeImplemented.Domain.ViewModel;
    using System.Linq;

    using ToBeImplemented.Domain.ViewModel.Concepts;
    using ToBeImplemented.Domain.ViewModel.Users;

    public class TbiMapper
    {
        public static void Initialize()
        {
            Concept2ConceptViewModel();
            User2AuthorViewModel();
            Tag2TagViewModel();
            Comment2CommentViewModel();
            Concept2EditConceptViewModel();
            Tag2String();
            ListOfTags2StringSemicolonSeparated();
            UpdateConceptViewModel2UpdateConcept();
            StringOfSemicolonSeparated2ListOfStrings();
            AddConceptViewModel2AddConcept();
            RegisterUserViewModel2RegisterUser();
            RegisterUser2User();
            User2UserProfileViewModel();
        }

        private static void User2UserProfileViewModel()
        {
            AutoMapper.Mapper.CreateMap<User, UserProfileViewModel>();
        }

        private static void RegisterUser2User()
        {
            AutoMapper.Mapper.CreateMap<RegisterUser, User>().ForMember(x => x.Id, o => o.UseValue(0));
        }

        private static void RegisterUserViewModel2RegisterUser()
        {
            AutoMapper.Mapper.CreateMap<RegisterUserViewModel, RegisterUser>()
                .ForMember(x => x.PasswordHash, o => o.UseValue(string.Empty));
        }

        private static void AddConceptViewModel2AddConcept()
        {
            AutoMapper.Mapper.CreateMap<AddConceptViewModel, AddConcept>()
                .ForMember(x => x.Tags, o => o.NullSubstitute(new List<string>()));
        }

        private static void StringOfSemicolonSeparated2ListOfStrings()
        {
            AutoMapper.Mapper.CreateMap<string, List<string>>()
                .ConvertUsing(s => s.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList());
        }

        private static void UpdateConceptViewModel2UpdateConcept()
        {
            AutoMapper.Mapper.CreateMap<UpdateConceptViewModel, UpdateConcept>()
                .ForMember(d => d.Tags, o => o.NullSubstitute(new List<Tag>()));
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
            AutoMapper.Mapper.CreateMap<Concept, UpdateConceptViewModel>();
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