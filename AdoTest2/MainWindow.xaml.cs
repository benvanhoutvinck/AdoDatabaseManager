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
using AdoGemeenschap;

namespace AdoTest2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool AddMode = false;
        private CollectionViewSource plantViewSource;
        CollectionViewSource leverancierViewSource;
        List<Plant> plantenList;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            plantViewSource = ((CollectionViewSource)(this.FindResource("plantViewSource")));
            leverancierViewSource = ((CollectionViewSource)(this.FindResource("leverancierViewSource")));

            var soortManager = new SoortManager();
            List<Soort> soorten = soortManager.GetSoorten();
            ComboBoxSoorten.ItemsSource =soorten;
            ComboBoxSoorten.IsEnabled = false;

            SetupScreen();

        }

        private void SetupScreen()
        {
            var manager = new LeverancierManager();
            leverancierViewSource.Source = manager.GetLeveranciers();

            ListBoxLeveranciers.Focus();
            ListBoxLeveranciers.SelectedIndex = 0;
            ListBoxPlanten.SelectedIndex = 0;

            ListBoxLeveranciers.ScrollIntoView(ListBoxLeveranciers.SelectedItem);
            ListBoxPlanten.ScrollIntoView(ListBoxPlanten.SelectedItem);
        }

       

        private bool checkOpFouten()
        {
            bool foutGevonden = false;
            foreach (var c in grid1.Children)
            {
                Control control = (Control)c;

                // perform update source on the controls to make sure the validation is triggered
                if (control.GetType().IsAssignableFrom(naamTextBox.GetType()))
                    ((Control)c).GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if (Validation.GetHasError((DependencyObject)c))
                {
                    foutGevonden = true;
                }
                ComboBoxSoorten.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
                if (Validation.GetHasError(ComboBoxSoorten))
                {
                    foutGevonden = true;
                }
            }
            return foutGevonden;
        }

        private void ButtonVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            var manager = new PlantenManager();
            manager.SchrijfVerwijderingen((int)ListBoxPlanten.SelectedValue);
            SetupScreen();
        }

        private void ButtonToevoegen_Click(object sender, RoutedEventArgs e)
        {
            if (!AddMode)
            {
                enableAddMode();
            }
            // knop bevestigen
            else
            {
                if (!checkOpFouten())
                {
                    var manager = new PlantenManager();
                    Plant NieuwePlant = plantenList[plantenList.Count - 1];
                    NieuwePlant.LeveranciersNr = (int)ListBoxLeveranciers.SelectedValue;
                    manager.SchrijfToevoeging(NieuwePlant);
                    disableAddMode();
                    SetupScreen();
                }
            }
        }

        private void ButtonWijzigen_Click(object sender, RoutedEventArgs e)
        {
            // toevoegen annuleren
            if (AddMode)
            {
                plantenList.RemoveAt(plantenList.Count - 1);
                disableAddMode();
                SetupScreen();
            }
            else
            {
                if (!checkOpFouten())
                {
                    var manager = new PlantenManager();
                    manager.schrijfWijzigingen((Plant)ListBoxPlanten.SelectedItem);
                }
            }
        }

        private void enableAddMode()
        {
            ComboBoxSoorten.IsEnabled = true;
            plantenList.Add(new Plant());
            plantViewSource.View.MoveCurrentToLast();

            ButtonWijzigen.Content = "Annuleren";
            ButtonVerwijderen.IsEnabled = false;
            ListBoxLeveranciers.IsEnabled = false;
            ListBoxPlanten.IsEnabled = false;

            AddMode = true;
        }

        private void disableAddMode()
        {
            ComboBoxSoorten.IsEnabled = false;
          

            ButtonWijzigen.Content = "Wijzigen";
            ButtonVerwijderen.IsEnabled = true;
            ListBoxLeveranciers.IsEnabled = true;
            ListBoxPlanten.IsEnabled = true;

            AddMode = false;
        }

        private void ListBoxLeveranciers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var manager = new PlantenManager();
            plantenList = manager.getPlanten(((Leverancier)ListBoxLeveranciers.SelectedItem).LevNr);

            plantViewSource.Source = plantenList;
        }
    }
}
