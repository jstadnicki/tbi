using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToBeImplemented.Application.Wpf
{
    using System.Net;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using ToBeImplemented.Domain.ViewModel;

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
