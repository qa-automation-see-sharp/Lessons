// Useful links:
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types

// This program demonstrates the use of numeric data types in C#

// sbyte from -128 to 127

sbyte mySbyte;
mySbyte = 105;
var mySbyte2 = 105;
var mySbyte3 = (sbyte)105;
Console.WriteLine($"Sbyte max value is {sbyte.MaxValue}, min value is {sbyte.MinValue}");

// byte from 0 to 255
byte myByte;
myByte = 255;
var myByte2 = 255;
var myByte3 = (byte)255;
Console.WriteLine($"Byte max value is {byte.MaxValue}, min value is {byte.MinValue}");

// short from -32,768 to 32,767
short myShort;
myShort = 31989;
var myShort2 = 31989; // Int32
var myShort3 = (short)31989;
Console.WriteLine($"Short max value is {short.MaxValue}, min value is {short.MinValue}");

// ushort from 0 to 65,535
ushort myUshort;
myUshort = 65535;
var myUshort2 = 65535; // Int32
var myUshort3 = (ushort)65535;
Console.WriteLine($"Ushort max value is {ushort.MaxValue}, min value is {ushort.MinValue}");

// int from -2,147,483,648 to 2,147,483,647
int myInt;
myInt = 2147483647;
var myInt2 = 2147483647; // Int32
var myInt3 = (int)2147483647;
int myCoolInt = 5;
//int myCoolInt2 = 5.5;
Console.WriteLine($"Int max value is {int.MaxValue},  min value is {int.MinValue}");

// uint from 0 to 4,294,967,295
uint myUint;
myUint = 4294967295;
var myUint2 = -4294967295; // Long or Int64
Console.WriteLine($"Uint max value is {uint.MaxValue}, min value is {uint.MinValue}");

long myLong; // long from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
myLong = 9223372036854775807;
var myLong2 = 9223372036854775807; //Long or Int64
var myLong3 = (long)9223372036854775807;
Console.WriteLine($"Long max value is {long.MaxValue}, min value is {long.MinValue}");

// ulong from 0 to 18,446,744,073,709,551,615
ulong myUlong;
myUlong = 18446744073709551615;
var myUlong2 = 18446744073709551615; // ULong or UInt64
var myUlong4 = (ulong)18446744073709551615;
var myUlong3 = -18446744073709551615d; // Decimal
Console.WriteLine($"Ulong max value is {ulong.MaxValue},  min value is {ulong.MinValue}");

nint myNint; // nint depends on platform (computed at runtime)
myNint = (nint)9223372036854775807;
var myNint2 = 9223372036854775807; // Int64
var myNint3 = (nint)9223372036854775807; // IntPtr
Console.WriteLine($"Nint max value is {nint.MaxValue}, min value is {nint.MinValue}");

nuint myNuint; // nuint depends on platform (computed at runtime)
myNuint = 125;
var myNuint2 = 125; // Int32
var myNuint3 = (nuint)125; // UIntPtr
Console.WriteLine($"Nuint max value is {nuint.MaxValue}, min value is {nuint.MinValue}");

// Action with numeric types
int sum = 5 + 10;
Console.WriteLine($"5 + 10 = {sum}");
int difference = 5 - 10;
Console.WriteLine($"5 - 10 = {difference}");
int product = 5 * 10;
Console.WriteLine($"5 * 10 = {product}");

// Why is this 0?
int quotient = 5 / 10;
Console.WriteLine($"5 / 10 = {quotient}");

// Why is this 1?
int quotient2 = 15 / 10;
Console.WriteLine($"15 / 10 = {quotient2}");


int coolInt = 6;
sbyte coolSbyte = 3;
var sum2 = coolInt + coolSbyte;
//sbyte sum3 = coolInt + coolSbyte; Error, why is that?
Console.WriteLine($"Sum of int {coolInt}and sbyte {coolSbyte} is " + sum2);