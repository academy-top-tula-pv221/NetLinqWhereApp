using ExampleClassLibrary;

var users = new List<User>()
{
    new("Sam", 23),
    new("Bob", 31),
    new("Tim", 29),
    new("Joe", 42),
    new("Leo", 35),
};

List<City> cities = new()
{
    new(){ Title = "Orel", Citizens = 300000 ,Streets = new List<string> {"Lenina", "Kutuzova"}},
    new(){ Title = "Tula", Citizens = 600000, Streets = new List<string> {"Boldina", "9 Maya"}},
    new(){ Title = "Moscow", Citizens = 10000000, Streets = new List<string> {"Smirnova", "Lenina"}},
    new(){ Title = "Kaluga", Citizens = 100000, Streets = new List<string> {"Lenina", "Pobedy"}},
};

var shapes = new List<Shape>()
{
    new Shape("Shape 1"),
    new Rectangle("Rectangle 1"),
    new Circle("Circle 1"),
    new Shape("Shape 2"),
    new Rectangle("Rectangle 2"),
    new Circle("Circle 2"),
};


var users30O = from u in users
               where u.Age > 30
               select u;

var users30M = users.Where(u => u.Age > 30);

var users30DO = from u in users
                where u.Age > 30
                where u.Name?.CompareTo("D") > 0
                select u;

var users30DM = users.Where(u => u.Age > 30 && u.Name?.CompareTo("D") > 0);

//foreach (var user in users30DM)
//    Console.WriteLine($"User name {user.Name}, age: {user.Age}");


var citiesLeninaO = from c in cities
                    from s in c.Streets!
                    where c.Citizens > 200000
                    where s.ToLower().Equals("lenina")
                    select c;

var citiesLeninaM = cities.SelectMany(
                                c => c.Streets!,
                                (c, s) => new { City = c, Street = s }
                            )
                           .Where(o => o.City.Citizens > 200000 && o.Street == "Lenina")
                           .Select(o => o.City);

//foreach(var c in citiesLeninaM)
//    Console.WriteLine($"title: {c.Title}, count: {c.Citizens}");

//var shapesTypeM = shapes.OfType<Shape>();

var shapesTypeO = from s in shapes
                  //where s.GetType() == typeof(Shape)
                  where (s is Shape)
                  select s;

foreach(Shape shape in shapesTypeO)
    Console.WriteLine(shape.Title);
class City
{
    public string? Title { set; get; }
    public int Citizens { set; get; }
    public List<string>? Streets { set; get; }
}

record Shape(string Title);
record Rectangle(string Title) : Shape(Title);
record Circle(string Title) : Shape(Title);

