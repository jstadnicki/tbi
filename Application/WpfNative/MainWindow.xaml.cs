﻿using System.Windows;

namespace WpfNative
{
    using System.Security.Claims;

    using ToBeImplemented.Business.Interfaces;
    using ToBeImplemented.Business.ViewModel.Concepts;

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
            this.conceptList.ItemsSource = result.Data.Concepts;
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

            ClaimsPrincipal notImplementedYet = null;
            this.conceptLogic.UpdateConcept(updateConceptViewModel, notImplementedYet);
        }
    }
}
