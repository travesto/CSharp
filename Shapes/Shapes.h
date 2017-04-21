#include <iostream>
//color at point is static
enum Color {BLACK, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, WHITE, INVALID}; //enum for color

//Shape
class Shape 
{
    public:
        Shape(Color colour) : c(colour) {}
        virtual ~Shape() {};
        //color getters and setters
        Color color() const {return c;} //color getter
        void color(Color colour) {c = colour;} //color setter 
        //shape func
        virtual void move(double dx, double dy) = 0; //shifts entire shape by dx,dy
        virtual double area() const = 0; //calculates area
        virtual double perimeter() const  = 0; //calculates perimeter
        virtual void render(std::ostream &os) const = 0; //diplays shape details
        virtual bool inside(double dx, double dy) const = 0; //if x,y is within a shape perim
        double thickness() const {return area()/perimeter();} //area / perim
        static Color colorAtPoint(Shape* array[], int num, double x, double y); // return the color of a shape at the point if there is a shape
    private:
        //member variables
        Color c;
        Shape(const Shape& other); //disallow copy ctor
        void operator=(const Shape& other); //disallow equivalence
};
//makes a box w/rounded eges
class RoundBox : public Shape
{
    public:
        RoundBox(Color colour, double left, double top, double right, double bottom, double rad); //ctor
        //getters and setters
        double left() const;
        double top() const;
        double right() const;
        double bottom() const;
        double radius() const;
        void left(double l);
        void top(double t);
        void right(double r);
        void bottom(double b);
        void radius(double rad);
        //others
        void render(std::ostream &os) const; //writes out rbox characteristics
        void move(double dx, double dy); //moves the entire shape by xy coord
        double area() const; //calculates area shape
        double perimeter() const; //calculates perim
        bool inside(double dx, double dy) const; //test if x,y is within a shape perim
    private:
        double l, t, r, b, rad; //sides of rbox and rad of corners
    
};
class Line : public Shape
{
    public:
        Line(Color colour, double leftx, double lefty, double rightx, double righty); //ctor
        //getters and setters
        double end1X() const;
        double end1Y() const;
        double end2X() const;
        double end2Y() const;
        void end1X(double lx);
        void end1Y(double ly);
        void end2X(double rx);
        void end2Y(double ry);
        //other funcs
        double area() const; //calculates area of shape
        void render(std::ostream &os) const; //writes out shape characterisitics
        void move(double dx, double dy); //shifts entire shape by xy
        double perimeter() const; // calculates distance between ends 
        bool inside(double dx, double dy) const; //test if x,y is within a shape perim (n/a for line)
    private:
        double left_x, left_y, right_x, right_y;
};
class Polygon : public Shape
{
    public:
        //cosntructor & destructor
        Polygon(Color colour, double* pts,int v);
        ~Polygon();
        //setters and getters
        double vertexX(int place) const;
        double vertexY(int place) const;
        void vertexX(int place, double coord);
        void vertexY(int place, double coord);
        int points() const;
        //poly funcs
        void move(double dx, double dy); // shift entire shape by xy
        double area() const; //calculates area
        double perimeter() const; //calculates perim
        void render(std::ostream &os) const; //writes shape characteristics
        bool inside(double dx, double dy) const; //test if x,y is within a shape perim
    private:
        double* vertices; //array of xy coords
        int vcount; //# vertices
};
class Box : public Shape
{
    public:
        Box(Color colour, double left, double top, double right, double bottom); //ctor
        //getters and setters
        double left() const;
        double top() const;
        double right() const;
        double bottom() const;
        void left(double l);
        void top(double t);
        void right(double r);
        void bottom(double b);
        //box funcs
        void render(std::ostream &os) const; //writes shape characteristics
        void move(double dx, double dy); //shifts shape by xy
        double area() const; //calculates area
        double perimeter() const; //calculates perim
        bool inside(double dx, double dy) const; //tests if x,y is within a shape perim
    private:
        double l, r, t, b;
};
class Circle : public Shape //makes a circle
{
    public:
        Circle(Color colour, double x, double y, double r); //ctor
        double centerX() const;//get x
        void centerX(double x); //set x
        double centerY() const;//get y
        void centerY(double y); //set y
        double radius() const;//get radius
        void radius(double r); //set rad
        void move(double dx, double dy);
        //circle funcs
        double area() const; //calc area
        double perimeter() const; //calc perim
        void render(std::ostream &os) const; //writes shape characteristics
        bool inside(double dx, double dy) const; //if x,y is within a shape perim
    private:
        double center_x, center_y, rad;
};
class Triangle : public Shape
{
    public:
        Triangle(Color colour, double corner1a, double corner1b, double corner2a, double corner2b, double corner3a, double corner3b); //ctor
        //triangle getters
        double cornerX1() const;
        double cornerY1() const;
        double cornerX2() const;
        double cornerY2() const;
        double cornerX3() const;
        double cornerY3() const;
        //triangle setters
        void cornerX1(double corner1a);
        void cornerY1(double corner1b);
        void cornerX2(double corner2a);
        void cornerY2(double corner2b);
        void cornerX3(double corner3a);
        void cornerY3(double corner3b);
        //others
        void move(double dx, double dy); //shift shape by xy
        double area() const; //calc area
        double perimeter() const; //calc perim
        void render(std::ostream &os) const; //writes shape characteristics
        bool inside(double dx, double dy) const; //if x,y is within a shape perim
    private:
        double corner1a, corner1b, corner2a, corner2b, corner3a, corner3b;
};