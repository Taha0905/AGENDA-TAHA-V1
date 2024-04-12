using System.Collections.ObjectModel;
using System.Windows.Controls;
using Google.Apis.Calendar.v3.Data;
using agenda_khelifi.service.DAO;
namespace agenda_khelifi.View
{
    /// <summary>
    /// Logique d'interaction pour ViewCalendar.xaml
    /// </summary>
    public partial class ViewCalendar : UserControl
    {
        public ObservableCollection<Event> Events { get; set; }

        public ViewCalendar()
        {
            InitializeComponent();
            Events = new ObservableCollection<Event>();
            DataContext = this;

            LoadEvents();
        }

        private void LoadEvents()
        {
            // Récupérer les événements du calendrier

            var events = DAO_google_calendar.GetEvents();
            foreach (var evt in events)
            {
                Events.Add(evt);
            }
        }

        private void RefreshButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //rafraichir les evenements
            Events.Clear();
            LoadEvents();
        }
    }
}
