namespace UI.CharacterInfoPopup
{
    public sealed class CharacterStatData
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public CharacterStatData(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}