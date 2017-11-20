//Grading ID: D2575
//Program 1A
//Due 10/11/26
//Section 76
/*This is a n abstract class that is used to create AirPackages (there will be no direct AirPackage objects) using the Package class as it's base. 
 * The AirPackage class has the new properties of IsHeavy and IsLarge which are bools, and are used to determine
 * added costs in shipping AirPackages. There is also a ToString method that returns all of the AirPackage properties to a string.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class AirPackage : Package
{
    private const byte MIN_HEAVY = 75;
    private const byte MIN_LARGE = 100;
    //constructor

    //precondition: 
    //height > 0
    //length > 0
    //width > 0
    //weight > 0 
    //postcondition: creates an air package with the height, length, width, weight, originAddress
    //and destAddress specified in the constructor.
    public AirPackage(double height, double width, double length,
        double weight, Address originAddress, Address destAddress)
        : base(height, width, length, weight, originAddress, destAddress)
    {

    }

    //methods

    //precondition: none
    //postcondition: returns true if the opject has a weight greater than or equal to 75 lbs, false if less.
    public bool IsHeavy()
    {
        if (Weight >= MIN_HEAVY)
        { return true; }
        else
        { return false; }
    }

    //precondition: none
    //postcondition: returns true if the package length + width + height is greater than or equal to 100
    //returns false if less than 100.
    public bool IsLarge()
    {
        if (Length + Width + Height >= MIN_LARGE)
        { return true; }
        else
        { return false; }
    }

    //precondition: none
    //postcondition: returns whether of not the package is heavy and/or large, as well as all the properties and methods
    //from the base class as a string.
    public override string ToString()
    {
        return string.Format("Heavy: {0} {3}Large: {1} {3}{2} {3}", IsHeavy(), IsLarge(), base.ToString(), Environment.NewLine);
    }

}
