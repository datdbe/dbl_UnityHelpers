using System;
using UnityEngine;

public class Point2D : IComparable, IComparable<Point2D>
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    //lets hope no one uses these values?
    public static readonly Point2D INVALID = new Point2D(-int.MaxValue, -int.MaxValue);
    public static readonly Point2D ZERO = new Point2D(0, 0);

    public Point2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int CompareTo(Point2D other)
    {
        int v = (X.CompareTo(other.X));

        if (v == 0)
            v = (Y.CompareTo(other.Y));

        return v;
    }

    public int CompareTo(object other)
    {
        if (other is Point2D)
            return this.CompareTo((Point2D)other);
        else if (other == null)
            return -1;

        throw new ArgumentException();
    }

    public override bool Equals(object o)
    {
        if (o == null || !(o is Point2D)) return false;

        Point2D p = (Point2D)o;

        return x == p.X && y == p.Y;
    }

    public bool Equals(Vector3 o)
    {
        return X == Mathf.RoundToInt(o.x) && Y == Mathf.RoundToInt(o.z);
    }

    public bool Equals(Point2D o)
    {
        return X == o.X && Y == o.Y;
    }

    public bool Equals(int x, int y)
    {
        return X == x && Y == y;
    }

    public override int GetHashCode()
    {
        //???
        return X ^ Y;
    }


    public int Distance(int toX, int toY)
    {
        int xd = Mathf.Abs(toX - X);
        int yd = Mathf.Abs(toY - Y);
        bool useFourWay = false;
        if (useFourWay)
        {
            return xd + yd;
        }

        return Mathf.Max(xd, yd);
    }
    public int Distance(Vector3 worldPoint)
    {
        Point2D p = worldPoint;

        return Distance(p.X, p.Y);
    }
    public int DistanceFourway(Vector3 worldPoint)
    {
        Point2D p = worldPoint;
        int xd = Mathf.Abs(p.X - X);
        int yd = Mathf.Abs(p.Y - Y);

        return xd + yd;

    }

    public static bool operator ==(Point2D l, Point2D r)
    {
        return l.X == r.X && l.Y == r.Y;
    }

    public static bool operator !=(Point2D l, Point2D r)
    {
        return l.X != r.X || l.Y != r.Y;
    }
    public static Point2D operator +(Point2D l, Point2D r)
    {
        return new Point2D(l.X + r.X, l.Y + r.Y);
    }
    public static Point2D operator -(Point2D l, Point2D r)
    {
        return new Point2D(l.X - r.X, l.Y - r.Y);
    }
    public static Point2D operator -(Point2D l, Vector3 r)
    {
        return l - (Point2D)r;
    }

    public static Point2D operator -(Vector3 l, Point2D r)
    {
        return r - (Point2D)l;
    }
    public static Point2D operator *(Point2D l, int r)
    {
        return new Point2D(l.X * r, l.Y * r);
    }

    public static implicit operator Vector3(Point2D d)
    {
        return new Vector3(d.X, 0, d.Y);
    }
    //  User-defined conversion from double to Digit 
    public static implicit operator Point2D(Vector3 d)
    {
        return new Point2D(Mathf.RoundToInt(d.x), Mathf.RoundToInt(d.z));
    }

    public override string ToString()
    {
        return "{" + X + "," + Y + "}";
    }

    public Vector3 ToWorld()
    {
        return new Vector3(X, 0, Y);
    }

}