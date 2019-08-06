namespace Redux.Props
{
    public class TotalProps
    {
        public TotalProps(string text, string sum, Colour textColor)
        {
            Text = text;
            Sum = sum;
            TextColor = textColor;
        }

        public string Text { get; }

        public string Sum { get; }

        public Colour TextColor { get; }
    }
}