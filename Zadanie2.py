class Activity:
    def __init__(self, name: str, time: str):
        self.name = name
        self.time = time

    def __str__(self):
        return f"{self.name} o godzinie {self.time}"
    
class Destination:
    def __init__(self, name: str):
        self.name = name
        self.activities = []

    def add_activity(self, activity: Activity):
        self.activities.append(activity)

    def show_schedule(self):
        print(f"\nCel wycieczki: {self.name}:")
        if not self.activities:
            print("Brak zaplanowanych aktywności.")
        for activity in self.activities:
            print(f" * {activity}")

    def remove_activity(self, activity: Activity):
        if activity in self.activities:
            self.activities.remove(activity)
        else:
            print(f"Nie można usunąć tej aktywności, ponieważ nie istnieje.")
        

class Trip:
    def __init__(self, title: str):
        self.name = title
        self.destinations = []

    def add_destination(self, destination: Destination):
        self.destinations.append(destination)

    def show_itinerary(self):
        print(f"\nPlan podróży: {self.name}")
        if not self.destinations:
            print("Brak zaplanowanych miejsc docelowych.")
        for destination in self.destinations:
            destination.show_schedule()
            
def main():
    print("\nWitaj w Kreatorze Planu Podróży!")
    trip_name = input("Podaj nazwę wycieczki: ")
    if not trip_name:
        trip_name = ("Moja podróż")
    trip = Trip(trip_name)

    while True:
        dest_name = input("\nPodaj nazwę miejsca docelowego (lub wciśnij Enter aby zakończyć): ").strip()
        if not dest_name:
            break

        destination = Destination(dest_name)

        while True:
            activity_name = input(f"Podaj nazwę aktywności dla {dest_name} (lub wciśnij Enter aby zakończyć): ").strip()
            if not activity_name:
                break
            activity_time = input(f"Podaj czas dla {activity_name} (np. 10:00): ").strip()
            if not activity_time:
                print("Czas nie może być pusty.")
                continue
            activity = Activity(activity_name, activity_time)
            destination.add_activity(activity)

        trip.add_destination(destination)

        trip.show_itinerary()

        while True:
            remove_activity = input(f"Czy chcesz usunąć jakąś aktywność z {dest_name}? (tak/nie): ").strip().lower()
            if remove_activity == "tak":
                activity_to_remove = input("Podaj nazwę aktywności do usunięcia: ").strip()
                activity_found = False
                for activity in destination.activities:
                    if activity.name == activity_to_remove:
                        destination.remove_activity(activity)
                        print(f"Aktywność '{activity_to_remove}' została usunięta.")
                        activity_found = True
                        trip.show_itinerary()
                        break
                if not activity_found:
                    print(f"Aktywność '{activity_to_remove}' nie została znaleziona.")
            elif remove_activity == "nie":
                break
            else:
                print("Proszę odpowiedzieć 'tak' lub 'nie'.")

    trip.show_itinerary()

if __name__ == "__main__":
    main()