function Event()
{
    this.NamedKeys = new Object();
    this.NamedFunctions = new Array();
    this.AnonymousFunctions = new Array();
    
    this.add = function(key, value)
    {
        if (key == "")
        {
            this.AnonymousFunctions.push(value);
        }
        else
        {
            var current = this.NamedFunctions.length;
            this.NamedKeys[key] = current;
            this.NamedFunctions.push(value);
        }
    }
    
    this.remove = function(key)
    {
        if (typeof(this.NamedKeys[key]) == "number")
        {
            var index = this.NamedKeys[key];
            this.NamedFunctions.splice(index, 1);
        }
    }
    
    this.execute = function()
    {
        var paraNumber = arguments.length;
        for (i = 0; i < this.NamedFunctions.length; i++)
        {
            this.NamedFunctions[i].apply(this, arguments);
        }
        for (i = 0; i < this.AnonymousFunctions.length; i++)
        {
            this.AnonymousFunctions[i].apply(this, arguments);
        }
    }
};

var e = new Event();
var namedFunction = function(a, b){document.write(a + b);};

e.add("namedFunction", namedFunction);
e.add("", function(a, b){document.write(a - b);});
e.execute();

e.remove("namedFunction");
e.execute();

e.add("", function(a, b){document.write(a * b);});
e.execute();