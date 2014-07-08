using System.Windows;

namespace ToBeImplemented.Application.Wpf
{
    using System.Net;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using ToBeImplemented.Business.ViewModel.Concepts;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConceptOnClick(object sender, RoutedEventArgs e)
        {
            using (var w = new WebClient())
            {
                var result = w.DownloadString("http://localhost:7397/concept");
                var jobject = JsonConvert.DeserializeObject(result);
                var obj = JObject.FromObject(jobject);
                var jconcept = obj["Data"];
                var list = JsonConvert.DeserializeObject<ListConceptViewModel>(jconcept.ToString());
                this.conceptList.ItemsSource = list.Concepts;
            }
        }

        private void UpdateSelected(object sender, RoutedEventArgs e)
        {
            var selected = conceptList.SelectedItem as ConceptViewModel;
            var updateConceptViewModel = new UpdateConceptViewModel
                                             {
                                                 AuthorId = selected.AuthorId,
                                                 Description = selected.Description,
                                                 Id = selected.Id,
                                                 Title = selected.Title
                                             };

            var json = JsonConvert.SerializeObject(updateConceptViewModel);
            using (var w = new WebClient())
            {
                w.Headers.Add("Content-Type", "application/json");
                w.UploadString("http://localhost:7397/concept", "PUT", json);
            }
        }
    }
}
