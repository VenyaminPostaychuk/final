using System;
using System.Linq;

namespace RoomTracker
{
    public class Room
    {
        #region FIELDS
        private int _id;
        private string _name;
        private double _width;
        private double _length;
        #endregion

        #region PROPERTIES
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Room()
        {

        }

        public Room(int id, string name, double width, double length)
        {
            _id = id;
            _name = name;
            _width = width;
            _length = length;
            
        }

        #endregion


        #region METHODS
        public double SquareFootage()
        {
            double newsize = _width * _length;

            return newsize;
        }
        #endregion



    }
}
