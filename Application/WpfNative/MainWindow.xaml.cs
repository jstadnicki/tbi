using System;
using System.Windows;

namespace WpfNative
{
    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Domain.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConceptLogic conceptLogic;

        public MainWindow(IConceptLogic conceptLogic)
        {
            this.conceptLogic = conceptLogic;
            InitializeComponent();
        }

        private void ConceptOnClick(object sender, RoutedEventArgs e)
        {
            var result = this.conceptLogic.List();
            this.conceptList.ItemsSource = result.Concepts;
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
            this.conceptLogic.UpdateConcept(updateConceptViewModel);
        }
    }
}
