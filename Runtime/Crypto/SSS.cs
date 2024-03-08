using System;
using System.Collections.Generic;

namespace Openfort.Crypto
{
    using System.Security.Cryptography;
    using System.Text;

    public class ShamirSecretSharing
    {
        public static string[] SplitPrivateKey(string secret, int shares, int threshold)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            // secret must be a non-empty UTF-8 byte array
            if (secretBytes.Length == 0)
            {
                throw new ArgumentException("Secret cannot be empty");
            }
         
            // shares must be a number in the range [2, 256)
            if (shares is < 2 or >= 256)
            {
                throw new ArgumentException("Shares must be in the range [2, 256)");
            }
        
            // threshold must be a number in the range [2, 256)
            if (threshold is < 2 or >= 256)
            {
                throw new ArgumentException("Threshold must be in the range [2, 256)");
            }
        
        
            // total number of shares must be greater than or equal to the required threshold
            if (shares < threshold)
            {
                throw new ArgumentException("Total number of shares must be greater than or equal to the required threshold");
            }
        
            var result = new byte[shares][];
            var secretLength = secretBytes.Length;
            var xCoordinates = NewCoordinates();
        
            for (var i = 0; i < shares; i++)
            {
                var share = new byte[secretLength + 1];
                share[secretLength] = xCoordinates[i];
                result[i] = share;
            }
        
            var degree = threshold - 1;
        
            for (var i = 0; i < secretLength; i++)
            {
                var secretByte = secretBytes[i];

                var coefficients = NewCoefficients(secretByte, degree);

                for (var j = 0; j < shares; j++)
                {
                    var x = xCoordinates[j];
                    var y = Evaluate(coefficients, x, degree);
                    result[j][i] = y;
                }
            }

            var resultStrings = new string[shares];
            for (var i = 0; i < shares; i++)
            {
                resultStrings[i] = result[i].ToHex();
            }
            return resultStrings;
        }
    
        public static string CombinePrivateKey(string[] shares)
        {
            var sharesLength = shares.Length;
            var sharesBytes = new byte[sharesLength][];
            for (var i = 0; i < sharesLength; i++)
            {
                sharesBytes[i] = shares[i].FromHex();
            }
        
            // Shares must be an array with length in the range [2, 256)
            if (sharesBytes.Length is < 2 or >= 256)
            {
                throw new ArgumentException("Shares must be an array with length in the range [2, 256)");
            }
       
            // Shares must be a Uint8Array with at least 2 bytes and all shares must have the same byte length.
            foreach (var share in sharesBytes)
            {
                if (share.Length < 2)
                {
                    throw new ArgumentException("Each share must be at least 2 bytes");
                }
                if (share.Length != sharesBytes[0].Length)
                {
                    throw new ArgumentException("All shares must have the same byte length");
                }
            }

            var shareLength = sharesBytes[0].Length;
        
        
            // This will be our reconstructed secret
            var secretLength = shareLength - 1;
            var secret = new byte[secretLength];
        
            var xSamples = new byte[sharesLength];
            var ySamples = new byte[sharesLength];
        
            var samples = new HashSet<int>();
            for (var i = 0; i < sharesLength; i++)
            {
                var share = sharesBytes[i];
                int sample = share[shareLength - 1];

                // The last byte of each share should be a unique value between 1-255 inclusive.
                if (samples.Contains(sample))
                {
                    throw new InvalidOperationException("Shares must contain unique values but a duplicate was found");
                }

                samples.Add(sample);
                xSamples[i] = (byte)sample;
            }

            for (var i = 0; i < secretLength; i++)
            {
                // Set the y value for each sample
                for (var j = 0; j < sharesLength; j++)
                {
                    ySamples[j] = sharesBytes[j][i];
                }

                // Interpolate the polynomial and compute the value at 0
                secret[i] = InterpolatePolynomial(xSamples, ySamples, 0);
            }

            return Encoding.UTF8.GetString(secret);
        }
    
    
        // Creates a set of values from [1, 256).
        // Returns a psuedo-random shuffling of the set.
        private static byte[] NewCoordinates()
        {
            var coordinates = new byte[255];
            for (var i = 0; i < 255; i++)
            {
                coordinates[i] = (byte)(i + 1);
            }  
        
            // Pseudo-randomize the array of coordinates.
            //
            // This impl maps almost perfectly because both of the lists (coordinates and randomIndices)
            // have a length of 255 and byte values are between 0 and 255 inclusive. The only value that
            // does not map neatly here is if the random byte is 255, since that value used as an index
            // would be out of bounds. Thus, for bytes whose value is 255, wrap around to 0.
            var randomIndices = GetRandomBytes(255);
            for (var i = 0; i < 255; i++)
            {
                var j = randomIndices[i] % 255; // Make sure to handle the case where the byte is 255.
                (coordinates[i], coordinates[j]) = (coordinates[j], coordinates[i]);
            }

            return coordinates;
        }
    
        private static byte[] NewCoefficients(byte intercept, int degree)
        {
            var coefficients = new byte[degree + 1];

            // The first byte is always the intercept
            coefficients[0] = intercept;

            for (var i = 1; i <= degree; i++)
            {
                // degree is equal to t-1, where t is the threshold of required shares.
                // The coefficient at t-1 cannot equal 0.
                var coefficientTMinus1 = i == degree;
                coefficients[i] = coefficientTMinus1 ? GetNonZeroRandomByte() : GetRandomByte();
            }

            return coefficients;
        }

    
        private static byte[] GetRandomBytes(int numBytes)
        {
            var randomBytes = new byte[numBytes];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return randomBytes;
        }
    
        private static byte GetRandomByte()
        {
            var randomBytes = GetRandomBytes(1);
            return randomBytes[0];
        }
    
        private static byte GetNonZeroRandomByte()
        {
            while (true)
            {
                var randomByte = GetRandomByte();
                if (randomByte > 0)
                {
                    return randomByte;
                }
            }
        }
    
    
        // Takes N sample points and returns the value at a given x using a lagrange interpolation.
        private static byte InterpolatePolynomial(byte[] xSamples, byte[] ySamples, byte x)
        {
            if (xSamples.Length != ySamples.Length)
            {
                throw new InvalidOperationException("Sample length mismatch");
            }

            var limit = xSamples.Length;
            byte result = 0;

            for (var i = 0; i < limit; i++)
            {
                byte basis = 1;

                for (var j = 0; j < limit; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var num = Add(x, xSamples[j]);
                    var denom = Add(xSamples[i], xSamples[j]);
                    var term = Div(num, denom);
                    basis = Mult(basis, term);
                }

                result = Add(result, Mult(ySamples[i], basis));
            }

            return result;
        }
    
        // Evaluates a polynomial with the given x using Horner's method.
        private static byte Evaluate(byte[] coefficients, byte x, int degree)
        {
            if (x == 0)
            {
                throw new Exception("Cannot evaluate secret polynomial at zero");
            }

            var result = coefficients[degree];

            for (var i = degree - 1; i >= 0; i--)
            {
                var coefficient = coefficients[i];
                result = Add(Mult(result, x), coefficient);
            }

            return result;
        }


        // Combines two numbers in GF(2^8).
        // This can be used for both addition and subtraction.
        private static byte Add(byte a, byte b)
        {
            return (byte)(a ^ b);
        }
    
        // Multiplies two numbers in GF(2^8).
        private static byte Mult(byte a, byte b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }

            var logA = LogTable[a];
            var logB = LogTable[b];
            var sum = (byte)((logA + logB) % 255);
            var result = ExpTable[sum];

            return result;
        }
    
    
        // Divides two numbers in GF(2^8).
        private static byte Div(byte a, byte b)
        {
            // This should never happen
            if (b == 0)
            {
                throw new InvalidOperationException("Cannot divide by zero");
            }

            int logA = LogTable[a];
            int logB = LogTable[b];
            var diff = (logA - logB + 255) % 255;
            var result = ExpTable[diff];

            return (byte)(a == 0 ? 0 : result);
        }

    
        // The Polynomial used is: x⁸ + x⁴ + x³ + x + 1
        //
        // Lookup tables pulled from:
        //
        //     * https://github.com/hashicorp/vault/blob/9d46671659cbfe7bbd3e78d1073dfb22936a4437/shamir/tables.go
        //     * http://www.samiam.org/galois.html
        //
        // 0xe5 (229) is used as the generator.

        // Provides log(X)/log(g) at each index X.
        private static readonly byte[] LogTable = new byte[]
        {
            0x00, 0xff, 0xc8, 0x08, 0x91, 0x10, 0xd0, 0x36, 0x5a, 0x3e, 0xd8, 0x43, 0x99, 0x77, 0xfe, 0x18,
            0x23, 0x20, 0x07, 0x70, 0xa1, 0x6c, 0x0c, 0x7f, 0x62, 0x8b, 0x40, 0x46, 0xc7, 0x4b, 0xe0, 0x0e,
            0xeb, 0x16, 0xe8, 0xad, 0xcf, 0xcd, 0x39, 0x53, 0x6a, 0x27, 0x35, 0x93, 0xd4, 0x4e, 0x48, 0xc3,
            0x2b, 0x79, 0x54, 0x28, 0x09, 0x78, 0x0f, 0x21, 0x90, 0x87, 0x14, 0x2a, 0xa9, 0x9c, 0xd6, 0x74,
            0xb4, 0x7c, 0xde, 0xed, 0xb1, 0x86, 0x76, 0xa4, 0x98, 0xe2, 0x96, 0x8f, 0x02, 0x32, 0x1c, 0xc1,
            0x33, 0xee, 0xef, 0x81, 0xfd, 0x30, 0x5c, 0x13, 0x9d, 0x29, 0x17, 0xc4, 0x11, 0x44, 0x8c, 0x80,
            0xf3, 0x73, 0x42, 0x1e, 0x1d, 0xb5, 0xf0, 0x12, 0xd1, 0x5b, 0x41, 0xa2, 0xd7, 0x2c, 0xe9, 0xd5,
            0x59, 0xcb, 0x50, 0xa8, 0xdc, 0xfc, 0xf2, 0x56, 0x72, 0xa6, 0x65, 0x2f, 0x9f, 0x9b, 0x3d, 0xba,
            0x7d, 0xc2, 0x45, 0x82, 0xa7, 0x57, 0xb6, 0xa3, 0x7a, 0x75, 0x4f, 0xae, 0x3f, 0x37, 0x6d, 0x47,
            0x61, 0xbe, 0xab, 0xd3, 0x5f, 0xb0, 0x58, 0xaf, 0xca, 0x5e, 0xfa, 0x85, 0xe4, 0x4d, 0x8a, 0x05,
            0xfb, 0x60, 0xb7, 0x7b, 0xb8, 0x26, 0x4a, 0x67, 0xc6, 0x1a, 0xf8, 0x69, 0x25, 0xb3, 0xdb, 0xbd,
            0x66, 0xdd, 0xf1, 0xd2, 0xdf, 0x03, 0x8d, 0x34, 0xd9, 0x92, 0x0d, 0x63, 0x55, 0xaa, 0x49, 0xec,
            0xbc, 0x95, 0x3c, 0x84, 0x0b, 0xf5, 0xe6, 0xe7, 0xe5, 0xac, 0x7e, 0x6e, 0xb9, 0xf9, 0xda, 0x8e,
            0x9a, 0xc9, 0x24, 0xe1, 0x0a, 0x15, 0x6b, 0x3a, 0xa0, 0x51, 0xf4, 0xea, 0xb2, 0x97, 0x9e, 0x5d,
            0x22, 0x88, 0x94, 0xce, 0x19, 0x01, 0x71, 0x4c, 0xa5, 0xe3, 0xc5, 0x31, 0xbb, 0xcc, 0x1f, 0x2d,
            0x3b, 0x52, 0x6f, 0xf6, 0x2e, 0x89, 0xf7, 0xc0, 0x68, 0x1b, 0x64, 0x04, 0x06, 0xbf, 0x83, 0x38,
        };
    
    
        // Provides the exponentiation value at each index X.
        private static readonly byte[] ExpTable = new byte[]
        {
            0x01, 0xe5, 0x4c, 0xb5, 0xfb, 0x9f, 0xfc, 0x12, 0x03, 0x34, 0xd4, 0xc4, 0x16, 0xba, 0x1f, 0x36,
            0x05, 0x5c, 0x67, 0x57, 0x3a, 0xd5, 0x21, 0x5a, 0x0f, 0xe4, 0xa9, 0xf9, 0x4e, 0x64, 0x63, 0xee,
            0x11, 0x37, 0xe0, 0x10, 0xd2, 0xac, 0xa5, 0x29, 0x33, 0x59, 0x3b, 0x30, 0x6d, 0xef, 0xf4, 0x7b,
            0x55, 0xeb, 0x4d, 0x50, 0xb7, 0x2a, 0x07, 0x8d, 0xff, 0x26, 0xd7, 0xf0, 0xc2, 0x7e, 0x09, 0x8c,
            0x1a, 0x6a, 0x62, 0x0b, 0x5d, 0x82, 0x1b, 0x8f, 0x2e, 0xbe, 0xa6, 0x1d, 0xe7, 0x9d, 0x2d, 0x8a,
            0x72, 0xd9, 0xf1, 0x27, 0x32, 0xbc, 0x77, 0x85, 0x96, 0x70, 0x08, 0x69, 0x56, 0xdf, 0x99, 0x94,
            0xa1, 0x90, 0x18, 0xbb, 0xfa, 0x7a, 0xb0, 0xa7, 0xf8, 0xab, 0x28, 0xd6, 0x15, 0x8e, 0xcb, 0xf2,
            0x13, 0xe6, 0x78, 0x61, 0x3f, 0x89, 0x46, 0x0d, 0x35, 0x31, 0x88, 0xa3, 0x41, 0x80, 0xca, 0x17,
            0x5f, 0x53, 0x83, 0xfe, 0xc3, 0x9b, 0x45, 0x39, 0xe1, 0xf5, 0x9e, 0x19, 0x5e, 0xb6, 0xcf, 0x4b,
            0x38, 0x04, 0xb9, 0x2b, 0xe2, 0xc1, 0x4a, 0xdd, 0x48, 0x0c, 0xd0, 0x7d, 0x3d, 0x58, 0xde, 0x7c,
            0xd8, 0x14, 0x6b, 0x87, 0x47, 0xe8, 0x79, 0x84, 0x73, 0x3c, 0xbd, 0x92, 0xc9, 0x23, 0x8b, 0x97,
            0x95, 0x44, 0xdc, 0xad, 0x40, 0x65, 0x86, 0xa2, 0xa4, 0xcc, 0x7f, 0xec, 0xc0, 0xaf, 0x91, 0xfd,
            0xf7, 0x4f, 0x81, 0x2f, 0x5b, 0xea, 0xa8, 0x1c, 0x02, 0xd1, 0x98, 0x71, 0xed, 0x25, 0xe3, 0x24,
            0x06, 0x68, 0xb3, 0x93, 0x2c, 0x6f, 0x3e, 0x6c, 0x0a, 0xb8, 0xce, 0xae, 0x74, 0xb1, 0x42, 0xb4,
            0x1e, 0xd3, 0x49, 0xe9, 0x9c, 0xc8, 0xc6, 0xc7, 0x22, 0x6e, 0xdb, 0x20, 0xbf, 0x43, 0x51, 0x52,
            0x66, 0xb2, 0x76, 0x60, 0xda, 0xc5, 0xf3, 0xf6, 0xaa, 0xcd, 0x9a, 0xa0, 0x75, 0x54, 0x0e, 0x01,
        };
    }
}