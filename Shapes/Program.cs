using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public enum Color {
        BLACK, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE, INVALID
    };
    public abstract class Shape
        {
            private Color colour;
            public Shape() {}
            public Shape(Color a) {this.colour = a;}
            //getters and setters
            public virtual void color(Color a) { colour = a;}
            public Color color() {return colour;}

            protected class coord {
                public double x;
                public double y;
            }
            //shape functions
            public abstract void move(double dx, double dy);
            public abstract double area();
            public abstract double perimeter();
            public abstract void render(); //display shape to osteam
            // public abstract bool inside(double dx, double dy);
            // double thickness() {return area()/perimeter();};
            // static Color colorAtPoint(Shape*[] arr, int num, double x, double y);

        }
    public class Polygon : Shape
    {
        public Polygon(Color colour, double[] pts, int v) : base(colour) {
            vertices = new double[v*2];
            for(int i = 0; i < v*2; i++) {
                vertices[i] = pts[i];
            }
            vcount = v;
        }
        
        //getters and setters
        double vertexX(int vertX) {return vertices[vertX*2];}
        double vertexY(int vertY) {return vertices[vertY*2+1];}
        void vertexX(int place, double coord) {vertices[place*2] = coord;}
        void vertexY(int place, double coord) {vertices[place*2+1] = coord;}
        
        void points(int x) {vcount = x;}
        int points() {return vcount;}
        //functions
        public override void move(double dx, double dy) {
            for (int i = 0; i < vcount*2; i += 2) {
                vertices[i] = vertices[i] + dx; //move x
            }
            for (int i = 1; i < vcount*2; i += 2) {
                vertices[i] = vertices[i] + dy; //move y
            }
        }
        public override double area() {
            double a = 0;
            int t = 0;
            for (; t < (vcount*2)-2; t += 2) {
                a += (vertices[t]*vertices[t+3]) - (vertices[t+2]*vertices[t+1]);
            }
            a += (vertices[t]*vertices[1]) - (vertices[t+1]*vertices[0]);
            return (a /= 2);
        }
        public override double perimeter() {
            double peri = 0;
            int i = 0;
            for (; i < (vcount*2)-2; i+=2)
            {
                peri += Math.Sqrt(Math.Pow((vertices[i] - vertices[i+2]), 2)+(Math.Pow((vertices[i+1] - vertices[i+3]), 2)));
            }
            peri += Math.Sqrt(Math.Pow((vertices[i] - vertices[0]), 2)+(Math.Pow((vertices[i+1] - vertices[1]), 2)));
            return peri;
        }
        public override void render() {
            Console.Write("Polygon(" + Enum.GetName(typeof(Color), color()) + "," + vcount + ",");
            int z = 0;
            for (; z < vcount*2 - 1; z++) {
                Console.Write(vertices[z] + ",");
            }
            Console.WriteLine(vertices[z] + ")");
        }

        private double[] vertices;
        private int vcount;

    }
    public class Box : Shape
    {
        private double ax, ay, bx, by;
        public Box(Color c, double left, double top, double right, double bottom) : base(c) {
            ax = left;
            ay = top;
            bx = right;
            by = bottom;
        }
        //setters and getters
        public void left( double izquierda) {ax = izquierda;}
        public void right( double derecha) { bx = derecha; }
        public void top( double arriba) { ay = arriba; }
        public void bottom( double abajo) { by = abajo; }

        public double left() {return ax;}
        public double right() {return bx;}
        public double top() {return ay;}
        public double bottom() {return by;}
        //functions
        public override double perimeter() {
            return (ay - by)*2+(bx-ax)*2;
        }
        public override double area() {
            return ((ay-by)*(bx-ax));
        }
        public override void move(double dx, double dy) {
            ay += dy;
            by += dy;
            ax += dx;
            bx += dx;
        }
        public override void render() {
            Console.WriteLine("Box(" + Enum.GetName(typeof(Color), color()) + "," + ax + "," + ay + "," + bx + "," + by + ")");
        }

    }
    public class Circle : Shape 
    {
        private double ax, ay;
        public Circle(Color c, double x, double y, double r) : base(c) {
            ax = x;
            ay = y;
            rad = r;
        }
        //setters and getters
        void centerX(double x) {ax = x;}
        void centerY(double y) {ay = y;}
        void radius(double r) {rad = r;}

        double centerX() {return ax;}
        double centerY() {return ax;}
        double radius() {return rad;}
        //functions
        public override void move(double dx, double dy) {
            ax += dx;
            ay += dy;
        }
        public override void render() {
            Console.WriteLine("Circle(" + Enum.GetName(typeof(Color), color()) + "," + ax + "," + ay + "," + rad + ")");
        }
        public override double perimeter() {
            return (2*rad*Math.PI);
        }
        public override double area() {
            return (Math.PI*(rad*rad));
        }
        double rad;
    }
    public class Triangle : Shape
    {
        double ax, ay, bx, by, cx, cy;
        public Triangle(Color c, double x1, double y1, double x2, double y2, double x3, double y3) : base(c) {
            ax = x1;
            ay = y1;
            bx = x2;
            by = y2;
            cx = x3;
            cy = y3;
        }
        //setters and getters
        void cornerX1(double x) {ax = x;}
        void cornerY1(double y) {ay = y;}
        void cornerX2(double x) {bx = x;}
        void cornerY2(double y) {by = y;}
        void cornerX3(double x) {cx = x;}
        void cornerY3(double y) {cy = y;}
        
        double cornerX1() {return ax;}
        double cornerY1() {return ay;}
        double cornerX2() {return bx;}
        double cornerY2() {return by;}
        double cornerX3() {return cx;}
        double cornerY3() {return cy;}
        
        //functions
        public override void move(double dx, double dy) {
            ax += dx;
            bx += dx;
            bx += dx;
            ay += dy;
            by += dy;
            cy += dy;
        }
        public override void render() {
            Console.WriteLine("Triangle(" + Enum.GetName(typeof(Color), color()) + "," + ax + "," + ay + "," + bx + "," + by + "," + cx + "," + cy + ")");
        }

        public override double perimeter() {
            return ((Math.Sqrt(Math.Pow((ax - bx), 2) + Math.Pow((ay -by), 2))) + (Math.Sqrt(Math.Pow((bx - cx), 2) + Math.Pow((by - cy), 2))) + (Math.Sqrt(Math.Pow((cx - ax), 2) + Math.Pow((cy - ay), 2))));
        }
        public override double area() {
            return (Math.Abs((ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)) / 2));
        }
        
    }
    static class Program
    {
        static void Main()
        {
            double[] pts = {1,1,7,2,3,5,6,8,4,3};
            Shape[] listOfShapes = new Shape[10];
            int count = 0;
            listOfShapes[count++] = new Box(Color.BLUE, 0, 1, 1, 0);
            listOfShapes[count++] = new Box(Color.CYAN, 2, 9, 4, 3);
            listOfShapes[count++] = new Circle(Color.WHITE, 5, 5, 3);
            listOfShapes[count++] = new Triangle(Color.BLACK, 1, 1, 5, 1, 3, 3);
            listOfShapes[count++] = new Polygon(Color.GREEN, pts, 5);

            double distance = 0;
            double area = 0;

            for (int i = 0; i < count; i++)
            {
                distance += listOfShapes[i].perimeter();
                area += listOfShapes[i].area();
                listOfShapes[i].render();
            }

            for (int i = 0; i < count; i++)
            {
                listOfShapes[i].move(10, 10);
                listOfShapes[i].render();
            }

            Console.WriteLine("distance: " + distance + " area: " + area + "\n");

        }
    }
}
