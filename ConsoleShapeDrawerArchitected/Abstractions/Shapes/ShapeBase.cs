using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShapeDrawerArchitectured.Abstractions.Shapes
{
    public abstract class ShapeBase :
        Interfaces.Shape.IShape,
        Interfaces.Feature.IDrawable
    {
        private string _name = string.Empty;
        private string _title = string.Empty;
        private string _description = string.Empty;

        private int _startPointX = 100;
        private int _startPointY = 100;

        public string Title { get => _title; set => _title = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }

        public int StartPointX { get => _startPointX; set => _startPointX = value; }
        public int StartPointY { get => _startPointY; set => _startPointY = value; }

        protected ShapeBase()
        {

        }
        protected ShapeBase(string title)
        {
            _title = title;
        }
        protected ShapeBase(int startPointX, int startPointY)
        {
            _startPointX = startPointX;
            _startPointY = startPointY;
        }
        protected ShapeBase(string title, string name, string description)
        {
            _title = title;
            _name = name;
            _description = description;
        }
        protected ShapeBase(string name, string title, string description, int startPointX, int startPointY) : this(name, title, description)
        {
            _startPointX = startPointX;
            _startPointY = startPointY;
        }
        protected ShapeBase(string title, int startPointX, int startPointY)
            : this(startPointX, startPointY)
        {
            _title = title;
        }

        public abstract bool IsDrawable();
    }
}
