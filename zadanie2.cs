using System;
using System.Collections.Generic;

namespace Planer
{
    public class Activity
    {
        public string Name { get; }
        public string Time { get; }
        public Activity(string name, string time)
        {
            Name = name;
            Time = time;
        }
        public override string ToString()
        {
            return $"{Name} at {Time}";
        }
    }
    public class Destination
    {
        public string Name { get; }
        private readonly List<Activity> Activities = new List<Activity>();
        public Destination(string name)
        {
            Name = name;
        }
        public void AddActivity(Activity activity)
        {
            Activities.Add(activity);
        }

        public void RemoveActivity(Activity activity)
        {
            if (Activities.Contains(activity))
            {
                Activities.Remove(activity);
            }
            else
            {
                Console.WriteLine("Nie można usunąć tej aktywności, ponieważ nie istnieje.");
            }
        }
        public Activity FindActivityByName(string name)
        {
            return Activities.Find(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public void ShowSchedule()
        {
            Console.WriteLine($"Cel wycieczki: {Name}");
            if (Activities.Count == 0)
            {
                Console.WriteLine("Brak zaplanowanych aktywności.");
            }
            foreach (var activity in Activities)
            {
                Console.WriteLine($" * {activity}");
            }
        }
    }

    public class Trip
    {
        public string Title { get; set; }
        public List<Destination> Destinations { get; set; }
        public Trip(string title)
        {
            Title = title;
            Destinations = new List<Destination>();
        }
        public void AddDestination(Destination destination)
        {
            Destinations.Add(destination);
        }
        public void ShowItinerary()
        {
            Console.WriteLine($"\nPlan podróży: {Title}");
            if (Destinations.Count == 0)
            {
                Console.WriteLine("Brak zaplanowanych celów podróży.");
            }
            foreach (var destination in Destinations)
            {
                destination.ShowSchedule();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nWitaj w Kreatorze Planu Podróży!");
            Console.Write("Podaj nazwę wycieczki: ");
            string title = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(title)) title = "Moja Podróż";
            
            Trip trip = new Trip(title);

            while (true)
            {
                Console.Write("\nPodaj nazwę miejsca docelowego (lub wciśnij Enter aby zakończyć):  ");
                string destName = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(destName))
                {
                    break;
                }

                Destination destination = new Destination(destName);

                while (true)
                {
                    Console.Write($"  Podaj nazwę atrakcji dla {destName} (lub wciśnij Enter, aby zakończyć ten cel): ");
                    string actName = Console.ReadLine()?.Trim();
                    if (string.IsNullOrEmpty(actName))
                    {
                        break;
                    }

                    Console.Write("  Podaj godzinę (np. 10:00): ");
                    string actTime = Console.ReadLine()?.Trim();

                    Activity activity = new Activity(actName, actTime);
                    destination.AddActivity(activity);
                }

                trip.AddDestination(destination);

                while (true)
                {
                    Console.Write($"Czy chcesz usunąć jakąś atrakcję z {destName}? (tak/nie): ");
                    string removeChoice = Console.ReadLine()?.Trim().ToLower();
                    if (removeChoice == "tak")
                    {
                        Console.Write("  Podaj nazwę atrakcji do usunięcia: ");
                        string removeActName = Console.ReadLine()?.Trim();
                        Activity toRemove = destination.FindActivityByName(removeActName);
                        if (toRemove != null)
                        {
                            destination.RemoveActivity(toRemove);
                            Console.WriteLine($"  Atrakcja '{removeActName}' została usunięta.");
                        }
                        else
                        {
                            Console.WriteLine($"  Nie znaleziono atrakcji o nazwie '{removeActName}'.");
                        }
                    }
                    else if (removeChoice == "nie")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("  Proszę odpowiedzieć 'tak' lub 'nie'.");
                    }
                }
            }

            trip.ShowItinerary();
        }
    }
}

