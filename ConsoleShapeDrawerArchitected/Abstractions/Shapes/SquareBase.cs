using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Shapes
{
    public abstract class SquareBase :
       ShapeBase,
       Interfaces.Shape.IShapeSquare,
       Interfaces.Feature.IColorized

    {
        private string _title = Resources.MessageResource.ShapeSquare;
        private readonly string _name = Enums.ShapeTypes.Square.ToString();
        private readonly string _description = Enums.ShapeTypes.Square.DescriptionAttribute();

        private string _borderColor = Enums.AvailableColors.Brown.DefaultValueAttribute();
        private string _fillColor = Enums.AvailableColors.Yellow.DefaultValueAttribute();

        private byte _sideLength = 0;

        public virtual byte SideLength { get => _sideLength; set => _sideLength = value; }

        public string BorderColor { get => _borderColor; set => _borderColor = value; }
        public string FillColor { get => _fillColor; set => _fillColor = value; }

        protected SquareBase() : base()
        {
            Title = _title;
            Description = _description;
            Name = _name;
        }
        protected SquareBase(string title)
            : base(title)
        {
            _title = title;
        }
        protected SquareBase(byte sideLength)
            : this()
        {
            _sideLength = sideLength;
        }
        protected SquareBase(string title, byte sideLength)
           : this(title)
        {
            _sideLength = sideLength;
        }
        protected SquareBase(int startPointX, int startPointY, byte sideLength) : base(startPointX, startPointY)
        {
            _sideLength = sideLength;
        }
        protected SquareBase(string title, int startPointX, int startPointY, byte sideLength)
            : this(startPointX, startPointY, sideLength)
        {
            _title = title;
        }
        protected SquareBase(string title, byte sideLength, string borderColor, string fillColor)
          : this(title, sideLength)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected SquareBase(byte sideLength, string borderColor, string fillColor)
           : this(sideLength)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected SquareBase(int startPointX, int startPointY, byte sideLength, string borderColor, string fillColor)
          : this(startPointX, startPointY, sideLength)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected SquareBase(string title, int startPointX, int startPointY, byte sideLength, string borderColor, string fillColor)
            : this(title, startPointX, startPointY, sideLength)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }

        [Attributes.Invoke]
        public double AreaCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(_sideLength * _sideLength) : 0D;
        }
        [Attributes.Invoke]
        public double PerimeterCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(4 * _sideLength) : 0D;
        }
        public override bool IsDrawable()
        {
            if (SideLength > 0)
                return true;
            return false;
        }
    }
}
