using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Shapes
{
    public abstract class RectangleBase :
       ShapeBase,
       Interfaces.Shape.IShapeRectangle,
       Interfaces.Feature.IColorized

    {
        private string _title = Resources.MessageResource.ShapeRectangle;
        private readonly string _name = Enums.ShapeTypes.Rectangle.ToString();
        private readonly string _description = Enums.ShapeTypes.Rectangle.DescriptionAttribute();

        private string _borderColor = Enums.AvailableColors.Lemon.DefaultValueAttribute();
        private string _fillColor = Enums.AvailableColors.Blue.DefaultValueAttribute();

        private byte _length = 0;
        private byte _width = 0;

        public virtual byte Length { get => _length; set => _length = value; }
        public virtual byte Width { get => _width; set => _width = value; }

        public string BorderColor { get => _borderColor; set => _borderColor = value; }
        public string FillColor { get => _fillColor; set => _fillColor = value; }

        protected RectangleBase() : base()
        {
            Title = _title;
            Description = _description;
            Name = _name;

        }
        protected RectangleBase(string title)
            : base(title)
        {
            _title = title;
        }
        protected RectangleBase(byte length, byte width)
            : this()
        {
            _length = length;
            _width = width;
        }
        protected RectangleBase(int startPointX, int startPointY, byte length, byte width) : base(startPointX, startPointY)
        {
            _length = length;
            _width = width;
        }
        protected RectangleBase(string title, int startPointX, int startPointY, byte length, byte width)
            : base(title, startPointX, startPointY)
        {
            _length = length;
            _width = width;
        }
        protected RectangleBase(byte length, byte width, string borderColor, string fillColor)
           : this(length, width)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected RectangleBase(string title, int startPointX, int startPointY, byte length, byte width, string borderColor, string fillColor)
            : this(title, startPointX, startPointY, length, width)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }

        [Attributes.Invoke]
        public double AreaCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(_length * _width) : 0D;
        }
        [Attributes.Invoke]
        public double PerimeterCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(2 * (_length + _width)) : 0D;
        }
        public override bool IsDrawable()
        {
            if (Length > 0 && Width > 0)
                return true;
            return false;
        }
    }
}
