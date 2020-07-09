using System;

using System.Collections.Generic;

using System.Linq;


namespace Codenation.Challenge

{

    public class SoccerTeamsManager : IManageSoccerTeams

    {

        private readonly List<Team> _team;

        private readonly List<Player> _player;

        public SoccerTeamsManager()

        {

            _team = new List<Team>();

            _player = new List<Player>();

        }



        public void AddTeam(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)

        {

            if (_team.Any(x => x.Id == id))

            {

                throw new Exceptions.UniqueIdentifierException();

            }


            _team.Add(new Team

            {

                Id = id,

                Name = name,

                CreateDate = createDate,

                MainShirtColor = mainShirtColor,

                SecondaryShirtColor = secondaryShirtColor

            });

        }

        public void AddPlayer(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)

        {

            ValidateAddPlayer(id, teamId);

            var age = new DateTime(DateTime.Now.Subtract(birthDate).Ticks).Year - 1;

            _player.Add(new Player

            {

                Id = id,

                TeamId = teamId,

                Name = name,

                BirthDate = birthDate,

                SkillLevel = skillLevel,

                Salary = salary,

                Age = age

            });

        }


        public void SetCaptain(long playerId)

        {

            HasPlayer(playerId);


            var teamID = _player.FirstOrDefault(x => x.Id == playerId).TeamId;


            if (_player.Any(x => x.TeamId == teamID && x.IsCaptain))

            {

                _player.FirstOrDefault(x => x.TeamId == teamID && x.IsCaptain).IsCaptain = false;

            }


            _player.FirstOrDefault(x => x.Id == playerId).IsCaptain = true;


        }


        public long GetTeamCaptain(long teamId)

        {

            HasTeam(teamId);

            HasCaptainTeam(teamId);

            return (_player.FirstOrDefault(x => x.Id == teamId)).Id;

        }


        public string GetPlayerName(long playerId)

        {

            HasPlayer(playerId);

            return _player.FirstOrDefault(x => x.Id == playerId).Name;

        }


        public string GetTeamName(long teamId)

        {

            HasTeam(teamId);

            return _team.FirstOrDefault(x => x.Id == teamId).Name;

        }


        public List<long> GetTeamPlayers(long teamId)

        {

            HasTeam(teamId);

            return _player.Where(x => x.TeamId == teamId).OrderBy(x => x.Id).Select(x => x.Id).ToList();

        }


        public long GetBestTeamPlayer(long teamId)

        {

            HasTeam(teamId);


            var player = _player.Where(x => x.TeamId == teamId)

                .OrderByDescending(x => x.SkillLevel)

                .FirstOrDefault();


            return ComparePlayerId(x => x.Id != player.Id && x.SkillLevel == player.SkillLevel, player.Id);

        }


        public long GetOlderTeamPlayer(long teamId)

        {

            HasTeam(teamId);

            var player = _player.Where(x => x.TeamId == teamId)

                .OrderByDescending(x => x.Age)

                .FirstOrDefault();


            return ComparePlayerId(x => x.Id != player.Id &&

                    x.Age == player.Age, player.Id);

        }


        public List<long> GetTeams()

        {

            if (_team.ToArray().Length == 0)

            {

                return new List<long>();

            }


            return _team.OrderBy(x => x.Id).Select(x => x.Id).ToList();

        }


        public long GetHigherSalaryPlayer(long teamId)

        {

            HasTeam(teamId);


            var player = _player.Where(x => x.TeamId == teamId)

                .OrderByDescending(x => x.Salary)

                .FirstOrDefault();


            return ComparePlayerId(x => x.Id != player.Id && x.Salary == player.Salary, player.Id);

        }


        public decimal GetPlayerSalary(long playerId)

        {

            HasPlayer(playerId);

            return _player.FirstOrDefault(x => x.Id == playerId).Salary;

        }


        public List<long> GetTopPlayers(int top)

        {

            var players = _player.ToList().OrderByDescending(x => x.SkillLevel);


            if (players.ToArray().Length == 0)

            {

                return new List<long>();

            }

            var list = new List<Player>();




            foreach (var value in players)

            {

                if (list.ToArray().Length == top)

                {

                    break;

                }
                else if (list.ToArray().Length == 0)

                {

                    list.Add(value);

                }
                else if (list.Any(x => x.SkillLevel == value.SkillLevel &&

              x.Id > value.Id))

                {

                    list.Add(value);

                }
                else

                {

                    list.Add(value);

                }

            }


            return list.Select(x => x.Id).ToList();

        }


        public string GetVisitorShirtColor(long teamId, long visitorTeamId)

        {

            HasTeam(teamId);

            HasTeam(visitorTeamId);


            var team = _team.FirstOrDefault(x => x.Id == teamId);

            var visitorTeam = _team.FirstOrDefault(x => x.Id == visitorTeamId);


            return visitorTeam.MainShirtColor.Equals(team.MainShirtColor) ?

                   visitorTeam.SecondaryShirtColor :

                   visitorTeam.MainShirtColor;



        }


        private void HasPlayer(long playerId)

        {

            if (!_player.Any(x => x.Id == playerId))

            {

                throw new Exceptions.PlayerNotFoundException();

            }

        }


        private void ValidateAddPlayer(long id, long teamId)

        {

            if (_player.Any(x => x.Id == id))

            {

                throw new Exceptions.UniqueIdentifierException();

            }

            else if (!_team.Any(x => x.Id == teamId))

            {

                throw new Exceptions.TeamNotFoundException();

            }

        }


        private void HasTeam(long teamId)

        {

            if (!_team.Any(x => x.Id == teamId))

            {

                throw new Exceptions.TeamNotFoundException();

            }

        }

        private void HasCaptainTeam(long teamId)

        {

            var hasCaptain = false;


            _player.ForEach(x =>

            {

                if (x.IsCaptain)

                {

                    hasCaptain = true;

                }

            });


            if (!hasCaptain)

            {

                throw new Exceptions.CaptainNotFoundException();

            }

        }

        private long ComparePlayerId(Func<Player, bool> expression, long compareId)

        {

            var players = _player.Where(expression);


            if (players.ToArray().Length > 0)

            {

                foreach (var value in players)

                {

                    if (compareId > value.Id)

                    {

                        compareId = value.Id;

                    }

                }

                return compareId;

            }

            return compareId;

        }

    }


    public class Player

    {

        public long Id { get; set; }

        public long TeamId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public int SkillLevel { get; set; }

        public decimal Salary { get; set; }

        public bool IsCaptain { get; set; }

        public int Age { get; set; }

    }



    public class Team

    {

        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public string MainShirtColor { get; set; }

        public string SecondaryShirtColor { get; set; }

    }

}