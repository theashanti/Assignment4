using Assignment4.Models;
using System.Linq;
using System.Xml.Linq;

namespace Assignment4.Managers
{
    public class FootballPlayersManager
    {

        private static int _nextId = 1;
        private static readonly List<FootballPlayer> List = new List<FootballPlayer>
        {
            new FootballPlayer {Id = _nextId++, Name = "John",Age = 18, ShirtNumber = 34},
            new FootballPlayer {Id = _nextId++, Name = "Ringo",Age = 23, ShirtNumber = 17},
            new FootballPlayer {Id = _nextId++, Name = "Paul",Age = 22, ShirtNumber = 11},
            new FootballPlayer {Id = _nextId++, Name = "George",Age = 24, ShirtNumber = 20},
        };

        public List<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(List);
        }

        public FootballPlayer GetById(int id)
        {
            return List.Find(player => player.Id == id);
        }

        public FootballPlayer Add(FootballPlayer newPlayer)
        {
            newPlayer.Id = _nextId++;
            List.Add(newPlayer);
            return newPlayer;
        }

        public FootballPlayer Delete(int id)
        {
            FootballPlayer player = List.Find(player1 => player1.Id == id);
            if (player == null) return null;
            List.Remove(player);
            return player;
        }

        public FootballPlayer Update(int id, FootballPlayer updates)
        {
            FootballPlayer player = List.Find(player1 => player1.Id == id);
            if (player == null) return null;
            player.Age=updates.Age;
            player.ShirtNumber=updates.ShirtNumber;
            player.Id=updates.Id;
            return player;
        }

        public void ValidateGetAll()
        {
            if (List.Count == 0) throw new ArgumentNullException("List is null");
        }
        public void ValidateAdd(FootballPlayer newPlayer)
        {
            if (!List.Contains(newPlayer)) throw new ArgumentException("Player not added");
        }
        public void ValidateGetById(int id)
        {
            FootballPlayer newPlayer = List.Find(player1 => player1.Id == id);
            if (!List.Contains(newPlayer)) throw new ArgumentException("Player is not on the list");
        }
    }
}

