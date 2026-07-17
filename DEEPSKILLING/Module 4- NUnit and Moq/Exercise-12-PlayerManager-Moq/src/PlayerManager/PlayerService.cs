using System;
using System.Collections.Generic;

namespace PlayerManager
{
    public interface IPlayerRepository
    {
        bool Exists(string name);
        void Add(Player player);
    }

    public class Player
    {
        public string Name { get; }
        public int Score { get; }

        public Player(string name, int score)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Score = score;
        }
    }

    public class PlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public bool RegisterPlayer(string name)
        {
            if (_playerRepository.Exists(name))
            {
                return false;
            }

            _playerRepository.Add(new Player(name, 0));
            return true;
        }
    }
}
