namespace ToBeImplemented.Infrastructure.EFContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using ToBeImplemented.Domain.Model;
    using ToBeImplemented.Domain.Model.Users;

    internal sealed class Configuration : DbMigrationsConfiguration<ToBeImplemented.Infrastructure.EFContext.TbiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToBeImplemented.Infrastructure.EFContext.TbiContext context)
        {
            context.Database.Delete();
            context.Database.Create();

            var t1 = new Tag { Text = "qwe" };
            var t2 = new Tag { Text = "lol" };
            var t3 = new Tag { Text = "zxc" };
            var t4 = new Tag { Text = "d" };
            var t5 = new Tag { Text = "flaksj fdoi" };
            var t6 = new Tag { Text = "poi098 da" };
            var t7 = new Tag { Text = "asdasd fdoi" };
            var t8 = new Tag { Text = "a asd j fdoi" };

            context.Tags.AddOrUpdate(tg => tg.Id, t1, t2, t3, t4, t5, t6, t7, t8);
            context.SaveChanges();

            var user = new User
                               {
                                   Comments = new List<Comment>(),
                                   Concepts = new List<Concept>(),
                                   DisplayName = "FancyLogin4A",
                                   Email = "user@email.com",
                                   UserName = "test-login",
                                   PasswordHash = "test-password-hash",
                                   UserConceptVotes = new List<UserConceptVote>(),
                                   RegisterDateTime = DateTime.Now,
                                   LastLoginDateTime = DateTime.Now
                               };

            context.Users.AddOrUpdate(x => x.Id, user);
            context.SaveChanges();

            for (int i = 0; i < 150; i++)
            {
                var concept = new Concept
                {
                    AuthorId = user.Id,
                    Comments = new List<Comment>(),
                    Created = DateTime.Now,
                    Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum vitae tempor augue. Vestibulum vel enim nec ante tincidunt tempor id id elit. Proin in blandit justo, eu congue nulla. Vestibulum at nulla euismod eros semper pulvinar. Etiam convallis porta vestibulum. Integer sed adipiscing orci. Fusce in sem imperdiet, tempus est at, condimentum mauris. Aliquam tempus eget tortor eget venenatis. Nulla feugiat risus vel lorem elementum dictum. Aliquam commodo dictum purus, a interdum risus sollicitudin ac.
Integer sit amet vulputate risus. Nunc ultricies aliquet nisi, eu sagittis turpis hendrerit ut. Cras vitae neque elementum, bibendum lectus ut, varius lorem. Cras vehicula placerat porta. Curabitur convallis, quam vitae laoreet rutrum, turpis eros tristique arcu, in aliquam tellus neque scelerisque nibh. Donec sit amet orci hendrerit, blandit tellus quis, suscipit mauris. Nam id justo ac arcu vestibulum cursus. Aliquam laoreet imperdiet nibh quis vestibulum. Sed egestas gravida eros ac bibendum. Fusce tristique dolor eu ultricies eleifend. Proin eu quam sit amet orci varius ullamcorper. Vivamus hendrerit aliquet leo. Maecenas odio nisl, consectetur nec risus ut, lobortis ultricies massa. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;
Aenean in justo faucibus, posuere tellus quis, vestibulum nisl. Sed sit amet turpis tortor. Duis non dapibus nisl. Suspendisse suscipit nulla id sapien accumsan, ut vehicula eros pretium. Cras pellentesque erat hendrerit elementum aliquam. Duis a felis ultricies, molestie odio in, facilisis nisl. Etiam tincidunt urna vel pellentesque placerat. Curabitur adipiscing felis luctus urna rutrum consectetur.
Donec bibendum ligula id leo porttitor, a congue massa dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eleifend massa metus, at hendrerit quam hendrerit et. Donec vel turpis condimentum, consectetur tortor non, ultrices quam. Aenean ornare varius eros, sit amet cursus mi fringilla eu. Suspendisse consectetur sollicitudin urna, porta pretium tellus consequat quis. Vivamus congue dignissim dolor a varius. Vestibulum non dui ac nulla faucibus gravida. Cras pretium in mi sed laoreet. Sed rutrum dapibus urna eget consectetur. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc interdum venenatis nisl eget accumsan. Praesent lacinia ante vitae sapien pellentesque, in viverra diam facilisis.
Nam dignissim massa quis ultrices aliquet. Etiam in arcu lacinia, lobortis quam in, imperdiet risus. Integer a egestas est, sed lacinia sem. In hac habitasse platea dictumst. Morbi quam sem, commodo a ipsum venenatis, feugiat malesuada orci. Fusce varius venenatis eros, quis ultricies dolor. Cras nec adipiscing augue. Ut eget posuere urna, non varius nunc. Proin turpis urna, luctus sed eleifend ultricies, luctus et lacus. Donec vehicula, erat vel pulvinar viverra, lorem purus placerat dui, id euismod turpis neque at dui. Nunc ligula nibh, lacinia nec ligula sit amet, interdum dapibus lectus. Nulla nunc magna, molestie ac imperdiet in, cursus vitae orci. In hac habitasse platea dictumst. Quisque ut dapibus nunc. Maecenas tellus nibh, auctor a nulla fermentum, blandit rutrum orci.
Wygenerowano 5 akapit�w, 474 s��w, 3248 bajt�w Lorem Ipsum",
                    DisplayCount = 3,
                    EditCount = 0,
                    LastUpdate = DateTime.Now,
                    Tags = new List<Tag> { t1, t2, t3, t4, t5, t6, t7, t8 },
                    Title = "Lorem Ipsum jest tekstem stosowanym jako przyk�adowy wype�niacz w przemy�le poligraficznym. Zosta� po raz pierwszy u�yty w XV w. przez nieznanego drukarza do wype�nienia tekstem pr�bnej ksi��ki",
                    VoteDown = 0,
                    VoteUp = 0,
                };

                context.Concepts.AddOrUpdate(c => c.Id, concept);
                context.SaveChanges();

                for (int j = 0; j < 7; j++)
                {
                    var comment = new Comment
                                      {
                                          AuthorId = user.Id,
                                          ConceptId = concept.Id,
                                          Created = DateTime.Now,
                                          Text =
                                              @"Donec bibendum ligula id leo porttitor, a congue massa dignissim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eleifend massa metus, at hendrerit quam hendrerit et. Donec vel turpis condimentum, consectetur tortor non, ultrices quam. Aenean ornare varius eros, sit amet cursus mi fringilla eu. Suspendisse consectetur sollicitudin urna, porta pretium tellus consequat quis. Vivamus congue dignissim dolor a varius. Vestibulum non dui ac nulla faucibus gravida. Cras pretium in mi sed laoreet. Sed rutrum dapibus urna eget consectetur. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc interdum venenatis nisl eget accumsan. Praesent lacinia ante vitae sapien pellentesque, in viverra diam facilisis.
Nam dignissim massa quis ultrices aliquet. Etiam in arcu lacinia, lobortis quam in, imperdiet risus. Integer a egestas est, sed lacinia sem. In hac habitasse platea dictumst. Morbi quam sem, commodo a ipsum venenatis, feugiat malesuada orci. Fusce varius venenatis eros, quis ultricies dolor. Cras nec adipiscing augue. Ut eget posuere urna, non varius nunc. Proin turpis urna, luctus sed eleifend ultricies, luctus et lacus. Donec vehicula, erat vel pulvinar viverra, lorem purus placerat dui, id euismod turpis neque at dui. Nunc ligula nibh, lacinia nec ligula sit amet, interdum dapibus lectus. Nulla nunc magna, molestie ac imperdiet in, cursus vitae orci. In hac habitasse platea dictumst. Quisque ut dapibus nunc. Maecenas tellus nibh, auctor a nulla fermentum, blandit rutrum orci.
Wygenerowano 5 akapit�w, 474 s��w, 3248 bajt�w Lorem Ipsum"
                                      };

                    context.Comments.AddOrUpdate(v => v.Id, comment);
                }
            }
            context.SaveChanges();
        }
    }
}
