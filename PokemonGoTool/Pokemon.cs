using System;

namespace PokemonGoTool
{
    public enum Gender
    {
        Male,
        Female,
        Undefined
    }

    public enum State
    {
        Normal,
        Shadow,
        Purified
    }

    public class Pokemon
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
        public int? Level { get; }
        public string? QuickMove { get; }
        public string? ChargeMove { get; }
        public string? ChargeMove2 { get; }
        public string? ScanDate { get; } //TODO
        public string? CatchDate { get; } //TODO
        public float? Weight { get; }
        public float? Height { get; }
        public int? Lucky { get; }

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
            Gender gender = Gender.Undefined,
            int? cp = null,
            int? hp = null,
            int? atkIV = null,
            int? defIV = null,
            int? staIV = null,
            int? level = null,
            string? quickMove = null,
            string? chargeMove = null,
            string? chargeMove2 = null,
            string? scanDate = null,
            string? catchDate = null,
            float? weight = null,
            float? height = null,
            int? lucky = null/*,
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
            Level = level;
            QuickMove = quickMove;
            ChargeMove = chargeMove;
            ChargeMove2 = chargeMove2;
            ScanDate = scanDate;
            CatchDate = catchDate;
            Weight = weight;
            Height = height;
            Lucky = lucky;
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
    }
}


