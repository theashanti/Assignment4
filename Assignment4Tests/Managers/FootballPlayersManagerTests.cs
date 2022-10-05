using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment4.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment4.Models;

namespace Assignment4.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        private List<FootballPlayer> playerList = new List<FootballPlayer>();
        private List<FootballPlayer> nullList = new List<FootballPlayer>();
        private FootballPlayer player = new FootballPlayer { Id = 1, Name = "John", Age = 18, ShirtNumber = 34 };


        [TestMethod()]
        public void AddTest()
        {
            playerList.Add(player);
            Assert.AreEqual(playerList.Count(), 1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            playerList.Remove(player);
            Assert.AreEqual(playerList.Count(), 0);
        }

    }
}