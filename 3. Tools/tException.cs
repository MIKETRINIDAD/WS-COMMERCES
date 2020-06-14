using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class daException : Exception
{
    public daException() { }
    public daException(String message) : base(message) { }
    public daException(Exception ex) : base(ex.Message, ex) { }
}

[Serializable]
public class blException : Exception
{
    public blException() { }
    public blException(String message) : base(message) { }
    public blException(Exception ex) : base(ex.Message, ex) { }
}

[Serializable]
public class clException : Exception
{
    public clException() { }
    public clException(String message) : base(message) { }
    public clException(Exception ex) : base(ex.Message, ex) { }
}

[Serializable]
public class mvwException : Exception
{
    public mvwException() { }
    public mvwException(String message) : base(message) { }
    public mvwException(Exception ex) : base(ex.Message, ex) { }
}

[Serializable]
public class rException : Exception
{
    public rException() { }
    public rException(String message) : base(message) { }
    public rException(Exception ex) : base(ex.Message, ex) { }
}
