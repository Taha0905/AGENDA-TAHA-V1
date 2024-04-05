using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace agenda_khelifi.service.DAO
{
    class DAO_google_calendar
    {
        // Définir les étendues d'accès
        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "agenda_khelifi";

        public static IList<Event> GetEvents()
        {
            UserCredential credential;

            // Charger les informations d'identification depuis le fichier credentials.json
            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Créer le service Google Calendar API
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Définir les paramètres de la requête
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 10;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // Récupérer les événements
            Events events = request.Execute();
            return events.Items;
        }
    }
}
