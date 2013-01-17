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
