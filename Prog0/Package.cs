//Grading ID: D2575
//Program 1A
//Due 10/11/26
//Section 76
/*Description: This is an abstract class that will be use in the construction of the GroudPackage class, and AirPackage class.
 * This class uses all of Parcel's properties, as well as adding heigh, length, width, and weight. This class also contains
 *a ToString method that will be used to return all of a Package's properties to a string.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Package : Parcel
{
    //Package backing fields
    private double _height = 0;
    private double _length = 0;
    private double _width = 0;
    private double _weight = 0;
    private const double MIN_HLWW = 0; // minumum height, length, width, and weight
    private const double MAX_HLWW = 9999; //max height, length, width, and weight 

     //Package constructor
     //precondition
     //height > 0
     //length > 0
     //width > 0
     //weight > 0
     //postcondition: the package is created with the height, length, width, weight, originAddress
     //and destAddress specified in the constructor.
    public Package(double height, double length, double width, double weight,
        Address originAddress, Address destAddress)
        : base(originAddress, destAddress)
    {
        Height = height;
        Length = length;
        Width = width;
        Weight = weight;
    }

    // Properties
    //precondition:  height > 0
    //postcondition: the property Height will return the height of the package or set the height if
    //the preconditions are met
    public double Height
    {
        //precondition: none
        //postcondition: returns the height of the package
        get { return _height; }
        //precondition: height > 0
        //postcondition: sets the height of the package, or throws an exception
        set
        {
            if (value > MIN_HLWW && value < MAX_HLWW)
            { _height = value; }
            else
            { throw new ArgumentOutOfRangeException("Please enter a Height graeter than 0, and less than" + MAX_HLWW); }
        }
    }

    //precondition: length > 0
    //postcondition: the property Length will return the length of the package or set the length if
    //the preconditions are met
    public double Length
    {
        //precondition: none
        //postcondition: returns the length of the package
        get { return _length; }
        //precondition: length > 0
        //postcondition: sets the length of the package or throws an exception
        set
        {
            if (value > MIN_HLWW && value < MAX_HLWW)
            { _length = value; }
            else
            { throw new ArgumentOutOfRangeException("Please enter a Length greater than 0, and less than " + MAX_HLWW); }
        }
    }

    //precondition: width > 0
    //postcondition: the property Width will return the width of the package or set the width if
    //the preconditions are met
    public double Width
    {
        //precondition: none
        //postcondition: returns the width of the package
        get { return _width; }
        //precondition: width > 0
        //postcondition: sets the width of the package or throws exception
        set
        {
            if (value > MIN_HLWW && value < MAX_HLWW)
            { _width = value; }
            else
            { throw new ArgumentOutOfRangeException("Please enter a Width greater than 0, and less than " + MAX_HLWW); }
        }
    }
    //precondition: weight > 0
    //postcondition: the property Weight will return the weight of the package or set the weight if
    //the preconditions are met
    public double Weight
    {
        //precondition: none
        //postcondition: returns the weight of the package
        get { return _weight; }
        //precondition: weight > 0
        //postcondtion: set the weight of the package or throws an exception
        set
        {
            if (value > MIN_HLWW && value <= MAX_HLWW)
            { _weight = value; }
            else
            { throw new ArgumentOutOfRangeException("Please enter a Weight greater than 0, and less than " + MAX_HLWW); }
        }
    }

    //precondition: none
    //postcondition: sends everything from the base class, as well as height, length, width, and weight to a string
    public override string ToString()
    {
        return string.Format("{0}, Height: {1}, Length: {2}, Width: {3}, Weight: {4}", base.ToString(), Height, Length, Width, Weight);
    }

}
