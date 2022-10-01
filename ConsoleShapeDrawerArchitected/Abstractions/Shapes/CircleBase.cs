using ConsoleShapeDrawerArchitectured.Utilities;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Shapes
{
    public abstract class CircleBase :
         ShapeBase,
         Interfaces.Shape.IShapeCircle,
         Interfaces.Feature.IColorized

    {
        private const double PI = Math.PI;

        private string _title = Resources.MessageResource.ShapeCircle;
        private readonly string _name = Enums.ShapeTypes.Circle.ToString();
        private readonly string _description = Enums.ShapeTypes.Circle.DescriptionAttribute();

        private string _borderColor = Enums.AvailableColors.Red.DefaultValueAttribute();
        private string _fillColor = Enums.AvailableColors.Green.DefaultValueAttribute();

        private byte _radius = 0;

        public virtual byte Radius { get => _radius; set => _radius = value; }

        public string BorderColor { get => _borderColor; set => _borderColor = value; }
        public string FillColor { get => _fillColor; set => _fillColor = value; }
        public CircleBase() : base()
        {
            Title = _title;
            Description = _description;
            Name = _name;
        }
        protected CircleBase(string title)
     : base(title)
        {
            _title = title;
        }
        protected CircleBase(byte radius) : this()
        {
            _radius = radius;
        }
        protected CircleBase(byte radius, string borderColor, string fillColor)
            : this(radius)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected CircleBase(byte radius, int startPointX, int startPointY, string borderColor, string fillColor)
           : this(radius, startPointX, startPointY)
        {
            _borderColor = borderColor;
            _fillColor = fillColor;
        }
        protected CircleBase(byte radius, int startPointX, int startPointY)
            : base(startPointX, startPointY)
        {
            _radius = radius;
        }
        protected CircleBase(string title, int startPointX, int startPointY, byte radius)
            : base(title, startPointX, startPointY)
        {
            _radius = radius;
        }

        [Attributes.Invoke]
        public double AreaCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(PI * _radius * _radius) : 0D;
        }
        [Attributes.Invoke]
        public double PerimeterCalculation()
        {
            return IsDrawable() ? Convert.ToDouble(2 * PI * _radius) : 0D;
        }
        public override bool IsDrawable()
        {
            if (Radius > 0)
                return true;
            return false;
        }

    }
}
