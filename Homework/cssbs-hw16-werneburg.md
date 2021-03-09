# C Sharp Homework 16

-- Dakin Werneburg   
-- MSSA Cloud Application Developer Certification   
-- 3/4/2021

---
## 1. Give five examples (using valid C# code) of the five bitwise operators listed in the text.

```c#

    uint number = 0;
    uint example1 = ~number;     // NOT(~): result will be 4,294,967,295
    unit example2 =  (4 << 2);   // Left-Shift(<<):  result will be 16;
    uint example3 = 2 | 4;       // OR(|): result will be 6.
    unit example4 = 2 & 4;       // AND(&): result will be 0.
    unit example5 = 2 ^ 4;       // XOR(^): result will be 6.

```

## 2. Does C# implement the right-shift (>>) operator? If so, give an example of its operation using valie C# code.
- Yes. It performs the same logic as Left-Shift, but moves the bits to the right.

```c# 

    uint example = 0b0_00001111;  // 16 base 10
    example = example >> 2        // example results to 3 base 10, or 0b0_00000011
```

## 3. Explain in detail this code: bits & (1 << index);.

- The binary representation of the number "1" has its bits shifted left by what ever the value of index is.  It then compares each of the "bits" variable binary representation with this new value and the assign a one if they are both a one.    

## 4. Explain in detail this code: bits |= (1 << index);.
- - The binary representation of the number "1" has its bits shifted left by what ever the value of index is.  It then compares each of the "bits" variable binary representation with this new value and the assign a one either of them is a one and zero if they are both zero.  


## 5. Explain in detail this code: bits &= (1 << index);.
- Same as Question3 but it assigns the value of calculation to the bits variable.

## 6. How does C# interpret this? bool peek = bits[n];

- It will retrieve the boolean value located at the nth index of the bits indexer.

## 7. How does C# interpret this? bits[n] = true;
- It will assign true to the nth index of the bits indexer

## 8. How does C# interpret this? bits[n] ^= true;

= It will assign a true if the nth position of the bits indexer is the opposite from what is being assigned.  In this case it will assign true only if the nth position is false.

## 9. Assume that users were assigned read, write, and execute permissions according to this scheme: read = 1, write = 2, execute = 4. How would you interpret the following user permissions:
> (a) permission = 0  // has no permission at all.
> (b) permission = 1  // only has permission to read.
> (c) permission = 2  // only has permission to write.
> (d) permission = 3  // has read and write permission.
> (e) permission = 4  // only has permission to execute.
> (f) permission = 5  // has read and execute permission.
> (g) permission = 6  // has write and execute permission.
> (h) permission = 7  // has all permissions.

## 10. Answer the previous question by converting the decimal permissions into binary permissions. What does this tell you about using this scheme of permissions?

> (a) permission = 0  // 0000
> (b) permission = 1  // 0001
> (c) permission = 2  // 0010
> (d) permission = 3  // 0011
> (e) permission = 4  // 0100
> (f) permission = 5  // 0101
> (g) permission = 6  // 0110
> (h) permission = 7  // 0111

You could assign a permission to a binary position and turn on and off that permission with a 1 or 0 value.  This is a good example of treating a number as an array of permissions or indexers in C#.