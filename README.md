unicode-hax
===========

A library to assist in testing and hacking Unicode enabled applications. 

Major features: 
- best fit mappings 
- Unicode normalization mappings 

For fuzzing applications it includes: 
- ill-formed byte sequences 
- non-characters
- private use area (PUA)
- unassigned code points 
- code points with special meaning such as the BOM and RLO 
- half-surrogate values

/TestUniHax
-----------
This Windows form application loads the UniHax library mainly to test the best-fit and normalization mappings.  
If you simply input a single ASCII character, all of its equivalent characters will be displayed.  

e.g. If you're testing a Web-application and want to test equivalents for the "<" character U+003C, 
enter that as input and select either "best-fit mapping", which is linked to a charset encoding,
or "normalization" equivalents.  For this character, the following are best-fits:

U+003B in the APL-ISO-IR-68 encoding
U+0014 in the CP424 encoding
etc...

Also, the following are normalization decomposition mappings:
U+FE64 SMALL LESS-THAN SIGN
U+FF1C FULLWIDTH LESS-THAN SIGN

/UniHax
-------
This library contains static Unicode characters in **Fuzzer.cs**, as well as the following method to return 
those characters as a byte array in any encoding.  

```csharp
public byte[] GetCharacterBytes(string encoding, string character)
```

There's also the following method to return any Unicode character as a malformed byte sequence, simply by 
trimming the last byte.

```csharp
public byte[] GetCharacterBytesMalformed(string encoding, string character)
```

This project also contains the data files, pre-created in the __/data__ folder, and a __Mapping.cs__ Mapping 
class which can lookup mapping equivalents.
