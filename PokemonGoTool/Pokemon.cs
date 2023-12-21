using System;
using System.Collections;
using System.Collections.Generic;

namespace PokemonGoTool
{
    public enum Gender
    {
        Genderless,
        Male,
        Female        
    }

    public enum State
    {
        Normal,
        Shadow,
        Purified
    }

    public class Pokemon : IEnumerable
    {
        // Properties to store Pokemon information
        public string Name { get; }
        public State State { get; }
        public int PokemonId { get; }
        public string? Form { get; }
        public Gender Gender { get; }
        public int? CP { get; }
        public int? HP { get; }
        public int? AtkIV { get; }
        public int? DefIV { get; }
        public int? StaIV { get; }
        public float? MinLevel { get; }
        public float? MaxLevel { get; }
        public string? QuickMove { get; }
        public string? ChargeMove { get; }
        public string? ChargeMove2 { get; }
        public string? ScanDate { get; } //TODO
        public string? CatchDate { get; } //TODO
        public float? Weight { get; }
        public float? Height { get; }
        public int? Lucky { get; }
        public bool Shiny { get; }

        /*TODO extract from Master file
        public int BaseAttack { get; }
        public int BaseDefense { get; }
        public int BaseHP { get; }
        */



        public Pokemon(
            string name,
            State state,
            int pokemonId,
            string? form = null,
            Gender gender = Gender.Genderless,
            int? cp = null,
            int? hp = null,
            int? atkIV = null,
            int? defIV = null,
            int? staIV = null,
            float? minLevel = null,
            float? maxLevel = null,
            string? quickMove = null,
            string? chargeMove = null,
            string? chargeMove2 = null,
            string? scanDate = null,
            string? catchDate = null,
            float? weight = null,
            float? height = null,
            int? lucky = null,
            bool shiny = false/*,
            int baseAttack = null,
            int baseDefense = null,
            int baseHP = null*/)
        {
            Name = name;
            State = state;
            PokemonId = pokemonId;
            Form = form;
            Gender = gender;
            CP = cp;
            HP = hp;
            AtkIV = atkIV;
            DefIV = defIV;
            StaIV = staIV;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            QuickMove = quickMove;
            ChargeMove = chargeMove;
            ChargeMove2 = chargeMove2;
            ScanDate = scanDate;
            CatchDate = catchDate;
            Weight = weight;
            Height = height;
            Lucky = lucky;
            Shiny = shiny;
            /*
            BaseAttack = baseAttack;
            BaseDefense = baseDefense;
            BaseHP = baseHP;
            */
        }

        /// <summary>
        /// The method tries to estimate the Level of the Pokemon object. An exact guess is only possible if all of the IV values and the CP value is provided, otherwise a range will be provided.
        /// </summary>
        /// <returns>A range of possible levels the Pokemon could have. If possible, an exact level is returned in which case the two tuple values will be the same.</returns>
        public (float min, float max) estimateLevel() // TODO
        {
            return (0.0f, 0.0f);
        }

        // Implementation of IEnumerable.GetEnumerator()
        public IEnumerator GetEnumerator()
        {
            return new PokemonEnumerator(this);
        }

        // Iterator class
        private class PokemonEnumerator : IEnumerator
        {
            private readonly Pokemon _pokemon;
            private int _currentIndex = -1;

            public PokemonEnumerator(Pokemon pokemon)
            {
                _pokemon = pokemon;
            }

            // Implementation of IEnumerator.MoveNext()
            public bool MoveNext()
            {
                _currentIndex++;
                return _currentIndex < 21; // Adjust the count based on the number of properties
            }

            // Implementation of IEnumerator.Reset()
            public void Reset()
            {
                _currentIndex = -1;
            }

            // Implementation of IEnumerator.Current
            public object Current
            {
                get
                {
                    // Return the corresponding property based on the current index
                    switch (_currentIndex)
                    {
                        case 0: return _pokemon.Name;
                        case 1: return _pokemon.State;
                        case 2: return _pokemon.PokemonId;
                        case 3: return _pokemon.Form;
                        case 4: return _pokemon.Gender;
                        case 5: return _pokemon.CP;
                        case 6: return _pokemon.HP;
                        case 7: return _pokemon.AtkIV;
                        case 8: return _pokemon.DefIV;
                        case 9: return _pokemon.StaIV;
                        case 10: return _pokemon.MinLevel;
                        case 11: return _pokemon.MaxLevel;
                        case 12: return _pokemon.QuickMove;
                        case 13: return _pokemon.ChargeMove;
                        case 14: return _pokemon.ChargeMove2;
                        case 15: return _pokemon.ScanDate;
                        case 16: return _pokemon.CatchDate;
                        case 17: return _pokemon.Weight;
                        case 18: return _pokemon.Height;
                        case 19: return _pokemon.Lucky;
                        case 20: return _pokemon.Shiny;
                        default: throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}


